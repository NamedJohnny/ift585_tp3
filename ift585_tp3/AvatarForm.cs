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
        public string chosenAvatar;
        public AvatarForm(string avatar)
        {
            InitializeComponent();

            if (avatar == "default")
                radioButtonDefault.Checked = true;
            else if (avatar == "homer")
                radioButtonHomer.Checked = true;
            else if (avatar == "ironman")
                radioButtonIronMan.Checked = true;
            else if (avatar == "minion")
                radioButtonMinion.Checked = true;
        }

        private void buttonConfirmer_Click(object sender, EventArgs e)
        {
            if (radioButtonDefault.Checked)
                chosenAvatar = "default";
            else if (radioButtonHomer.Checked)
                chosenAvatar = "homer";
            else if (radioButtonIronMan.Checked)
                chosenAvatar = "ironman";
            else if (radioButtonMinion.Checked)
                chosenAvatar = "minion";

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
