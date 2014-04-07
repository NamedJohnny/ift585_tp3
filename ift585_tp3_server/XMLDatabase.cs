using ift585_tp3_library;
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

        static public XMLData Load()
        {
            //  Load data from DB (XML files)
            string fileName = "Data.xml";
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }
            FileStream fs = new FileStream(fileName, FileMode.Open);
            XMLData xmlData = new XMLData();

            DataContractSerializer serializer = new DataContractSerializer(xmlData.GetType(), null,
                0x7FFF, // maxItemsInObjectGraph
                false, // ignoreExtensionDataObject
                true, // preserveObjectReferences
                null // dataContractSurrogate
            );
            //serializer.WriteObject(Console.OpenStandardOutput(), gdd);
            xmlData = serializer.ReadObject(fs) as XMLData;
            fs.Close();
            return xmlData;
        }

        static public void Add()
        {
            //  Load data from DB (XML files)
            string fileName = "Data.xml";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            FileStream fs = new FileStream(fileName, FileMode.Create);
            User user1 = new User();
            User user2 = new User();
            User user3 = new User();
            User user4 = new User();
            User user5 = new User();
            User user6 = new User();

            user1.Id = 1;
            user1.FirstName = "Alexandre";
            user1.LastName = "Roy";
            user1.Avatar = "ironman";
            user1.DislikeNum = 0;
            user1.LikeNum = 0;
            user1.NumMessages = 0;
            user1.UserName = "itaki";
            user1.Password = "123";

            user2.Id = 2;
            user2.FirstName = "Alex";
            user2.LastName = "Nault";
            user2.Avatar = "homer";
            user2.DislikeNum = 0;
            user2.LikeNum = 0;
            user2.NumMessages = 0;
            user2.UserName = "tiQnault";
            user2.Password = "123";

            user3.Id = 3;
            user3.FirstName = "Johny";
            user3.LastName = "Forcier";
            user3.Avatar = "default";
            user3.DislikeNum = 0;
            user3.LikeNum = 0;
            user3.NumMessages = 0;
            user3.UserName = "namedJohny";
            user3.Password = "123";

            user4.Id = 4;
            user4.FirstName = "Vincent";
            user4.LastName = "Philippon";
            user4.Avatar = "minion";
            user4.DislikeNum = 0;
            user4.LikeNum = 0;
            user4.NumMessages = 0;
            user4.UserName = "virack";
            user4.Password = "123";

            user5.Id = 5;
            user5.FirstName = "Francois";
            user5.LastName = "Genois";
            user5.Avatar = "homer";
            user5.DislikeNum = 0;
            user5.LikeNum = 0;
            user5.NumMessages = 0;
            user5.UserName = "franktdatank";
            user5.Password = "123";

            user6.Id = 6;
            user6.FirstName = "Tommy";
            user6.LastName = "Gregoire";
            user6.Avatar = "ironman";
            user6.DislikeNum = 0;
            user6.LikeNum = 0;
            user6.NumMessages = 0;
            user6.UserName = "titom";
            user6.Password = "123";

            DiscussionRoom room1 = new DiscussionRoom();
            DiscussionRoom room2 = new DiscussionRoom();
            DiscussionRoom room3 = new DiscussionRoom();

            room1.Id = 1;
            room1.Name = "Salle1";
            room1.Description = "Premiere salle de discussion dans le monde!";


            room2.Id = 2;
            room2.Name = "Salle2";
            room2.Description = "Deuxieme salle de discussion dans le monde!";


            room3.Id = 3;
            room3.Name = "Salle3";
            room3.Description = "Troisieme salle de discussion dans le monde!";

            List<DiscussionRoom> rooms = new List<DiscussionRoom>();
            rooms.Add(room1);
            rooms.Add(room2);
            rooms.Add(room3);

            List<User> users = new List<User>();
            users.Add(user1);
            users.Add(user2);
            users.Add(user3);
            users.Add(user4);
            users.Add(user5);
            users.Add(user6);

            XMLData xmlData = new XMLData(rooms, users);


            DataContractSerializer serializer = new DataContractSerializer(xmlData.GetType(), null,
                0x7FFF, // maxItemsInObjectGraph
                false, // ignoreExtensionDataObject
                true, // preserveObjectReferences
                null // dataContractSurrogate
            );
            //Console.WriteLine("Testing for type: {0}", typeof(XMLData));
            serializer.WriteObject(fs, xmlData);
            fs.Close();
        }

        static public void Save(XMLData xmlData)
        {
            // Sauvegarde en XML les salles de discussions et les utilisateurs
            // TODO Getter les données du moment et les enregistrer
            string fileName = "Data.xml";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            DataContractSerializer serializer = new DataContractSerializer(xmlData.GetType(), null,
                0x7FFF, // maxItemsInObjectGraph
                false, // ignoreExtensionDataObject
                true, // preserveObjectReferences
                null // dataContractSurrogate
            );
            FileStream fs = new FileStream(fileName, FileMode.Create);
            //Console.WriteLine("Testing for type: {0}", typeof(XMLData));
            serializer.WriteObject(fs, xmlData);
            fs.Close();
        }
    }
}
