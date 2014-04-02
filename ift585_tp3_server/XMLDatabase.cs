using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ift585_tp3_server
{
    class XMLDatabase
    {
        public XMLDatabase()
        {

        }

        public void Load()
        {
            /*// TODO (roy) Load data from DB (JSON files)
            //  Load data from DB (XML files)
            string fileName = "Data.xml";
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }
            FileStream fs = new FileStream(fileName, FileMode.Open);
            List<XMLData> gdd = new List<XMLData>();

            DataContractSerializer serializer = new DataContractSerializer(gdd.GetType(), null,
                0x7FFF, // maxItemsInObjectGraph
                false, // ignoreExtensionDataObject
                true, // preserveObjectReferences
                null // dataContractSurrogate
            );
            //serializer.WriteObject(Console.OpenStandardOutput(), gdd);
            gdd = serializer.ReadObject(fs) as List<XMLData>;
            fs.Close();*/
        }

        public void Save()
        {
            /*// Sauvegarde en XML les salles de discussions et les utilisateurs
            // TODO Getter les données du moment et les enregistrer
            fs = File.Open("Data.xml", FileMode.Create);
            Console.WriteLine("Testing for type: {0}", typeof(XMLData));
            serializer.WriteObject(fs, gdd);
            fs.Close();*/
        }
    }
}
