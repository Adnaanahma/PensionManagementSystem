using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PensionManagementSystem.Application.Entities;
using PensionManagementSystem.Application.ViewModels;

namespace PensionManagementSystem.Domain.Services
{
    public class AuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<AuthResponse> LoginEmployerAsync(EmployerLoginModel model)
        {
            var employerRepo = _unitOfWork.GetRepository<Employer>();
            var employer = await employerRepo.GetFirstOrDefaultAsync(e =>
                e.RegistrationNumber == model.RegistrationNumber && e.IsActive, null, null, false);

                if (employer == null)
                throw new Exception("Employer not found");

            var accessToken = GenerateAccessToken(employer.Id.ToString(), "Employer");
            var refreshToken = GenerateRefreshToken();

            employer.RefreshToken = refreshToken;
            employer.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);

            await _unitOfWork.SaveChangesAsync();

            return new AuthResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task<AuthResponse> RefreshTokenAsync(string refreshToken)
        {
            var employerRepo = _unitOfWork.GetRepository<Employer>();
            var employer = await employerRepo.GetFirstOrDefaultAsync(e =>
                e.RefreshToken == refreshToken && e.RefreshTokenExpiry > DateTime.UtcNow, null, null, false);

            if (employer == null)
                throw new Exception("Invalid or expired refresh token");

            var newAccessToken = GenerateAccessToken(employer.Id.ToString(), "Employer");
            var newRefreshToken = GenerateRefreshToken();

            employer.RefreshToken = newRefreshToken;
            employer.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);

            await _unitOfWork.SaveChangesAsync();

            return new AuthResponse
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }

        private string GenerateAccessToken(string userId, string role)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Role, role)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }

        //private bool VerifyPassword(string inputPassword, string storedHash)
        //{
        //    // Use your preferred hashing method (e.g., BCrypt)
        //    return BCrypt.Net.BCrypt.Verify(inputPassword, storedHash);
        //}
    }

}
