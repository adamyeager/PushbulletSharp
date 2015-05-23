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


        private TimeZoneInfo _timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("UTC");
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

                User result = new User();
                string jsonResult = GetRequest(string.Concat(PushbulletConstants.BaseUrl, PushbulletConstants.UsersUrls.Me));
                result = JsonSerializer.Deserialize<User>(jsonResult);
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

                UserDevices result = new UserDevices();
                string jsonResult = GetRequest(string.Concat(PushbulletConstants.BaseUrl, PushbulletConstants.DevicesUrls.Me, additionalQuery).Trim());
                result = JsonSerializer.Deserialize<UserDevices>(jsonResult);
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

                UserContacts result = new UserContacts();
                string jsonResult = GetRequest(string.Concat(PushbulletConstants.BaseUrl, PushbulletConstants.ContactsUrls.Contacts, additionalQuery).Trim());
                result = JsonSerializer.Deserialize<UserContacts>(jsonResult);
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

                if (string.IsNullOrWhiteSpace(request.name))
                {
                    throw new Exception(PushbulletConstants.CreateContactErrorMessages.ErrorNameProperty);
                }

                if (string.IsNullOrWhiteSpace(request.email))
                {
                    throw new Exception(PushbulletConstants.CreateContactErrorMessages.ErrorEmailProperty);
                }

                #endregion pre-processing

                #region processing

                string requestJson = JsonSerializer.Serialize(request);
                string responseJson = PostRequest(string.Concat(PushbulletConstants.BaseUrl, PushbulletConstants.ContactsUrls.Contacts), requestJson);
                Contact response = JsonSerializer.Deserialize<Contact>(responseJson);
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

                if(request == null)
                {
                    throw new ArgumentException("update contact request");
                }

                if(string.IsNullOrWhiteSpace(request.contact_iden))
                {
                    throw new Exception(PushbulletConstants.UpdateContactErrorMessages.ErrorContactIdenProperty);
                }

                if(string.IsNullOrWhiteSpace(request.name))
                {
                    throw new Exception(PushbulletConstants.UpdateContactErrorMessages.ErrorNameProperty);
                }

                #endregion pre-processing


                #region processing

                string requestJson = JsonSerializer.Serialize(new { name = request.name });
                string responseJson = PostRequest(string.Format("{0}{1}/{2}", PushbulletConstants.BaseUrl, PushbulletConstants.ContactsUrls.Contacts, request.contact_iden), requestJson);
                Contact response = JsonSerializer.Deserialize<Contact>(responseJson);
                return response;

                #endregion processing
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void DeleteContact(DeleteContactRequest request)
        {
            try
            {
                #region pre-processing

                if(request == null)
                {
                    throw new ArgumentException("delete contact request");
                }

                if (string.IsNullOrWhiteSpace(request.contact_iden))
                {
                    throw new Exception(PushbulletConstants.DeleteContactErrorMessages.ErrorContactIdenProperty);
                }

                #endregion pre-processing


                #region processing

                string jsonResult = DeleteRequest(string.Format("{0}{1}/{2}", PushbulletConstants.BaseUrl, PushbulletConstants.ContactsUrls.Contacts, request.contact_iden));

                #endregion processing
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Contacts Methods


        #region Channels Methods

        public Subscription SubscribeToChannel(string channel_tag)
        {
            #region pre-processing

            if (string.IsNullOrWhiteSpace(channel_tag))
            {
                throw new ArgumentNullException("channel_tag");
            }

            #endregion pre-processing


            #region processing

            ChannelSubscriptionRequest request = new ChannelSubscriptionRequest()
            {
                channel_tag = channel_tag
            };

            string requestJson = JsonSerializer.Serialize(request);
            string responseJson = PostRequest(string.Concat(PushbulletConstants.BaseUrl, PushbulletConstants.SubscriptionUrls.Subscriptions), requestJson);
            var basicResponse = JsonSerializer.Deserialize<BasicSubscription>(responseJson);
            Subscription result = ConvertFromBasicSubscription(basicResponse);
            return result;

            #endregion processing
        }


        /// <summary>
        /// Get the current user's subscriptions.
        /// </summary>
        /// <param name="showActiveOnly">if set to <c>true</c> [show active only].</param>
        /// <returns></returns>
        public UserSubscriptions CurrentUsersSubscriptions(bool showActiveOnly = false)
        {
            try
            {
                #region pre-processing

                string additionalQuery = string.Empty;

                if(showActiveOnly)
                {
                    additionalQuery = "?active=true";
                }

                #endregion end pre-processing

                #region processing

                UserSubscriptions result = new UserSubscriptions();
                string jsonResult = GetRequest(string.Concat(PushbulletConstants.BaseUrl, PushbulletConstants.SubscriptionUrls.Subscriptions, additionalQuery).Trim());
                var basicResult = JsonSerializer.Deserialize<BasicUserSubscriptions>(jsonResult);
                foreach(var sub in basicResult.subscriptions)
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


        private Subscription ConvertFromBasicSubscription(BasicSubscription basicSubscription)
        {
            Subscription result = new Subscription();
            result.active = basicSubscription.active;
            result.channel = basicSubscription.channel;
            result.iden = basicSubscription.iden;
            result.created = TimeZoneInfo.ConvertTimeFromUtc(basicSubscription.created.UnixTimeToDateTime(), TimeZoneInfo);
            result.modified = TimeZoneInfo.ConvertTimeFromUtc(basicSubscription.modified.UnixTimeToDateTime(), TimeZoneInfo);
            return result;
        }


        /// <summary>
        /// Unsubscribes from channel.
        /// </summary>
        /// <param name="channel_iden">The channel_iden.</param>
        /// <exception cref="System.ArgumentException">unsubscribe from channel request</exception>
        /// <exception cref="System.Exception"></exception>
        public void UnsubscribeFromChannel(string channel_iden)
        {
            #region pre-processing

            if (string.IsNullOrWhiteSpace(channel_iden))
            {
                throw new ArgumentNullException("channel_iden");
            }

            #endregion pre-processing


            #region processing

            string jsonResult = DeleteRequest(string.Format("{0}{1}/{2}", PushbulletConstants.BaseUrl, PushbulletConstants.SubscriptionUrls.Subscriptions, channel_iden));

            #endregion processing
        }


        /// <summary>
        /// Gets the channel information.
        /// </summary>
        /// <param name="channel_tag">The channel_tag.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">channel_tag</exception>
        public Channel GetChannelInformation(string channel_tag)
        {
            #region pre-processing

            if (string.IsNullOrWhiteSpace(channel_tag))
            {
                throw new ArgumentNullException("channel_tag");
            }

            #endregion pre-processing


            #region processing

            string jsonResult = GetRequest(string.Format("{0}{1}?tag={2}", PushbulletConstants.BaseUrl, PushbulletConstants.SubscriptionUrls.ChannelInfo, channel_tag));
            var result = JsonSerializer.Deserialize<Channel>(jsonResult);
            return result;

            #endregion processing
        }

        #endregion Channels Methods


        #region Push Methods

        /// <summary>
        /// Pushes the note.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">request</exception>
        public PushResponse PushNote(PushNoteRequest request, bool ignoreEmptyFields = false)
        {
            try
            {
                #region pre-processing

                if (request == null)
                {
                    throw new ArgumentNullException("note request");
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
                        throw new Exception(PushbulletConstants.PushNoteRequestErrorMessages.EmptyTitleProperty);
                    }

                    if (string.IsNullOrWhiteSpace(request.body))
                    {
                        throw new Exception(PushbulletConstants.PushNoteRequestErrorMessages.EmptyBodyProperty);
                    }
                }

                #endregion pre-processing


                #region processing

                return PostPushRequest(JsonSerializer.Serialize(request));

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
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">request</exception>
        public PushResponse PushAddress(PushAddressRequest request, bool ignoreEmptyFields = false)
        {
            try
            {
                #region pre-processing

                if (request == null)
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

                #endregion pre-processing


                #region processing

                return PostPushRequest(JsonSerializer.Serialize(request));

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
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">request</exception>
        public PushResponse PushLink(PushLinkRequest request, bool ignoreEmptyFields = false)
        {
            try
            {
                #region pre-processing

                if (request == null)
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

                #endregion pre-processing


                #region processing

                return PostPushRequest(JsonSerializer.Serialize(request));

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
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">list request</exception>
        public PushResponse PushList(PushListRequest request, bool ignoreEmptyFields = false)
        {
            try
            {
                #region pre-processing

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

                #endregion pre-processing


                #region processing

                return PostPushRequest(JsonSerializer.Serialize(request));

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
        public PushResponse PushFile(PushFileRequest request)
        {
            try
            {
                #region pre-processing

                if (request == null)
                {
                    throw new ArgumentNullException("file request");
                }

                if (string.IsNullOrWhiteSpace(request.device_iden) && string.IsNullOrWhiteSpace(request.email))
                {
                    throw new Exception(PushbulletConstants.PushRequestErrorMessages.EmptyEmailProperty);
                }

                if (string.IsNullOrWhiteSpace(request.file_name))
                {
                    throw new Exception(PushbulletConstants.PushFileErrorMessages.EmptyFileNameProperty);
                }

                if (string.IsNullOrWhiteSpace(request.file_type))
                {
                    throw new Exception(PushbulletConstants.PushFileErrorMessages.EmptyFileTypeProperty);
                }

                if (request.file_stream == null)
                {
                    throw new Exception(PushbulletConstants.PushFileErrorMessages.EmptyFileStreamProperty);
                }

                if (!request.file_stream.CanRead)
                {
                  throw new Exception(PushbulletConstants.PushFileErrorMessages.CantReadFileStreamProperty);
                }

                #endregion pre-processing


                #region processing

                FileUploadResponse uploadRequestResponse = PostFileUploadRequest(request);

                if (uploadRequestResponse.data == null || string.IsNullOrWhiteSpace(uploadRequestResponse.file_url))
                {
                    throw new Exception(PushbulletConstants.PushFileErrorMessages.ErrorMakingFileUploadRequest);
                }

                PushFileToAmazonAWS(request, uploadRequestResponse);
                request.file_url = uploadRequestResponse.file_url;
                return PostPushRequest(JsonSerializer.Serialize(request));

                #endregion processing
            }
            catch (Exception)
            {
                throw;
            }
        }


        public PushResponseContainer GetPushesSinceModifiedTime(PushResponseFilter filter)
        {
            try
            {
                #region pre-processing

                if (filter == null)
                {
                    throw new ArgumentNullException("filter");
                }

                if(filter.ModifiedDate == null)
                {
                    throw new ArgumentNullException("filter", PushbulletConstants.PushResponseFilterErrorMessages.MissingDateModifiedError);
                }

                string additionalQuery = string.Concat("?modified_after=", filter.ModifiedDate.DateTimeToUnixTime());

                if(filter.Active)
                {
                    additionalQuery = string.Concat(additionalQuery, "&active=true");
                }

                #endregion


                #region processing

                PushResponseContainer results = new PushResponseContainer();
                string jsonResult = GetRequest(string.Concat(PushbulletConstants.BaseUrl, PushbulletConstants.PushesUrls.Push, additionalQuery).Trim());
                if(string.IsNullOrWhiteSpace(jsonResult))
                {
                    throw new Exception("Connect issue.");
                }

                BasicPushResponseContainer basicPushContainer = JsonSerializer.Deserialize<BasicPushResponseContainer>(jsonResult);
                PushResponseContainer pushContainer = ConvertBasicPushResponseContainer(basicPushContainer);

                if(filter.IncludeTypes != null && filter.IncludeTypes.Count() > 0)
                {
                    foreach(var type in filter.IncludeTypes)
                    {
                        results.pushes.AddRange(pushContainer.pushes.Where(o => o.Type == type).ToList());
                    }
                    results.pushes = results.pushes.OrderByDescending(o => o.Created).ToList();
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
            foreach(var basicPush in container.pushes)
            {
                result.pushes.Add(ConvertBasicPushResponse(basicPush));
            }
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

                string grantTypeParam = string.Concat("grant_type=", request.grant_type);
                string clientIdParam = string.Concat("client_id=", request.client_id);
                string clientSecretParam = string.Concat("client_secret=", request.client_secret);
                string codeParam = string.Concat("code=", request.code);
                string jsonResult = PostRequest(string.Concat(PushbulletConstants.BaseUrlNonVersion, PushbulletConstants.OAuthUrls.OAuthToken), grantTypeParam, clientIdParam, clientSecretParam, codeParam);
                var result = JsonSerializer.Deserialize<OAuthTokenResponse>(jsonResult);
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
        /// Deletes the request.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        private string DeleteRequest(string url)
        {
            var request = GetWebRequest(url);
            request.Method = PushbulletConstants.HttpMethods.DELETE;

            using(var response = request.GetResponse())
            {
                using(var reader = new StreamReader(response.GetResponseStream()))
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
            BasicPushResponse basicResponse = JsonSerializer.Deserialize<BasicPushResponse>(responseJson);
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
            response.Active = basicResponse.active;
            response.Created = TimeZoneInfo.ConvertTimeFromUtc(basicResponse.created.UnixTimeToDateTime(), TimeZoneInfo);
            response.Dismissed = basicResponse.dismissed;
            response.Direction = basicResponse.direction;
            response.Iden = basicResponse.iden;
            response.Modified = TimeZoneInfo.ConvertTimeFromUtc(basicResponse.modified.UnixTimeToDateTime(), TimeZoneInfo);
            response.ReceiverEmail = basicResponse.receiver_email;
            response.ReceiverEmailNormalized = basicResponse.receiver_email_normalized;
            response.ReceiverIden = basicResponse.receiver_iden;
            response.SenderEmail = basicResponse.sender_email;
            response.SenderEmailNormalized = basicResponse.sender_email_normalized;
            response.SenderIden = basicResponse.sender_iden;
            response.SenderName = basicResponse.sender_name;
            response.SourceDeviceIden = basicResponse.source_device_iden;
            response.TargetDeviceIden = basicResponse.target_device_iden;
            response.Type = ConvertPushResponseType(basicResponse.type);
            response.ClientIden = basicResponse.client_iden;
            response.Title = basicResponse.title;
            response.Body = basicResponse.body;
            response.Url = basicResponse.url;
            response.FileName = basicResponse.file_name;
            response.FileType = basicResponse.file_type;
            response.FileUrl = basicResponse.file_url;
            response.ImageUrl = basicResponse.image_url;
            response.Name = basicResponse.name;
            response.Address = basicResponse.address;
            if(basicResponse.items != null)
            {
                response.Items = basicResponse.items.Select(o => new ListItem() { Checked = o.Checked, Text = o.text }).ToList();
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
        /// Posts the request.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="json">The json.</param>
        /// <returns></returns>
        private string PostRequest(string url, string json)
        {
            string result = string.Empty;

            var request = (HttpWebRequest)HttpWebRequest.Create(url);

            request.Method = PushbulletConstants.HttpMethods.POST;
            request.ContentType = PushbulletConstants.MimeTypes.Json;
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
        /// Posts the request.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        private string PostRequest(string url, params string[] parameters)
        {
            try
            {
                string result = string.Empty;

                var request = (HttpWebRequest)HttpWebRequest.Create(url);

                request.Method = PushbulletConstants.HttpMethods.POST;
                request.ContentType = PushbulletConstants.MimeTypes.FormUrlEncoded;
                string postData = string.Join("&", parameters);
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(postData);
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
                    catch (Exception)
                    {
                        throw;
                    }
                }, null);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
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
                    awsaccesskeyidContent = CreateStringContentFromNameValue(FileUploadResponseData.Properties.awsaccesskeyid, fileUploadResponse.data.awsaccesskeyid);
                    aclContent = CreateStringContentFromNameValue(FileUploadResponseData.Properties.acl, fileUploadResponse.data.acl);
                    keyContent = CreateStringContentFromNameValue(FileUploadResponseData.Properties.key, fileUploadResponse.data.key);
                    signatureContent = CreateStringContentFromNameValue(FileUploadResponseData.Properties.signature, fileUploadResponse.data.signature);
                    policyContent = CreateStringContentFromNameValue(FileUploadResponseData.Properties.policy, fileUploadResponse.data.policy);
                    contentTypeContent = CreateStringContentFromNameValue(PushbulletConstants.AmazonHeaders.ContentType, fileUploadResponse.file_type);

                    multiPartCont.Add(awsaccesskeyidContent);
                    multiPartCont.Add(aclContent);
                    multiPartCont.Add(keyContent);
                    multiPartCont.Add(signatureContent);
                    multiPartCont.Add(policyContent);
                    multiPartCont.Add(contentTypeContent);

                    using (var memoryStream = new MemoryStream()) { 
                      request.file_stream.CopyTo(memoryStream);
                      fileContent = new ByteArrayContent(memoryStream.ToArray());
                    }

                    fileContent.Headers.Add(PushbulletConstants.AmazonHeaders.ContentType, PushbulletConstants.MimeTypes.OctetStream);
                    fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = string.Format("\"{0}\"", "file"),
                        FileName = string.Format("\"{0}\"", request.file_name)
                    };

                    multiPartCont.Add(fileContent);

                    using (var httpClient = new HttpClient())
                    {
                        Task<HttpResponseMessage> httpRequest = httpClient.PostAsync(fileUploadResponse.upload_url, multiPartCont);
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