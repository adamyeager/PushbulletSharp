namespace PushbulletSharpCore.Models.Responses
{
    public class ListItem
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ListItem"/> is checked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if checked; otherwise, <c>false</c>.
        /// </value>
        public bool Checked { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; set; }
    }
}