﻿using Corporate.Systems.Applications.Common;

namespace Corporate.Systems.Applications.Application5.Model;

public class User
{
    public DataKey? DataKey { get; set; }
    public int Index { get; set; }
    public Guid Guid { get; set; }
    public bool IsActive { get; set; }
    public string? Balance { get; set; }
    public string? Picture { get; set; }
    public int Age { get; set; }
    public string? EyeColor { get; set; }
    public string? Name { get; set; }
    public string? Gender { get; set; }
    public string? Company { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? About { get; set; }
    public string? Registered { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public List<string>? Tags { get; set; }
    public List<Friend>? Friends { get; set; }
    public string? Greeting { get; set; }
    public string? FavoriteFruit { get; set; }
}
