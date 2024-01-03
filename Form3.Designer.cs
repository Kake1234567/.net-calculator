namespace FuncMatic
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            fontsize = new NumericUpDown();
            label1 = new Label();
            savebtn = new Button();
            label2 = new Label();
            keyboardsel = new ComboBox();
            label3 = new Label();
            colorsel = new ComboBox();
            closebtn = new Button();
            label4 = new Label();
            label5 = new Label();
            themesel = new ComboBox();
            langsel = new ComboBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)fontsize).BeginInit();
            SuspendLayout();
            // 
            // fontsize
            // 
            fontsize.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            fontsize.Location = new Point(30, 74);
            fontsize.Name = "fontsize";
            fontsize.Size = new Size(330, 27);
            fontsize.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.GrayText;
            label1.Location = new Point(30, 52);
            label1.Name = "label1";
            label1.Size = new Size(82, 19);
            label1.TabIndex = 1;
            label1.Text = "Fontin koko";
            // 
            // savebtn
            // 
            savebtn.Cursor = Cursors.Hand;
            savebtn.FlatAppearance.BorderColor = SystemColors.ControlLight;
            savebtn.FlatAppearance.MouseDownBackColor = SystemColors.Window;
            savebtn.FlatAppearance.MouseOverBackColor = SystemColors.Window;
            savebtn.FlatStyle = FlatStyle.Flat;
            savebtn.Location = new Point(214, 339);
            savebtn.Name = "savebtn";
            savebtn.Size = new Size(70, 28);
            savebtn.TabIndex = 2;
            savebtn.Text = "OK";
            savebtn.UseVisualStyleBackColor = true;
            savebtn.Click += savebtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.GrayText;
            label2.Location = new Point(30, 106);
            label2.Name = "label2";
            label2.Size = new Size(86, 19);
            label2.TabIndex = 3;
            label2.Text = "Näppäimistö";
            // 
            // keyboardsel
            // 
            keyboardsel.DropDownStyle = ComboBoxStyle.DropDownList;
            keyboardsel.FlatStyle = FlatStyle.System;
            keyboardsel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            keyboardsel.FormattingEnabled = true;
            keyboardsel.Items.AddRange(new object[] { "Päällä", "Pois" });
            keyboardsel.Location = new Point(30, 128);
            keyboardsel.Name = "keyboardsel";
            keyboardsel.Size = new Size(330, 28);
            keyboardsel.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.GrayText;
            label3.Location = new Point(30, 161);
            label3.Name = "label3";
            label3.Size = new Size(82, 19);
            label3.TabIndex = 5;
            label3.Text = "Tekstin värit";
            // 
            // colorsel
            // 
            colorsel.DropDownStyle = ComboBoxStyle.DropDownList;
            colorsel.FlatStyle = FlatStyle.System;
            colorsel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            colorsel.FormattingEnabled = true;
            colorsel.Items.AddRange(new object[] { "Päällä", "Pois" });
            colorsel.Location = new Point(30, 183);
            colorsel.Name = "colorsel";
            colorsel.Size = new Size(330, 28);
            colorsel.TabIndex = 6;
            // 
            // closebtn
            // 
            closebtn.Cursor = Cursors.Hand;
            closebtn.FlatAppearance.BorderColor = SystemColors.Window;
            closebtn.FlatAppearance.MouseDownBackColor = SystemColors.Window;
            closebtn.FlatAppearance.MouseOverBackColor = SystemColors.Window;
            closebtn.FlatStyle = FlatStyle.Flat;
            closebtn.Location = new Point(290, 339);
            closebtn.Name = "closebtn";
            closebtn.Size = new Size(70, 28);
            closebtn.TabIndex = 7;
            closebtn.Text = "Sulje";
            closebtn.UseVisualStyleBackColor = true;
            closebtn.Click += closebtn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(12, 9);
            label4.Name = "label4";
            label4.Size = new Size(84, 21);
            label4.TabIndex = 8;
            label4.Text = "Asetukset";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.GrayText;
            label5.Location = new Point(30, 216);
            label5.Name = "label5";
            label5.Size = new Size(48, 19);
            label5.TabIndex = 9;
            label5.Text = "Teema";
            // 
            // themesel
            // 
            themesel.DropDownStyle = ComboBoxStyle.DropDownList;
            themesel.FlatStyle = FlatStyle.System;
            themesel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            themesel.FormattingEnabled = true;
            themesel.Items.AddRange(new object[] { "Valkoinen", "Violetti", "Vihreä", "Sininen", "Tumma", "Hiekka" });
            themesel.Location = new Point(30, 238);
            themesel.Name = "themesel";
            themesel.Size = new Size(330, 28);
            themesel.TabIndex = 10;
            // 
            // langsel
            // 
            langsel.DropDownStyle = ComboBoxStyle.DropDownList;
            langsel.FlatStyle = FlatStyle.System;
            langsel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            langsel.FormattingEnabled = true;
            langsel.Items.AddRange(new object[] { "Suomi", "Englanti", "Espanja" });
            langsel.Location = new Point(30, 293);
            langsel.Name = "langsel";
            langsel.Size = new Size(330, 28);
            langsel.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.GrayText;
            label6.Location = new Point(30, 271);
            label6.Name = "label6";
            label6.Size = new Size(33, 19);
            label6.TabIndex = 12;
            label6.Text = "Kieli";
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(390, 384);
            ControlBox = false;
            Controls.Add(label6);
            Controls.Add(langsel);
            Controls.Add(themesel);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(closebtn);
            Controls.Add(colorsel);
            Controls.Add(label3);
            Controls.Add(keyboardsel);
            Controls.Add(label2);
            Controls.Add(savebtn);
            Controls.Add(label1);
            Controls.Add(fontsize);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Settings";
            Text = "Settings";
            Load += settings_Load;
            ((System.ComponentModel.ISupportInitialize)fontsize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown fontsize;
        private Label label1;
        private Button savebtn;
        private Label label2;
        private ComboBox keyboardsel;
        private Label label3;
        private ComboBox colorsel;
        private Button closebtn;
        private Label label4;
        private Label label5;
        private ComboBox themesel;
        private ComboBox langsel;
        private Label label6;
    }
}