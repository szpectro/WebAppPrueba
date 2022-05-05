using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebAppPrueba.Utils
{
    public class Utils
    {

        //Función que regresa un token refresh
        //public static async Task<Token> GetTokenRefreshAsync(Configuracion config, DataToken token)
        //{
        //    var utcTimeNow = DateTime.UtcNow;
        //    var serviceProvider = new ServiceCollection().AddHttpClient().BuildServiceProvider();
        //    var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
        //    TokenConfiguration XeroConfig = new TokenConfiguration
        //    {
        //        AppName = config.AppName,
        //        ClientId = config.ClientId,
        //        ClientSecret = config.ClientSecret,
        //        CallbackUri = new Uri(config.CallbackUri),
        //        Scope = config.Scope,
        //        State = config.State
        //    };

        //    var t = new TokenOAuth2Token();
        //    t.AccessToken = token.access_token;
        //    t.ExpiresAtUtc = UnixTimeStampToDateTime(token.expires_in);
        //    t.IdToken = token.id_token;
        //    t.RefreshToken = token.refresh_token;

        //    var fechaToken = UnixTimeStampToDateTime(token.expires_in);
        //    if (utcTimeNow > fechaToken)
        //    {
        //        var client = new TokenClient(XeroConfig, httpClientFactory);
        //        t = (TokenOAuth2Token)await client.RefreshAccessTokenAsync(t);
        //    }

        //    token.access_token = t.AccessToken;
        //    token.expires_in = DateTimeToUnixTimestamp(t.ExpiresAtUtc);
        //    token.id_token = t.IdToken;
        //    token.refresh_token = t.RefreshToken;

        //    string output = Newtonsoft.Json.JsonConvert.SerializeObject(token, Newtonsoft.Json.Formatting.Indented);
        //    File.WriteAllText(@"C:\Token.json", output);

        //    return token;
        //}
    }
}
