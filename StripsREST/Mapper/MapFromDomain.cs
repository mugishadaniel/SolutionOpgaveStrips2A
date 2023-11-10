using StripsBL.Model;
using StripsREST.Model.Output;

namespace StripsREST.Mapper
{
    public class MapFromDomain
    {
        public static ReeksRESToutputDTO MapFromReeksDomain(Reeks reeks, string url)
        {
            List<StripRESToutputDTO> strips = new List<StripRESToutputDTO>();

            foreach (Strip strip in reeks.Strips)
            {
                if (strip.Nr == null)
                {
                    strips.Add(new StripRESToutputDTO(strip.Titel, 0, url + "/strip/" + strip.ID));
                }
                else
                {
                    strips.Add(new StripRESToutputDTO(strip.Titel, (int)strip.Nr, url + "/strip/" + strip.ID));
                }
                
            }
            
            return new ReeksRESToutputDTO(reeks.ID, reeks.Naam,url+$"/reeks/{reeks.ID}", strips, reeks.Strips.Count);
        }


    }
}
