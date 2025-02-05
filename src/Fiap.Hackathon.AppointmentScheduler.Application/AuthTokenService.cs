using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Fiap.Hackathon.AppointmentScheduler.Application.Options;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Fiap.Hackathon.AppointmentScheduler.Application;

public class AuthTokenService
{
    private readonly JwtTokenOptions _jwtTokenOptions;

    public AuthTokenService(IOptions<JwtTokenOptions> jwtTokenOptions)
    {
        _jwtTokenOptions = jwtTokenOptions.Value;
    }

    public string GetToken(Patient patient)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, patient.Email),
            new(ClaimTypes.Role, patient.Profile.ToString())
        };
        
        return GenerateToken(claims);
    }
    
    public string GetToken(Doctor doctor)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, doctor.Crm),
            new(ClaimTypes.Role, doctor.Profile.ToString())
        };
        
        return GenerateToken(claims);
    }

    private string GenerateToken(IEnumerable<Claim> claims)
    {
        
        var tokenHandler = new JwtSecurityTokenHandler(); 
        var chaveCriptografia = Encoding.ASCII.GetBytes(_jwtTokenOptions.Secret);
        var tokenPropriedades = new SecurityTokenDescriptor() 
        {
            Subject = new ClaimsIdentity(claims),
                
            // Tempo de expiração do token
            Expires = DateTime.UtcNow.AddHours(8), 
                
            // Adiciona a nossa chave de criptografia
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(chaveCriptografia),
                SecurityAlgorithms.HmacSha256Signature)
        };
        
        var token = tokenHandler.CreateToken(tokenPropriedades);
        return tokenHandler.WriteToken(token);
    }
}