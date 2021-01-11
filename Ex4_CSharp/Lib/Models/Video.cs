using System;
using System.Collections.Generic;

namespace Ex4_CSharp.Lib.Models
{
    public class Video
    {
        public int Id { get; set; }
        public Guid ProID { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public List<string>  TagList { get; set; }

        public Video(string Url, string Title)
        {
            Id = this.Id;
            ProID = Guid.NewGuid();
            Url = this.Url;
            Title = this.Title;
            this.TagList = new List<string>();
        }

        public override string ToString()
        {
            var output = $"- Id: {Id}\n- ProID: {ProID}\n- Títol: {Title}\n- Url: {Url}";
            output = output + "\nTags: [";
            foreach (var tag in TagList)
            {
                output = output + tag + ", ";
            }
            output = output + "]";
            return output;
        }

        public void AddTag (string newTag)
        {
            TagList.Add(newTag);
        }
    }
}
