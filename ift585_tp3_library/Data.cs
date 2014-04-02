using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ift585_tp3_library
{
    [SerializableAttribute] // remove?
    public class Data
    {

        #region private members
        public enum DataType
        {
            Login = 0,
            Logout = 1,
            SendMessage = 2,
            GetMessages = 3,
            Like = 4,
            Dislike = 5,
            ViewProfile = 6,
            UpdateProfile = 7
        }

        int id;
        DataType command;
        User user;
        DateTime date;
        string text;
        int num;
        bool more;
        #endregion private members

        public Data()
        {
            date = DateTime.Now;
            text = "";
            num = 0;
            more = false;
        }

        #region public members

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public int Num
        {
            get { return num; }
            set { num = value; }
        }

        public DataType Command
        {
            get { return command; }
            set { command = value; }
        }

        public bool More
        {
            get { return more; }
            set { more = value; }
        }

        public string ClientUserName
        {
            get
            {
                return User.UserName;
            }
        }

        #endregion public members

        #region public methods
        /*public Byte[] ToByteArray()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                XmlSerializer xmlS = new XmlSerializer(typeof(Data));
                xmlS.Serialize(ms, this);

                return ms.ToArray();
            }
        }

        public static Data FromByteArray(Byte[] bObj)
        {
            using (MemoryStream ms = new MemoryStream(bObj))
            {
                XmlSerializer xmlS = new XmlSerializer(typeof(Data));
                return (Data)xmlS.Deserialize(ms);
            }
        }*/

        public static byte[] Serialize(Data data)
        {
            using (var memoryStream = new MemoryStream())
            {
                (new BinaryFormatter()).Serialize(memoryStream, data);
                return memoryStream.ToArray();
            }
        }

        public static Data Deserialize(byte[] message)
        {
            using (var memoryStream = new MemoryStream(message))
                return (new BinaryFormatter()).Deserialize(memoryStream) as Data;
        }
        #endregion public methods
    }
}
