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
    public partial class AddRoomForm : Form
    {
        public DiscussionRoom room = new DiscussionRoom();

        public AddRoomForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// On ajoute la salle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            
            room.Name = textBoxName.Text;
            room.Description = textBoxDescription.Text;

            if (String.IsNullOrEmpty(room.Name + room.Description))
            {
                MessageBox.Show("Il est nécessaire d'avoir un nom et une description");
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            this.Close();
        }

        /// <summary>
        /// On quitte l'ajout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
