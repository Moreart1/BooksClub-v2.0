using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BooksClub_v2._0.Service
{
    public interface IUserService
    {
        string Authenticate(string user, string password);
    }
    internal sealed class UserService : IUserService
    {
        private IDictionary<string, string> _users = new Dictionary<string, string>()
        {
            {"test", "test"}
        };

        public const string SecretCode = "Greetings, my friend.Welcome to the book world.";

        public string Authenticate(string user, string password)
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
            {
                return string.Empty;
            }
            int i = 0;
            foreach (KeyValuePair<string, string> pair in _users)
            {
                i++;
                if (string.CompareOrdinal(pair.Key, user) == 0 && string.CompareOrdinal(pair.Value, password) == 0)
                {
                    return GenerateJwtToken(i);
                }
            }
            return string.Empty;
        }

        private string GenerateJwtToken(int id)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes(SecretCode);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
