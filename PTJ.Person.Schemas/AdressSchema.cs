using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTJ.Person.Schemas
{
    public class AdressSchema
    {
	    public int Id;
	    public int AdressTyp_FKID;
	    public int Person_FKID;
	    public int Organisation_FKID;
	    public int AdressVariant_FKID;
	    public DateTime SkapadDatum;
        public DateTime UpdateradDatum;
    }
}
