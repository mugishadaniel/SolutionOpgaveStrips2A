using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StripsBL.Exceptions;
using StripsBL.Managers;
using StripsBL.Model;
using StripsREST.Mapper;
using StripsREST.Model.Output;

namespace StripsREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripsController : ControllerBase
    {
        private StripsManager stripsManager;
        private string url = "http://localhost:5044/api/Strips/beheer";

        public StripsController(StripsManager stripsManager)
        {
            this.stripsManager = stripsManager;
        }

        [HttpGet]
        [Route("Reeks/{reeksid}")]
        public ActionResult<ReeksRESToutputDTO> GetReeks(int reeksid) 
        {
            try
            {
                
                Reeks reeks = stripsManager.GeefReeks(reeksid);
                if (reeks == null)
                {
                    return NotFound("Reeks niet gevonden");
                }
                return Ok(MapFromDomain.MapFromReeksDomain(reeks, url));
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }


        
    }
}
