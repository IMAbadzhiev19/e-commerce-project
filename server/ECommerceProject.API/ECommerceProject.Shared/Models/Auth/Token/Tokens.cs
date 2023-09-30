﻿using System.IdentityModel.Tokens.Jwt;

namespace ECommerceProject.Shared.Models.Auth.Token;

public class Tokens
{
    public JwtSecurityToken? AccessToken { get; set; } = new();
    public JwtSecurityToken? RefreshToken { get; set; } = new();
}
