using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.Contract.Models
{
    public class ReviewModel
    {
        public string author_name { get; set; }
        public string author_url { get; set; }
        public string language { get; set; }
        public string profile_photo_url { get; set; }
        public int rating { get; set; }
        public string relative_time_description { get; set; }
        public string text { get; set; }
        public int time { get; set; }
    }
}
