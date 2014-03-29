namespace ift585_tp3
{
    partial class AvatarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonConfirmer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButtonHomer = new System.Windows.Forms.RadioButton();
            this.radioButtonMinion = new System.Windows.Forms.RadioButton();
            this.radioButtonIronMan = new System.Windows.Forms.RadioButton();
            this.radioButtonDefault = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonConfirmer
            // 
            this.buttonConfirmer.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.buttonConfirmer.Location = new System.Drawing.Point(159, 353);
            this.buttonConfirmer.Name = "buttonConfirmer";
            this.buttonConfirmer.Size = new System.Drawing.Size(89, 32);
            this.buttonConfirmer.TabIndex = 0;
            this.buttonConfirmer.Text = "Confirmer";
            this.buttonConfirmer.UseVisualStyleBackColor = true;
            this.buttonConfirmer.Click += new System.EventHandler(this.buttonConfirmer_Click);
            // 
            // label2
            // 
            this.label2.Image = global::ift585_tp3.Properties.Resources.ironman;
            this.label2.Location = new System.Drawing.Point(262, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 101);
            this.label2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Image = global::ift585_tp3.Properties.Resources.minion;
            this.label3.Location = new System.Drawing.Point(63, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 102);
            this.label3.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Image = global::ift585_tp3.Properties.Resources._default;
            this.label4.Location = new System.Drawing.Point(262, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 102);
            this.label4.TabIndex = 4;
            // 
            // radioButtonHomer
            // 
            this.radioButtonHomer.AutoSize = true;
            this.radioButtonHomer.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radioButtonHomer.Location = new System.Drawing.Point(57, 141);
            this.radioButtonHomer.Name = "radioButtonHomer";
            this.radioButtonHomer.Size = new System.Drawing.Size(120, 21);
            this.radioButtonHomer.TabIndex = 5;
            this.radioButtonHomer.TabStop = true;
            this.radioButtonHomer.Text = "Homer Simpson";
            this.radioButtonHomer.UseVisualStyleBackColor = true;
            // 
            // radioButtonMinion
            // 
            this.radioButtonMinion.AutoSize = true;
            this.radioButtonMinion.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radioButtonMinion.Location = new System.Drawing.Point(57, 294);
            this.radioButtonMinion.Name = "radioButtonMinion";
            this.radioButtonMinion.Size = new System.Drawing.Size(66, 21);
            this.radioButtonMinion.TabIndex = 6;
            this.radioButtonMinion.TabStop = true;
            this.radioButtonMinion.Text = "Minion";
            this.radioButtonMinion.UseVisualStyleBackColor = true;
            // 
            // radioButtonIronMan
            // 
            this.radioButtonIronMan.AutoSize = true;
            this.radioButtonIronMan.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radioButtonIronMan.Location = new System.Drawing.Point(265, 141);
            this.radioButtonIronMan.Name = "radioButtonIronMan";
            this.radioButtonIronMan.Size = new System.Drawing.Size(79, 21);
            this.radioButtonIronMan.TabIndex = 7;
            this.radioButtonIronMan.TabStop = true;
            this.radioButtonIronMan.Text = "Iron Man";
            this.radioButtonIronMan.UseVisualStyleBackColor = true;
            // 
            // radioButtonDefault
            // 
            this.radioButtonDefault.AutoSize = true;
            this.radioButtonDefault.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDefault.Location = new System.Drawing.Point(265, 294);
            this.radioButtonDefault.Name = "radioButtonDefault";
            this.radioButtonDefault.Size = new System.Drawing.Size(64, 21);
            this.radioButtonDefault.TabIndex = 8;
            this.radioButtonDefault.TabStop = true;
            this.radioButtonDefault.Text = "Défaut";
            this.radioButtonDefault.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonConfirmer);
            this.panel1.Controls.Add(this.radioButtonDefault);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.radioButtonIronMan);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.radioButtonMinion);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.radioButtonHomer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 402);
            this.panel1.TabIndex = 9;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.buttonCancel.Location = new System.Drawing.Point(271, 353);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(89, 32);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.Image = global::ift585_tp3.Properties.Resources.homer;
            this.label1.Location = new System.Drawing.Point(54, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 100);
            this.label1.TabIndex = 1;
            // 
            // AvatarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 402);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AvatarForm";
            this.Text = "Choisir votre avatar..";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonConfirmer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButtonHomer;
        private System.Windows.Forms.RadioButton radioButtonMinion;
        private System.Windows.Forms.RadioButton radioButtonIronMan;
        private System.Windows.Forms.RadioButton radioButtonDefault;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
    }
}