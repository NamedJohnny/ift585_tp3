using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ift585_tp3_library
{
    [SerializableAttribute]
    [DataContract(Name = "discussionRoom", Namespace = "")]
    public class DiscussionRoom
    {
        #region private properties
        int id;
        string name;
        string description;
        List<User> clientList = new List<User>();
        List<Data> messageList = new List<Data>();
        DateTime lastModified;
        #endregion private properties

        #region public properties
        [DataMember(Name = "id", Order = 0)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Nom
        /// </summary>
        [DataMember(Name = "name", Order = 1)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Description
        /// </summary>
        [DataMember(Name = "description", Order = 2)]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Liste des clients associés
        /// </summary>
        [DataMember(Name = "clientList", Order = 3)]
        public List<User> ClientList
        {
            get { return clientList; }
            set { clientList = value; }
        }

        /// <summary>
        /// Date dernier ajout
        /// </summary>
        [DataMember(Name = "dateTime", Order = 3)]
        public DateTime LastModified
        {
            get { return lastModified; }
            set { lastModified = value; }
        }

        /// <summary>
        /// Liste des messages textuels
        /// </summary>
        [DataMember(Name = "messageListe", Order = 3)]
        public List<Data> MessageList
        {
            get { return messageList; }
            set { messageList = value; }
        }

        #endregion public properties
    }
}
