using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Web.Http;
using System.Xml.Serialization;
using Geta.GoogleProductFeed.Models;
using Geta.GoogleProductFeed.Repositories;

namespace Geta.GoogleProductFeed.Controllers
{
    public class GoogleProductFeedController : ApiController
    {
        private readonly IFeedHelper _feedHelper;


        public GoogleProductFeedController(IFeedHelper feedHelper)
        {
            _feedHelper = feedHelper;
        }

        [Route("{culture}/googleproductfeed")]
        public IHttpActionResult Get(string culture)
        {
            if (string.IsNullOrWhiteSpace(culture)) throw new ArgumentNullException(culture);

            var cultureTyped = CultureInfo.CreateSpecificCulture(culture);

            var feed = _feedHelper.GetLatestFeed(cultureTyped);

            if (feed == null)
                return Content(HttpStatusCode.NotFound, "No feed generated", new NamespacedXmlMediaTypeFormatter());

            return Content(HttpStatusCode.OK, feed, new NamespacedXmlMediaTypeFormatter());
        }
    }
}
