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
                MessageBox.Show("Il est nécessaire d'avoir un nom et une description.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Data addRoomRequest = new Data();
            addRoomRequest.Command = Data.DataType.AddRoom;
            addRoomRequest.Other = room;
            Program.callBackOnReceive.Enqueue(CallBackAddRoom);
            Program.client.Send(addRoomRequest);
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

        private int CallBackAddRoom(Data received)
        {
            if (received.Command == Data.DataType.AddRoom)
            {
                if (received.Text == "201")
                {
                    this.Invoke((MethodInvoker)delegate() 
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    });
                }
                else
                {
                    MessageBox.Show("Une salle existe déjà avec ce nom.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //MessageBox.Show("ERROR!!!.");
            }
            return 0;
        }
    }
}
