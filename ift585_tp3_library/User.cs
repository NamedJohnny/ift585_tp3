using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ift585_tp3_library
{
    public class User : ICloneable
    {
        #region private properties
        private int id;
        private string firstName;
        private string lastName;
        private string userName;
        private string password;
        private bool isConnected;
        private string ipAdress;
        private int likeNum;
        private int dislikeNum;
        private int numMessages;
        private string avatar;
        #endregion private properties

        public User()
        {

        }

        #region public properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Nom
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        /// <summary>
        /// Prénom
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        /// <summary>
        /// Nom usager
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        /// <summary>
        /// Mot de passe
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Si connecté
        /// </summary>
        public bool IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; }
        }

        /// <summary>
        /// Adresse IP
        /// </summary>
        public string IpAdress
        {
            get { return ipAdress; }
            set { ipAdress = value; }
        }

        /// <summary>
        /// Nombre de likes
        /// </summary>
        public int LikeNum
        {
            get { return likeNum; }
            set { likeNum = value; }
        }

        /// <summary>
        /// Nombre de dislikes
        /// </summary>
        public int DislikeNum
        {
            get { return dislikeNum; }
            set { dislikeNum = value; }
        }

        /// <summary>
        /// Nombre de messages
        /// </summary>
        public int NumMessages
        {
            get { return numMessages; }
            set { numMessages = value; }
        }

        /// <summary>
        /// Avatar choisi
        /// </summary>
        public string Avatar
        {
            get { return avatar; }
            set { avatar = value; }
        }

        #endregion public properties

        #region public methods


        object ICloneable.Clone()
        {
            return this.Clone();
        }
        public User Clone()
        {
            return (User)this.MemberwiseClone();
        }
        #endregion public methods

        
    }
}
