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
            Data loginRequest = new Data();
            loginRequest.Command = Data.DataType.Login;
            loginRequest.Text = txtUsername.Text;
            loginRequest.Other = txtPassword.Text;

            Program.callBackOnReceive.Enqueue(CallBackOnLogin);
            Program.client.Send(loginRequest);
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

        private int CallBackOnLogin(Data received)
        {
            if (received.Command == Data.DataType.Login)
            {
                if (received.Text == "200")
                {
                    this.Invoke((MethodInvoker)delegate() { this.Hide(); });
                    HomeForm homeForm = new HomeForm(received.User);
                    homeForm.ShowDialog();
                    this.Invoke((MethodInvoker)delegate() { this.Show(); });
                }
                else if (received.Text == "401")
                    MessageBox.Show("This user is already connected.");
                else if (received.Text == "404")
                    MessageBox.Show("The username or password is incorrect.");
            }
            else
            {
                //MessageBox.Show("ERROR!!!.");
            }
            return 0;
        }
    }
}
