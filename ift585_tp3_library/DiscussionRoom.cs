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
        List<Client> clientList = null;
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
        public List<Client> ClientList
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

        #endregion public properties
    }
}
