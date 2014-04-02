namespace ift585_tp3
{
    partial class HomeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBoxChatRooms = new System.Windows.Forms.ListBox();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelConnected = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelAvatar = new System.Windows.Forms.Label();
            this.buttonProfil = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAddRoom = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.Location = new System.Drawing.Point(128, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usager : ";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 146);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBoxChatRooms);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBoxUsers);
            this.splitContainer1.Size = new System.Drawing.Size(502, 306);
            this.splitContainer1.SplitterDistance = 231;
            this.splitContainer1.TabIndex = 1;
            // 
            // listBoxChatRooms
            // 
            this.listBoxChatRooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxChatRooms.FormattingEnabled = true;
            this.listBoxChatRooms.Location = new System.Drawing.Point(0, 0);
            this.listBoxChatRooms.Name = "listBoxChatRooms";
            this.listBoxChatRooms.Size = new System.Drawing.Size(231, 306);
            this.listBoxChatRooms.TabIndex = 0;
            this.listBoxChatRooms.DoubleClick += new System.EventHandler(this.listBoxChatRooms_DoubleClick);
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.Location = new System.Drawing.Point(0, 0);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(267, 306);
            this.listBoxUsers.TabIndex = 0;
            this.listBoxUsers.DoubleClick += new System.EventHandler(this.listBoxUsers_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonAddRoom);
            this.panel1.Controls.Add(this.labelConnected);
            this.panel1.Controls.Add(this.labelUserName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.labelAvatar);
            this.panel1.Controls.Add(this.buttonProfil);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 114);
            this.panel1.TabIndex = 2;
            // 
            // labelConnected
            // 
            this.labelConnected.AutoSize = true;
            this.labelConnected.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnected.ForeColor = System.Drawing.Color.Lime;
            this.labelConnected.Location = new System.Drawing.Point(164, 48);
            this.labelConnected.Name = "labelConnected";
            this.labelConnected.Size = new System.Drawing.Size(76, 17);
            this.labelConnected.TabIndex = 5;
            this.labelConnected.Text = "CONNECTÉ";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.labelUserName.Location = new System.Drawing.Point(182, 20);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(49, 17);
            this.labelUserName.TabIndex = 4;
            this.labelUserName.Text = "Default";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label5.Location = new System.Drawing.Point(128, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "État : ";
            // 
            // labelAvatar
            // 
            this.labelAvatar.Image = global::ift585_tp3.Properties.Resources._default;
            this.labelAvatar.Location = new System.Drawing.Point(12, 9);
            this.labelAvatar.Name = "labelAvatar";
            this.labelAvatar.Size = new System.Drawing.Size(100, 97);
            this.labelAvatar.TabIndex = 2;
            // 
            // buttonProfil
            // 
            this.buttonProfil.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.buttonProfil.Location = new System.Drawing.Point(356, 12);
            this.buttonProfil.Name = "buttonProfil";
            this.buttonProfil.Size = new System.Drawing.Size(123, 38);
            this.buttonProfil.TabIndex = 1;
            this.buttonProfil.Text = "Profil";
            this.buttonProfil.UseVisualStyleBackColor = true;
            this.buttonProfil.Click += new System.EventHandler(this.buttonProfil_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label3.Location = new System.Drawing.Point(12, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Salles de discussions :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label4.Location = new System.Drawing.Point(232, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Utilisateurs :";
            // 
            // buttonAddRoom
            // 
            this.buttonAddRoom.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.buttonAddRoom.Location = new System.Drawing.Point(356, 56);
            this.buttonAddRoom.Name = "buttonAddRoom";
            this.buttonAddRoom.Size = new System.Drawing.Size(123, 38);
            this.buttonAddRoom.TabIndex = 6;
            this.buttonAddRoom.Text = "Ajout d\'une salle";
            this.buttonAddRoom.UseVisualStyleBackColor = true;
            this.buttonAddRoom.Click += new System.EventHandler(this.buttonAddRoom_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 452);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HomeForm";
            this.Text = "Windows Live Messenger";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBoxChatRooms;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelAvatar;
        private System.Windows.Forms.Button buttonProfil;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelConnected;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAddRoom;
    }
}