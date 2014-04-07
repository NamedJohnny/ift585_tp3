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
    public partial class HomeForm : Form
    {
        User actualClient = new User();
        RoomForm roomForm = null;

        public HomeForm(User client)
        {
            actualClient = client;
            InitializeComponent();

            labelUserName.Text = client.UserName;

            DisplayConnect(client.IsConnected);

            labelAvatar.Image = (Bitmap)Resources.ResourceManager.GetObject(!String.IsNullOrEmpty(client.Avatar) ? client.Avatar : "default");
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            //On va chercher la liste des Client
            List<User> clientList = new List<User>();
            listBoxUsers.DataSource = clientList;

            Data listUserRequest = new Data();
            listUserRequest.Command = Data.DataType.ListClient;
            Program.callBackOnReceive.Enqueue(CallBackListClient);
            Program.client.Send(listUserRequest);

            // On va chercher la liste des salles
            List<DiscussionRoom> roomList = new List<DiscussionRoom>();
            listBoxChatRooms.DataSource = roomList;
            listBoxChatRooms.DisplayMember = "Name";

            Data listRoomRequest = new Data();
            listRoomRequest.Command = Data.DataType.ListDiscussionRoom;
            Program.callBackOnReceive.Enqueue(CallBackListDiscussionRoom);
            Program.client.Send(listRoomRequest);
        }

        /// <summary>
        /// Afiche l'état de connexion
        /// </summary>
        /// <param name="connected"></param>
        public void DisplayConnect(bool connected)
        {
            if (connected)
            {
                labelConnected.Text = "CONNECTÉ";
                labelConnected.ForeColor = Color.Lime;
            }
            else
            {
                labelConnected.Text = "DÉCONNECTÉ";
                labelConnected.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// Modification/affichage du profil et des stats
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonProfil_Click(object sender, EventArgs e)
        {
            Data viewProfileRequest = new Data();
            viewProfileRequest.Command = Data.DataType.ViewProfile;
            viewProfileRequest.Text = actualClient.UserName;
            Program.callBackOnReceive.Enqueue(CallBackViewProfile);
            Program.client.Send(viewProfileRequest);
        }

        /// <summary>
        /// Double clique sur une salle de discussion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxChatRooms_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxChatRooms.SelectedItem != null && (roomForm == null || !roomForm.Visible))
            {
                if (listBoxChatRooms.SelectedItem.ToString().Length != 0)
                {
                    DiscussionRoom selectedRoom = listBoxChatRooms.SelectedItem as DiscussionRoom;
                    Data getRoomRequest = new Data();
                    getRoomRequest.Command = Data.DataType.EnterRoom;
                    getRoomRequest.User = actualClient;
                    getRoomRequest.Text = selectedRoom.Name;
                    Program.callBackOnReceive.Enqueue(CallBackEnterRoom);
                    Program.client.Send(getRoomRequest);
                }
            }
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
                    User selectedClient = listBoxUsers.SelectedItem as User;
                    Data viewProfileRequest = new Data();
                    viewProfileRequest.Command = Data.DataType.ViewProfile;
                    viewProfileRequest.Text = selectedClient.UserName;
                    Program.callBackOnReceive.Enqueue(CallBackViewProfile);
                    Program.client.Send(viewProfileRequest);
                }
            }
        }

        /// <summary>
        /// Ajouter une salle de discussion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddRoom_Click(object sender, EventArgs e)
        {
            AddRoomForm addRoomForm = new AddRoomForm();
            if (addRoomForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                List<DiscussionRoom> listRoom = (List<DiscussionRoom>)listBoxChatRooms.DataSource;
                listRoom.Add(addRoomForm.room);
                listBoxChatRooms.DataSource = new List<DiscussionRoom>(listRoom);
                listBoxChatRooms.DisplayMember = "Name";
            }
        }

        /// <summary>
        /// Se déconnecter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            Data disconnectRequest = new Data();
            disconnectRequest.Command = Data.DataType.Logout;
            disconnectRequest.Text = actualClient.UserName;
            Program.callBackOnReceive.Enqueue(CallBackDisconnect);
            Program.client.Send(disconnectRequest);
        }

        private int CallBackDisconnect(Data received)
        {
            if (received.Command == Data.DataType.Logout)
            {
                this.Invoke((MethodInvoker)delegate()
                {
                    if (roomForm != null)
                        roomForm.Close();
                    this.Close();
                });
            }
            else
            {
                MessageBox.Show("Disconnect callback error!");
            }
            return 0;
        }


        private int CallBackListClient(Data received)
        {
            if (received.Command == Data.DataType.ListClient)
            {
                this.Invoke((MethodInvoker)delegate() 
                { 
                    listBoxUsers.DataSource = new List<User>((List<User>)received.Other); 
                });
            }
            else
            {
                MessageBox.Show("ERROR!!!.");
            }
            return 0;
        }

        private int CallBackListDiscussionRoom(Data received)
        {
            if (received.Command == Data.DataType.ListDiscussionRoom)
            {
                this.Invoke((MethodInvoker)delegate() 
                { 
                    listBoxChatRooms.DataSource = new List<DiscussionRoom>((List<DiscussionRoom>)received.Other); 
                });
            }
            else
            {
                MessageBox.Show("ERROR!!!.");
            }
            return 0;
        }

        private int CallBackEnterRoom(Data received)
        {
            if (received.Command == Data.DataType.EnterRoom)
            {
                DiscussionRoom room = (DiscussionRoom)received.Other;
                if (room == null)
                {
                    MessageBox.Show("Cet salle n'existe plus sous ce nom.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    roomForm = new RoomForm(room, actualClient);
                    this.Invoke((MethodInvoker)delegate() { roomForm.Show(); });
                }

                Data listRoomRequest = new Data();
                listRoomRequest.Command = Data.DataType.ListDiscussionRoom;
                Program.callBackOnReceive.Enqueue(CallBackListDiscussionRoom);
                Program.client.Send(listRoomRequest);
            }
            else
            {
                MessageBox.Show("ERROR!!!.");
            }
            return 0;
        }

        private int CallBackViewProfile(Data received)
        {
            if (received.Command == Data.DataType.ViewProfile)
            {
                User user = (User)received.Other;
                if (user == null)
                {
                    MessageBox.Show("Cet utilisateur n'existe plus sous ce nom.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool readOnly = user.UserName != actualClient.UserName;
                    UserProfilForm profilForm = new UserProfilForm(user, readOnly);
                    DialogResult result = DialogResult.None;
                    this.Invoke((MethodInvoker)delegate() { result = profilForm.ShowDialog(); });

                    if (!readOnly)
                    {
                        if (result == DialogResult.OK)
                        {
                            actualClient = user;
                        }
                        else
                        {
                            actualClient = profilForm.oldClient;
                        }

                        this.Invoke((MethodInvoker)delegate()
                        {
                            labelUserName.Text = actualClient.UserName;
                            labelAvatar.Image = (Bitmap)Resources.ResourceManager.GetObject(actualClient.Avatar);
                        });
                    }
                }

                Data listUserRequest = new Data();
                listUserRequest.Command = Data.DataType.ListClient;
                Program.callBackOnReceive.Enqueue(CallBackListClient);
                Program.client.Send(listUserRequest);
            }
            else
            {
                MessageBox.Show("ERROR!!!.");
            }
            return 0;
        }
    }
}
