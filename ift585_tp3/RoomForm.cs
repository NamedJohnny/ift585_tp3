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
    public partial class RoomForm : Form
    {
        public RoomForm(DiscussionRoom room)
        {
            InitializeComponent();
            this.bindingSourceRoom.DataSource = room;
            this.clientListBindingSource.DataSource = room.ClientList;
        }


        /// <summary>
        /// Double clique sur un utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxUsers_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxUsers.SelectedItem != null)
            {
                if (listBoxUsers.SelectedItem.ToString().Length != 0)
                {
                    Client selectedClient = listBoxUsers.SelectedItem as Client;
                    UserProfilForm profilForm = new UserProfilForm(selectedClient, true);
                    profilForm.Show();
                }
            }
        }

        /// <summary>
        /// Envoyer un message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSend_Click(object sender, EventArgs e)
        {

        }
    }
}
