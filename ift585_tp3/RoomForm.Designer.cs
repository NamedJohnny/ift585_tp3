namespace ift585_tp3
{
    partial class RoomForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.clientListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewMessage = new System.Windows.Forms.DataGridView();
            this.messageListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.discussionRoomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LikeNum = new System.Windows.Forms.DataGridViewImageColumn();
            this.DislikeNum = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discussionRoomBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBoxUsers);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(675, 396);
            this.splitContainer1.SplitterDistance = 109;
            this.splitContainer1.TabIndex = 0;
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.DataSource = this.clientListBindingSource;
            this.listBoxUsers.DisplayMember = "UserName";
            this.listBoxUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.Location = new System.Drawing.Point(0, 0);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(109, 396);
            this.listBoxUsers.TabIndex = 0;
            this.listBoxUsers.DoubleClick += new System.EventHandler(this.listBoxUsers_DoubleClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridViewMessage);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(562, 396);
            this.splitContainer2.SplitterDistance = 296;
            this.splitContainer2.TabIndex = 1;
            // 
            // dataGridViewMessage
            // 
            this.dataGridViewMessage.AllowUserToAddRows = false;
            this.dataGridViewMessage.AllowUserToDeleteRows = false;
            this.dataGridViewMessage.AllowUserToResizeColumns = false;
            this.dataGridViewMessage.AllowUserToResizeRows = false;
            this.dataGridViewMessage.AutoGenerateColumns = false;
            this.dataGridViewMessage.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewMessage.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewMessage.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewMessage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMessage.ColumnHeadersVisible = false;
            this.dataGridViewMessage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Client,
            this.ColumnMessage,
            this.LikeNum,
            this.DislikeNum});
            this.dataGridViewMessage.DataSource = this.messageListBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMessage.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMessage.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMessage.Name = "dataGridViewMessage";
            this.dataGridViewMessage.RowHeadersVisible = false;
            this.dataGridViewMessage.Size = new System.Drawing.Size(562, 296);
            this.dataGridViewMessage.TabIndex = 0;
            this.dataGridViewMessage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMessage_CellContentClick);
            this.dataGridViewMessage.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMessage_CellMouseEnter);
            // 
            // messageListBindingSource
            // 
            this.messageListBindingSource.DataMember = "MessageList";
            this.messageListBindingSource.DataSource = this.discussionRoomBindingSource;
            // 
            // discussionRoomBindingSource
            // 
            this.discussionRoomBindingSource.DataSource = typeof(ift585_tp3_library.DiscussionRoom);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.textBoxMessage);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.buttonSend);
            this.splitContainer3.Size = new System.Drawing.Size(562, 96);
            this.splitContainer3.SplitterDistance = 405;
            this.splitContainer3.TabIndex = 2;
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMessage.Location = new System.Drawing.Point(0, 0);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(405, 96);
            this.textBoxMessage.TabIndex = 0;
            // 
            // buttonSend
            // 
            this.buttonSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSend.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSend.Location = new System.Drawing.Point(0, 0);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(153, 96);
            this.buttonSend.TabIndex = 1;
            this.buttonSend.Text = "Envoyer";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            dataGridViewCellStyle1.NullValue = "0000-00-00";
            this.Date.DefaultCellStyle = dataGridViewCellStyle1;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Client
            // 
            this.Client.DataPropertyName = "ClientUserName";
            this.Client.HeaderText = "Client";
            this.Client.Name = "Client";
            this.Client.ReadOnly = true;
            // 
            // ColumnMessage
            // 
            this.ColumnMessage.DataPropertyName = "Text";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnMessage.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnMessage.HeaderText = "Message";
            this.ColumnMessage.Name = "ColumnMessage";
            this.ColumnMessage.ReadOnly = true;
            this.ColumnMessage.Width = 700;
            // 
            // LikeNum
            // 
            this.LikeNum.HeaderText = "LikeNum";
            this.LikeNum.Image = global::ift585_tp3.Properties.Resources.thumbs_up_24;
            this.LikeNum.Name = "LikeNum";
            this.LikeNum.Width = 24;
            // 
            // DislikeNum
            // 
            this.DislikeNum.HeaderText = "DislikeNum";
            this.DislikeNum.Image = global::ift585_tp3.Properties.Resources.thumbs_down_24;
            this.DislikeNum.Name = "DislikeNum";
            this.DislikeNum.Width = 24;
            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 396);
            this.Controls.Add(this.splitContainer1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.discussionRoomBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "Salle de discussion", "Salle de discussion - 0"));
            this.Name = "RoomForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clientListBindingSource)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discussionRoomBindingSource)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.DataGridView dataGridViewMessage;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.BindingSource clientListBindingSource;
        private System.Windows.Forms.BindingSource discussionRoomBindingSource;
        private System.Windows.Forms.BindingSource messageListBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMessage;
        private System.Windows.Forms.DataGridViewImageColumn LikeNum;
        private System.Windows.Forms.DataGridViewImageColumn DislikeNum;
    }
}