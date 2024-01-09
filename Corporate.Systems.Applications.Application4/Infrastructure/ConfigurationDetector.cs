namespace Corporate.Systems.Applications.Application4.Infrastructure
{
    public sealed class ConfigurationDetector<TService> where TService : class
    {
        public ConfigurationDetector()
        {
            
        }

        /// <summary>
        /// TODO: Add configuration detection in a baseline component
        /// </summary>
        /// <typeparam name="TConfigurationSectionType"></typeparam>
        /// <param name="section"></param>
        /// <returns></returns>
        public IConfigurationSection? DetectConfigurationSection<TConfigurationSectionType>(IConfiguration? section) where TConfigurationSectionType : class
        {
            var name = typeof(TConfigurationSectionType).Name;
            return section!.GetSection(name).GetChildren().Any() ? section.GetSection(name) : null;
        }
    }
}
