using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace IdentityApp.Services
{
    public class TokenUrlEncoderService
    {
        public virtual string EncodeToken(string token)
        {
            return WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
        }
        public virtual string DecodeToken(string urlToken)
        {
            return Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(urlToken));
        }
    }
}
