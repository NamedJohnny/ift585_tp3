using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ift585_tp3_library
{
    public class DiscussionRoom
    {
        #region private properties
        int id;
        string name;
        string description;
        List<User> clientList = new List<User>();
        List<Data> messageList = new List<Data>();
        DateTime lastAdded;
        #endregion private properties

        #region public properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Nom
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Liste des clients associés
        /// </summary>
        public List<User> ClientList
        {
            get { return clientList; }
            set { clientList = value; }
        }

        /// <summary>
        /// Date dernier ajout
        /// </summary>
        public DateTime LastAdded
        {
            get { return lastAdded; }
            set { lastAdded = value; }
        }

        /// <summary>
        /// Liste des messages textuels
        /// </summary>
        public List<Data> MessageList
        {
            get { return messageList; }
            set { messageList = value; }
        }

        #endregion public properties
    }
}
