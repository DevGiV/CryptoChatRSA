using System;
using System.Windows.Forms;

namespace DesktopApp
{
    partial class ConversationTabPage
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        //Controls
        private Button btn_send;
        private Panel panelSend;
        private RichTextBox tb_send_message;
        private WebBrowser wb_receive_message;
        private Panel panelReceive;

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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Обязательный метод для поддержки дизайнера.
        /// Содержимое метода нельзя изменять с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_send = new System.Windows.Forms.Button();
            this.panelSend = new System.Windows.Forms.Panel();
            this.btn_emoji = new System.Windows.Forms.Button();
            this.tb_send_message = new System.Windows.Forms.RichTextBox();
            this.wb_receive_message = new System.Windows.Forms.WebBrowser();
            this.panelReceive = new System.Windows.Forms.Panel();
            this.panelSend.SuspendLayout();
            this.panelReceive.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(281, 87);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(100, 25);
            this.btn_send.TabIndex = 0;
            this.btn_send.Text = "Отправить";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // panelSend
            // 
            this.panelSend.Controls.Add(this.btn_emoji);
            this.panelSend.Controls.Add(this.btn_send);
            this.panelSend.Controls.Add(this.tb_send_message);
            this.panelSend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSend.Location = new System.Drawing.Point(0, 421);
            this.panelSend.Name = "panelSend";
            this.panelSend.Size = new System.Drawing.Size(397, 122);
            this.panelSend.TabIndex = 1;
            this.panelSend.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSend_Paint);
            // 
            // btn_emoji
            // 
            this.btn_emoji.BackColor = System.Drawing.Color.Transparent;
            this.btn_emoji.BackgroundImage = global::DesktopApp.Properties.Resources.emoticon;
            this.btn_emoji.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_emoji.Location = new System.Drawing.Point(357, 6);
            this.btn_emoji.Name = "btn_emoji";
            this.btn_emoji.Size = new System.Drawing.Size(40, 40);
            this.btn_emoji.TabIndex = 4;
            this.btn_emoji.UseVisualStyleBackColor = false;
            this.btn_emoji.Click += new System.EventHandler(this.btn_emoji_Click);
            // 
            // tb_send_message
            // 
            this.tb_send_message.Location = new System.Drawing.Point(12, 6);
            this.tb_send_message.MaxLength = 550;
            this.tb_send_message.Name = "tb_send_message";
            this.tb_send_message.Size = new System.Drawing.Size(340, 75);
            this.tb_send_message.TabIndex = 2;
            this.tb_send_message.Text = "";
            this.tb_send_message.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_send_message_KeyUp);
            // 
            // wb_receive_message
            // 
            this.wb_receive_message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb_receive_message.Location = new System.Drawing.Point(0, 0);
            this.wb_receive_message.Name = "wb_receive_message";
            this.wb_receive_message.Size = new System.Drawing.Size(397, 421);
            this.wb_receive_message.TabIndex = 1;
            // 
            // panelReceive
            // 
            this.panelReceive.Controls.Add(this.wb_receive_message);
            this.panelReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReceive.Location = new System.Drawing.Point(0, 0);
            this.panelReceive.Name = "panelReceive";
            this.panelReceive.Size = new System.Drawing.Size(397, 421);
            this.panelReceive.TabIndex = 3;
            // 
            // ConversationTabPage
            // 
            this.Controls.Add(this.panelReceive);
            this.Controls.Add(this.panelSend);
            this.Size = new System.Drawing.Size(397, 543);
            this.panelSend.ResumeLayout(false);
            this.panelReceive.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btn_emoji;
    }
}
