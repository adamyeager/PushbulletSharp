using System.Runtime.Serialization;

namespace PushbulletSharpCore.Models.Responses
{
    /// <summary>
    /// Response when request a push for a file
    /// 
    /// Exmple response:
    /// 
    /// {
    ///     "file_type": "image/png",
    ///     "file_name": "image.png",
    ///     "file_url": "https://s3.amazonaws.com/pushbullet-uploads/ubd-VWb1dP5XrZzvHReWHCycIwPyuAMp2R9I/image.png",
    ///     "upload_url": "https://s3.amazonaws.com/pushbullet-uploads",
    ///     "data": {
    ///         "awsaccesskeyid": "AKIAJJIUQPUDGPM4GD3W",
    ///         "acl": "public-read",
    ///         "key": "ubd-CWb1dP5XrZzvHReWHCycIwPyuAMp2R9I/image.png",
    ///         "signature": "UX5s1uIy1ov6+xlj58JY7rGFKcs=",
    ///         "policy": "eyKjb25kaXRpb25zIjTE6MzcuMjM0MTMwWiJ9",
    ///         "content-type": "image/png"
    ///     }
    /// }
    /// 
    /// </summary>
    [DataContract]
    internal class FileUploadResponse
    {
        /// <summary>
        /// Gets or sets the file_type.
        /// </summary>
        /// <value>
        /// The file_type.
        /// </value>
        [DataMember(Name = "file_type")]
        public string FileType { get; set; }

        /// <summary>
        /// Gets or sets the file_name.
        /// </summary>
        /// <value>
        /// The file_name.
        /// </value>
        [DataMember(Name = "file_name")]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the file_url.
        /// </summary>
        /// <value>
        /// The file_url.
        /// </value>
        [DataMember(Name = "file_url")]
        public string FileUrl { get; set; }

        /// <summary>
        /// Gets or sets the upload_url.
        /// </summary>
        /// <value>
        /// The upload_url.
        /// </value>
        [DataMember(Name = "upload_url")]
        public string UploadUrl { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [DataMember(Name = "data")]
        public FileUploadResponseData Data { get; set; }
    }

    [DataContract]
    internal class FileUploadResponseData
    {
        internal class Properties
        {
            internal const string AWSAccessKeyId = "awsaccesskeyid";
            internal const string Acl = "acl";
            internal const string Key = "key";
            internal const string Signature = "signature";
            internal const string Policy = "policy";
        }

        /// <summary>
        /// Gets or sets the awsaccesskeyid.
        /// </summary>
        /// <value>
        /// The awsaccesskeyid.
        /// </value>
        [DataMember(Name = "awsaccesskeyid")]
        public string AWSAccessKeyId { get; set; }

        /// <summary>
        /// Gets or sets the acl.
        /// </summary>
        /// <value>
        /// The acl.
        /// </value>
        [DataMember(Name = "acl")]
        public string Acl { get; set; }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        [DataMember(Name = "key")]
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the signature.
        /// </summary>
        /// <value>
        /// The signature.
        /// </value>
        [DataMember(Name = "signature")]
        public string Signature { get; set; }

        /// <summary>
        /// Gets or sets the policy.
        /// </summary>
        /// <value>
        /// The policy.
        /// </value>
        [DataMember(Name = "policy")]
        public string Policy { get; set; }
    }
}