using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTJ.Person.Schemas
{
    public class AdressVariantSchema
    {
        	public int Id;
	        public int AdressTyp_FKID;
	        public string Variant;
	        public DateTime SkapadDatum;
            public DateTime UpdateradDatum;
    }
}
