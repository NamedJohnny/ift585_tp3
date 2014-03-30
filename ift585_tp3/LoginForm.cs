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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            bool connexionValid = true;
            Client client = new Client();

            //Envoi de requete pour vérification
            //Assignation de l'entité client

            //Si la connexion est bonne on affiche le menu d'accueil
            if (connexionValid)
            {
                client.IsConnected = true;
                this.Hide();
                HomeForm homeForm = new HomeForm(client);
                homeForm.ShowDialog();
                this.Close();
            }
        }

        /// <summary>
        /// On ferme le programme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
