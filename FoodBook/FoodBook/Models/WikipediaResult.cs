namespace FoodBook.Models
{
    class WikipediaResult
    {
        public string Extract { get; set; }
        public WikipediaResult(string Content)
        {
            string keyToStart = "\"extract\":";
            int startIndex = Content.IndexOf(keyToStart) + keyToStart.Length;
            int endIndex = Content.Substring(startIndex).IndexOf(@"\n");
            //int endIndex = Content.LastIndexOf("}}}}");
            Extract = Content
                .Substring(startIndex,endIndex).Replace("<p>","")
                .Replace("</p>", "")
                .Replace("<b>", "")
                .Replace("</b>", "")
                .Replace("<i>", "")
                .Replace("</i>", "");
        }
    }
}
