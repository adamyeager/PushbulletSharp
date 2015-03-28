namespace PushbulletSharp.Models.Responses
{
    public class Channel
    {
        /// <summary>
        /// Gets or sets the iden.
        /// </summary>
        /// <value>
        /// The iden.
        /// </value>
        public string iden { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public string tag { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string description { get; set; }

        /// <summary>
        /// Gets or sets the website_url.
        /// </summary>
        /// <value>
        /// The website_url.
        /// </value>
        public string website_url { get; set; }

        /// <summary>
        /// Gets or sets the image_url.
        /// </summary>
        /// <value>
        /// The image_url.
        /// </value>
        public string image_url { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if(!string.IsNullOrWhiteSpace(name))
            {
                return name;
            }
            
            return base.ToString();
        }
    }
}