using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTJ.Person.Schemas
{
    public class TelefonSchema
    {
        	public int Id;
	        public int Adress_FKID;
	        public int AdressTyp_FKID;
	        public int AdressVariant_FKID;
	        public int TelefonNummer;
	        public DateTime SkapadDatum;
            public DateTime UpdateradDatum;
    }
}
