using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Api;
using TwitchLib.Client.Models;

namespace TwitchChatBot
{
    internal class ConnectionDatas
    {
        public ConnectionCredentials Credentials;
        public TwitchAPI API;

        public string BotUsername = "OldMonk_Bot", BotOAuth = "0ab906dars0abxim8vxyxarnob7kk0";
        public string refreshToken = "sm0xdur5p7njsmxdbu9kv3riba4pf5df29lh16csq45ekzqtir";

        //ezek most az oldMOnkCB cuccai
        public string clientID = "sr9wohpxzd484uil8jbwfixp8x8jnb";
        public string secret = "jhquro5zfr1gzvwagf06qmbwyr7oto";


        public async void Initialize() 
        {
            API = new TwitchAPI();
            API.Settings.Secret = secret;
            API.Settings.ClientId = clientID;
            API.Settings.AccessToken = BotOAuth;
            await RefreshMyToken();
        }
        public async Task RefreshMyToken()
        {
            var refreshResult = await API.Auth.RefreshAuthTokenAsync(refreshToken, secret, clientID);
            BotOAuth = refreshResult.AccessToken;
            //meg kell még csinálni hogy a refreshelt token bekerüljön a botoAuth helyére <---ez elvileg kész, de elég bot megoldás, minden inditaskor ujrahivja

            //zöld név duplaklikk ha meg akarok tudni róla valamit
        }
    }
}
