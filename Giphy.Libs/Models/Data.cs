using System.Runtime.Serialization;

namespace Giphy.Libs.Models
{
    [DataContract]
    public class Data
    {
        [DataMember(Name = "embed_url")]
        public string EmbedUrl { get; set; }
    }
}