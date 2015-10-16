using PushbulletSharp.Filters;
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
using System.Threading.Tasks;

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
        public PushbulletClient(string accessToken, TimeZoneInfo timeZoneInfo = null)
        {
            if(string.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentNullException("accessToken");
            }

            if(timeZoneInfo != null)
            {
                _timeZoneInfo = timeZoneInfo;
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
            set
            {
                _accessToken = value;
            }
        }


        private TimeZoneInfo _timeZoneInfo = TimeZoneInfo.Utc;
        /// <summary>
        /// Gets the time zone information.
        /// </summary>
        /// <value>
        /// The time zone information.
        /// </value>
        internal TimeZoneInfo TimeZoneInfo
        {
            get
            {
                return _timeZoneInfo;
            }
        }

        #endregion properties



        #region public methods

        #region User Information Methods

        /// <summary>
        /// Currents the users information.
        /// </summary>
        /// <returns></returns>
        public User CurrentUsersInformation()
        {
            try
            {
                #region processing

                User result = GetRequest<User>(string.Concat(PushbulletConstants.BaseUrl, PushbulletConstants.UsersUrls.Me));
                return result;

                #endregion processing
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Currents the users devices.
        /// </summary>
        /// <param name="showActiveOnly">if set to <c>true</c> [show active only].</param>
        /// <returns></returns>
        public UserDevices CurrentUsersDevices(bool showActiveOnly = false)
        {
            try
            {
                #region pre-processing

                string additionalQuery = string.Empty;

                if (showActiveOnly)
                {
                    additionalQuery = "?active=true";
                }

                #endregion end pre-processing

                #region processing

                UserDevices result = GetRequest<UserDevices>(string.Concat(PushbulletConstants.BaseUrl, PushbulletConstants.DevicesUrls.Me, additionalQuery).Trim());
                return result;

                #endregion processing
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion User Information Methods


        #region Contacts Methods

        /// <summary>
        /// Currents the users contacts.
        /// </summary>
        /// <param name="showActiveOnly">if set to <c>true</c> [show active only].</param>
        /// <returns></returns>
        public UserContacts CurrentUsersContacts(bool showActiveOnly = false)
        {
            try
            {
                #region pre-processing

                string additionalQuery = string.Empty;

                if (showActiveOnly)
                {
                    additionalQuery = "?active=true";
                }

                #endregion end pre-processing

                #region processing

                UserContacts result = GetRequest<UserContacts>(string.Concat(PushbulletConstants.BaseUrl, PushbulletConstants.ContactsUrls.Contacts, additionalQuery).Trim());
                return result;

                #endregion processing
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Creates the new contact.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">create contact request</exception>
        /// <exception cref="System.Exception">
        /// </exception>
        public Contact CreateNewContact(CreateContactRequest request)
        {
            try
            {
                #region pre-processing

                if (request == null)
                {
                    throw new ArgumentException("create contact request");
                }

                if (string.IsNullOrWhiteSpace(request.Name))
                {
                    throw new Exception(PushbulletConstants.CreateContactErrorMessages.ErrorNameProperty);
                }

                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    throw new Exception(PushbulletConstants.CreateContactErrorMessages.ErrorEmailProperty);
                }

                #endregion pre-processing

                #region processing

                Contact response = PostRequest<Contact>(string.Concat(PushbulletConstants.BaseUrl, PushbulletConstants.ContactsUrls.Contacts), request);
                return response;

                #endregion processing
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Updates the contact.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">update contact request</exception>
        /// <exception cref="System.Exception">
        /// </exception>
        public Contact UpdateContact(UpdateContactRequest request)
        {
            try
            {
                #region pre-processing

                if (request == null)
                {
                    throw new ArgumentException("update contact request");
                }

                if (string.IsNullOrWhiteSpace(request.ContactIden))
                {
                    throw new Exception(PushbulletConstants.UpdateContactErrorMessages.ErrorContactIdenProperty);
                }

                if (string.IsNullOrWhiteSpace(request.Name))
                {
                    throw new Exception(PushbulletConstants.UpdateContactErrorMessages.ErrorNameProperty);
                }

                #endregion pre-processing


                #region processing

                Contact response = PostRequest<Contact>(
                    string.Format("{0}{1}/{2}", 
                        PushbulletConstants.BaseUrl, 
                        PushbulletConstants.ContactsUrls.Contacts, 
                        request.ContactIden), 
                    request);
                return response;

                #endregion processing
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Deletes the contact.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <exception cref="System.ArgumentException">delete contact request</exception>
        /// <exception cref="System.Exception"></exception>
        public void DeleteContact(DeleteContactRequest request)
        {
            try
            {
                #region pre-processing

                if (request == null)
                {
                    throw new ArgumentException("delete contact request");
                }

                if (string.IsNullOrWhiteSpace(request.ContactIden))
                {
                    throw new Exception(PushbulletConstants.DeleteContactErrorMessages.ErrorContactIdenProperty);
                }

                #endregion pre-processing


                #region processing

                string jsonResult = DeleteRequest(string.Format("{0}{1}/{2}", PushbulletConstants.BaseUrl, PushbulletConstants.ContactsUrls.Contacts, request.ContactIden));

                #endregion processing
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Contacts Methods


        #region Channels Methods

        /// <summary>
        /// Subscribes to channel.
        /// </summary>
        /// <param name="channelTag">The channel tag.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">channel_tag</exception>
        public Subscription SubscribeToChannel(string channelTag)
        {
            #region pre-processing

            if (string.IsNullOrWhiteSpace(channelTag))
            {
                throw new ArgumentNullException("channel_tag");
            }

            #endregion pre-processing


            #region processing

            ChannelSubscriptionRequest request = new ChannelSubscriptionRequest()
            {
                ChannelTag = channelTag
            };

            BasicSubscription basicResponse = PostRequest<BasicSubscription>(string.Concat(PushbulletConstants.BaseUrl, PushbulletConstants.SubscriptionUrls.Subscriptions), request);
            Subscription result = ConvertFromBasicSubscription(basicResponse);
            return result;

            #endregion processing
        }


        /// <summary>
        /// Currents the users subscriptions.
        /// </summary>
        /// <param name="showActiveOnly">if set to <c>true</c> [show active only].</param>
        /// <returns></returns>
        public UserSubscriptions CurrentUsersSubscriptions(bool showActiveOnly = false)
        {
            try
            {
                #region pre-processing

                string additionalQuery = string.Empty;

                if (showActiveOnly)
                {
                    additionalQuery = "?active=true";
                }

                #endregion end pre-processing

                #region processing

                UserSubscriptions result = new UserSubscriptions(); 
                var basicResult = GetRequest<BasicUserSubscriptions>(string.Concat(PushbulletConstants.BaseUrl, PushbulletConstants.SubscriptionUrls.Subscriptions, additionalQuery).Trim());
                foreach (var sub in basicResult.Subscriptions)
                {
                    result.Subscriptions.Add(ConvertFromBasicSubscription(sub));
                }
                return result;

                #endregion processing
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Converts from basic subscription.
        /// </summary>
        /// <param name="basicSubscription">The basic subscription.</param>
        /// <returns></returns>
        private Subscription ConvertFromBasicSubscription(BasicSubscription basicSubscription)
        {
            Subscription result = new Subscription();
            result.Active = basicSubscription.Active;
            result.Channel = basicSubscription.Channel;
            result.Iden = basicSubscription.Iden;
            result.Created = TimeZoneInfo.ConvertTime(basicSubscription.Created.UnixTimeToDateTime(), TimeZoneInfo);
            result.Modified = TimeZoneInfo.ConvertTime(basicSubscription.Modified.UnixTimeToDateTime(), TimeZoneInfo);
            return result;
        }


        /// <summary>
        /// Unsubscribes from channel.
        /// </summary>
        /// <param name="channelIden">The channel iden.</param>
        /// <exception cref="System.ArgumentNullException">channel_iden</exception>
        public void UnsubscribeFromChannel(string channelIden)
        {
            #region pre-processing

            if (string.IsNullOrWhiteSpace(channelIden))
            {
                throw new ArgumentNullException("channel_iden");
            }

            #endregion pre-processing


            #region processing

            string jsonResult = DeleteRequest(string.Format("{0}{1}/{2}", PushbulletConstants.BaseUrl, PushbulletConstants.SubscriptionUrls.Subscriptions, channelIden));

            #endregion processing
        }


        /// <summary>
        /// Gets the channel information.
        /// </summary>
        /// <param name="channelTag">The channel tag.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">channel_tag</exception>
        public Channel GetChannelInformation(string channelTag)
        {
            #region pre-processing

            if (string.IsNullOrWhiteSpace(channelTag))
            {
                throw new ArgumentNullException("channel_tag");
            }

            #endregion pre-processing


            #region processing

            Channel result = GetRequest<Channel>(string.Format("{0}{1}?tag={2}", PushbulletConstants.BaseUrl, PushbulletConstants.SubscriptionUrls.ChannelInfo, channelTag));
            return result;

            #endregion processing
        }

        #endregion Channels Methods


        #region Push Methods

        /// <summary>
        /// Pushes the note.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="ignoreEmptyFields">if set to <c>true</c> [ignore empty fields].</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">note request</exception>
        /// <exception cref="System.Exception">
        /// </exception>
        public PushResponse PushNote(PushNoteRequest request, bool ignoreEmptyFields = false)
        {
            try
            {
                #region pre-processing

                if (request == null)
                {
                    throw new ArgumentNullException("note request");
                }

                if (string.IsNullOrWhiteSpace(request.Type))
                {
                    throw new Exception(PushbulletConstants.PushRequestErrorMessages.EmptyTypeProperty);
                }

                if (!ignoreEmptyFields)
                {
                    if (string.IsNullOrWhiteSpace(request.Title))
                    {
                        throw new Exception(PushbulletConstants.PushNoteRequestErrorMessages.EmptyTitleProperty);
                    }

                    if (string.IsNullOrWhiteSpace(request.Body))
                    {
                        throw new Exception(PushbulletConstants.PushNoteRequestErrorMessages.EmptyBodyProperty);
                    }
                }

                #endregion pre-processing


                #region processing

                return PostPushRequest<PushNoteRequest>(request);

                #endregion processing
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Pushes the address.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="ignoreEmptyFields">if set to <c>true</c> [ignore empty fields].</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">address request</exception>
        /// <exception cref="System.Exception">
        /// </exception>
        public PushResponse PushAddress(PushAddressRequest request, bool ignoreEmptyFields = false)
        {
            try
            {
                #region pre-processing

                if (request == null)
                {
                    throw new ArgumentNullException("address request");
                }

                if (string.IsNullOrWhiteSpace(request.Type))
                {
                    throw new Exception(PushbulletConstants.PushRequestErrorMessages.EmptyTypeProperty);
                }

                if (!ignoreEmptyFields)
                {
                    if (string.IsNullOrWhiteSpace(request.Name))
                    {
                        throw new Exception(PushbulletConstants.PushAddressErrorMessages.EmptyNameProperty);
                    }

                    if (string.IsNullOrWhiteSpace(request.Address))
                    {
                        throw new Exception(PushbulletConstants.PushAddressErrorMessages.EmptyAddressProperty);
                    }
                }

                #endregion pre-processing


                #region processing

                return PostPushRequest<PushAddressRequest>(request);

                #endregion processing
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Pushes the link.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="ignoreEmptyFields">if set to <c>true</c> [ignore empty fields].</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">link request</exception>
        /// <exception cref="System.Exception">
        /// </exception>
        public PushResponse PushLink(PushLinkRequest request, bool ignoreEmptyFields = false)
        {
            try
            {
                #region pre-processing

                if (request == null)
                {
                    throw new ArgumentNullException("link request");
                }

                if (string.IsNullOrWhiteSpace(request.Type))
                {
                    throw new Exception(PushbulletConstants.PushRequestErrorMessages.EmptyTypeProperty);
                }

                if (!ignoreEmptyFields)
                {
                    if (string.IsNullOrWhiteSpace(request.Title))
                    {
                        throw new Exception(PushbulletConstants.PushLinkErrorMessages.EmptyTitleProperty);
                    }

                    if (string.IsNullOrWhiteSpace(request.Url))
                    {
                        throw new Exception(PushbulletConstants.PushLinkErrorMessages.EmptyUrlProperty);
                    }

                    //the body property is optional.
                }

                #endregion pre-processing


                #region processing

                return PostPushRequest<PushLinkRequest>(request);

                #endregion processing
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Pushes the list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="ignoreEmptyFields">if set to <c>true</c> [ignore empty fields].</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">list request</exception>
        /// <exception cref="System.Exception">
        /// </exception>
        public PushResponse PushList(PushListRequest request, bool ignoreEmptyFields = false)
        {
            try
            {
                #region pre-processing

                if (request == null)
                {
                    throw new ArgumentNullException("list request");
                }

                if (string.IsNullOrWhiteSpace(request.Type))
                {
                    throw new Exception(PushbulletConstants.PushRequestErrorMessages.EmptyTypeProperty);
                }

                if (!ignoreEmptyFields)
                {
                    if (string.IsNullOrWhiteSpace(request.Title))
                    {
                        throw new Exception(PushbulletConstants.PushListErrorMessages.EmptyTitleProperty);
                    }
                }

                #endregion pre-processing


                #region processing

                return PostPushRequest<PushListRequest>(request);

                #endregion processing
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Pushes the file.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">file request</exception>
        /// <exception cref="System.Exception">
        /// </exception>
        public PushResponse PushFile(PushFileRequest request)
        {
            try
            {
                #region pre-processing

                if (request == null)
                {
                    throw new ArgumentNullException("file request");
                }

                if (string.IsNullOrWhiteSpace(request.FileName))
                {
                    throw new Exception(PushbulletConstants.PushFileErrorMessages.EmptyFileNameProperty);
                }

                if (string.IsNullOrWhiteSpace(request.FileType))
                {
                    throw new Exception(PushbulletConstants.PushFileErrorMessages.EmptyFileTypeProperty);
                }

                if (request.FileStream == null)
                {
                    throw new Exception(PushbulletConstants.PushFileErrorMessages.EmptyFileStreamProperty);
                }

                if (!request.FileStream.CanRead)
                {
                    throw new Exception(PushbulletConstants.PushFileErrorMessages.CantReadFileStreamProperty);
                }

                #endregion pre-processing


                #region processing

                FileUploadResponse uploadRequestResponse = PostRequest<FileUploadResponse>(string.Concat(PushbulletConstants.BaseUrl, PushbulletConstants.FileUrls.UploadRequest), request);

                if (uploadRequestResponse.Data == null || string.IsNullOrWhiteSpace(uploadRequestResponse.FileUrl))
                {
                    throw new Exception(PushbulletConstants.PushFileErrorMessages.ErrorMakingFileUploadRequest);
                }

                PushFileToAmazonAWS(request, uploadRequestResponse);
                request.FileUrl = uploadRequestResponse.FileUrl;
                return PostPushRequest<PushFileRequest>(request);

                #endregion processing
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Gets the pushes.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// filter
        /// or
        /// filter
        /// </exception>
        /// <exception cref="System.Exception">Connect issue.</exception>
        public PushResponseContainer GetPushes(PushResponseFilter filter)
        {
            try
            {
                #region pre-processing

                if (filter == null)
                {
                    throw new ArgumentNullException("filter");
                }

                string queryString = string.Empty;
                List<string> queryStringList = new List<string>();

                if (!string.IsNullOrWhiteSpace(filter.Cursor))
                {
                    string cursorQueryString = string.Format("cursor={0}", filter.Cursor);
                    queryStringList.Add(cursorQueryString);
                }
                else
                {
                    if (filter.ModifiedDate != null)
                    {
                        string modifiedDate = filter.ModifiedDate.DateTimeToUnixTime().ToString(System.Globalization.CultureInfo.InvariantCulture);
                        string modifiedDateQueryString = string.Format("modified_after={0}", modifiedDate);
                        queryStringList.Add(modifiedDateQueryString);
                    }

                    if (filter.Active != null)
                    {
                        string activeQueryString = string.Format("active={0}", (bool)filter.Active);
                        queryStringList.Add(activeQueryString);
                    }

                    if(filter.Limit > 0)
                    {
                        string limitQueryString = string.Format("limit={0}", filter.Limit);
                        queryStringList.Add(limitQueryString);
                    }
                }

                //Email filtering can be done on either cursor or regular queries
                if (!string.IsNullOrWhiteSpace(filter.Email))
                {
                    string emailQueryString = string.Format("email={0}", filter.Email);
                    queryStringList.Add(emailQueryString);
                }

                //Join all of the query strings
                if (queryStringList.Count() > 0)
                {
                    queryString = string.Concat("?", string.Join("&", queryStringList));
                }

                #endregion


                #region processing

                PushResponseContainer results = new PushResponseContainer();
                BasicPushResponseContainer basicPushContainer = GetRequest<BasicPushResponseContainer>(string.Concat(PushbulletConstants.BaseUrl, PushbulletConstants.PushesUrls.Push, queryString).Trim());
                PushResponseContainer pushContainer = ConvertBasicPushResponseContainer(basicPushContainer);

                if (filter.IncludeTypes != null && filter.IncludeTypes.Count() > 0)
                {
                    foreach (var type in filter.IncludeTypes)
                    {
                        results.Pushes.AddRange(pushContainer.Pushes.Where(o => o.Type == type).ToList());
                    }
                    results.Pushes = results.Pushes.OrderByDescending(o => o.Created).ToList();
                }
                else
                {
                    results = pushContainer;
                }

                return results;

                #endregion processing
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Converts the basic push response container.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <returns></returns>
        private PushResponseContainer ConvertBasicPushResponseContainer(BasicPushResponseContainer container)
        {
            PushResponseContainer result = new PushResponseContainer();
            foreach(var basicPush in container.Pushes)
            {
                result.Pushes.Add(ConvertBasicPushResponse(basicPush));
            }
            result.Cursor = container.Cursor;
            return result;
        }

        #endregion Push Methods


        #region OAuth Methods

        /// <summary>
        /// Requests the token.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">oauth token request</exception>
        /// <exception cref="System.Exception"></exception>
        public OAuthTokenResponse RequestToken(OAuthTokenRequest request)
        {
            try
            {
                #region pre-processing

                if (request == null)
                {
                    throw new ArgumentNullException("oauth token request");
                }

                #endregion pre-processing


                #region processing

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
                parameters.Add(new KeyValuePair<string, string>("grant_type", request.GrantType));
                parameters.Add(new KeyValuePair<string, string>("client_id", request.ClientId));
                parameters.Add(new KeyValuePair<string, string>("client_secret", request.ClientSecret));
                parameters.Add(new KeyValuePair<string, string>("code", request.Code));
                string jsonResult = PostFormUrlEncodedContentRequest(string.Concat(PushbulletConstants.BaseUrlNonVersion, PushbulletConstants.OAuthUrls.OAuthToken), parameters);
                var result = jsonResult.JsonToOjbect<OAuthTokenResponse>();
                return result;

                #endregion processing
            }
            catch (WebException ex)
            {
                var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                throw new Exception(string.Format(PushbulletConstants.OAuthErrorMessages.WebExceptionFormat, statusCode, ex.Message), ex);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion OAuth Methods

        #endregion public methods



        #region private methods

        /// <summary>
        /// Gets the request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="System.Net.Http.HttpRequestException"></exception>
        private T GetRequest<T>(string url)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add(PushbulletConstants.HeadersConstants.AuthorizationKey, string.Format(PushbulletConstants.HeadersConstants.AuthorizationValue, this.AccessToken));
            HttpClient client = new HttpClient();
            var response = client.SendAsync(request).Result;

            switch((int)response.StatusCode)
            {
                case (int)HttpStatusCode.OK:
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        var output = result.JsonToOjbect<T>();
                        return output;
                    }
                default:
                    HandleOtherStatusCodes(response.StatusCode);
                    throw new HttpRequestException(string.Format(PushbulletConstants.StatusCodeExceptions.Default, (int)response.StatusCode, response.StatusCode));
            }
        }


        /// <summary>
        /// Posts the request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="requestObject">The request object.</param>
        /// <returns></returns>
        /// <exception cref="System.Net.Http.HttpRequestException"></exception>
        private T PostRequest<T>(string url, object requestObject)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add(PushbulletConstants.HeadersConstants.AuthorizationKey, string.Format(PushbulletConstants.HeadersConstants.AuthorizationValue, this.AccessToken));
            request.Content = new StringContent(requestObject.ToJson(), Encoding.UTF8, PushbulletConstants.MimeTypes.Json);
            
            HttpClient client = new HttpClient();
            var response = client.SendAsync(request).Result;

            switch ((int)response.StatusCode)
            {
                case (int)HttpStatusCode.OK:
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        var output = result.JsonToOjbect<T>();
                        return output;
                    }
                default:
                    HandleOtherStatusCodes(response.StatusCode);
                    throw new HttpRequestException(string.Format(PushbulletConstants.StatusCodeExceptions.Default, (int)response.StatusCode, response.StatusCode));
            }
        }


        /// <summary>
        /// Posts the form URL encoded content request.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        /// <exception cref="System.Net.Http.HttpRequestException"></exception>
        private string PostFormUrlEncodedContentRequest(string url, List<KeyValuePair<string, string>> parameters)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add(PushbulletConstants.HeadersConstants.AuthorizationKey, string.Format(PushbulletConstants.HeadersConstants.AuthorizationValue, this.AccessToken));
                //string postData = string.Join("&", parameters);
                request.Content = new FormUrlEncodedContent(parameters);

                HttpClient client = new HttpClient();
                var response = client.SendAsync(request).Result;

                switch ((int)response.StatusCode)
                {
                    case (int)HttpStatusCode.OK:
                        {
                            var result = response.Content.ReadAsStringAsync().Result;
                            return result;
                        }
                    default:
                        HandleOtherStatusCodes(response.StatusCode);
                        throw new HttpRequestException(string.Format(PushbulletConstants.StatusCodeExceptions.Default, (int)response.StatusCode, response.StatusCode));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Deletes the request.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        private string DeleteRequest(string url)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Headers.Add(PushbulletConstants.HeadersConstants.AuthorizationKey, string.Format(PushbulletConstants.HeadersConstants.AuthorizationValue, this.AccessToken));
            HttpClient client = new HttpClient();
            var response = client.SendAsync(request).Result;

            switch ((int)response.StatusCode)
            {
                case (int)HttpStatusCode.OK:
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        return result;
                    }
                default:
                    HandleOtherStatusCodes(response.StatusCode);
                    throw new HttpRequestException(string.Format(PushbulletConstants.StatusCodeExceptions.Default, (int)response.StatusCode, response.StatusCode));
            }
        }


        /// <summary>
        /// Handles the other status codes.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <exception cref="System.Net.Http.HttpRequestException">
        /// </exception>
        private void HandleOtherStatusCodes(HttpStatusCode statusCode)
        {
            switch((int)statusCode)
            {
                case (int)HttpStatusCode.BadRequest:
                    throw new HttpRequestException(PushbulletConstants.StatusCodeExceptions.BadRequest);
                case (int)HttpStatusCode.Unauthorized:
                    throw new HttpRequestException(PushbulletConstants.StatusCodeExceptions.Unauthorized);
                case (int)HttpStatusCode.Forbidden:
                    throw new HttpRequestException(PushbulletConstants.StatusCodeExceptions.Forbidden);
                case (int)HttpStatusCode.NotFound:
                    throw new HttpRequestException(PushbulletConstants.StatusCodeExceptions.NotFound);
                case 429:
                    throw new HttpRequestException(PushbulletConstants.StatusCodeExceptions.BadRequest);
                case (int)HttpStatusCode.InternalServerError:
                case (int)HttpStatusCode.NotImplemented:
                case (int)HttpStatusCode.BadGateway:
                case (int)HttpStatusCode.ServiceUnavailable:
                case (int)HttpStatusCode.GatewayTimeout:
                case (int)HttpStatusCode.HttpVersionNotSupported:
                    throw new HttpRequestException(string.Format(PushbulletConstants.StatusCodeExceptions.FiveHundredXX, (int)statusCode, statusCode));
            }
        }


        /// <summary>
        /// Posts the push request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestObject">The request object.</param>
        /// <returns></returns>
        private PushResponse PostPushRequest<T>(T requestObject)
        {
            var basicResponse = PostRequest<BasicPushResponse>(string.Concat(PushbulletConstants.BaseUrl, PushbulletConstants.PushesUrls.Push), requestObject);
            PushResponse response = ConvertBasicPushResponse(basicResponse);
            return response;
        }


        /// <summary>
        /// Converts the basic push response.
        /// </summary>
        /// <param name="basicResponse">The basic response.</param>
        /// <returns></returns>
        private PushResponse ConvertBasicPushResponse(BasicPushResponse basicResponse)
        {
            PushResponse response = new PushResponse();
            response.Active = basicResponse.Active;
            if(basicResponse.Created != null)
            {
                response.Created = TimeZoneInfo.ConvertTime(basicResponse.Created.UnixTimeToDateTime(), TimeZoneInfo);
            }
            response.Dismissed = basicResponse.Dismissed;
            response.Direction = basicResponse.Direction;
            response.Iden = basicResponse.Iden;
            if(basicResponse.Modified != null)
            {
                response.Modified = TimeZoneInfo.ConvertTime(basicResponse.Modified.UnixTimeToDateTime(), TimeZoneInfo);
            }
            response.ReceiverEmail = basicResponse.ReceiverEmail;
            response.ReceiverEmailNormalized = basicResponse.ReceiverEmailNormalized;
            response.ReceiverIden = basicResponse.ReceiverIden;
            response.SenderEmail = basicResponse.SenderEmail;
            response.SenderEmailNormalized = basicResponse.SenderEmailNormalized;
            response.SenderIden = basicResponse.SenderIden;
            response.SenderName = basicResponse.SenderName;
            response.SourceDeviceIden = basicResponse.SourceDeviceIden;
            response.TargetDeviceIden = basicResponse.TargetDeviceIden;
            response.Type = ConvertPushResponseType(basicResponse.Type);
            response.ClientIden = basicResponse.ClientIden;
            response.Title = basicResponse.Title;
            response.Body = basicResponse.Body;
            response.Url = basicResponse.Url;
            response.FileName = basicResponse.FileName;
            response.FileType = basicResponse.FileType;
            response.FileUrl = basicResponse.FileUrl;
            response.ImageUrl = basicResponse.ImageUrl;
            response.Name = basicResponse.Name;
            response.Address = basicResponse.Address;
            if(basicResponse.Items != null)
            {
                response.Items = basicResponse.Items.Select(o => new ListItem() { Checked = o.Checked, Text = o.Text }).ToList();
            }
            return response;
        }


        /// <summary>
        /// Converts the type of the push response.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        private PushResponseType ConvertPushResponseType(string type)
        {
            switch(type)
            {
                case PushbulletConstants.TypeConstants.Address:
                    return PushResponseType.Address;
                case PushbulletConstants.TypeConstants.File:
                    return PushResponseType.File;
                case PushbulletConstants.TypeConstants.Link:
                    return PushResponseType.Link;
                case PushbulletConstants.TypeConstants.List:
                    return PushResponseType.List;
                case PushbulletConstants.TypeConstants.Note:
                default:
                    return PushResponseType.Note;
            }
        }


        /// <summary>
        /// Pushes the file to amazon aws.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="fileUploadResponse">The file upload response.</param>
        /// <exception cref="System.Exception"></exception>
        private void PushFileToAmazonAWS(PushFileRequest request, FileUploadResponse fileUploadResponse)
        {
            StringContent awsaccesskeyidContent = null;
            StringContent aclContent = null;
            StringContent keyContent = null;
            StringContent signatureContent = null;
            StringContent policyContent = null;
            StringContent contentTypeContent = null;
            StringContent cacheControlContent = null;
            ByteArrayContent fileContent = null;

            try
            {
                using (var multiPartCont = new MultipartFormDataContent())
                {
                    awsaccesskeyidContent = CreateStringContentFromNameValue(FileUploadResponseData.Properties.AWSAccessKeyId, fileUploadResponse.Data.AWSAccessKeyId);
                    aclContent = CreateStringContentFromNameValue(FileUploadResponseData.Properties.Acl, fileUploadResponse.Data.Acl);
                    keyContent = CreateStringContentFromNameValue(FileUploadResponseData.Properties.Key, fileUploadResponse.Data.Key);
                    signatureContent = CreateStringContentFromNameValue(FileUploadResponseData.Properties.Signature, fileUploadResponse.Data.Signature);
                    policyContent = CreateStringContentFromNameValue(FileUploadResponseData.Properties.Policy, fileUploadResponse.Data.Policy);
                    contentTypeContent = CreateStringContentFromNameValue(PushbulletConstants.AmazonHeaders.ContentType, fileUploadResponse.FileType);

                    multiPartCont.Add(awsaccesskeyidContent);
                    multiPartCont.Add(aclContent);
                    multiPartCont.Add(keyContent);
                    multiPartCont.Add(signatureContent);
                    multiPartCont.Add(policyContent);
                    multiPartCont.Add(contentTypeContent);

                    using (var memoryStream = new MemoryStream()) { 
                      request.FileStream.CopyTo(memoryStream);
                      fileContent = new ByteArrayContent(memoryStream.ToArray());
                    }

                    fileContent.Headers.Add(PushbulletConstants.AmazonHeaders.ContentType, PushbulletConstants.MimeTypes.OctetStream);
                    fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = string.Format("\"{0}\"", "file"),
                        FileName = string.Format("\"{0}\"", request.FileName)
                    };

                    multiPartCont.Add(fileContent);

                    using (var httpClient = new HttpClient())
                    {
                        Task<HttpResponseMessage> httpRequest = httpClient.PostAsync(fileUploadResponse.UploadUrl, multiPartCont);
                        HttpResponseMessage httpResponse = httpRequest.Result;

                        Task<string> xmlContentResponse = httpResponse.Content.ReadAsStringAsync();
                        if(!string.IsNullOrWhiteSpace(xmlContentResponse.Result))
                        {
                            throw new Exception(xmlContentResponse.Result);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (awsaccesskeyidContent != null)
                {
                    awsaccesskeyidContent.Dispose();
                }
                if (aclContent != null)
                {
                    aclContent.Dispose();
                }
                if (keyContent != null)
                {
                    keyContent.Dispose();
                }
                if (signatureContent != null)
                {
                    signatureContent.Dispose();
                }
                if (policyContent != null)
                {
                    policyContent.Dispose();
                }
                if (contentTypeContent != null)
                {
                    contentTypeContent.Dispose();
                }
                if (cacheControlContent != null)
                {
                    cacheControlContent.Dispose();
                }
                if (fileContent != null)
                {
                    fileContent.Dispose();
                }
            }
        }


        /// <summary>
        /// Creates the string content from name value.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private StringContent CreateStringContentFromNameValue(string name, string value)
        {
            var content = new StringContent(value);
            content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = string.Format("\"{0}\"", name)
            };
            return content;
        }

        #endregion private methods
    }
}