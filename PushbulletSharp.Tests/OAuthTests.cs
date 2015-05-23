using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PushbulletSharp.Tests
{
    [TestClass]
    public class OAuthTests : TestBase
    {
        [TestMethod]
        public void RequestTokenTest()
        {
            try
            {
                Models.Requests.OAuthTokenRequest request = new Models.Requests.OAuthTokenRequest()
                {
                    client_id = "--YOUR APP CLIENT ID--",
                    client_secret = "--YOUR APP CLIENT SECRET--",
                    code = "--USER CODE FROM REDIRECT--"
                };

                var result = Client.RequestToken(request);

                Client.AccessToken = result.access_token;
                var oauthUserInformation = Client.CurrentUsersInformation();
                var oauthTestPushResults = Client.PushNote(new Models.Requests.PushNoteRequest()
                {
                    title = "OAuth Push Test",
                    body = "This is a test push using OAuth!",
                    email = oauthUserInformation.email
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
