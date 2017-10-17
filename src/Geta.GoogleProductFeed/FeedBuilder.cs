using System.Collections.Generic;
using System.Globalization;
using Geta.GoogleProductFeed.Models;

namespace Geta.GoogleProductFeed
{
    public abstract class FeedBuilder
    {
        /// <summary>
        /// Return collection of google shopping feeds.
        /// </summary>
        /// <returns>
        /// Each feed is mapped to a culture, which can be a generic (nl) or specific (nl-be) culture.
        /// </returns>
        public abstract IDictionary<CultureInfo, Feed> Build();
    }
}
