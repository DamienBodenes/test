using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parse_JSON
{
    public class RecordSiren
    {
        public String Siren { get; set; }
        public String NIC { get; set; }
        public String Siret { get { return Siren + NIC; } }
        public String Nom { get; set; }
        public String L1_norm { get; set; }
        public String L2_norm { get; set; }
        public String CodePostal { get; set; }
        public String Rue { get; set; }
        public String Num { get; set; }
        public String Ville { get; set; }

        public String Adresse { get { return Num + " " + Rue; } }

        public String Activite { get; set; }
    }

    public class RecordSirenMap : ClassMap<RecordSiren>
    {
        public RecordSirenMap()
        {
       
            Map(x => x.NIC).Name("NIC");
            Map(x => x.Siren).Name("SIREN");
            Map(x => x.Nom).Name("NOMEN_LONG");
            Map(x => x.L1_norm).Name("L1_NORMALISEE");
            Map(x => x.L2_norm).Name("L2_NORMALISEE");

            Map(x => x.CodePostal).Name("CODPOS");
            Map(x => x.Rue).Name("LIBVOIE");
            Map(x => x.Num).Name("NUMVOIE");
            Map(x => x.Ville).Name("LIBCOM");

            Map(x => x.Activite).Name("LIBAPET");

            


        }
    }
}
