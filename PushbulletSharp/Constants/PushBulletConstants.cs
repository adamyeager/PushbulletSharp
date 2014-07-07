namespace PushbulletSharp
{
    public class PushbulletConstants
    {
        public const string BaseUrl = "https://api.pushbullet.com/v2/";

        public class PushRequestErrorMessages
        {
            public const string EmptyDeviceIdenProperty = "The device iden property for the reqeust is empty.";
            public const string EmptyTypeProperty = "The type property for the reqeust is empty. Not even sure how that happened.";
            public const string EmptyEmailProperty = "The email property for the request is empty. This is only a problem because the device iden was empty, too.";
        }


        public class PushNoteRequestErrorMessages
        {
            public const string EmptyTitleProperty = "The title property for the note request is empty. Please provide a title.";
            public const string EmptyBodyProperty = "The body property for the note request is empty. Please provide a body.";
        }


        public class PushAddressErrorMessages
        {
            public const string EmptyNameProperty = "The name property for the address request is empty. Please provide a name.";
            public const string EmptyAddressProperty = "The address property for the address request is empty. Please provide a name.";
        }


        public class PushLinkErrorMessages
        {
            public const string EmptyTitleProperty = "The title property for the link request is empty. Please provide a title.";
            public const string EmptyUrlProperty = "The url property for the link request is empty. Please provide a url.";
        }


        public class PushListErrorMessages
        {
            public const string EmptyTitleProperty = "The title property for the list request is empty. Please provide a title.";
        }


        public class HeadersConstants
        {
            public const string AuthorizationKey = "Authorization";
            public const string AuthorizationValue = "Bearer {0}";
        }


        public class TypeConstants
        {
            public const string Note = "note";
            public const string Link = "link";
            public const string Address = "address";
            public const string List = "list";
            public const string File = "file";
        }


        public class UsersUrls
        {
            public const string Me = "users/me";
        }


        public class DevicesUrls
        {
            public const string Me = "devices";
        }


        public class PushesUrls
        {
            public const string Push = "pushes";
        }
    }
}