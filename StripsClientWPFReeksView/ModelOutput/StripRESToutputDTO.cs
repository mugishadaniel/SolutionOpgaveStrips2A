using System;

namespace StripsClientWPFReeksView.ModelOutput
{
    public class StripRESToutputDTO
    {
        public StripRESToutputDTO(string titel, int nr, string url)
        {
            Titel = titel;
            Nr = Convert.ToString(nr);
            Url = url;
        }

        public string? Nr { get; set; }
        public string Titel { get; set; }
        public string Url { get; set; }
    }
}
