namespace FuncMatic
{
    partial class unit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(unit));
            okbtn = new Button();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            closebtn = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            quantsel = new ComboBox();
            SuspendLayout();
            // 
            // okbtn
            // 
            okbtn.Cursor = Cursors.Hand;
            okbtn.FlatAppearance.BorderColor = SystemColors.ControlLight;
            okbtn.FlatAppearance.MouseDownBackColor = SystemColors.Window;
            okbtn.FlatAppearance.MouseOverBackColor = SystemColors.Window;
            okbtn.FlatStyle = FlatStyle.Flat;
            okbtn.Location = new Point(214, 230);
            okbtn.Name = "okbtn";
            okbtn.Size = new Size(70, 28);
            okbtn.TabIndex = 0;
            okbtn.Text = "OK";
            okbtn.UseVisualStyleBackColor = false;
            okbtn.Click += okbtn_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownHeight = 150;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DropDownWidth = 200;
            comboBox1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.IntegralHeight = false;
            comboBox1.Location = new Point(30, 129);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(330, 28);
            comboBox1.TabIndex = 1;
            // 
            // comboBox2
            // 
            comboBox2.DropDownHeight = 150;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownWidth = 200;
            comboBox2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox2.FormattingEnabled = true;
            comboBox2.IntegralHeight = false;
            comboBox2.Location = new Point(30, 184);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(330, 28);
            comboBox2.TabIndex = 2;
            // 
            // closebtn
            // 
            closebtn.Cursor = Cursors.Hand;
            closebtn.FlatAppearance.BorderSize = 0;
            closebtn.FlatAppearance.MouseDownBackColor = SystemColors.Window;
            closebtn.FlatAppearance.MouseOverBackColor = SystemColors.Window;
            closebtn.FlatStyle = FlatStyle.Flat;
            closebtn.Location = new Point(290, 230);
            closebtn.Name = "closebtn";
            closebtn.Size = new Size(70, 28);
            closebtn.TabIndex = 3;
            closebtn.Text = "Peru";
            closebtn.UseVisualStyleBackColor = true;
            closebtn.Click += closebtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(141, 21);
            label1.TabIndex = 4;
            label1.Text = "Yksikkömuunnos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.GrayText;
            label2.Location = new Point(29, 107);
            label2.Name = "label2";
            label2.Size = new Size(46, 19);
            label2.TabIndex = 5;
            label2.Text = "Mistä:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.GrayText;
            label3.Location = new Point(28, 162);
            label3.Name = "label3";
            label3.Size = new Size(47, 19);
            label3.TabIndex = 6;
            label3.Text = "Mihin:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.GrayText;
            label4.Location = new Point(30, 52);
            label4.Name = "label4";
            label4.Size = new Size(47, 19);
            label4.TabIndex = 7;
            label4.Text = "Suure:";
            // 
            // quantsel
            // 
            quantsel.DropDownStyle = ComboBoxStyle.DropDownList;
            quantsel.DropDownWidth = 200;
            quantsel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            quantsel.FormattingEnabled = true;
            quantsel.Items.AddRange(new object[] { "Mittayksikkö", "Neliö", "Kuutio", "Aika" });
            quantsel.Location = new Point(30, 74);
            quantsel.Name = "quantsel";
            quantsel.Size = new Size(330, 28);
            quantsel.TabIndex = 8;
            // 
            // unit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(390, 271);
            ControlBox = false;
            Controls.Add(quantsel);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(closebtn);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(okbtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "unit";
            Text = "Unit selection";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button okbtn;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button closebtn;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox quantsel;
    }
}