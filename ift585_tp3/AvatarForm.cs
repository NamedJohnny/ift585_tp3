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
    public partial class AvatarForm : Form
    {
        public Client actualClient = null;
        public AvatarForm(Client client)
        {
            InitializeComponent();

            actualClient = client;

            switch (client.Avatar)
            {
                case "default":
                    radioButtonDefault.Checked = true;
                    break;
                case "homer":
                    radioButtonHomer.Checked = true;
                    break;
                case "ironman":
                    radioButtonIronMan.Checked = true;
                    break;
                case "minion":
                    radioButtonMinion.Checked = true;
                    break;
                default:
                    break;
            }

        }

        private void buttonConfirmer_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
           
            if (radioButtonDefault.Checked)
                actualClient.Avatar = "default";
            else if (radioButtonHomer.Checked)
                actualClient.Avatar = "homer";
            else if (radioButtonIronMan.Checked)
                actualClient.Avatar = "ironman";
            else if (radioButtonMinion.Checked)
                actualClient.Avatar = "minion";

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
