using System.Globalization;
using System.Linq;
using EPiServer.Data;
using EPiServer.Data.Dynamic;
using EPiServer.ServiceLocation;
using Geta.GoogleProductFeed.Models;

namespace Geta.GoogleProductFeed.Repositories
{
    [ServiceConfiguration(typeof(IFeedRepository))]
    public class FeedRepository : IFeedRepository
    {
        public void RemoveOldVersion(CultureInfo culture)
        {
            var items = FeedStore.Items<FeedData>()
                            .Where(f => f.Culture == culture)
                            .OrderByDescending(f => f.Created)
                            .ToList();

            if (items.Count > 1)
            {
                for (int i = items.Count - 1; i >= 1; i--)
                {
                    FeedStore.Delete(items[i].Id);
                }
            }
        }

        public FeedData GetLatestFeedData(CultureInfo culture)
        {
            return FeedStore.Items<FeedData>()
                        .Where(f => f.Culture == culture)
                        .OrderByDescending(f => f.Created)
                        .FirstOrDefault();
        }

        public void Save(FeedData feedData)
        {
            if (feedData == null)
                return;

            FeedStore.Save(feedData);
        }


        private static DynamicDataStore FeedStore
        {
            get
            {
                return typeof(FeedData).GetStore();
            }
        }
    }
}