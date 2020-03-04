using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace XKCDTest.DTO.ViewModels
{
    public class VMComicDetail
    {
        public string Month { get; set; }
        public int Num { get; set; }
        public string Link { get; set; }
        public string Yeat { get; set; }
        [JsonProperty(PropertyName = "safe_title")]
        public string SafeTitle { get; set; }
        public string Transcript { get; set; }
        public string Alt { get; set; }
        public string Img { get; set; }
        public string Title { get; set; }
        public string day { get; set; }
    }
}
