using System.Windows.Forms;

namespace DesktopApp
{
    partial class frm_main : Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Очистка используемых ресурсов.
        /// </summary>
        /// <param name="disposing">True, если управляемые ресурсы должны быть удалены; в противном случае Ложь.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Обязательный метод для поддержки дизайнера.
        /// Содержимое метода нельзя изменять с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_main));
            this.btn_connect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_uid = new System.Windows.Forms.TextBox();
            this.lb_clients = new System.Windows.Forms.ListBox();
            this.tb_log = new System.Windows.Forms.RichTextBox();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tc_conversations = new System.Windows.Forms.TabControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_connect
            // 
            this.btn_connect.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_connect.Location = new System.Drawing.Point(273, 13);
            this.btn_connect.Margin = new System.Windows.Forms.Padding(4);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(129, 38);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Text = "Подключиться";
            this.btn_connect.UseVisualStyleBackColor = false;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Имя:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.label2.Location = new System.Drawing.Point(828, 319);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Пользователи в сети:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tb_uid
            // 
            this.tb_uid.Location = new System.Drawing.Point(67, 7);
            this.tb_uid.Margin = new System.Windows.Forms.Padding(4);
            this.tb_uid.Name = "tb_uid";
            this.tb_uid.Size = new System.Drawing.Size(180, 22);
            this.tb_uid.TabIndex = 4;
            // 
            // lb_clients
            // 
            this.lb_clients.FormattingEnabled = true;
            this.lb_clients.ItemHeight = 16;
            this.lb_clients.Location = new System.Drawing.Point(834, 358);
            this.lb_clients.Margin = new System.Windows.Forms.Padding(4);
            this.lb_clients.Name = "lb_clients";
            this.lb_clients.Size = new System.Drawing.Size(443, 212);
            this.lb_clients.TabIndex = 5;
            this.lb_clients.DoubleClick += new System.EventHandler(this.lb_clients_DoubleClick);
            // 
            // tb_log
            // 
            this.tb_log.Location = new System.Drawing.Point(564, 71);
            this.tb_log.Margin = new System.Windows.Forms.Padding(4);
            this.tb_log.Name = "tb_log";
            this.tb_log.ReadOnly = true;
            this.tb_log.Size = new System.Drawing.Size(259, 499);
            this.tb_log.TabIndex = 7;
            this.tb_log.Text = "";
            // 
            // tb_ip
            // 
            this.tb_ip.Location = new System.Drawing.Point(67, 39);
            this.tb_ip.Margin = new System.Windows.Forms.Padding(4);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(180, 22);
            this.tb_ip.TabIndex = 9;
            this.tb_ip.Text = "153.17.132.191";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(13, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "IP:";
            // 
            // tc_conversations
            // 
            this.tc_conversations.Location = new System.Drawing.Point(16, 71);
            this.tc_conversations.Margin = new System.Windows.Forms.Padding(4);
            this.tc_conversations.Name = "tc_conversations";
            this.tc_conversations.SelectedIndex = 0;
            this.tc_conversations.Size = new System.Drawing.Size(540, 499);
            this.tc_conversations.TabIndex = 11;
            this.tc_conversations.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tc_conversations_DrawItem);
            this.tc_conversations.SelectedIndexChanged += new System.EventHandler(this.tc_conversations_SelectedIndexChanged);
            this.tc_conversations.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tc_conversations_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(834, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(444, 277);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1290, 578);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tc_conversations);
            this.Controls.Add(this.tb_ip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_log);
            this.Controls.Add(this.lb_clients);
            this.Controls.Add(this.tb_uid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_connect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_main";
            this.Text = "RSACryptoCDA | DesktopApp";
            this.Activated += new System.EventHandler(this.frm_main_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_main_FormClosing);
            this.Load += new System.EventHandler(this.frm_main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_uid;
        private System.Windows.Forms.ListBox lb_clients;
        private System.Windows.Forms.RichTextBox tb_log;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tc_conversations;
        private PictureBox pictureBox1;
    }
}

