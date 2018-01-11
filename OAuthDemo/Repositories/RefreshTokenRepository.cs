using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OAuthDemo.Model;

namespace OAuthDemo.Repositories
{
    public class RefreshTokenRepository
    {
        private static readonly ICollection<Client> clients = new List<Client>();
        private static readonly ICollection<RefreshToken> refreshTokens = new List<RefreshToken>();

        static RefreshTokenRepository()
        {
            clients.Add(new Client
            {
                Id = "ngAuthApp",
                Name = "Angular JS Web App",
                ApplicationType = ApplicationTypes.JavaScript,
                Active = true,
                AllowedOrigin = "*",
                RefreshTokenLifeTime = 7200
            });
        }

        public Client FindClient(string clientId)
        {
            var client = clients.SingleOrDefault(c => c.Id == clientId);
            return client;
        }

        public async Task<bool> AddRefreshToken(RefreshToken token)
        {
            var existingToken = refreshTokens.SingleOrDefault(r => r.Subject == token.Subject && r.ClientId == token.ClientId);
            if (existingToken != null)
            {
                await RemoveRefreshToken(existingToken);
            }

            refreshTokens.Add(token);

            return true;
        }

        public Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken = refreshTokens.SingleOrDefault(r => r.Id == refreshTokenId);
            if (refreshToken != null)
            {
                refreshTokens.Remove(refreshToken);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        public Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
        {
            refreshTokens.Remove(refreshToken);
            return Task.FromResult(true);
        }

        public Task<RefreshToken> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = refreshTokens.SingleOrDefault(r => r.Id == refreshTokenId);
            return Task.FromResult(refreshToken);
        }

        public List<RefreshToken> GetAllRefreshTokens()
        {
            return refreshTokens.ToList();
        }
    }
}