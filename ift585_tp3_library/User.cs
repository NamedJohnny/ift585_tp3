using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ift585_tp3_library
{
    [SerializableAttribute]
    [DataContract(Name = "user", Namespace = "")]
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
        [DataMember(Name = "id", Order = 0)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Nom
        /// </summary>

        [DataMember(Name = "firstName", Order = 1)]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        /// <summary>
        /// Prénom
        /// </summary>
        [DataMember(Name = "lastName", Order = 2)]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        /// <summary>
        /// Nom usager
        /// </summary>
        [DataMember(Name = "userName", Order = 3)]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        /// <summary>
        /// Mot de passe
        /// </summary>
        [DataMember(Name = "password", Order = 4)]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Si connecté
        /// </summary>

        [DataMember(Name = "isConnected", Order = 5)]
        public bool IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; }
        }

        /// <summary>
        /// Adresse IP
        /// </summary>
        [DataMember(Name = "ipAdress", Order = 6)]
        public string IpAdress
        {
            get { return ipAdress; }
            set { ipAdress = value; }
        }

        /// <summary>
        /// Nombre de likes
        /// </summary>
        [DataMember(Name = "likeNum", Order = 7)]
        public int LikeNum
        {
            get { return likeNum; }
            set { likeNum = value; }
        }

        /// <summary>
        /// Nombre de dislikes
        /// </summary>
        [DataMember(Name = "dislikeNum", Order = 8)]
        public int DislikeNum
        {
            get { return dislikeNum; }
            set { dislikeNum = value; }
        }

        /// <summary>
        /// Nombre de messages
        /// </summary>
        [DataMember(Name = "numMessages", Order = 9)]
        public int NumMessages
        {
            get { return numMessages; }
            set { numMessages = value; }
        }

        /// <summary>
        /// Avatar choisi
        /// </summary>
        [DataMember(Name = "avatar", Order = 10)]
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
