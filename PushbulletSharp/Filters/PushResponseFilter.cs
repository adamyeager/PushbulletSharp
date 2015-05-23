using PushbulletSharp.Models.Responses;
using System;

namespace PushbulletSharp.Filters
{
    public class PushResponseFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PushResponseFilter"/> class.
        /// </summary>
        public PushResponseFilter()
        {
            ModifiedDate = DateTime.Now;
            Active = true;
        }

        /// <summary>
        /// Gets or sets the modified date.
        /// </summary>
        /// <value>
        /// The modified date.
        /// </value>
        public DateTime ModifiedDate { get; set; }

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