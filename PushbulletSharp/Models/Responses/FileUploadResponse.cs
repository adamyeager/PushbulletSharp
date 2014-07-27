namespace PushbulletSharp.Models.Responses
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
    internal class FileUploadResponse
    {
        /// <summary>
        /// Gets or sets the file_type.
        /// </summary>
        /// <value>
        /// The file_type.
        /// </value>
        public string file_type { get; set; }

        /// <summary>
        /// Gets or sets the file_name.
        /// </summary>
        /// <value>
        /// The file_name.
        /// </value>
        public string file_name { get; set; }

        /// <summary>
        /// Gets or sets the file_url.
        /// </summary>
        /// <value>
        /// The file_url.
        /// </value>
        public string file_url { get; set; }

        /// <summary>
        /// Gets or sets the upload_url.
        /// </summary>
        /// <value>
        /// The upload_url.
        /// </value>
        public string upload_url { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public FileUploadResponseData data { get; set; }
    }


    internal class FileUploadResponseData
    {
        /// <summary>
        /// Gets or sets the awsaccesskeyid.
        /// </summary>
        /// <value>
        /// The awsaccesskeyid.
        /// </value>
        public string awsaccesskeyid { get; set; }

        /// <summary>
        /// Gets or sets the acl.
        /// </summary>
        /// <value>
        /// The acl.
        /// </value>
        public string acl { get; set; }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string key { get; set; }

        /// <summary>
        /// Gets or sets the signature.
        /// </summary>
        /// <value>
        /// The signature.
        /// </value>
        public string signature { get; set; }

        /// <summary>
        /// Gets or sets the policy.
        /// </summary>
        /// <value>
        /// The policy.
        /// </value>
        public string policy { get; set; }
    }
}