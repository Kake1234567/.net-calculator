namespace FuncMatic
{
    partial class about
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(about));
            label1 = new Label();
            iconslink = new LinkLabel();
            label2 = new Label();
            label4 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(30, 218);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 0;
            label1.Text = "Kaikki kuvakkeet";
            // 
            // iconslink
            // 
            iconslink.AutoSize = true;
            iconslink.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            iconslink.Location = new Point(30, 238);
            iconslink.Name = "iconslink";
            iconslink.Size = new Size(88, 21);
            iconslink.TabIndex = 1;
            iconslink.TabStop = true;
            iconslink.Text = "icons8.com";
            iconslink.LinkClicked += iconslink_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(99, 317);
            label2.Name = "label2";
            label2.Size = new Size(137, 21);
            label2.TabIndex = 2;
            label2.Text = "Copyright © KAKE";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(12, 9);
            label4.Name = "label4";
            label4.Size = new Size(58, 21);
            label4.TabIndex = 9;
            label4.Text = "Tietoa";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(30, 52);
            label3.Name = "label3";
            label3.Size = new Size(317, 100);
            label3.TabIndex = 10;
            label3.Text = "-FuncMatic on lisenssoitu GPL -lisenssillä\r\n\r\n-FuncMatic on täysin ilmainen laskinohjelmisto\r\n\r\n-Sovellusta ylläpitää ja päivittää KAKE\r\n";
            // 
            // about
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.Window;
            ClientSize = new Size(390, 361);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(iconslink);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "about";
            Text = "About";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private LinkLabel iconslink;
        private Label label2;
        private Label label4;
        private Label label3;
    }
}