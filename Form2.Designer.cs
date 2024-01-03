namespace FuncMatic
{
    partial class Main
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
            ColumnHeader Funktio;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            ListViewItem listViewItem1 = new ListViewItem("sqrt()");
            ListViewItem listViewItem2 = new ListViewItem("cbrt()");
            ListViewItem listViewItem3 = new ListViewItem("π");
            ListViewItem listViewItem4 = new ListViewItem("In()");
            ListViewItem listViewItem5 = new ListViewItem("exp()");
            ListViewItem listViewItem6 = new ListViewItem("sin()");
            ListViewItem listViewItem7 = new ListViewItem("cos()");
            ListViewItem listViewItem8 = new ListViewItem("tan()");
            ListViewItem listViewItem9 = new ListViewItem("arcsin()");
            ListViewItem listViewItem10 = new ListViewItem("arccos()");
            ListViewItem listViewItem11 = new ListViewItem("arctan()");
            ListViewItem listViewItem12 = new ListViewItem("sinh()");
            ListViewItem listViewItem13 = new ListViewItem("cosh()");
            ListViewItem listViewItem14 = new ListViewItem("tanh()");
            ListViewItem listViewItem15 = new ListViewItem("arcsinh()");
            ListViewItem listViewItem16 = new ListViewItem("arccosh()");
            ListViewItem listViewItem17 = new ListViewItem("arctanh()");
            ListViewItem listViewItem18 = new ListViewItem("unit()");
            panel1 = new Panel();
            unitopen = new Panel();
            openuniticon = new PictureBox();
            openunittext = new Label();
            simpleopen = new Panel();
            simpleopenicon = new PictureBox();
            simpleopentext = new Label();
            funcsidepanel = new Panel();
            panel6 = new Panel();
            listView1 = new ListView();
            panel2 = new Panel();
            panel10 = new Panel();
            closeside = new PictureBox();
            label2 = new Label();
            panel3 = new Panel();
            panel5 = new Panel();
            panel7 = new Panel();
            arccosbtn = new Button();
            arctanbtn = new Button();
            arcsinbtn = new Button();
            inbtn = new Button();
            tanbtn = new Button();
            cosbtn = new Button();
            sinbtn = new Button();
            expbtn = new Button();
            xisbtn = new Button();
            variabbtn = new Button();
            ansbtn = new Button();
            pibutton = new Button();
            facbtn = new Button();
            brackrightbtn = new Button();
            powbtn = new Button();
            button24 = new Button();
            percentbtn = new Button();
            brackleftbtn = new Button();
            erasebtn = new Button();
            clearbtn = new Button();
            plusbtn = new Button();
            minusbtn = new Button();
            multiplebtn = new Button();
            button13 = new Button();
            dividebtn = new Button();
            button12 = new Button();
            button0 = new Button();
            button9 = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel4 = new Panel();
            funcboard = new RichTextBox();
            panel8 = new Panel();
            panel9 = new Panel();
            lineboard = new TextBox();
            menuStrip1 = new MenuStrip();
            tiedostoToolStripMenuItem = new ToolStripMenuItem();
            openfile = new ToolStripMenuItem();
            savefile = new ToolStripMenuItem();
            savefileasname = new ToolStripMenuItem();
            editmenu = new ToolStripMenuItem();
            emptyfuncboard = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            opensettings = new ToolStripMenuItem();
            keyboardToolStripMenuItem = new ToolStripMenuItem();
            addunit = new ToolStripMenuItem();
            sidebarcontrol = new ToolStripMenuItem();
            unititem = new ToolStripMenuItem();
            setradians = new ToolStripMenuItem();
            setdegrees = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            infoToolStripMenuItem = new ToolStripMenuItem();
            aboutopen = new ToolStripMenuItem();
            Funktio = new ColumnHeader();
            panel1.SuspendLayout();
            unitopen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)openuniticon).BeginInit();
            simpleopen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)simpleopenicon).BeginInit();
            funcsidepanel.SuspendLayout();
            panel6.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)closeside).BeginInit();
            panel5.SuspendLayout();
            panel7.SuspendLayout();
            panel4.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // Funktio
            // 
            Funktio.Text = "Funktiot";
            Funktio.Width = 100;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = Color.FromArgb(242, 242, 242);
            panel1.Controls.Add(unitopen);
            panel1.Controls.Add(simpleopen);
            panel1.Controls.Add(funcsidepanel);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel10);
            panel1.Location = new Point(0, 40);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(254, 521);
            panel1.TabIndex = 2;
            // 
            // unitopen
            // 
            unitopen.Controls.Add(openuniticon);
            unitopen.Controls.Add(openunittext);
            unitopen.Cursor = Cursors.Hand;
            unitopen.Location = new Point(8, 60);
            unitopen.Name = "unitopen";
            unitopen.Size = new Size(237, 23);
            unitopen.TabIndex = 5;
            unitopen.Paint += unitopen_Paint;
            // 
            // openuniticon
            // 
            openuniticon.BackColor = Color.Transparent;
            openuniticon.Image = (Image)resources.GetObject("openuniticon.Image");
            openuniticon.Location = new Point(197, 3);
            openuniticon.Name = "openuniticon";
            openuniticon.Size = new Size(15, 15);
            openuniticon.SizeMode = PictureBoxSizeMode.StretchImage;
            openuniticon.TabIndex = 1;
            openuniticon.TabStop = false;
            // 
            // openunittext
            // 
            openunittext.AutoSize = true;
            openunittext.BackColor = Color.Transparent;
            openunittext.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            openunittext.Location = new Point(4, 2);
            openunittext.Name = "openunittext";
            openunittext.Size = new Size(142, 19);
            openunittext.TabIndex = 0;
            openunittext.Text = "Yksikkömuunnokset";
            // 
            // simpleopen
            // 
            simpleopen.Controls.Add(simpleopenicon);
            simpleopen.Controls.Add(simpleopentext);
            simpleopen.Cursor = Cursors.Hand;
            simpleopen.Location = new Point(8, 30);
            simpleopen.Name = "simpleopen";
            simpleopen.Size = new Size(237, 23);
            simpleopen.TabIndex = 4;
            simpleopen.Paint += simpleopen_Paint;
            // 
            // simpleopenicon
            // 
            simpleopenicon.BackColor = Color.Transparent;
            simpleopenicon.Image = (Image)resources.GetObject("simpleopenicon.Image");
            simpleopenicon.Location = new Point(197, 3);
            simpleopenicon.Name = "simpleopenicon";
            simpleopenicon.Size = new Size(15, 15);
            simpleopenicon.SizeMode = PictureBoxSizeMode.StretchImage;
            simpleopenicon.TabIndex = 1;
            simpleopenicon.TabStop = false;
            // 
            // simpleopentext
            // 
            simpleopentext.AutoSize = true;
            simpleopentext.BackColor = Color.Transparent;
            simpleopentext.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            simpleopentext.Location = new Point(4, 2);
            simpleopentext.Name = "simpleopentext";
            simpleopentext.Size = new Size(55, 19);
            simpleopentext.TabIndex = 0;
            simpleopentext.Text = "Kaavat";
            // 
            // funcsidepanel
            // 
            funcsidepanel.BackColor = Color.FromArgb(112, 110, 135);
            funcsidepanel.Controls.Add(panel6);
            funcsidepanel.Location = new Point(8, 53);
            funcsidepanel.Name = "funcsidepanel";
            funcsidepanel.Size = new Size(237, 350);
            funcsidepanel.TabIndex = 3;
            funcsidepanel.Visible = false;
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.Control;
            panel6.Controls.Add(listView1);
            panel6.Location = new Point(1, 1);
            panel6.Name = "panel6";
            panel6.Size = new Size(235, 348);
            panel6.TabIndex = 1;
            // 
            // listView1
            // 
            listView1.AutoArrange = false;
            listView1.BackColor = SystemColors.Control;
            listView1.BorderStyle = BorderStyle.None;
            listView1.Columns.AddRange(new ColumnHeader[] { Funktio });
            listView1.FullRowSelect = true;
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView1.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4, listViewItem5, listViewItem6, listViewItem7, listViewItem8, listViewItem9, listViewItem10, listViewItem11, listViewItem12, listViewItem13, listViewItem14, listViewItem15, listViewItem16, listViewItem17, listViewItem18 });
            listView1.Location = new Point(2, 2);
            listView1.Name = "listView1";
            listView1.Size = new Size(231, 344);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.BackColor = Color.FromArgb(112, 110, 135);
            panel2.Location = new Point(253, 0);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1, 521);
            panel2.TabIndex = 0;
            // 
            // panel10
            // 
            panel10.Controls.Add(closeside);
            panel10.Controls.Add(label2);
            panel10.Location = new Point(0, 0);
            panel10.Margin = new Padding(0);
            panel10.Name = "panel10";
            panel10.Size = new Size(254, 23);
            panel10.TabIndex = 1;
            // 
            // closeside
            // 
            closeside.BackColor = Color.Transparent;
            closeside.Cursor = Cursors.Hand;
            closeside.Image = (Image)resources.GetObject("closeside.Image");
            closeside.Location = new Point(221, 2);
            closeside.Name = "closeside";
            closeside.Size = new Size(19, 19);
            closeside.SizeMode = PictureBoxSizeMode.StretchImage;
            closeside.TabIndex = 3;
            closeside.TabStop = false;
            closeside.Click += closeside_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(17, 2);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(55, 19);
            label2.TabIndex = 2;
            label2.Text = "Kaavat";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Info;
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 24);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1084, 16);
            panel3.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Control;
            panel5.Controls.Add(panel7);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 381);
            panel5.Margin = new Padding(0);
            panel5.Name = "panel5";
            panel5.Size = new Size(830, 140);
            panel5.TabIndex = 6;
            // 
            // panel7
            // 
            panel7.Controls.Add(arccosbtn);
            panel7.Controls.Add(arctanbtn);
            panel7.Controls.Add(arcsinbtn);
            panel7.Controls.Add(inbtn);
            panel7.Controls.Add(tanbtn);
            panel7.Controls.Add(cosbtn);
            panel7.Controls.Add(sinbtn);
            panel7.Controls.Add(expbtn);
            panel7.Controls.Add(xisbtn);
            panel7.Controls.Add(variabbtn);
            panel7.Controls.Add(ansbtn);
            panel7.Controls.Add(pibutton);
            panel7.Controls.Add(facbtn);
            panel7.Controls.Add(brackrightbtn);
            panel7.Controls.Add(powbtn);
            panel7.Controls.Add(button24);
            panel7.Controls.Add(percentbtn);
            panel7.Controls.Add(brackleftbtn);
            panel7.Controls.Add(erasebtn);
            panel7.Controls.Add(clearbtn);
            panel7.Controls.Add(plusbtn);
            panel7.Controls.Add(minusbtn);
            panel7.Controls.Add(multiplebtn);
            panel7.Controls.Add(button13);
            panel7.Controls.Add(dividebtn);
            panel7.Controls.Add(button12);
            panel7.Controls.Add(button0);
            panel7.Controls.Add(button9);
            panel7.Controls.Add(button8);
            panel7.Controls.Add(button7);
            panel7.Controls.Add(button6);
            panel7.Controls.Add(button5);
            panel7.Controls.Add(button4);
            panel7.Controls.Add(button3);
            panel7.Controls.Add(button2);
            panel7.Controls.Add(button1);
            panel7.Location = new Point(50, 4);
            panel7.Name = "panel7";
            panel7.Size = new Size(730, 132);
            panel7.TabIndex = 38;
            // 
            // arccosbtn
            // 
            arccosbtn.FlatStyle = FlatStyle.System;
            arccosbtn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            arccosbtn.Location = new Point(646, 67);
            arccosbtn.Name = "arccosbtn";
            arccosbtn.Size = new Size(77, 29);
            arccosbtn.TabIndex = 36;
            arccosbtn.Text = "arccos";
            arccosbtn.UseVisualStyleBackColor = true;
            arccosbtn.Click += arccosbtn_Click;
            // 
            // arctanbtn
            // 
            arctanbtn.FlatStyle = FlatStyle.System;
            arctanbtn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            arctanbtn.Location = new Point(646, 99);
            arctanbtn.Name = "arctanbtn";
            arctanbtn.Size = new Size(77, 29);
            arctanbtn.TabIndex = 35;
            arctanbtn.Text = "arctan";
            arctanbtn.UseVisualStyleBackColor = true;
            arctanbtn.Click += arctanbtn_Click;
            // 
            // arcsinbtn
            // 
            arcsinbtn.FlatStyle = FlatStyle.System;
            arcsinbtn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            arcsinbtn.Location = new Point(646, 35);
            arcsinbtn.Name = "arcsinbtn";
            arcsinbtn.Size = new Size(77, 29);
            arcsinbtn.TabIndex = 34;
            arcsinbtn.Text = "arcsin";
            arcsinbtn.UseVisualStyleBackColor = true;
            arcsinbtn.Click += arcsinbtn_Click;
            // 
            // inbtn
            // 
            inbtn.FlatStyle = FlatStyle.System;
            inbtn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            inbtn.Location = new Point(646, 3);
            inbtn.Name = "inbtn";
            inbtn.Size = new Size(77, 29);
            inbtn.TabIndex = 33;
            inbtn.Text = "In";
            inbtn.UseVisualStyleBackColor = true;
            inbtn.Click += inbtn_Click;
            // 
            // tanbtn
            // 
            tanbtn.FlatStyle = FlatStyle.System;
            tanbtn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            tanbtn.Location = new Point(566, 99);
            tanbtn.Name = "tanbtn";
            tanbtn.Size = new Size(77, 29);
            tanbtn.TabIndex = 32;
            tanbtn.Text = "tan";
            tanbtn.UseVisualStyleBackColor = true;
            tanbtn.Click += tanbtn_Click;
            // 
            // cosbtn
            // 
            cosbtn.FlatStyle = FlatStyle.System;
            cosbtn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cosbtn.Location = new Point(566, 67);
            cosbtn.Name = "cosbtn";
            cosbtn.Size = new Size(77, 29);
            cosbtn.TabIndex = 31;
            cosbtn.Text = "cos";
            cosbtn.UseVisualStyleBackColor = true;
            cosbtn.Click += cosbtn_Click;
            // 
            // sinbtn
            // 
            sinbtn.FlatStyle = FlatStyle.System;
            sinbtn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            sinbtn.Location = new Point(566, 35);
            sinbtn.Name = "sinbtn";
            sinbtn.Size = new Size(77, 29);
            sinbtn.TabIndex = 30;
            sinbtn.Text = "sin";
            sinbtn.UseVisualStyleBackColor = true;
            sinbtn.Click += sinbtn_Click;
            // 
            // expbtn
            // 
            expbtn.FlatStyle = FlatStyle.System;
            expbtn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            expbtn.Location = new Point(566, 3);
            expbtn.Name = "expbtn";
            expbtn.Size = new Size(77, 29);
            expbtn.TabIndex = 29;
            expbtn.Text = "exp";
            expbtn.UseVisualStyleBackColor = true;
            expbtn.Click += expbtn_Click;
            // 
            // xisbtn
            // 
            xisbtn.FlatStyle = FlatStyle.System;
            xisbtn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            xisbtn.Location = new Point(486, 99);
            xisbtn.Name = "xisbtn";
            xisbtn.Size = new Size(77, 29);
            xisbtn.TabIndex = 28;
            xisbtn.Text = "x=";
            xisbtn.UseVisualStyleBackColor = true;
            xisbtn.Click += xisbtn_Click;
            // 
            // variabbtn
            // 
            variabbtn.FlatStyle = FlatStyle.System;
            variabbtn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            variabbtn.Location = new Point(486, 67);
            variabbtn.Name = "variabbtn";
            variabbtn.Size = new Size(77, 29);
            variabbtn.TabIndex = 27;
            variabbtn.Text = "x";
            variabbtn.UseVisualStyleBackColor = true;
            variabbtn.Click += variabbtn_Click;
            // 
            // ansbtn
            // 
            ansbtn.FlatStyle = FlatStyle.System;
            ansbtn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            ansbtn.Location = new Point(486, 35);
            ansbtn.Name = "ansbtn";
            ansbtn.Size = new Size(77, 29);
            ansbtn.TabIndex = 26;
            ansbtn.Text = "ans";
            ansbtn.UseVisualStyleBackColor = true;
            ansbtn.Click += ansbtn_Click;
            // 
            // pibutton
            // 
            pibutton.FlatStyle = FlatStyle.System;
            pibutton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            pibutton.Location = new Point(486, 3);
            pibutton.Name = "pibutton";
            pibutton.Size = new Size(77, 29);
            pibutton.TabIndex = 25;
            pibutton.Text = "π";
            pibutton.UseVisualStyleBackColor = true;
            pibutton.Click += pibutton_Click;
            // 
            // facbtn
            // 
            facbtn.FlatStyle = FlatStyle.System;
            facbtn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            facbtn.Location = new Point(406, 99);
            facbtn.Name = "facbtn";
            facbtn.Size = new Size(77, 29);
            facbtn.TabIndex = 24;
            facbtn.Text = "!";
            facbtn.UseVisualStyleBackColor = true;
            facbtn.Click += facbtn_Click;
            // 
            // brackrightbtn
            // 
            brackrightbtn.FlatStyle = FlatStyle.System;
            brackrightbtn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            brackrightbtn.Location = new Point(406, 67);
            brackrightbtn.Name = "brackrightbtn";
            brackrightbtn.Size = new Size(77, 29);
            brackrightbtn.TabIndex = 23;
            brackrightbtn.Text = ")";
            brackrightbtn.UseVisualStyleBackColor = true;
            brackrightbtn.Click += brackrightbtn_Click;
            // 
            // powbtn
            // 
            powbtn.FlatStyle = FlatStyle.System;
            powbtn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            powbtn.Location = new Point(406, 35);
            powbtn.Name = "powbtn";
            powbtn.Size = new Size(77, 29);
            powbtn.TabIndex = 22;
            powbtn.Text = "^";
            powbtn.UseVisualStyleBackColor = true;
            powbtn.Click += powbtn_Click;
            // 
            // button24
            // 
            button24.FlatStyle = FlatStyle.System;
            button24.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            button24.Location = new Point(406, 3);
            button24.Name = "button24";
            button24.Size = new Size(77, 29);
            button24.TabIndex = 21;
            button24.Text = "√ ";
            button24.UseVisualStyleBackColor = true;
            button24.Click += button24_Click;
            // 
            // percentbtn
            // 
            percentbtn.FlatStyle = FlatStyle.System;
            percentbtn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            percentbtn.Location = new Point(326, 99);
            percentbtn.Name = "percentbtn";
            percentbtn.Size = new Size(77, 29);
            percentbtn.TabIndex = 20;
            percentbtn.Text = "%";
            percentbtn.UseVisualStyleBackColor = true;
            percentbtn.Click += percentbtn_Click;
            // 
            // brackleftbtn
            // 
            brackleftbtn.FlatStyle = FlatStyle.System;
            brackleftbtn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            brackleftbtn.Location = new Point(326, 67);
            brackleftbtn.Name = "brackleftbtn";
            brackleftbtn.Size = new Size(77, 29);
            brackleftbtn.TabIndex = 19;
            brackleftbtn.Text = "(";
            brackleftbtn.UseVisualStyleBackColor = true;
            brackleftbtn.Click += brackleftbtn_Click;
            // 
            // erasebtn
            // 
            erasebtn.FlatStyle = FlatStyle.System;
            erasebtn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            erasebtn.Location = new Point(326, 35);
            erasebtn.Name = "erasebtn";
            erasebtn.Size = new Size(77, 29);
            erasebtn.TabIndex = 18;
            erasebtn.Text = "E";
            erasebtn.UseVisualStyleBackColor = true;
            erasebtn.Click += erasebtn_Click;
            // 
            // clearbtn
            // 
            clearbtn.FlatStyle = FlatStyle.System;
            clearbtn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            clearbtn.Location = new Point(326, 3);
            clearbtn.Name = "clearbtn";
            clearbtn.Size = new Size(77, 29);
            clearbtn.TabIndex = 17;
            clearbtn.Text = "C";
            clearbtn.UseVisualStyleBackColor = true;
            clearbtn.Click += clearbtn_Click;
            // 
            // plusbtn
            // 
            plusbtn.FlatStyle = FlatStyle.System;
            plusbtn.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            plusbtn.Location = new Point(246, 99);
            plusbtn.Name = "plusbtn";
            plusbtn.Size = new Size(77, 29);
            plusbtn.TabIndex = 15;
            plusbtn.Text = "+";
            plusbtn.UseVisualStyleBackColor = true;
            plusbtn.Click += plusbtn_Click;
            // 
            // minusbtn
            // 
            minusbtn.FlatStyle = FlatStyle.System;
            minusbtn.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            minusbtn.Location = new Point(246, 67);
            minusbtn.Name = "minusbtn";
            minusbtn.Size = new Size(77, 29);
            minusbtn.TabIndex = 14;
            minusbtn.Text = "─";
            minusbtn.UseVisualStyleBackColor = true;
            minusbtn.Click += minusbtn_Click;
            // 
            // multiplebtn
            // 
            multiplebtn.FlatStyle = FlatStyle.System;
            multiplebtn.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            multiplebtn.Location = new Point(246, 35);
            multiplebtn.Name = "multiplebtn";
            multiplebtn.Size = new Size(77, 29);
            multiplebtn.TabIndex = 13;
            multiplebtn.Text = "*";
            multiplebtn.UseVisualStyleBackColor = true;
            multiplebtn.Click += multiplebtn_Click;
            // 
            // button13
            // 
            button13.FlatStyle = FlatStyle.System;
            button13.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button13.Location = new Point(166, 99);
            button13.Name = "button13";
            button13.Size = new Size(77, 29);
            button13.TabIndex = 12;
            button13.Text = "=";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // dividebtn
            // 
            dividebtn.FlatStyle = FlatStyle.System;
            dividebtn.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            dividebtn.Location = new Point(246, 3);
            dividebtn.Name = "dividebtn";
            dividebtn.Size = new Size(77, 29);
            dividebtn.TabIndex = 10;
            dividebtn.Text = "÷";
            dividebtn.UseVisualStyleBackColor = true;
            dividebtn.Click += dividebtn_Click;
            // 
            // button12
            // 
            button12.FlatStyle = FlatStyle.System;
            button12.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button12.Location = new Point(86, 99);
            button12.Name = "button12";
            button12.Size = new Size(77, 29);
            button12.TabIndex = 11;
            button12.Text = ",";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button0
            // 
            button0.FlatStyle = FlatStyle.System;
            button0.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button0.Location = new Point(6, 99);
            button0.Name = "button0";
            button0.Size = new Size(77, 29);
            button0.TabIndex = 9;
            button0.Text = "0";
            button0.UseVisualStyleBackColor = true;
            button0.Click += button0_Click;
            // 
            // button9
            // 
            button9.FlatStyle = FlatStyle.System;
            button9.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button9.Location = new Point(166, 3);
            button9.Name = "button9";
            button9.Size = new Size(77, 29);
            button9.TabIndex = 8;
            button9.Text = "9";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button8
            // 
            button8.FlatStyle = FlatStyle.System;
            button8.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button8.Location = new Point(86, 3);
            button8.Name = "button8";
            button8.Size = new Size(77, 29);
            button8.TabIndex = 7;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button7
            // 
            button7.FlatStyle = FlatStyle.System;
            button7.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button7.Location = new Point(6, 3);
            button7.Name = "button7";
            button7.Size = new Size(77, 29);
            button7.TabIndex = 6;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.FlatStyle = FlatStyle.System;
            button6.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button6.Location = new Point(166, 35);
            button6.Name = "button6";
            button6.Size = new Size(77, 29);
            button6.TabIndex = 5;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.FlatStyle = FlatStyle.System;
            button5.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(86, 35);
            button5.Name = "button5";
            button5.Size = new Size(77, 29);
            button5.TabIndex = 4;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.FlatStyle = FlatStyle.System;
            button4.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(6, 35);
            button4.Name = "button4";
            button4.Size = new Size(77, 29);
            button4.TabIndex = 3;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.System;
            button3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(166, 67);
            button3.Name = "button3";
            button3.Size = new Size(77, 29);
            button3.TabIndex = 2;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.System;
            button2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(86, 67);
            button2.Name = "button2";
            button2.Size = new Size(77, 29);
            button2.TabIndex = 1;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.System;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(6, 67);
            button1.Name = "button1";
            button1.Size = new Size(77, 29);
            button1.TabIndex = 0;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.Controls.Add(funcboard);
            panel4.Controls.Add(panel8);
            panel4.Controls.Add(panel5);
            panel4.Location = new Point(254, 40);
            panel4.Margin = new Padding(4, 5, 4, 5);
            panel4.Name = "panel4";
            panel4.Size = new Size(830, 521);
            panel4.TabIndex = 4;
            // 
            // funcboard
            // 
            funcboard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            funcboard.BorderStyle = BorderStyle.None;
            funcboard.Location = new Point(4, 4);
            funcboard.Margin = new Padding(0);
            funcboard.Name = "funcboard";
            funcboard.Size = new Size(822, 343);
            funcboard.TabIndex = 8;
            funcboard.Text = "";
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel8.BackColor = SystemColors.Control;
            panel8.Controls.Add(panel9);
            panel8.Location = new Point(0, 351);
            panel8.Margin = new Padding(0);
            panel8.Name = "panel8";
            panel8.Size = new Size(830, 31);
            panel8.TabIndex = 7;
            panel8.Paint += panel8_Paint;
            // 
            // panel9
            // 
            panel9.BackColor = Color.Transparent;
            panel9.Controls.Add(lineboard);
            panel9.Location = new Point(50, 3);
            panel9.Margin = new Padding(4, 5, 4, 5);
            panel9.Name = "panel9";
            panel9.Size = new Size(730, 25);
            panel9.TabIndex = 5;
            // 
            // lineboard
            // 
            lineboard.BorderStyle = BorderStyle.FixedSingle;
            lineboard.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lineboard.Location = new Point(0, 0);
            lineboard.Margin = new Padding(0);
            lineboard.Name = "lineboard";
            lineboard.Size = new Size(730, 25);
            lineboard.TabIndex = 3;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { tiedostoToolStripMenuItem, editmenu, editToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1084, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // tiedostoToolStripMenuItem
            // 
            tiedostoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openfile, savefile, savefileasname });
            tiedostoToolStripMenuItem.Name = "tiedostoToolStripMenuItem";
            tiedostoToolStripMenuItem.Size = new Size(64, 20);
            tiedostoToolStripMenuItem.Text = "Tiedosto";
            // 
            // openfile
            // 
            openfile.Image = (Image)resources.GetObject("openfile.Image");
            openfile.Name = "openfile";
            openfile.Size = new Size(159, 22);
            openfile.Text = "Avaa";
            openfile.Click += openfile_Click;
            // 
            // savefile
            // 
            savefile.Image = (Image)resources.GetObject("savefile.Image");
            savefile.Name = "savefile";
            savefile.Size = new Size(159, 22);
            savefile.Text = "Tallenna";
            savefile.Click += savefile_Click;
            // 
            // savefileasname
            // 
            savefileasname.Image = (Image)resources.GetObject("savefileasname.Image");
            savefileasname.Name = "savefileasname";
            savefileasname.Size = new Size(159, 22);
            savefileasname.Text = "Tallenna nimellä";
            savefileasname.Click += savefileasname_Click;
            // 
            // editmenu
            // 
            editmenu.DropDownItems.AddRange(new ToolStripItem[] { emptyfuncboard });
            editmenu.Name = "editmenu";
            editmenu.Size = new Size(68, 20);
            editmenu.Text = "Muokkaa";
            // 
            // emptyfuncboard
            // 
            emptyfuncboard.Name = "emptyfuncboard";
            emptyfuncboard.Size = new Size(180, 22);
            emptyfuncboard.Text = "Tyhjennä laskut";
            emptyfuncboard.Click += emptyfuncboard_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { opensettings, keyboardToolStripMenuItem, addunit, sidebarcontrol, unititem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(50, 20);
            editToolStripMenuItem.Text = "Näytä";
            // 
            // opensettings
            // 
            opensettings.Image = (Image)resources.GetObject("opensettings.Image");
            opensettings.Name = "opensettings";
            opensettings.Size = new Size(181, 22);
            opensettings.Text = "Asetukset";
            opensettings.Click += opensettings_Click;
            // 
            // keyboardToolStripMenuItem
            // 
            keyboardToolStripMenuItem.Image = (Image)resources.GetObject("keyboardToolStripMenuItem.Image");
            keyboardToolStripMenuItem.Name = "keyboardToolStripMenuItem";
            keyboardToolStripMenuItem.Size = new Size(181, 22);
            keyboardToolStripMenuItem.Text = "Näppäimistö";
            keyboardToolStripMenuItem.Click += keyboardToolStripMenuItem_Click;
            // 
            // addunit
            // 
            addunit.Image = (Image)resources.GetObject("addunit.Image");
            addunit.Name = "addunit";
            addunit.Size = new Size(181, 22);
            addunit.Text = "Yksikkömuunnokset";
            addunit.Click += addunit_Click;
            // 
            // sidebarcontrol
            // 
            sidebarcontrol.Image = (Image)resources.GetObject("sidebarcontrol.Image");
            sidebarcontrol.Name = "sidebarcontrol";
            sidebarcontrol.Size = new Size(181, 22);
            sidebarcontrol.Text = "Sivupaneeli";
            sidebarcontrol.Click += sidebarcontrol_Click;
            // 
            // unititem
            // 
            unititem.DropDownItems.AddRange(new ToolStripItem[] { setradians, setdegrees });
            unititem.Name = "unititem";
            unititem.Size = new Size(181, 22);
            unititem.Text = "Yksikkö";
            // 
            // setradians
            // 
            setradians.Name = "setradians";
            setradians.Size = new Size(123, 22);
            setradians.Text = "Radiaanit";
            setradians.Click += setradians_Click;
            // 
            // setdegrees
            // 
            setdegrees.Name = "setdegrees";
            setdegrees.Size = new Size(123, 22);
            setdegrees.Text = "Asteet";
            setdegrees.Click += setdegrees_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { infoToolStripMenuItem, aboutopen });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(47, 20);
            helpToolStripMenuItem.Text = "Apua";
            // 
            // infoToolStripMenuItem
            // 
            infoToolStripMenuItem.Image = (Image)resources.GetObject("infoToolStripMenuItem.Image");
            infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            infoToolStripMenuItem.Size = new Size(109, 22);
            infoToolStripMenuItem.Text = "Ohjeet";
            // 
            // aboutopen
            // 
            aboutopen.Image = (Image)resources.GetObject("aboutopen.Image");
            aboutopen.Name = "aboutopen";
            aboutopen.Size = new Size(109, 22);
            aboutopen.Text = "Tietoa";
            aboutopen.Click += aboutopen_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1084, 561);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(937, 0);
            Name = "Main";
            Text = "FuncMatic";
            Load += Main_Load;
            panel1.ResumeLayout(false);
            unitopen.ResumeLayout(false);
            unitopen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)openuniticon).EndInit();
            simpleopen.ResumeLayout(false);
            simpleopen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)simpleopenicon).EndInit();
            funcsidepanel.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)closeside).EndInit();
            panel5.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel5;
        private Panel panel4;
        private Panel panel8;
        private TextBox lineboard;
        private Panel panel9;
        private Panel panel10;
        private Label label2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tiedostoToolStripMenuItem;
        private ToolStripMenuItem openfile;
        private ToolStripMenuItem savefile;
        private ToolStripMenuItem savefileasname;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem infoToolStripMenuItem;
        private ToolStripMenuItem aboutopen;
        private Panel panel7;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem opensettings;
        private ToolStripMenuItem keyboardToolStripMenuItem;
        private Button arccosbtn;
        private Button arctanbtn;
        private Button arcsinbtn;
        private Button inbtn;
        private Button tanbtn;
        private Button cosbtn;
        private Button sinbtn;
        private Button expbtn;
        private Button button28;
        private Button variabbtn;
        private Button ansbtn;
        private Button pibutton;
        private Button facbtn;
        private Button brackrightbtn;
        private Button powbtn;
        private Button button24;
        private Button percentbtn;
        private Button brackleftbtn;
        private Button erasebtn;
        private Button clearbtn;
        private Button plusbtn;
        private Button minusbtn;
        private Button multiplebtn;
        private Button button13;
        private Button dividebtn;
        private Button button12;
        private Button button0;
        private Button button9;
        private Button button8;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Panel simpleopen;
        private Button xisbtn;
        private Panel funcsidepanel;
        private RichTextBox funcboard;
        private PictureBox closeside;
        private ToolStripMenuItem sidebarcontrol;
        private Panel panel11;
        private PictureBox simpleopenicon;
        private Label simpleopentext;
        private ListView listView1;
        private ColumnHeader Funktio;
        private ToolStripMenuItem editmenu;
        private ToolStripMenuItem piirtoohjelmaToolStripMenuItem;
        private ToolStripMenuItem laskinToolStripMenuItem;
        private Panel unitopen;
        private PictureBox openuniticon;
        private Label openunittext;
        private Panel panel6;
        private ToolStripMenuItem unititem;
        private ToolStripMenuItem setradians;
        private ToolStripMenuItem setdegrees;
        private ToolStripMenuItem emptyfuncboard;
        private ToolStripMenuItem addunit;
    }
}