using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationAPI.Integration.SpotifyApi.Models
{
    public class Artist
    {
        public ExternalUrl ExternalUrls { get; set; }

        public Follower Followers { get; set; }

        public string[] Genres { get; set; }

        public string Href { get; set; }

        public string Id { get; set; }

        public Image[] Images { get; set; }

        public string Name { get; set; }

        public int Popularity { get; set; }

        public string Type { get; set; }

        public string Uri { get; set; }
    }
}
