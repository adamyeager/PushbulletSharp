using PushbulletSharp.Models.Requests;
using PushbulletSharp.Models.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PushbulletSharp
{
    public class PushbulletClient
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PushBulletManager"/> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <exception cref="System.ArgumentNullException">accessToken</exception>
        public PushbulletClient(string accessToken)
        {
            if(string.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentNullException("accessToken");
            }

            _accessToken = accessToken;
        }

        #endregion



        #region properties

        private string _accessToken;
        /// <summary>
        /// Gets the access token.
        /// </summary>
        /// <value>
        /// The access token.
        /// </value>
        public string AccessToken
        {
            get
            {
                return _accessToken;
            }
        }

        private JavaScriptSerializer _jsonSerializer;
        /// <summary>
        /// Gets or sets the json serializer.
        /// </summary>
        /// <value>
        /// The json serializer.
        /// </value>
        internal JavaScriptSerializer JsonSerializer
        {
            get
            {
                if(_jsonSerializer == null)
                {
                    _jsonSerializer = new JavaScriptSerializer();
                }
                return _jsonSerializer;
            }
        }

        #endregion properties



        #region public methods

        /// <summary>
        /// Currents the users information.
        /// </summary>
        /// <returns></returns>
        public User CurrentUsersInformation()
        {
            User result = new User();

            string jsonResult = GetRequest(string.Concat(PushbulletConstants.BaseUrl, PushbulletConstants.UsersUrls.Me));
            result = JsonSerializer.Deserialize<User>(jsonResult);

            return result;
        }


        /// <summary>
        /// Currents the users devices.
        /// </summary>
        /// <returns></returns>
        public UserDevices CurrentUsersDevices()
        {
            UserDevices result = new UserDevices();

            string jsonResult = GetRequest(string.Concat(PushbulletConstants.BaseUrl, PushbulletConstants.DevicesUrls.Me));
            result = JsonSerializer.Deserialize<UserDevices>(jsonResult);

            return result;
        }


        /// <summary>
        /// Currents the users active devices.
        /// </summary>
        /// <returns></returns>
        public UserDevices CurrentUsersActiveDevices()
        {
            UserDevices result = CurrentUsersDevices();
            result.Devices = result.Devices.Where(o => o.active).ToList();
            return result;
        }


        /// <summary>
        /// Pushes the note.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">request</exception>
        public PushResponse PushNote(PushNoteRequest request, bool ignoreEmptyFields = false)
        {
            if(request == null)
            {
                throw new ArgumentNullException("note request");
            }

            if (string.IsNullOrWhiteSpace(request.device_iden) && string.IsNullOrWhiteSpace(request.email))
            {
                throw new Exception(PushbulletConstants.PushRequestErrorMessages.EmptyEmailProperty);
            }

            if(string.IsNullOrWhiteSpace(request.type))
            {
                throw new Exception(PushbulletConstants.PushRequestErrorMessages.EmptyTypeProperty);
            }

            if(!ignoreEmptyFields)
            {
                if(string.IsNullOrWhiteSpace(request.title))
                {
                    throw new Exception(PushbulletConstants.PushNoteRequestErrorMessages.EmptyTitleProperty);
                }

                if(string.IsNullOrWhiteSpace(request.body))
                {
                    throw new Exception(PushbulletConstants.PushNoteRequestErrorMessages.EmptyBodyProperty);
                }
            }

            return PostPushRequest(JsonSerializer.Serialize(request));
        }


        /// <summary>
        /// Pushes the address.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">request</exception>
        public PushResponse PushAddress(PushAddressRequest request, bool ignoreEmptyFields = false)
        {
            if(request == null)
            {
                throw new ArgumentNullException("address request");
            }

            if (string.IsNullOrWhiteSpace(request.device_iden) && string.IsNullOrWhiteSpace(request.email))
            {
                throw new Exception(PushbulletConstants.PushRequestErrorMessages.EmptyEmailProperty);
            }

            if (string.IsNullOrWhiteSpace(request.type))
            {
                throw new Exception(PushbulletConstants.PushRequestErrorMessages.EmptyTypeProperty);
            }

            if (!ignoreEmptyFields)
            {
                if (string.IsNullOrWhiteSpace(request.name))
                {
                    throw new Exception(PushbulletConstants.PushAddressErrorMessages.EmptyNameProperty);
                }

                if (string.IsNullOrWhiteSpace(request.address))
                {
                    throw new Exception(PushbulletConstants.PushAddressErrorMessages.EmptyAddressProperty);
                }
            }

            return PostPushRequest(JsonSerializer.Serialize(request));
        }

        /// <summary>
        /// Pushes the link.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">request</exception>
        public PushResponse PushLink(PushLinkRequest request, bool ignoreEmptyFields = false)
        {
            if(request == null)
            {
                throw new ArgumentNullException("link request");
            }

            if (string.IsNullOrWhiteSpace(request.device_iden) && string.IsNullOrWhiteSpace(request.email))
            {
                throw new Exception(PushbulletConstants.PushRequestErrorMessages.EmptyEmailProperty);
            }

            if (string.IsNullOrWhiteSpace(request.type))
            {
                throw new Exception(PushbulletConstants.PushRequestErrorMessages.EmptyTypeProperty);
            }

            if (!ignoreEmptyFields)
            {
                if (string.IsNullOrWhiteSpace(request.title))
                {
                    throw new Exception(PushbulletConstants.PushLinkErrorMessages.EmptyTitleProperty);
                }

                if (string.IsNullOrWhiteSpace(request.url))
                {
                    throw new Exception(PushbulletConstants.PushLinkErrorMessages.EmptyUrlProperty);
                }

                //the body property is optional.
            }

            return PostPushRequest(JsonSerializer.Serialize(request));
        }


        /// <summary>
        /// Pushes the list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">list request</exception>
        public PushResponse PushList(PushListRequest request, bool ignoreEmptyFields = false)
        {
            if (request == null)
            {
                throw new ArgumentNullException("list request");
            }

            if (string.IsNullOrWhiteSpace(request.device_iden) && string.IsNullOrWhiteSpace(request.email))
            {
                throw new Exception(PushbulletConstants.PushRequestErrorMessages.EmptyEmailProperty);
            }

            if (string.IsNullOrWhiteSpace(request.type))
            {
                throw new Exception(PushbulletConstants.PushRequestErrorMessages.EmptyTypeProperty);
            }

            if (!ignoreEmptyFields)
            {
                if (string.IsNullOrWhiteSpace(request.title))
                {
                    throw new Exception(PushbulletConstants.PushListErrorMessages.EmptyTitleProperty);
                }
            }

            return PostPushRequest(JsonSerializer.Serialize(request));
        }


        /// <summary>
        /// Pushes the file.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">file request</exception>
        public string PushFile(PushFileRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("file request");
            }

            FileUploadResponse uploadRequestResponse = PostFileUploadRequest(request);

            if(uploadRequestResponse.data == null || string.IsNullOrWhiteSpace(uploadRequestResponse.file_url))
            {
                throw new Exception(PushbulletConstants.PushFileErrorMessages.ErrorMakingFileUploadRequest);
            }

            try
            {
                PushFileToAmazonAWS(request.file_path, uploadRequestResponse);
            }
            catch (Exception)
            {
                throw;
            }

            return "";
        }
          

        #endregion public methods



        #region private methods

        /// <summary>
        /// Gets the request.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        private string GetRequest(string url)
        {
            var request = GetWebRequest(url);

            using (var response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
        }


        /// <summary>
        /// Gets the web request.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        private WebRequest GetWebRequest(string url)
        {
            var request = WebRequest.Create(url);
            request.Headers.Add(PushbulletConstants.HeadersConstants.AuthorizationKey, string.Format(PushbulletConstants.HeadersConstants.AuthorizationValue, this.AccessToken));
            return request;
        }


        /// <summary>
        /// Posts the push request.
        /// </summary>
        /// <param name="requestJson">The request json.</param>
        /// <returns></returns>
        private PushResponse PostPushRequest(string requestJson)
        {
            string responseJson = PostRequest(string.Concat(PushbulletConstants.BaseUrl, PushbulletConstants.PushesUrls.Push), requestJson);
            PushResponse response = JsonSerializer.Deserialize<PushResponse>(responseJson);
            return response;
        }


        /// <summary>
        /// Posts the request.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="json">The json.</param>
        /// <returns></returns>
        private string PostRequest(string url, string json)
        {
            string result = string.Empty;

            var request = (HttpWebRequest)HttpWebRequest.Create(url);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add(PushbulletConstants.HeadersConstants.AuthorizationKey, string.Format(PushbulletConstants.HeadersConstants.AuthorizationValue, this.AccessToken));

            var encoding = new System.Text.UTF8Encoding();
            byte[] bytes = encoding.GetBytes(json);

            request.ContentLength = bytes.Length;

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }

            request.BeginGetResponse((x) =>
            {
                try
                {
                    using (var response = request.EndGetResponse(x))
                    {
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
            }, null);

            return result;
        }


        /// <summary>
        /// Posts the file upload request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        private FileUploadResponse PostFileUploadRequest(PushFileRequest request)
        {
            string requestJson = JsonSerializer.Serialize(request);
            string responseJson = PostRequest(string.Concat(PushbulletConstants.BaseUrl, PushbulletConstants.FileUrls.UploadRequest), requestJson);
            FileUploadResponse response = JsonSerializer.Deserialize<FileUploadResponse>(responseJson);
            return response;
        }


        private void PushFileToAmazonAWS(string filePath, FileUploadResponse fileUploadResponse)
        {
            try
            {
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(PushbulletConstants.FileUrls.AmazonAWS)))
                {
                    requestMessage.Headers.ExpectContinue = false;

                    using (var multiPartCont = new MultipartFormDataContent())
                    {
                        multiPartCont.Add(CreateStringContentFromNameValue("awsaccesskeyid", fileUploadResponse.data.awsaccesskeyid));
                        multiPartCont.Add(CreateStringContentFromNameValue("acl", fileUploadResponse.data.acl));
                        multiPartCont.Add(CreateStringContentFromNameValue("key", fileUploadResponse.data.key));
                        multiPartCont.Add(CreateStringContentFromNameValue("signature", fileUploadResponse.data.signature));
                        multiPartCont.Add(CreateStringContentFromNameValue("policy", fileUploadResponse.data.policy));
                        multiPartCont.Add(CreateStringContentFromNameValue("content", fileUploadResponse.file_type));
                        multiPartCont.Add(CreateFileHttpContentFromFilePath(filePath));

                        using (var httpClient = new HttpClient())
                        {
                            Task<HttpResponseMessage> httpRequest = httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
                            HttpResponseMessage httpResponse = httpRequest.Result;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Creates the file HTTP content from file path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        private ByteArrayContent CreateFileHttpContentFromFilePath(string filePath)
        {
            byte[] fileContents = File.ReadAllBytes(filePath);
            ByteArrayContent content = new ByteArrayContent(fileContents);
            content.Headers.Add("Content-Type", "application/octet-stream");
            content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "\"file\"",
                FileName = string.Format("\"{0}\"", Path.GetFileName(filePath))
            };
            return content;
        }


        /// <summary>
        /// Creates the string content from name value.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private StringContent CreateStringContentFromNameValue(string name, string value)
        {
            using (var content = new StringContent(value))
            {
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = string.Format("\"{0}\"", name)
                };
                return content;
            }
        }

        #endregion private methods
    }
}