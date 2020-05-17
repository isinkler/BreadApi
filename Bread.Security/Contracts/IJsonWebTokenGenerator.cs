namespace Bread.Security.Contracts
{
    public interface IJsonWebTokenGenerator
    {
        string GenerateJsonWebToken(int id, string lastName);
    }
}
