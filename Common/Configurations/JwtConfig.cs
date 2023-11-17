namespace Common.Configurations;

public static class JwtConfig
{
    public static string Secret = "JWTAuthenticationHIGHsecuredPasswordVVVp1OH7Xzyr";
    public static string ValidIssuer = "http://localhost:11111";
    public static string ValidAudience = "http://localhost:11111";
    public static int ExpireDays = 3;
}