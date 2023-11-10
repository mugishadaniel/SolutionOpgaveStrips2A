using StripsBL.Model;

namespace StripsREST.Model.Output
{
    public class ReeksRESToutputDTO
    {
        public ReeksRESToutputDTO(int iD, string naam,string url, List<StripRESToutputDTO> strips, int aantalStrips)
        {
            ID = iD;
            Naam = naam;
            Url = url;
            Strips = strips;
            AantalStrips = aantalStrips;
        }

        public int ID { get; set; }
        public string Naam { get; set; }
        public string Url { get; set; }
        public List<StripRESToutputDTO> Strips { get; set; }
        public int AantalStrips { get; set; }
    }
}
