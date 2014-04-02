using ift585_tp3.Properties;
using ift585_tp3_library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ift585_tp3
{
    public partial class UserProfilForm : Form
    {
        public User oldClient = null;
        public UserProfilForm(User client, bool readOnly)
        {
            InitializeComponent();
            //Un backup si on enregistre pas
            oldClient = client.Clone();

            this.ReadOnly = readOnly;

            //On assigne si on peut modifier
            buttonEditAvatar.Enabled = !readOnly;
            buttonConfirm.Enabled = !readOnly;

            //On assigne les sources de données
            this.ActualClient = client;
            this.userProfilFormBindingSource.DataSource = this;

            labelAvatar.Image = (Bitmap)Resources.ResourceManager.GetObject(!String.IsNullOrEmpty(ActualClient.Avatar) ? ActualClient.Avatar : "default");
        }

        /// <summary>
        /// Lecture seule
        /// </summary>
        public bool ReadOnly
        {
            get;
            set;
        }
        /// <summary>
        /// Le client actuel
        /// </summary>
        /// <returns></returns>
        public User ActualClient
        {
            get
            {
                return this.bindingSourceUser.DataSource as User;
            }
            set
            {
                this.bindingSourceUser.DataSource = value;
            }
        }

        /// <summary>
        /// Changer d'avatar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEditAvatar_Click(object sender, EventArgs e)
        {
            AvatarForm avatarForm = new AvatarForm(ActualClient);

            if (avatarForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                labelAvatar.Image = (Bitmap)Resources.ResourceManager.GetObject(ActualClient.Avatar);
        }

        /// <summary>
        /// On enregistre les changements sur la BD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// On annule les changements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
