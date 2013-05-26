using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

using DotNetOpenAuth.OAuth2;

using Google.Apis.Authentication.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
using Google.Apis.Services;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Util;

namespace TPU_Schedule_to_Google_Calendar.Google_Calendar
{
    class CalendarHelper
    {
        private static CalendarService service;
        private static byte[] s_aditionalEntropy = { 9, 8, 7, 6, 5 };

        public static CalendarService getService()
        {
            var provider = new NativeApplicationClient(GoogleAuthenticationServer.Description)
            {
                ClientIdentifier = "270432743729-h2hsit1kitdiu3u55j26q7d060e3pn2d.apps.googleusercontent.com",
                ClientSecret = "E2EA8mPPjNeBt0m4sP35NOuS"
            };

            var auth = new OAuth2Authenticator<NativeApplicationClient>(provider, GetAuthorization);

            service = new CalendarService(new BaseClientService.Initializer()
            {
                Authenticator = auth
            });

            return service;
        }

        public static IAuthorizationState GetAuthorization(NativeApplicationClient arg)
        {
            IAuthorizationState state = new AuthorizationState(
                new[] { 
                    CalendarService.Scopes.Calendar.GetStringValue()
                }
            );

            state.Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl);

            string refreshToken = LoadRefreshToken();
            if (!String.IsNullOrWhiteSpace(refreshToken))
            {
                state.RefreshToken = refreshToken;

                if (arg.RefreshToken(state))
                {
                    return state;
                }
            }

            Uri authUri = arg.RequestUserAuthorization(state);

            Process.Start(authUri.ToString());
            string authCode = "";

            AuthenticationForm authenticationDialog = new AuthenticationForm();
            authenticationDialog.ShowDialog();

            if (authenticationDialog.DialogResult.HasValue && authenticationDialog.DialogResult.Value)
            {
                authCode = authenticationDialog.authToken.Text;

                if (authCode == String.Empty)
                {
                    Application.Current.Shutdown();
                }
            }

            authenticationDialog.Hide();

            var result = arg.ProcessUserAuthorization(authCode, state);

            StoreRefreshToken(state);

            return result;
        }

        private static string LoadRefreshToken()
        {
            if (Properties.Settings.Default.RefreshToken != String.Empty)
            {
                return Encoding.Unicode.GetString(
                    ProtectedData.Unprotect(
                        Convert.FromBase64String(Properties.Settings.Default.RefreshToken),
                        s_aditionalEntropy,
                        DataProtectionScope.CurrentUser
                    )
                );
            }

            return "";
        }

        private static void StoreRefreshToken(IAuthorizationState state)
        {
            Properties.Settings.Default.RefreshToken = Convert.ToBase64String(
                ProtectedData.Protect(
                    Encoding.Unicode.GetBytes(state.RefreshToken), 
                    s_aditionalEntropy, 
                    DataProtectionScope.CurrentUser
                )
            );

            Properties.Settings.Default.Save();
        }
    }
}
