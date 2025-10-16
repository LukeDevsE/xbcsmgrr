using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Stylet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using XboxCsMgr.Client.ViewModels;
using XboxCsMgr.Helpers.Win32;
using XboxCsMgr.XboxLive;
using XboxCsMgr.XboxLive.Model.Authentication;
using XboxCsMgr.XboxLive.Services;

namespace XboxCsMgr.Client
{
    public class AppBootstrapper : Bootstrapper<ShellViewModel>
    {
        public static XboxLiveConfig? XblConfig { get; internal set; }

        private AuthenticateService authenticateService;
        //private string DeviceToken { get; set; }
        private string UserToken = "";
        public string CLIENT_ID = "c36a9fb6-4f2a-41ff-90bd-ae7cc92031eb"; //prism launchers
        protected override void ConfigureIoC(StyletIoC.IStyletIoCBuilder builder)
        {
            base.ConfigureIoC(builder);

            builder.Bind<IDialogFactory>().ToAbstractFactory();
        }

        protected override async void OnStart()
        {
            Debug.WriteLine("Start program");
            var dialog = new Dialogue();
            await Task.Yield();
            dialog.ShowDialog();
            string code = dialog.txtResponse.Text;
            MicrosoftOAuth oauth = new MicrosoftOAuth(CLIENT_ID, "Xboxlive.signin Xboxlive.offline_access",new HttpClient());
            MicrosoftOAuthCode code2 = new MicrosoftOAuthCode();
            code2.Code = code;
            Debug.WriteLine("Getting Access Token");
            var codes = await oauth.GetTokens(code2);
            authenticateService = new AuthenticateService(XblConfig);
            Debug.WriteLine("Getting User Token");
            var finaltoken = await authenticateService.AuthenticateUser(codes.AccessToken,"d=");
            UserToken = finaltoken.Token;
            Debug.WriteLine("Authorizing");
            //LoadXblTokenCredentials();
            var result = await authenticateService.AuthorizeXsts(UserToken);
            if (result != null)
            {
                Debug.WriteLine("Authorized! Token: " + result.Token);
                XblConfig = new XboxLiveConfig(result.Token, result.DisplayClaims.XboxUserIdentity[0]);
                this.RootViewModel.OnAuthComplete();
            }
            base.OnStart();
        }

        // no longer needed

        private void LoadXblTokenCredentials()
        {
            // Lookup current Xbox Live authentication data stored via wincred
            Dictionary<string, string> currentCredentials = CredentialUtil.EnumerateCredentials();
            foreach (var cred in currentCredentials.Keys)
            {
                Debug.WriteLine(cred);
            }
            var xblCredentials = currentCredentials.Where(k => k.Key.Contains("Xbl|")
                    && k.Key.Contains("Dtoken") 
                    || k.Key.Contains("Utoken"))
                    .ToDictionary(p => p.Key, p => p.Value);

            foreach (var credential in xblCredentials)
            {
                // Remove trailing 'X' that is found on some credentials
                var fixedJson = credential.Value.TrimEnd('X').ToString();
                XboxLiveToken? token = JsonConvert.DeserializeObject<XboxLiveToken>(fixedJson);
                if (token.TokenData.NotAfter > DateTime.UtcNow)
                {
                    if (credential.Key.Contains("Dtoken"))
                    {
                        //DeviceToken = token.TokenData.Token;
                    }
                    else if (credential.Key.Contains("Utoken"))
                    {
                        if (token.TokenData.Token != "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA") UserToken = token.TokenData.Token;
                    }
                }
            }
        }
    }
}
