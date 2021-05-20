namespace PromotionCodeAPI.Authentication
{
    /// <summary>
    /// Interface for JWT Authentication
    /// </summary>
    public interface IJWTAuthenticationManager
    {
        /// <summary>
        /// Method for Authentication
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Token</returns>
        string Authenticate(string username);
    }
}
