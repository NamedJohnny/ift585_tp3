using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ift585_tp3_library
{
    public class Data
    {

        #region private members
        int id;
        string text;
        User client;
        DateTime date;
        int likeNum;
        int dislikeNum;
        DataType dataType;
        #endregion private members

        public Data()
        {

        }

        enum DataType
        {
            Login = 0,
            Logout = 1,
            Message = 2
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

        public User Client
        {
            get { return client; }
            set { client = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public int LikeNum
        {
            get { return likeNum; }
            set { likeNum = value; }
        }

        public int DislikeNum
        {
            get { return dislikeNum; }
            set { dislikeNum = value; }
        }

        private DataType DataType1
        {
            get { return dataType; }
            set { dataType = value; }
        }

        public string ClientUserName
        {
            get
            {
                return Client.UserName;
            }
        }
        
        #endregion public members
    }
}
