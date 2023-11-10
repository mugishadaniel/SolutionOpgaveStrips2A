
using StripsBL.Exceptions;
using StripsBL.Interfaces;
using StripsBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.Managers
{
    public class StripsManager
    {
        private IStripsRepository stripsRepository;

        public StripsManager(IStripsRepository stripsRepository)
        {
            this.stripsRepository = stripsRepository;
        }

        public Reeks GeefReeks(int reeksid)
        {
            try
            {
                return stripsRepository.GeefReeks(reeksid);
            }
            catch (Exception ex)
            {

                throw new StripsManagerException("Geefreeks", ex);
            }
        }
       
    }
}
