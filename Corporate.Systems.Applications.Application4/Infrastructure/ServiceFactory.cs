using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Corporate.Application.Services.Config;

namespace Corporate.Systems.Applications.Application4.Infrastructure;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TService"></typeparam>
public sealed class ServiceFactory<TService> : IServiceFactory<TService> where TService : class
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<TService> _logger;
    private readonly IConfiguration _configuration;
    private readonly JsonSerializerOptions _options;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpClientFactory"></param>
    /// <param name="configuration"></param>
    /// <param name="logger"></param>
    public ServiceFactory(IHttpClientFactory httpClientFactory, IConfiguration configuration, ILogger<TService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
        _logger = logger;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    /// <summary>
    /// HTTP GET method
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public async Task<TResult?> Execute<TResult>(IEnumerable<KeyValuePair<string, string>> parameters) where TResult : class
    {
        var querystring = $"/?{string.Join("&", parameters.Select(x => $"{x.Key}={x.Value}"))}";

        // TODO: Move http creational pattern in a baseline component.
        var httpClient = CreateHttpClient();
        return await GetData<TResult>(httpClient, querystring);
    }

    /// <summary>
    /// HTTP GET method
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="querystring"></param>
    /// <returns></returns>
    public async Task<TResult?> Execute<TResult>(string querystring) where TResult : class
    {
        var httpClient = CreateHttpClient();
        return await GetData<TResult>(httpClient, querystring);
    }

    /// <summary>
    /// HTTP POST method
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="jsonDocument"></param>
    /// <returns></returns>
    public async Task<TResult?> Execute<TResult>(JsonDocument jsonDocument) where TResult : class
    {
        var httpClient = CreateHttpClient();
        return await PostData<TResult>(httpClient, jsonDocument);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Execute<T>(T data) where T : class
    {
        var json = JsonSerializer.Serialize(data);
        throw new NotImplementedException();
    }

    /// <summary>
    /// HTTP GET method
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="client"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    private async Task<TResult?> GetData<TResult>(HttpClient client, string parameters) where TResult : class
    {
        var uri = new Uri($"{client.BaseAddress}{parameters}");
        _logger.LogInformation($"Calling '{uri.AbsoluteUri}'");
        
        // TODO: Determine to encrypt request and decrypt response
        using var response = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);

        response.EnsureSuccessStatusCode();
        var message = response.IsSuccessStatusCode && response.ReasonPhrase == "OK" ? "- Data successfully submitted" : "- Data not submitted";
        _logger?.LogInformation($"{response.ReasonPhrase}{message} for: {typeof(TService).Name}-{client.BaseAddress}");
        
        var stream = await response.Content.ReadAsStreamAsync();
        var result = await JsonSerializer.DeserializeAsync<TResult>(stream, _options);

        return result;
    }

    /// <summary>
    /// HTTP POST method
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="client"></param>
    /// <param name="jsonDocument"></param>
    /// <returns></returns>
    private async Task<TResult?> PostData<TResult>(HttpClient client, JsonDocument jsonDocument) where TResult : class
    {
        if (jsonDocument == null) throw new ArgumentNullException(nameof(jsonDocument));

        var content = new StringContent(jsonDocument.ToString()!, Encoding.UTF8, "application/json");
        
        // TODO: Determine to encrypt request and decrypt response
        using var response = await client.PostAsync(client.BaseAddress, content);

        response.EnsureSuccessStatusCode();
        var message = response.IsSuccessStatusCode && response.ReasonPhrase == "OK" ? "- Data successfully submitted" : "- Data not submitted";
        _logger?.LogInformation($"{response.ReasonPhrase}{message} for: {typeof(TService).Name}-{client.BaseAddress}");
        
        var stream = await response.Content.ReadAsStreamAsync();
        var result = await JsonSerializer.DeserializeAsync<TResult>(stream, _options);

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private HttpClient CreateHttpClient()
    {
        var client = _httpClientFactory.CreateClient($"{typeof(TService).Name}Client");
        var configList = new List<Action<IConfigurationSection, HttpClient>>
        {
            ConfigureJwt, ConfigureApiKey
        };

        // Detect configuration and enrich client headers accordingly.
        var rootSection = _configuration.GetSection($"{typeof(TService).Name}Config");
        foreach (var config in configList)
        {
            config.Invoke(rootSection, client);
        }

        return client;
    }

    // TODO: Add configuration detection in a baseline component
    /// <summary>
    /// Detects JWT configuration in service configuration.
    /// </summary>
    /// <returns></returns>
    private void ConfigureJwt(IConfigurationSection? section, HttpClient client)
    {
        var jwtConfigurationSection = DetectConfigurationSection<JwtConfig>(section);
        if(jwtConfigurationSection != null) 
        {
            var jwtConfiguration = jwtConfigurationSection.Get<JwtConfig>();
            var publicKeyPath = jwtConfiguration.PublicKeyFilePath;
            var privateKeyPath = jwtConfiguration.PrivateKeyFilePath;
            var algorithm = jwtConfiguration.Algorithm;

            var accessToken = GenerateToken();
            // Add JWT stuff to the client header here.
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
        };
    }

    /// <summary>
    ///  TODO: Add configuration detection in a baseline component
    /// </summary>
    /// <returns></returns>
    private void ConfigureApiKey(IConfigurationSection? section, HttpClient client)
    {
        var apikeyConfigurationSection = DetectConfigurationSection<ApikeyConfig>(section);
        if (apikeyConfigurationSection != null)
        {
            var apikeyConfiguration = apikeyConfigurationSection.Get<ApikeyConfig>();
            var apikey = apikeyConfiguration.Key;
            var enableEncryption = apikeyConfiguration.EnableEncryption;

            // Add API key stuff to the client header here.
            client.DefaultRequestHeaders.Add("x-api-key", apikey);
        }
    }

    /// <summary>
    /// TODO: Add configuration detection in a baseline component
    /// </summary>
    /// <typeparam name="TConfigurationSectionType"></typeparam>
    /// <param name="section"></param>
    /// <returns></returns>
    private IConfigurationSection? DetectConfigurationSection<TConfigurationSectionType>(IConfiguration? section) where TConfigurationSectionType : class
    {
        var name = typeof(TConfigurationSectionType).Name;
        return section!.GetSection(name).GetChildren().Any() ? section.GetSection(name) : null;
    }

    /// <summary>
    /// TODO: Add token creation in a baseline component
    /// </summary>
    /// <returns></returns>
    private string GenerateToken()
    {
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";
        _logger.LogInformation(token);
        return token;
    }
}
