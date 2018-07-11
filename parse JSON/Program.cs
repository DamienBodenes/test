using CsvHelper;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parse_JSON
{


    class Program
    {
        static void Main(string[] args)
        {
           String ConnectionString = String.Format("SERVER = localhost;DATABASE = base_sirene; UID=root;;SslMode=none");
            MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString);
            mySqlConnection.Open();
            Int64 count = 0;
            var serializer = new JsonSerializer();
            using (StreamReader streamReader = new StreamReader("base_sirene.csv", Encoding.GetEncoding("iso-8859-1")))
            using (CsvReader reader = new CsvReader(streamReader))
                {
                reader.Configuration.RegisterClassMap<RecordSirenMap>();
                reader.Configuration.Delimiter = ";";
                reader.Configuration.HeaderValidated = null;
                reader.Configuration.MissingFieldFound = null;

                while (reader.Read())
                {
            
                    {
                        try
                        {

                            RecordSiren c = reader.GetRecord<RecordSiren>();
                            ++count;
                            MySqlCommand lCommand = mySqlConnection.CreateCommand();
                            lCommand.CommandText = String.Format("INSERT INTO sirene (siret,siren,nom,L1_norm,L2_norm,CodePostal,Ville,Adresse,Activite) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", c.Siret, 
                                c.Siren, MySql.Data.MySqlClient.MySqlHelper.EscapeString(c.Nom), MySql.Data.MySqlClient.MySqlHelper.EscapeString(c.L1_norm), MySql.Data.MySqlClient.MySqlHelper.EscapeString(c.L2_norm),
                                c.CodePostal, MySql.Data.MySqlClient.MySqlHelper.EscapeString(c.Ville), MySql.Data.MySqlClient.MySqlHelper.EscapeString(c.Adresse), MySql.Data.MySqlClient.MySqlHelper.EscapeString(c.Activite));

                            lCommand.ExecuteNonQuery();
                            Console.WriteLine(count);

                        }
                        catch(Exception ex)
                        {

                        }
                        
                    }
                }

                }
            mySqlConnection.Close();
            
        }
    }
}
