using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace giphy2.Models
{    
    public class GiphyModel
    {
        public IEnumerable<Data> Data { get; set; }
    }

    [DataContract]
    public class Data
    {
        [DataMember(Name = "embed_url")]
        public string EmbedUrl { get; set; }
    }
}
