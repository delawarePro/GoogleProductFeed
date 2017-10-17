using System;
using System.Globalization;
using EPiServer.Data;
using EPiServer.Data.Dynamic;

namespace Geta.GoogleProductFeed.Models
{
    [EPiServerDataStore(AutomaticallyCreateStore = true, AutomaticallyRemapStore = true)]
    public class FeedData
    {
        public DateTime Created { get; set; }
        public byte[] FeedBytes { get; set; }
        public CultureInfo Culture { get; set; }

        [EPiServerDataIndex]
        public Identity Id { get; set; }
    }
}
