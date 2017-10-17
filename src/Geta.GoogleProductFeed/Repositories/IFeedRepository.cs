using System.Globalization;
using EPiServer.Data;
using Geta.GoogleProductFeed.Models;

namespace Geta.GoogleProductFeed.Repositories
{
    public interface IFeedRepository
    {
        void RemoveOldVersion(CultureInfo culture);
        
        FeedData GetLatestFeedData(CultureInfo culture);

        void Save(FeedData feedData);
    }
}
