using PushbulletSharp.Models.Responses;

namespace PushbulletSharp.Filters
{
    public class PushResponseFilter
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PushResponseFilter"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the include types.
        /// </summary>
        /// <value>
        /// The include types.
        /// </value>
        public PushResponseType[] IncludeTypes { get; set; }
    }
}