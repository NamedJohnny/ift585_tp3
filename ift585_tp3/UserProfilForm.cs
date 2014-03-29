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
        Client actualClient = new Client();

        public UserProfilForm(Client client)
        {
            actualClient = client;
            InitializeComponent();

            textBoxFirstName.Text = client.FirstName;
            textBoxLastName.Text = client.LastName;
            textBoxUserName.Text = client.UserName;
            labelDislike.Text = client.DislikeNum.ToString();
            labelLike.Text = client.LikeNum.ToString();
            labelAvatar.Image = (Bitmap)Resources.ResourceManager.GetObject(!String.IsNullOrEmpty(client.Avatar) ? client.Avatar : "default");

        }

        /// <summary>
        /// Changer d'avatar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEditAvatar_Click(object sender, EventArgs e)
        {
            AvatarForm avatarForm = new AvatarForm(actualClient.Avatar);
            avatarForm.FormClosing += avatarForm_FormClosing;
            avatarForm.ShowDialog();
        }

        void avatarForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!String.IsNullOrEmpty((sender as AvatarForm).chosenAvatar))
            {
                labelAvatar.Image = (Bitmap)Resources.ResourceManager.GetObject((sender as AvatarForm).chosenAvatar);
                actualClient.Avatar = (sender as AvatarForm).chosenAvatar;
            }
        }

        /// <summary>
        /// On enregistre les changements sur la BD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            //On envoit les changements
            actualClient.FirstName = textBoxFirstName.Text;
            actualClient.LastName = textBoxLastName.Text;
            actualClient.UserName = textBoxUserName.Text;

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
