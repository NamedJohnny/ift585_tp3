namespace ift585_tp3
{
    partial class UserProfilForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.bindingSourceUser = new System.Windows.Forms.BindingSource(this.components);
            this.userProfilFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelAvatar = new System.Windows.Forms.Label();
            this.buttonEditAvatar = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelDislike = new System.Windows.Forms.Label();
            this.labelLike = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelConnected = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userProfilFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.Location = new System.Drawing.Point(50, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Prénom : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label3.Location = new System.Drawing.Point(50, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Avatar : ";
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceUser, "LastName", true));
            this.textBoxLastName.DataBindings.Add(new System.Windows.Forms.Binding("ReadOnly", this.userProfilFormBindingSource, "ReadOnly", true));
            this.textBoxLastName.Location = new System.Drawing.Point(147, 118);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(148, 20);
            this.textBoxLastName.TabIndex = 3;
            // 
            // bindingSourceUser
            // 
            this.bindingSourceUser.DataSource = typeof(ift585_tp3_library.User);
            // 
            // userProfilFormBindingSource
            // 
            this.userProfilFormBindingSource.DataSource = typeof(ift585_tp3.UserProfilForm);
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceUser, "FirstName", true));
            this.textBoxFirstName.DataBindings.Add(new System.Windows.Forms.Binding("ReadOnly", this.userProfilFormBindingSource, "ReadOnly", true));
            this.textBoxFirstName.Location = new System.Drawing.Point(147, 83);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(148, 20);
            this.textBoxFirstName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 37);
            this.label4.TabIndex = 6;
            this.label4.Text = "Profil";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label7.Location = new System.Drawing.Point(50, 398);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Statistiques : ";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceUser, "UserName", true));
            this.textBoxUserName.DataBindings.Add(new System.Windows.Forms.Binding("ReadOnly", this.userProfilFormBindingSource, "ReadOnly", true));
            this.textBoxUserName.Location = new System.Drawing.Point(147, 152);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(148, 20);
            this.textBoxUserName.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label6.Location = new System.Drawing.Point(50, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Pseudo : ";
            // 
            // label9
            // 
            this.label9.Image = global::ift585_tp3.Properties.Resources.thumbs_down_24;
            this.label9.Location = new System.Drawing.Point(257, 398);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 26);
            this.label9.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.Image = global::ift585_tp3.Properties.Resources.thumbs_up_24;
            this.label8.Location = new System.Drawing.Point(176, 398);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 26);
            this.label8.TabIndex = 14;
            // 
            // labelAvatar
            // 
            this.labelAvatar.Image = global::ift585_tp3.Properties.Resources._default;
            this.labelAvatar.Location = new System.Drawing.Point(144, 238);
            this.labelAvatar.Name = "labelAvatar";
            this.labelAvatar.Size = new System.Drawing.Size(100, 101);
            this.labelAvatar.TabIndex = 7;
            // 
            // buttonEditAvatar
            // 
            this.buttonEditAvatar.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.buttonEditAvatar.Location = new System.Drawing.Point(147, 342);
            this.buttonEditAvatar.Name = "buttonEditAvatar";
            this.buttonEditAvatar.Size = new System.Drawing.Size(97, 33);
            this.buttonEditAvatar.TabIndex = 16;
            this.buttonEditAvatar.Text = "Modifier...";
            this.buttonEditAvatar.UseVisualStyleBackColor = true;
            this.buttonEditAvatar.Click += new System.EventHandler(this.buttonEditAvatar_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.buttonConfirm.Location = new System.Drawing.Point(157, 457);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(97, 33);
            this.buttonConfirm.TabIndex = 17;
            this.buttonConfirm.Text = "Confirmer";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.buttonCancel.Location = new System.Drawing.Point(260, 457);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(97, 33);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "Quitter";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelDislike
            // 
            this.labelDislike.AutoSize = true;
            this.labelDislike.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceUser, "DislikeNum", true));
            this.labelDislike.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.labelDislike.Location = new System.Drawing.Point(213, 398);
            this.labelDislike.Name = "labelDislike";
            this.labelDislike.Size = new System.Drawing.Size(15, 17);
            this.labelDislike.TabIndex = 20;
            this.labelDislike.Text = "0";
            // 
            // labelLike
            // 
            this.labelLike.AutoSize = true;
            this.labelLike.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceUser, "LikeNum", true));
            this.labelLike.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.labelLike.Location = new System.Drawing.Point(138, 398);
            this.labelLike.Name = "labelLike";
            this.labelLike.Size = new System.Drawing.Size(15, 17);
            this.labelLike.TabIndex = 21;
            this.labelLike.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label5.Location = new System.Drawing.Point(50, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "État : ";
            // 
            // labelConnected
            // 
            this.labelConnected.AutoSize = true;
            this.labelConnected.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelConnected.Location = new System.Drawing.Point(144, 196);
            this.labelConnected.Name = "labelConnected";
            this.labelConnected.Size = new System.Drawing.Size(76, 17);
            this.labelConnected.TabIndex = 23;
            this.labelConnected.Text = "CONNECTÉ";
            // 
            // UserProfilForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 502);
            this.Controls.Add(this.labelConnected);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelLike);
            this.Controls.Add(this.labelDislike);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.buttonEditAvatar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelAvatar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UserProfilForm";
            this.Text = "Profil";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userProfilFormBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelAvatar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonEditAvatar;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelDislike;
        private System.Windows.Forms.Label labelLike;
        public System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.BindingSource bindingSourceUser;
        private System.Windows.Forms.BindingSource userProfilFormBindingSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelConnected;
    }
}