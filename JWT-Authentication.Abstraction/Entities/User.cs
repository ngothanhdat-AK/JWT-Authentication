using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT_Authentication.Abstraction.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // Default role is User, can be changed later
        public string? RefreshToken { get; set; } // Optional, can be used for refresh token functionality
        public DateTime? RefreshTokenExpiryTime { get; set; } // Optional, can be used for refresh token functionality
    }
}
