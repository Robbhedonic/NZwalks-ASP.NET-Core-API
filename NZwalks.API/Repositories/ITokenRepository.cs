using NZWalks.API.MODELS.DOMAIN;

namespace NZWalks.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(User user);
    }
}