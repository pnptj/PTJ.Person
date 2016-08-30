using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTJ.Person.Schemas
{
    public class GatuAdressSchema
    {
        	public int      Id;
	        public int      Adress_FKID;
	        public int      AdressTyp_FKID;
	        public int      AdressVariant_FKID;
	        public string   AdressRad1;
	        public string   AdressRad2;
	        public string   AdressRad3;
	        public string   AdressRad4;
	        public string   AdressRad5;
	        public int      Postnummer;
	        public string   Stad;
	        public string   Land;
	        public DateTime SkapadDatum;
            public DateTime UpdateradDatum;
    }
}
