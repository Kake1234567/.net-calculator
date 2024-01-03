
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO.IsolatedStorage;
using System.IO.Pipes;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace FuncMatic
{
    public partial class Main : Form
    {
        private string userValue;
        private string ans;
        private string calcfunction;
        private string variable;
        private string oldfunc;
        private string savepath;
        private string savefilecontents;
        private Boolean hasUnsavedChanges;
        private Boolean textcoloring;
        private Boolean sidebarcont;
        private string errorcalc = "Ongelma laskulausekkeessa";
        private string notsameuniterr = "Muutettava arvo ja uusi arvo evät voi olla samat";
        private string notfunc = "Funktiota ei ole";
        private string notfileopened = "Tiedostoa ei ole avattu tällä hetkellä. Paina 'avaa' avaaksesi tiedoston.";
        private string errfileopen = "Ongelma tiedostoa avattaessa";
        private string errfilesave = "Ongelma tiedostoa tallennettaessa";
        private string closeappask = "Haluatko, että laskusi tallennetaan ennen sulkemista?";
        private string closeappaskhead = "Tallenna muutokset";
        private string settingsreaderr = "Ongelma asetuksien asettamisessa";
        private string raddeg = "degrees";

        public Main()
        {
            InitializeComponent();
            startsave();
            loadLang();
            centerlineboard();
            centerfuncbook();
            listView1.ItemSelectionChanged += listView1_ItemSelectionChanged;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Main_KeyDown);
            float dpiScale = CreateGraphics().DpiX / 96f;
            int minw = (int)(760 * dpiScale);
            Size minimumSize = new Size(minw, 0);
            this.MinimumSize = minimumSize;
            simpleopen.Click += new System.EventHandler(simpleopen_Click);
            simpleopenicon.Click += new System.EventHandler(simpleopen_Click);
            simpleopentext.Click += new System.EventHandler(simpleopen_Click);
            unitopen.Click += new System.EventHandler(unitopen_Click);
            openuniticon.Click += new System.EventHandler(unitopen_Click);
            openunittext.Click += new System.EventHandler(unitopen_Click);
            this.userValue = userValue;
            panel3.Paint += new PaintEventHandler(panel3_Paint);
            funcsidepanel.Paint += new PaintEventHandler(funcsidepanel_Paint);
            panel6.Paint += new PaintEventHandler(panel6_Paint);
            simpleopen.Paint += new PaintEventHandler(simpleopen_Paint);
            unitopen.Paint += new PaintEventHandler(unitopen_Paint);
            panel10.Paint += new PaintEventHandler(panel10_Paint);
            menuStrip1.Paint += new PaintEventHandler(menuStrip1_Paint);
            this.FormClosing += new FormClosingEventHandler(Main_FormClosing);
            funcboard.TextChanged += new EventHandler(funcboard_TextChanged);
            lineboard.KeyPress += lineboard_enter;
            this.Resize += new EventHandler(Main_Resize);
        }
        public string LineboardValue
        {
            get { return lineboard.Text; }
            set { lineboard.Text += value; }
        }
        public string TextColorapplied
        {
            get { return textcoloring.ToString(); }
            set { textcoloring = Convert.ToBoolean(value); }
        }
        public string keyboardseton
        {
            set
            {
                showkeyboard();
            }
        }
       


        private void SaveXmlFileToIsolatedStorage(XmlDocument document, string fileName)
        {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (!isoStore.FileExists(fileName))
                {
                    using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(fileName, FileMode.Create, isoStore))
                    {
                        document.Save(isoStream);
                    }
                }
            }
        }
        private void UpdateXmlFileInIsolatedStorage(XmlDocument document, string fileName)
        {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (isoStore.FileExists(fileName))
                {
                    using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(fileName, FileMode.Create, isoStore))
                    {
                        document.Save(isoStream);
                    }
                }
                else
                {

                }
            }
        }
        private void SaveXmlFileToIsolatedStorage(string sourceFilePath, string fileName)
        {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (!isoStore.FileExists(fileName))
                {
                    using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(fileName, FileMode.Create, isoStore))
                    {
                        using (FileStream fileStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
                        {
                            byte[] buffer = new byte[1024];
                            int bytesRead;
                            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                isoStream.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                }
            }
        }

        private XmlDocument LoadXmlFileFromIsolatedStorage(string fileName)
        {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (isoStore.FileExists(fileName))
                {
                    using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(fileName, FileMode.Open, isoStore))
                    {
                        XmlDocument document = new XmlDocument();
                        document.Load(isoStream);
                        return document;
                    }
                }
                else
                {
                    return null; 
                }
            }
        }
        private void startsave()
        {
            string xmlFilePath = AppDomain.CurrentDomain.BaseDirectory + "settings.xml";
            string isolatedStorageFileName = "settings.xml"; 

            SaveXmlFileToIsolatedStorage(xmlFilePath, isolatedStorageFileName);
        }
        public void setTheme(string theme)
        {
            if (textcoloring == true)
            {
                ColorWordsBeforeParenthesis();
            }
            if (theme == "white")
            {
                panel4.BackColor = Color.White;
                funcboard.BackColor = Color.White;
                funcboard.ForeColor = Color.Black;
            }
            if (theme == "purple")
            {
                panel4.BackColor = Color.FromArgb(47, 20, 52);
                funcboard.BackColor = Color.FromArgb(47, 20, 52);
                funcboard.ForeColor = Color.White;
            }
            if (theme == "green")
            {
                panel4.BackColor = Color.FromArgb(45, 55, 40);
                funcboard.BackColor = Color.FromArgb(45, 55, 40);
                funcboard.ForeColor = Color.White;
            }
            if (theme == "blue")
            {
                panel4.BackColor = Color.FromArgb(42, 52, 90);
                funcboard.BackColor = Color.FromArgb(42, 52, 90);
                funcboard.ForeColor = Color.White;
            }
            if (theme == "dark")
            {
                panel4.BackColor = Color.FromArgb(19, 19, 19);
                funcboard.BackColor = Color.FromArgb(19, 19, 19);
                funcboard.ForeColor = Color.White;
            }
            if (theme == "sand")
            {
                panel4.BackColor = Color.FromArgb(255, 255, 242);
                funcboard.BackColor = Color.FromArgb(255, 255, 242);
                funcboard.ForeColor = Color.Black;
            }
        }
        public void SetFuncBoardFont(Font newFont)
        {
            funcboard.Font = newFont;
        }
        public void setLang(string lang)
        {
            if (lang != null)
            {
                if (lang == "En")
                {
                    simpleopentext.Text = "Formulas";
                    openunittext.Text = "Unit conversions";
                    label2.Text = "Formulas";
                    tiedostoToolStripMenuItem.Text = "File";
                    openfile.Text = "Open";
                    savefile.Text = "Save";
                    savefileasname.Text = "Save as";
                    editmenu.Text = "Edit";
                    addunit.Text = "Unit conversions";
                    editToolStripMenuItem.Text = "Show";
                    opensettings.Text = "Settings";
                    keyboardToolStripMenuItem.Text = "Keyboard";
                    sidebarcontrol.Text = "Sidepanel";
                    helpToolStripMenuItem.Text = "Help";
                    aboutopen.Text = "About";
                    infoToolStripMenuItem.Text = "Info";

                    //infoboxes//
                    errorcalc = "Syntax error";
                    notsameuniterr = "New unit cannot be same as old unit";
                    notfunc = "Function not found";
                    notfileopened = "No openeed files, press 'open' to open a file";
                    errfileopen = "Error when opening file";
                    errfilesave = "Error when saving file";
                    closeappask = "Save changes before closing";
                    closeappaskhead = "Save changes";
                    settingsreaderr = "Error when setting settings";
                    setradians.Text = "Radians";
                    setdegrees.Text = "Degrees";
                    unititem.Text = "Unit";
                    emptyfuncboard.Text = "Empty calculations";

                    listView1.Columns[0].Text = "Functions";
                }
                if (lang == "Es")
                {
                    simpleopentext.Text = "Fórmulas";
                    openunittext.Text = "Conversiones de unidades";
                    label2.Text = "Fórmulas";
                    tiedostoToolStripMenuItem.Text = "Archivo";
                    openfile.Text = "Abrir";
                    savefile.Text = "Guardar";
                    savefileasname.Text = "Guardar como";
                    editmenu.Text = "Editar";
                    addunit.Text = "Conversiones de unidades";
                    editToolStripMenuItem.Text = "Espectáculo";
                    opensettings.Text = "Ajustes";
                    keyboardToolStripMenuItem.Text = "Teclado";
                    sidebarcontrol.Text = "Panel lateral";
                    helpToolStripMenuItem.Text = "Ayuda";
                    aboutopen.Text = "Acerca de";
                    infoToolStripMenuItem.Text = "Info";

                    //infoboxes//
                    errorcalc = "Error de sintaxis";
                    notsameuniterr = "La nueva unidad no puede ser igual a la antigua";
                    notfunc = "Función no encontrada";
                    notfileopened = "No hay archivos abiertos, presione 'abrir' para abrir un archivo";
                    errfileopen = "Error al abrir el archivo";
                    errfilesave = "Error al guardar el archivo";
                    closeappask = "Guardar cambios antes de cerrar";
                    closeappaskhead = "Guardar cambios";
                    settingsreaderr = "Error al configurar la configuración";
                    setradians.Text = "Radianes";
                    setdegrees.Text = "Grados";
                    unititem.Text = "Unidad";
                    emptyfuncboard.Text = "Cálculos vacíos";

                    listView1.Columns[0].Text = "Funciones";
                }
                if (lang == "Fin")
                {
                    simpleopentext.Text = "Kaavat";
                    openunittext.Text = "Yksikkömuunnokset";
                    label2.Text = "Kaavat";
                    tiedostoToolStripMenuItem.Text = "Tiedosto";
                    openfile.Text = "Avaa";
                    savefile.Text = "Tallenna";
                    savefileasname.Text = "Tallenna nimellä";
                    editmenu.Text = "Muokkaa";
                    addunit.Text = "Yksikkömuunnokset";
                    editToolStripMenuItem.Text = "Näytä";
                    opensettings.Text = "Asetukset";
                    keyboardToolStripMenuItem.Text = "Näppäimistö";
                    sidebarcontrol.Text = "Sivupaneeli";
                    helpToolStripMenuItem.Text = "Apua";
                    aboutopen.Text = "Tietoa";
                    infoToolStripMenuItem.Text = "Ohjeet";

                    //infoboxes//
                    errorcalc = "Onglema laskulausekkeessa";
                    notsameuniterr = "Muutettava arvo ja uusi arvo evät voi olla samat";
                    notfunc = "Funktiota ei ole";
                    notfileopened = "Tiedostoa ei ole avattu tällä hetkellä. Paina 'avaa' avaaksesi tiedoston.";
                    errfileopen = "Ongelma tiedostoa avattaessa";
                    errfilesave = "Ongelma tiedostoa tallennettaessa";
                    closeappask = "Haluatko, että laskusi tallennetaan ennen sulkemista?";
                    closeappaskhead = "Tallenna muutokset";
                    settingsreaderr = "Ongelma asetuksien asettamisessa";
                    setradians.Text = "Radiaanit";
                    setdegrees.Text = "Asteet";
                    unititem.Text = "Yksikkö";
                    emptyfuncboard.Text = "Tyhjennä laskut";

                    listView1.Columns[0].Text = "Funktiot";
                }
            }
        }
        string selectedIcon = AppDomain.CurrentDomain.BaseDirectory + "doticon.png";
        private void loadLang()
        {
            string fileName = "settings.xml";
            XmlDocument document = LoadXmlFileFromIsolatedStorage(fileName);
            XmlElement lang = document.SelectSingleNode("/settings/language") as XmlElement;
            XmlElement unit = document.SelectSingleNode("/settings/unit") as XmlElement;
            if (unit.InnerText == "rad")
            {
                raddeg = "radians";
                setradians.Image = Image.FromFile(selectedIcon);
            }
            if (unit.InnerText == "deg")
            {
                raddeg = "degrees";
                setdegrees.Image = Image.FromFile(selectedIcon);
            }
            if (lang != null)
            {
                if (lang.InnerText == "En")
                {
                    simpleopentext.Text = "Formulas";
                    openunittext.Text = "Unit conversions";
                    label2.Text = "Formulas";
                    tiedostoToolStripMenuItem.Text = "File";
                    openfile.Text = "Open";
                    savefile.Text = "Save";
                    savefileasname.Text = "Save as";
                    editmenu.Text = "Edit";
                    addunit.Text = "Unit conversions";
                    editToolStripMenuItem.Text = "Show";
                    opensettings.Text = "Settings";
                    keyboardToolStripMenuItem.Text = "Keyboard";
                    sidebarcontrol.Text = "Sidepanel";
                    helpToolStripMenuItem.Text = "Help";
                    aboutopen.Text = "About";
                    infoToolStripMenuItem.Text = "Info";

                    //infoboxes//
                    errorcalc = "Syntax error";
                    notsameuniterr = "New unit cannot be same as old unit";
                    notfunc = "Function not found";
                    notfileopened = "No openeed files, press 'open' to open a file";
                    errfileopen = "Error when opening file";
                    errfilesave = "Error when saving file";
                    closeappask = "Save changes before closing";
                    closeappaskhead = "Save changes";
                    settingsreaderr = "Error when setting settings";
                    setradians.Text = "Radians";
                    setdegrees.Text = "Degrees";
                    unititem.Text = "Unit";
                    emptyfuncboard.Text = "Empty calculations";

                    listView1.Columns[0].Text = "Functions";

                }
                if (lang.InnerText == "Es")
                {
                    simpleopentext.Text = "Fórmulas";
                    openunittext.Text = "Conversiones de unidades";
                    label2.Text = "Fórmulas";
                    tiedostoToolStripMenuItem.Text = "Archivo";
                    openfile.Text = "Abrir";
                    savefile.Text = "Guardar";
                    savefileasname.Text = "Guardar como";
                    editmenu.Text = "Editar";
                    addunit.Text = "Conversiones de unidades";
                    editToolStripMenuItem.Text = "Espectáculo";
                    opensettings.Text = "Ajustes";
                    keyboardToolStripMenuItem.Text = "Teclado";
                    sidebarcontrol.Text = "Panel lateral";
                    helpToolStripMenuItem.Text = "Ayuda";
                    aboutopen.Text = "Acerca de";
                    infoToolStripMenuItem.Text = "Info";

                    //infoboxes//
                    errorcalc = "Error de sintaxis";
                    notsameuniterr = "La nueva unidad no puede ser igual a la antigua";
                    notfunc = "Función no encontrada";
                    notfileopened = "No hay archivos abiertos, presione 'abrir' para abrir un archivo";
                    errfileopen = "Error al abrir el archivo";
                    errfilesave = "Error al guardar el archivo";
                    closeappask = "Guardar cambios antes de cerrar";
                    closeappaskhead = "Guardar cambios";
                    settingsreaderr = "Error al configurar la configuración";
                    setradians.Text = "Radianes";
                    setdegrees.Text = "Grados";
                    unititem.Text = "Unidad";
                    emptyfuncboard.Text = "Cálculos vacíos";

                    listView1.Columns[0].Text = "Funciones";
                }
            }
        }
        private void ReadKeyboardSetting()
        {
            try
            {
                string fileName = "settings.xml";
                XmlDocument document = LoadXmlFileFromIsolatedStorage(fileName);
                XmlElement keyboardElement = document.SelectSingleNode("/settings/keyboard") as XmlElement;
                XmlElement fontsizefele = document.SelectSingleNode("/settings/fontsizefboard") as XmlElement;
                XmlElement textcolor = document.SelectSingleNode("/settings/iscoloron") as XmlElement;
                XmlElement sidebar = document.SelectSingleNode("/settings/sidebar") as XmlElement;
                XmlElement themecolor = document.SelectSingleNode("/settings/calbackground") as XmlElement;
                XmlElement lang = document.SelectSingleNode("/settings/language") as XmlElement;

                if (themecolor != null)
                {
                    if (themecolor.InnerText == "white")
                    {
                        setTheme("white");
                    }
                    if (themecolor.InnerText == "purple")
                    {
                        setTheme("purple");
                    }
                    if (themecolor.InnerText == "green")
                    {
                        setTheme("green");
                    }
                    if (themecolor.InnerText == "blue")
                    {
                        setTheme("blue");
                    }
                    if (themecolor.InnerText == "dark")
                    {
                        setTheme("dark");
                    }
                    if (themecolor.InnerText == "sand")
                    {
                        setTheme("sand");
                    }
                }


                if (textcolor != null)
                {
                    if (textcolor.InnerText == "On")
                    {
                        textcoloring = true;
                    }
                    else
                    {
                        textcoloring = false;
                    }
                }
                if (sidebar != null)
                {
                    if (sidebar.InnerText == "On")
                    {
                        sidebarcont = true;
                    }
                    else
                    {
                        int newHeight = panel8.Height;
                        float dpiScale = CreateGraphics().DpiX / 96f;
                        sidebarcont = false;
                        panel1.Visible = false;
                        int yPos = (int)(40 * dpiScale);
                        this.Width = (int)(760 * dpiScale);
                        panel4.Dock = DockStyle.Fill;
                        panel4.Location = new Point(0, yPos);
                        int newWidth = panel8.Width;
                        int xpoint = (((int)newWidth - panel9.Width) / 2);
                        int ypoint = (int)((newHeight - lineboard.Height) / 2);
                        int y2point = (int)(4 * dpiScale);

                        // Example: Resize and reposition a button
                        panel9.Location = new Point(xpoint, ypoint);

                        int x2point = (((int)newWidth - panel7.Width) / 2);
                        panel7.Location = new Point(x2point, y2point);
                    }
                }

                if (keyboardElement != null)
                {
                    if (keyboardElement.InnerText == "On")
                    {

                    }
                    else
                    {
                        panel5.Visible = false;
                        float dpiScale = CreateGraphics().DpiX / 96f;
                        int yPos = (int)(140 * dpiScale);
                        funcboard.Height = funcboard.Height + yPos;
                        panel8.Dock = DockStyle.Bottom;
                    }
                    string fontf = fontsizefele.InnerText;
                    int fontfuncint = Convert.ToInt32(fontf);
                    funcboard.Font = new Font(funcboard.Font.FontFamily, fontfuncint, funcboard.Font.Style);

                    // Now, you have the keyboard setting in the 'keyboardSetting' variable.
                    // You can use it as needed.
                }
                else
                {
                    // Handle the case where the 'keyboard' element is missing.
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during file reading or parsing.
                MessageBox.Show(settingsreaderr + ex.Message);
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            ReadKeyboardSetting();
            listView1.Columns[0].Width = -2;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (i % 2 == 0)
                {
                    listView1.Items[i].BackColor = Color.FromArgb(242, 242, 242);
                }
                else
                {
                    listView1.Items[i].BackColor = Color.FromArgb(255, 255, 255);
                }
            }
        }
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                if (e.Item != null)
                {
                    string selectedItemText = e.Item.Text;
                    lineboard.Text += selectedItemText;
                }
            }
        }
        private void emptyfuncboard_Click(object sender, EventArgs e)
        {
            funcboard.Clear();
        }
        private void setradians_Click(object sender, EventArgs e)
        {
            raddeg = "radians";
            setdegrees.Image = null;
            setradians.Image = Image.FromFile(selectedIcon);
            string fileName = "settings.xml";
            XmlDocument document = LoadXmlFileFromIsolatedStorage(fileName);
            XmlElement unit = document.SelectSingleNode("/settings/unit") as XmlElement;
            unit.InnerText = "rad";
            UpdateXmlFileInIsolatedStorage(document, fileName);
        }
        private void setdegrees_Click(object sender, EventArgs e)
        {
            raddeg = "degrees";
            setradians.Image = null;
            setdegrees.Image = Image.FromFile(selectedIcon);
            string fileName = "settings.xml"; 
            XmlDocument document = LoadXmlFileFromIsolatedStorage(fileName);
            XmlElement unit = document.SelectSingleNode("/settings/unit") as XmlElement;
            unit.InnerText = "deg";
            UpdateXmlFileInIsolatedStorage(document, fileName);
        }
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control && e.KeyCode == Keys.K)
            {
                showkeyboard();
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                savefilemath();
            }
            if (e.Control && e.KeyCode == Keys.D)
            {
                closesidebar();
            }
        }
        private void funcboard_TextChanged(object sender, EventArgs e)
        {

            hasUnsavedChanges = true;
            if (textcoloring == true)
            {
                ColorWordsBeforeParenthesis();
            }
        }

        private void ColorWordsBeforeParenthesis()
        {
            string text = funcboard.Text;
            Color targetColor = Color.FromArgb(255, 24, 24);
            Color parenthesisColor = Color.FromArgb(119, 119, 119);
            Color insideParenthesesColor = Color.Green;
            Color operatorColor = Color.Orange;

            string parenthesispattern = @"[()]";
            MatchCollection matchesparenthesis = Regex.Matches(text, parenthesispattern);
            foreach (Match match in matchesparenthesis)
            {
                string parenthesis = match.Value;
                int startIndex = match.Index;

                funcboard.Select(startIndex, 1);
                funcboard.SelectionColor = parenthesisColor;
            }

            string pattern = @"(\w+)\(";
            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (Match match in matches)
            {
                string word = match.Groups[1].Value;
                int startIndex = match.Index;


                if (startIndex == 0 || !char.IsLetterOrDigit(text[startIndex - 1]))
                {
                    funcboard.Select(startIndex, word.Length);
                    funcboard.SelectionColor = targetColor;
                }


                int openParenthesisIndex = startIndex + word.Length;
                int closeParenthesisIndex = text.IndexOf(')', openParenthesisIndex);

                if (closeParenthesisIndex > openParenthesisIndex)
                {

                    funcboard.Select(openParenthesisIndex + 1, closeParenthesisIndex - openParenthesisIndex - 1);
                    funcboard.SelectionColor = insideParenthesesColor;
                }
            }


            string[] operators = { "+", "-", "*", "^" }; 

            foreach (string op in operators)
            {
                int index = text.IndexOf(op);
                while (index >= 0)
                {
                    funcboard.Select(index, op.Length);
                    funcboard.SelectionColor = operatorColor;
                    index = text.IndexOf(op, index + 1);
                }
            }
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (savefilecontents != null)
            {
                if (savefilecontents != funcboard.Text)
                {

                    DialogResult result = MessageBox.Show(closeappask, closeappaskhead, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (savepath != null)
                        {
                            savefile_Click(sender, e); 
                        }
                        else
                        {
                            savefileasname_Click(sender, e);
                        }
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        e.Cancel = true; 
                    }
                }
            }
            else
            {
                if (hasUnsavedChanges)
                {

                    DialogResult result = MessageBox.Show(closeappask, closeappaskhead, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (savepath != null)
                        {
                            savefile_Click(sender, e); 
                        }
                        else
                        {
                            savefileasname_Click(sender, e);
                        }
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        e.Cancel = true; 
                    }
                }
            }
        }
        private void simpleopen_Click(object sender, EventArgs e)
        {
            float dpiScale = CreateGraphics().DpiX / 96f;
            if (funcsidepanel.Visible == false)
            {
                funcsidepanel.Visible = true;
                int newl = (int)(8 * dpiScale);
                int newt = (int)(60 * dpiScale + funcsidepanel.ClientSize.Height);
                unitopen.Location = new Point(newl, newt);
            }
            else
            {
                funcsidepanel.Visible = false;
                int newl = (int)(8 * dpiScale);
                int newt = (int)(60 * dpiScale);
                unitopen.Location = new Point(newl, newt);
            }
        }
        private void unitmenu()
        {
            unit unitForm = new unit(this); 
            unitForm.StartPosition = FormStartPosition.CenterParent; 
            unitForm.Owner = this; 
            unitForm.ShowDialog();
        }
        private void addunit_Click(object sender, EventArgs e)
        {
            unitmenu();
        }
        private void unitopen_Click(object sender, EventArgs e)
        {
            unitmenu();
        }
        private void showdraw_Click(object sender, EventArgs e)
        {

        }
        private void showcalc_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;

        }
        private void lineboard_enter(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {

                Calculate();


                e.Handled = true;
            }
        }
        private void savefileasname_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "fmc Files (*.fmc)|*.fmc|All Files (*.*)|*.*";
                saveFileDialog.Title = "Save fmc File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string fileName = saveFileDialog.FileName;

                    try
                    {

                        string textToSave = funcboard.Text;


                        File.WriteAllText(fileName, textToSave);
                        hasUnsavedChanges = false;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(errfilesave + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void openfile_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "fmc Files (*.fmc)|*.fmc|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                openFileDialog.Title = "Open fmc File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string filePath = openFileDialog.FileName;
                    savepath = filePath;

                    try
                    {

                        string fileContents = File.ReadAllText(filePath);
                        savefilecontents = fileContents;

                        funcboard.Text = fileContents;
                        ColorWordsBeforeParenthesis();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(errfileopen + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void savefilemath()
        {
            if (!string.IsNullOrEmpty(savepath))
            {
                try
                {
                    string textToSave = funcboard.Text;
                    File.WriteAllText(savepath, textToSave);
                    hasUnsavedChanges = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(errfilesave + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(notfileopened, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void savefile_Click(object sender, EventArgs e)
        {
            savefilemath();
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            Rectangle gradientRect = new Rectangle(0, 0, panel.Width, panel.Height);
            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                        gradientRect,
                                                  Color.FromArgb(245, 246, 248), 
        Color.FromArgb(192, 211, 226), 
                        LinearGradientMode.Vertical);


            e.Graphics.FillRectangle(gradientBrush, gradientRect);
        }
        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;

            if (panel.Width > 0 && panel.Height > 0)
            {
                Rectangle gradientRect = new Rectangle(0, 0, panel.Width, panel.Height);
                LinearGradientBrush gradientBrush = new LinearGradientBrush(
                    gradientRect,
                    Color.FromArgb(248, 248, 248),
                    Color.FromArgb(205, 207, 209),
                    LinearGradientMode.Vertical);


                e.Graphics.FillRectangle(gradientBrush, gradientRect);
            }
        }
        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            Panel button = (Panel)sender;

            int borderRadius = 4;
            Rectangle gradientRect = new Rectangle(0, 0, button.Width, button.Height);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(gradientRect.Left, gradientRect.Top, borderRadius * 2, borderRadius * 2, 180, 90);
            path.AddArc(gradientRect.Right - borderRadius * 2, gradientRect.Top, borderRadius * 2, borderRadius * 2, 270, 90);
            path.AddArc(gradientRect.Right - borderRadius * 2, gradientRect.Bottom - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90);
            path.AddArc(gradientRect.Left, gradientRect.Bottom - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90);
            path.CloseFigure();

            Region region = new Region(path);

            button.Region = region;

        }

        private void funcsidepanel_Paint(object sender, PaintEventArgs e)
        {
            Panel button = (Panel)sender;

            int borderRadius = 4;
            Rectangle gradientRect = new Rectangle(0, 0, button.Width, button.Height);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(gradientRect.Left, gradientRect.Top, borderRadius * 2, borderRadius * 2, 180, 90);
            path.AddArc(gradientRect.Right - borderRadius * 2, gradientRect.Top, borderRadius * 2, borderRadius * 2, 270, 90); 
            path.AddArc(gradientRect.Right - borderRadius * 2, gradientRect.Bottom - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90);
            path.AddArc(gradientRect.Left, gradientRect.Bottom - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90); 
            path.CloseFigure();


            Region region = new Region(path);


            button.Region = region;

        }
        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            Rectangle gradientRect = new Rectangle(0, 0, panel.Width, panel.Height);
            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                        gradientRect,
                             Color.FromArgb(248, 248, 248), 
                Color.FromArgb(205, 207, 209), 
                        LinearGradientMode.Vertical); 

            e.Graphics.FillRectangle(gradientBrush, gradientRect);
        }
        private void openbasic_Click(object sender, PaintEventArgs e)
        {

        }
        private void menuStrip1_Paint(object sender, PaintEventArgs e)
        {
            MenuStrip panel = (MenuStrip)sender;
            Rectangle gradientRect = new Rectangle(0, 0, panel.Width, panel.Height);
            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                        gradientRect,
                                  Color.FromArgb(248, 248, 248), 
                Color.FromArgb(205, 207, 209),
                        LinearGradientMode.Vertical);


            e.Graphics.FillRectangle(gradientBrush, gradientRect);
        }
        private void showkeyboard()
        {
            if (panel5.Visible == true)
            {
                string fileName = "settings.xml"; 
                XmlDocument document = LoadXmlFileFromIsolatedStorage(fileName);
                XmlElement keyboardElement = document.SelectSingleNode("/settings/keyboard") as XmlElement;
                keyboardElement.InnerText = "Off";
                UpdateXmlFileInIsolatedStorage(document, fileName);
                panel5.Visible = false;
                float dpiScale = CreateGraphics().DpiX / 96f;
                int yPos = (int)(140 * dpiScale);
                funcboard.Height = funcboard.Height + yPos;
                panel8.Dock = DockStyle.Bottom;
            }
            else
            {
                string fileName = "settings.xml";
                XmlDocument document = LoadXmlFileFromIsolatedStorage(fileName);
                XmlElement keyboardElement = document.SelectSingleNode("/settings/keyboard") as XmlElement;
                keyboardElement.InnerText = "On";
                UpdateXmlFileInIsolatedStorage(document, fileName);
                panel5.Visible = true;
                float dpiScale = CreateGraphics().DpiX / 96f;
                int yPos = (int)(140 * dpiScale);
                funcboard.Height = funcboard.Height - yPos;
                int newloc = panel4.ClientSize.Height - yPos - panel8.Height;
                panel8.Dock = DockStyle.None;
                panel8.Width = panel4.Width;
                panel8.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                panel8.Location = new Point(0, newloc);
            }
        }
        private void keyboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showkeyboard();
        }
        private void aboutopen_Click(object sender, EventArgs e)
        {
            about about = new about();
            about.StartPosition = FormStartPosition.CenterParent;
            about.ShowDialog();
        }
        private void sidebarcontrol_Click(object sender, EventArgs e)
        {
            closesidebar();
        }
        private void closesidebar()
        {
            int bigw = this.Width;
            float dpiScale = CreateGraphics().DpiX / 96f;
            int newHeight = panel8.Height;

            if (panel1.Visible == true)
            {

                panel1.Visible = false;
                this.Width = (int)(760 * dpiScale);
                int yPos = (int)(40 * dpiScale);
                panel4.Dock = DockStyle.Fill;
                panel4.Location = new Point(0, yPos);
                int newWidth = panel8.Width;
                int xpoint = (((int)newWidth - panel9.Width) / 2);
                int ypoint = (int)((newHeight - lineboard.Height) / 2);
                int y2point = (int)(4 * dpiScale);

 
                panel9.Location = new Point(xpoint, ypoint);

                int x2point = (((int)newWidth - panel7.Width) / 2);
                panel7.Location = new Point(x2point, y2point);

                string fileName = "settings.xml";
                XmlDocument document = LoadXmlFileFromIsolatedStorage(fileName);
                XmlElement sidebar = document.SelectSingleNode("/settings/sidebar") as XmlElement;
                sidebar.InnerText = "Off";
                UpdateXmlFileInIsolatedStorage(document, fileName);
                sidebarcont = false;

            }
            else
            {
                if (this.Width > 1049 * dpiScale)
                {

                    panel1.Visible = true;
                    panel4.Dock = DockStyle.None;
                    int yPos = (int)(40 * dpiScale);
                    int xPos = (int)(254 * dpiScale);
                    int flexh = (int)(16 * dpiScale);
                    int neww = (int)(bigw - xPos - flexh);

                    int newh = (int)((this.Height) - (40 * dpiScale) - (38 * dpiScale));



                    panel4.Width = neww;
                    panel4.Height = newh;
                    panel4.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
                    panel4.Location = new Point(xPos, yPos);
                    int newWidth = panel8.Width;
                    int xpoint = (((int)newWidth - panel9.Width) / 2);
                    int ypoint = (int)((newHeight - lineboard.Height) / 2);
                    int y2point = (int)(4 * dpiScale);


                    panel9.Location = new Point(xpoint, ypoint);

                    int x2point = (((int)newWidth - panel7.Width) / 2);
                    panel7.Location = new Point(x2point, y2point);


                    string fileName = "settings.xml"; 
                    XmlDocument document = LoadXmlFileFromIsolatedStorage(fileName);
                    XmlElement sidebar = document.SelectSingleNode("/settings/sidebar") as XmlElement;
                    sidebar.InnerText = "On";
                    UpdateXmlFileInIsolatedStorage(document, fileName);
                    sidebarcont = true;
                }
                else
                {
                    this.Width = (int)(1049 * dpiScale);
                    int newallwidth = this.Width;
                    panel1.Visible = true;
                    panel4.Dock = DockStyle.None;
                    int yPos = (int)(40 * dpiScale);
                    int xPos = (int)(254 * dpiScale);
                    int flexh = (int)(16 * dpiScale);
                    int neww = (int)(newallwidth - xPos - flexh);

                    int newh = (int)((this.Height) - (40 * dpiScale) - (38 * dpiScale));



                    panel4.Width = neww;
                    panel4.Height = newh;
                    panel4.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
                    panel4.Location = new Point(xPos, yPos);
                    int newWidth = panel8.Width;
                    int xpoint = (((int)newWidth - panel9.Width) / 2);
                    int ypoint = (int)((newHeight - lineboard.Height) / 2);
                    int y2point = (int)(4 * dpiScale);


                    panel9.Location = new Point(xpoint, ypoint);

                    int x2point = (((int)newWidth - panel7.Width) / 2);
                    panel7.Location = new Point(x2point, y2point);

                    string fileName = "settings.xml";
                    XmlDocument document = LoadXmlFileFromIsolatedStorage(fileName);
                    XmlElement sidebar = document.SelectSingleNode("/settings/sidebar") as XmlElement;
                    sidebar.InnerText = "On";
                    UpdateXmlFileInIsolatedStorage(document, fileName);
                    sidebarcont = true;
                }
            }
        }
        private void Main_Resize(object sender, EventArgs e)
        {
            int bigw = this.Width;
            int newWidth = panel8.Width;
            int newHeight = panel8.Height;
            int xpoint = (((int)newWidth - panel9.Width) / 2);
            float dpiScale = CreateGraphics().DpiX / 96f;
            centerlineboard();

            int y2point = (int)(4 * dpiScale);


            int x2point = (((int)newWidth - panel7.Width) / 2);
            panel7.Location = new Point(x2point, y2point);

            int smallWidth = (int)(1030 * dpiScale);
            int bigWidth = (int)(1029 * dpiScale);
            if (sidebarcont == true)
            {

                if (bigw < smallWidth)
                {
                    panel1.Visible = false;
                    int yPos = (int)(40 * dpiScale);
                    panel4.Dock = DockStyle.Fill;
                    panel4.Location = new Point(0, yPos);
                }
                if (bigw > bigWidth)
                {
                    panel1.Visible = true;
                    panel4.Dock = DockStyle.None;
                    int yPos = (int)(40 * dpiScale);
                    int xPos = (int)(254 * dpiScale);
                    int flexh = (int)(16 * dpiScale);
                    int neww = (int)(bigw - xPos - flexh);
                    int newh = (int)((this.Height) - (40 * dpiScale) - (38 * dpiScale));

                    panel4.Width = neww;
                    panel4.Height = newh;
                    panel4.Location = new Point(xPos, yPos);
                    panel4.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
                }
            }
        }
        private void centerfuncbook()
        {
            int parentWidth = funcsidepanel.Width;
            int parentHeight = funcsidepanel.Height;
            int newLocationY = (int)(parentHeight - panel6.Height) / 2;
            int newLocationX = (int)(parentWidth - panel6.Width) / 2;
            panel6.Location = new Point(newLocationX, newLocationY);

        }
        private void centerlineboard()
        {
            int newWidth = panel8.Width;
            int newHeight = panel8.Height;
            int xpoint = (((int)newWidth - panel9.Width) / 2);
            int newy = (int)((newHeight - lineboard.Height) / 2);

            panel9.Location = new Point(xpoint, newy);

        }
        private void opensettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(this);
            settings.StartPosition = FormStartPosition.CenterParent; 
            settings.Owner = this; 
            settings.ShowDialog();
        }
        private void simpleopen_Paint(object sender, PaintEventArgs e)
        {
            Panel button = (Panel)sender;

            int borderRadius = 4; 
            Rectangle gradientRect = new Rectangle(0, 0, button.Width, button.Height);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(gradientRect.Left, gradientRect.Top, borderRadius * 2, borderRadius * 2, 180, 90); 
            path.AddArc(gradientRect.Right - borderRadius * 2, gradientRect.Top, borderRadius * 2, borderRadius * 2, 270, 90);
            path.AddArc(gradientRect.Right - borderRadius * 2, gradientRect.Bottom - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90); 
            path.AddArc(gradientRect.Left, gradientRect.Bottom - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90); 
            path.CloseFigure();


            Region region = new Region(path);

            button.Region = region;

            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                gradientRect,
                Color.FromArgb(248, 248, 248), 
                Color.FromArgb(205, 207, 209), 
                LinearGradientMode.Vertical);


            e.Graphics.FillPath(gradientBrush, path);

        }
        private void unitopen_Paint(object sender, PaintEventArgs e)
        {
            Panel button = (Panel)sender;

            int borderRadius = 4; 
            Rectangle gradientRect = new Rectangle(0, 0, button.Width, button.Height);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(gradientRect.Left, gradientRect.Top, borderRadius * 2, borderRadius * 2, 180, 90); 
            path.AddArc(gradientRect.Right - borderRadius * 2, gradientRect.Top, borderRadius * 2, borderRadius * 2, 270, 90); 
            path.AddArc(gradientRect.Right - borderRadius * 2, gradientRect.Bottom - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90); 
            path.AddArc(gradientRect.Left, gradientRect.Bottom - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90);
            path.CloseFigure();

            Region region = new Region(path);

            button.Region = region;

            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                gradientRect,
                Color.FromArgb(248, 248, 248),
                Color.FromArgb(205, 207, 209), 
                LinearGradientMode.Vertical);

            e.Graphics.FillPath(gradientBrush, path);

        }
        private void colorans()
        {
            string word = ans;
            Color color = Color.FromArgb(110, 165, 238);
            string text = funcboard.Text;

            MatchCollection matches = Regex.Matches(text, @"\b" + word + @"\b");

            foreach (Match match in matches)
            {
                int startIndex = match.Index;
                int length = match.Length;

                funcboard.Select(startIndex, length);
                funcboard.SelectionColor = color;
            }
        }
        private void closeside_Click(object sender, EventArgs e)
        {
            closesidebar();
        }
        //Start calculator//



        //keyboard//

        private void xisbtn_Click(object sender, EventArgs e)
        {
            string func = "x=";
            lineboard.Text += func;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number = 1;
            lineboard.Text += number;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int number = 2;
            lineboard.Text += number;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int number = 3;
            lineboard.Text += number;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int number = 4;
            lineboard.Text += number;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int number = 5;
            lineboard.Text += number;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            int number = 6;
            lineboard.Text += number;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            int number = 7;
            lineboard.Text += number;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            int number = 8;
            lineboard.Text += number;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            int number = 9;
            lineboard.Text += number;
        }
        private void button0_Click(object sender, EventArgs e)
        {
            int number = 0;
            lineboard.Text += number;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string icon = ".";
            lineboard.Text += icon;
        }
        private void percentbtn_Click(object sender, EventArgs e)
        {
            string icon = "%";
            lineboard.Text += icon;
        }
        private void variabbtn_Click(object sender, EventArgs e)
        {
            string icon = "x";
            lineboard.Text += icon;
        }
        private void button13_Click(object sender, EventArgs e)
        {
            Calculate();
        }
        private void button24_Click(object sender, EventArgs e)
        {
            string func = "sqrt(";
            lineboard.Text += func;
        }
        private void plusbtn_Click(object sender, EventArgs e)
        {
            string icon = "+";
            lineboard.Text += icon;
        }
        private void minusbtn_Click(object sender, EventArgs e)
        {
            string icon = "-";
            lineboard.Text += icon;
        }
        private void multiplebtn_Click(object sender, EventArgs e)
        {
            string icon = "*";
            lineboard.Text += icon;
        }
        private void dividebtn_Click(object sender, EventArgs e)
        {
            string icon = "/";
            lineboard.Text += icon;
        }
        private void clearbtn_Click(object sender, EventArgs e)
        {
            lineboard.Text = "";
        }
        private void erasebtn_Click(object sender, EventArgs e)
        {
            if (lineboard.Text.Length > 0)
            {
                lineboard.Text = lineboard.Text.Substring(0, lineboard.Text.Length - 1);
            }
        }
        private void brackleftbtn_Click(object sender, EventArgs e)
        {
            string icon = "(";
            lineboard.Text += icon;
        }
        private void brackrightbtn_Click(object sender, EventArgs e)
        {
            string icon = ")";
            lineboard.Text += icon;
        }
        private void sinbtn_Click(object sender, EventArgs e)
        {
            string func = "sin(";
            lineboard.Text += func;
        }
        private void cosbtn_Click(object sender, EventArgs e)
        {
            string func = "cos(";
            lineboard.Text += func;
        }
        private void tanbtn_Click(object sender, EventArgs e)
        {
            string func = "tan(";
            lineboard.Text += func;
        }
        private void arcsinbtn_Click(object sender, EventArgs e)
        {
            string func = "arcsin(";
            lineboard.Text += func;
        }
        private void arccosbtn_Click(object sender, EventArgs e)
        {
            string func = "arccos(";
            lineboard.Text += func;
        }
        private void arctanbtn_Click(object sender, EventArgs e)
        {
            string func = "arctan(";
            lineboard.Text += func;
        }
        private void pibutton_Click(object sender, EventArgs e)
        {
            string icon = "π";
            lineboard.Text += icon;
        }
        private void powbtn_Click(object sender, EventArgs e)
        {
            string icon = "^";
            lineboard.Text += icon;
        }
        private void ansbtn_Click(object sender, EventArgs e)
        {
            string func = "ans";
            lineboard.Text += func;
        }
        private void inbtn_Click(object sender, EventArgs e)
        {
            string func = "In(";
            lineboard.Text += func;
        }
        private void expbtn_Click(object sender, EventArgs e)
        {
            string func = "exp(";
            lineboard.Text += func;
        }
        private void facbtn_Click(object sender, EventArgs e)
        {
            string icon = "!";
            lineboard.Text += icon;
        }

        private double CustomExponentiation(double baseNumber, double exponentNumber)
        {
            return Math.Pow(baseNumber, exponentNumber);
        }
        private long CalculateFactorial(int n)
        {
            if (n == 0)
                return 1;
            long result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        Dictionary<string, string> rvariables = new Dictionary<string, string>();
        private void Calculate()
        {
            try
            {
                string expression = lineboard.Text;
                double result = 0;
                string[] predefinedFunctions = { "f", "g", "y" };
                string[] predefinedvariables = { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "j", "k", "l", "z", "c", "v", "b", "n", "m" };
                expression = expression.Replace("π", Math.PI.ToString());
                expression = expression.Replace("ans", ans);
                expression = expression.Replace(",", ".");

                expression = expression.Replace("%", "/100");

                string pattern = @"([-+]?\d*\.?\d*[\*]?[a-z](?:\^\d+)?)\s*([-+]\s*\d*\.?\d*[\*]?[a-z](?:\^\d+)?)*";
                if (Regex.IsMatch(expression, pattern))
                {
                }


                foreach (string variable in predefinedvariables)
                {
                    if (expression.Contains($"{variable}="))
                    {
                        string[] newex = expression.Split('=');

                        string answer = string.Empty;

                        if (newex.Length > 1)
                        {
                            string variableName = newex[0].Trim();
                            string variableValueStr = newex[1].Trim();
                            double resultval = Convert.ToDouble(variableValueStr);
                            expression = variableValueStr;
                            result = resultval;
                            rvariables[variableName] = variableValueStr;
                        }
                        if (rvariables.ContainsKey($"{variable}"))
                        {
                            string valueOfVa = rvariables[$"{variable}"];
                        }
                    }

                }
                foreach (var variable in rvariables)
                {
                    string variableName = variable.Key;
                    string variableValue = variable.Value;

                    string patternv = $@"\b{Regex.Escape(variableName)}\b";

                    expression = Regex.Replace(expression, patternv, variableValue);
                }
                if (!expression.Contains("x"))
                {
                    expression = Regex.Replace(expression, @"\(([^)]+)\)\^(-?\d+(\.\d+)?)", match =>
                {
                    string baseExpression = match.Groups[1].Value;
                    double exponent = double.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);

                    double baseResult = Convert.ToDouble(new System.Data.DataTable().Compute(baseExpression, ""));
                    double result = Math.Pow(baseResult, exponent);

                    return result.ToString(CultureInfo.InvariantCulture);
                });
                }

                expression = Regex.Replace(expression, @"(\d+(\.\d+)?)\^(-?\d+(\.\d+)?)", match =>
                {
                    double baseNumber = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
                    double exponentNumber = double.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);

                    double result;
                    if (exponentNumber >= 0)
                    {
                        result = CustomExponentiation(baseNumber, exponentNumber);
                    }
                    else
                    {
                        result = 1.0 / CustomExponentiation(baseNumber, -exponentNumber);
                    }

                    return result.ToString(CultureInfo.InvariantCulture);
                });

                if (expression.Contains("!"))
                {
                    expression = Regex.Replace(expression, @"(\d+)!", m =>
                    {
                        int number = int.Parse(m.Groups[1].Value);
                        long factorial = CalculateFactorial(number);
                        return factorial.ToString();
                    });
                    expression = Regex.Replace(expression, @"\(([^)]+)\)!", m =>
                    {
                        string subexpression = m.Groups[1].Value;
                        double subresult = Convert.ToDouble(new System.Data.DataTable().Compute(subexpression, ""));
                        long factorial = CalculateFactorial((int)subresult);
                        return factorial.ToString();
                    });
                }
                foreach (string function in predefinedFunctions)
                {
                    if (expression.Contains("x="))
                    {
                        if (oldfunc != null)
                        {
                            string[] newex = expression.Split('=');

                            string[] old = oldfunc.Split('=');
                            string afterx = string.Empty;
                            string answer = string.Empty;

                            if (newex.Length > 1)
                            {
                                afterx = newex[1].Trim();
                            }
                            if (old.Length > 1)
                            {
                                string calcfunction = old[1].Trim();
                                answer = calcfunction.Replace("x", afterx);
                            }
                            try
                            {
                                answer = Regex.Replace(answer, @"(\d+(\.\d+)?)\s*\^\s*(-?\d+(\.\d+)?)", match =>
                                {
                                    CultureInfo culture = CultureInfo.InvariantCulture;
                                    NumberFormatInfo nfi = culture.NumberFormat;

                                    double baseNumber;
                                    if (double.TryParse(match.Groups[1].Value, NumberStyles.AllowDecimalPoint, culture, out baseNumber))
                                    {
                                        double exponentNumber = double.Parse(match.Groups[3].Value, culture);

                                        double result;
                                        if (exponentNumber >= 0)
                                        {
                                            result = CustomExponentiation(baseNumber, exponentNumber);
                                        }
                                        else
                                        {
                                            result = 1.0 / CustomExponentiation(baseNumber, -exponentNumber);
                                        }

                                        return result.ToString(culture);
                                    }
                                    else
                                    {

                                        return "Invalid Base Number";
                                    }
                                });
                                double answerdoub = Convert.ToDouble(new System.Data.DataTable().Compute(answer, ""));
                                result = answerdoub;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error evaluating expression: " + ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show(notfunc, "Calculator Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                foreach (string function in predefinedFunctions)
                {
                    if (expression.Contains($"{function}("))
                    {
                        int startIndex = expression.IndexOf($"{function}(") + 2;
                        int endIndex = expression.IndexOf(")", startIndex);
                        if (startIndex >= 0 && endIndex > startIndex)
                        {
                            CultureInfo culture = CultureInfo.InvariantCulture;
                            string innerExpression = expression.Substring(startIndex, endIndex - startIndex);
                            double innerResult = Convert.ToDouble(new System.Data.DataTable().Compute(innerExpression, ""));
                            oldfunc = expression;


                            expression = expression.Replace("x", innerResult.ToString(culture));
                            expression = Regex.Replace(expression, @"\(([^)]+)\)\^(-?\d+(\.\d+)?)", match =>
                            {

                                string baseExpression = match.Groups[1].Value;
                                double exponent = double.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);

                                double baseResult = Convert.ToDouble(new System.Data.DataTable().Compute(baseExpression, ""));

                                double result = Math.Pow(baseResult, exponent);

                                return result.ToString(CultureInfo.InvariantCulture);
                            });
                            expression = Regex.Replace(expression, @"(\d+(\.\d+)?)\^(-?\d+(\.\d+)?)", match =>
                            {
                                double baseNumber = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
                                double exponentNumber = double.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);

                                double result;
                                if (exponentNumber >= 0)
                                {
                                    result = CustomExponentiation(baseNumber, exponentNumber);
                                }
                                else
                                {
                                    result = 1.0 / CustomExponentiation(baseNumber, -exponentNumber);
                                }

                                return result.ToString(CultureInfo.InvariantCulture);
                            });
                            string[] parts = expression.Split('=');
                            double answer;
                            if (parts.Length > 1)
                            {
                                calcfunction = parts[1].Trim();
                            }
                            answer = Convert.ToDouble(new System.Data.DataTable().Compute(calcfunction, ""));

                            expression = parts[0].Trim();
                            expression = expression.Replace($"{function}({innerExpression})", answer.ToString());
                            expression = expression.Replace(",", ".");
                            result = Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
                        }
                    }
                }



                while (expression.Contains("unit("))
                {
                    try
                    {
                        int startIndex = expression.IndexOf("unit(") + 5;
                        int endIndex = expression.IndexOf(")", startIndex);

                        string[] variables = { "m", "mm", "l", "y", "m2", "a", "m3", "t", "i", "s", "h", "n" };

                        if (startIndex >= 0 && endIndex > startIndex)
                        {
                            string innerExpression = expression.Substring(startIndex, endIndex - startIndex);
                            string[] parts = expression.Split('=');
                            string variablePart = parts[0];
                            string valuePart = parts[1];
                            bool validVariableFound = false;

                            foreach (string variable in variables)
                            {
                                if (innerExpression.Contains($"{variable}_"))
                                {
                                    string patterni = $"{variable}_(\\d+(\\.\\d+)?)";
                                    Match match = Regex.Match(expression, patterni);

                                    if (match.Success)
                                    {
                                        CultureInfo culture = CultureInfo.InvariantCulture;
                                        string bfu = innerExpression.Split('_')[0];

                                        string chnumbStr = match.Groups[1].Value;
                                        string newuni = null;
                                        double res = 0;
                                        if (parts.Length > 1)
                                        {
                                            newuni = parts[1].TrimEnd(')');
                                        }
                                        if (variablePart.Contains($"{variable}_"))
                                        {
                                            validVariableFound = true;
                                            if (newuni != bfu)
                                            {
                                                if (double.TryParse(chnumbStr, NumberStyles.Any, culture, out double chnumb))
                                                {

                                                    if (newuni == "mm" && bfu == "m")
                                                    {
                                                        res = chnumb * 1000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "m" && newuni == "cm")
                                                    {
                                                        res = chnumb * 100;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "m" && newuni == "dm")
                                                    {
                                                        res = chnumb * 10;
                                                        expression = res.ToString();
                                                    }

                                                    if (bfu == "mm" && newuni == "m")
                                                    {
                                                        res = chnumb / 1000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "mm" && newuni == "dm")
                                                    {
                                                        res = chnumb / 100;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "mm" && newuni == "cm")
                                                    {
                                                        res = chnumb / 10;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "cm" && newuni == "mm")
                                                    {
                                                        res = chnumb * 10;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "cm" && newuni == "dm")
                                                    {
                                                        res = chnumb / 10;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "cm" && newuni == "m")
                                                    {
                                                        res = chnumb / 100;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dm" && newuni == "m")
                                                    {
                                                        res = chnumb / 10;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dm" && newuni == "cm")
                                                    {
                                                        res = chnumb * 10;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dm" && newuni == "mm")
                                                    {
                                                        res = chnumb * 100;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "mm" && newuni == "km")
                                                    {
                                                        res = chnumb / 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "mm" && newuni == "hm")
                                                    {
                                                        res = chnumb / 100000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "mm" && newuni == "dam")
                                                    {
                                                        res = chnumb / 10000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "cm" && newuni == "km")
                                                    {
                                                        res = chnumb / 100000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "cm" && newuni == "hm")
                                                    {
                                                        res = chnumb / 10000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "cm" && newuni == "dam")
                                                    {
                                                        res = chnumb / 1000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dm" && newuni == "km")
                                                    {
                                                        res = chnumb / 10000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dm" && newuni == "hm")
                                                    {
                                                        res = chnumb / 1000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dm" && newuni == "dam")
                                                    {
                                                        res = chnumb / 100;
                                                        expression = res.ToString();
                                                    }

                                                    if (bfu == "m" && newuni == "km")
                                                    {
                                                        res = chnumb / 1000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "m" && newuni == "hm")
                                                    {
                                                        res = chnumb / 100;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "m" && newuni == "dam")
                                                    {
                                                        res = chnumb / 10;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "km" && newuni == "mm")
                                                    {
                                                        res = chnumb * 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "km" && newuni == "cm")
                                                    {
                                                        res = chnumb * 100000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "km" && newuni == "dm")
                                                    {
                                                        res = chnumb * 10000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "km" && newuni == "m")
                                                    {
                                                        res = chnumb * 1000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "km" && newuni == "dam")
                                                    {
                                                        res = chnumb * 100;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "km" && newuni == "hm")
                                                    {
                                                        res = chnumb * 10;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "hm" && newuni == "mm")
                                                    {
                                                        res = chnumb * 100000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "hm" && newuni == "cm")
                                                    {
                                                        res = chnumb * 10000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "hm" && newuni == "dm")
                                                    {
                                                        res = chnumb * 1000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "hm" && newuni == "m")
                                                    {
                                                        res = chnumb * 100;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "hm" && newuni == "dam")
                                                    {
                                                        res = chnumb * 10;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "hm" && newuni == "km")
                                                    {
                                                        res = chnumb / 10;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dam" && newuni == "m")
                                                    {
                                                        res = chnumb * 10;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dam" && newuni == "dm")
                                                    {
                                                        res = chnumb * 100;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dam" && newuni == "cm")
                                                    {
                                                        res = chnumb * 1000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dam" && newuni == "mm")
                                                    {
                                                        res = chnumb * 10000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dam" && newuni == "hm")
                                                    {
                                                        res = chnumb / 10;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dam" && newuni == "km")
                                                    {
                                                        res = chnumb / 100;
                                                        expression = res.ToString();
                                                    }

                                                    //Normal end//

                                                    if (bfu == "mm2" && newuni == "km2")
                                                    {
                                                        res = chnumb / 1000000 / 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "mm2" && newuni == "ha")
                                                    {
                                                        res = chnumb / 10000 / 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "mm2" && newuni == "a")
                                                    {
                                                        res = chnumb / 100 / 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "mm2" && newuni == "m2")
                                                    {
                                                        res = chnumb / 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "mm2" && newuni == "dm2")
                                                    {
                                                        res = chnumb / 10000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "mm2" && newuni == "cm2")
                                                    {
                                                        res = chnumb / 100;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "cm2" && newuni == "km2")
                                                    {
                                                        res = chnumb / 10000 / 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "cm2" && newuni == "ha")
                                                    {
                                                        res = chnumb / 100 / 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "cm2" && newuni == "a")
                                                    {
                                                        res = chnumb / 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "cm2" && newuni == "m2")
                                                    {
                                                        res = chnumb / 10000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "cm2" && newuni == "dm2")
                                                    {
                                                        res = chnumb / 100;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "cm2" && newuni == "mm2")
                                                    {
                                                        res = chnumb * 100;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dm2" && newuni == "km2")
                                                    {
                                                        res = chnumb / 100 / 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dm2" && newuni == "ha")
                                                    {
                                                        res = chnumb / 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dm2" && newuni == "a")
                                                    {
                                                        res = chnumb / 10000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dm2" && newuni == "m2")
                                                    {
                                                        res = chnumb / 100;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dm2" && newuni == "cm2")
                                                    {
                                                        res = chnumb * 100;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dm2" && newuni == "mm2")
                                                    {
                                                        res = chnumb * 10000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "m2" && newuni == "km2")
                                                    {
                                                        res = chnumb / 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "m2" && newuni == "ha")
                                                    {
                                                        res = chnumb / 10000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "m2" && newuni == "a")
                                                    {
                                                        res = chnumb / 100;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "m2" && newuni == "dm2")
                                                    {
                                                        res = chnumb * 100;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "m2" && newuni == "cm2")
                                                    {
                                                        res = chnumb * 10000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "m2" && newuni == "mm2")
                                                    {
                                                        res = chnumb * 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "a" && newuni == "km2")
                                                    {
                                                        res = chnumb / 10000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "a" && newuni == "ha")
                                                    {
                                                        res = chnumb / 100;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "a" && newuni == "m2")
                                                    {
                                                        res = chnumb * 100;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "a" && newuni == "dm2")
                                                    {
                                                        res = chnumb * 10000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "a" && newuni == "cm2")
                                                    {
                                                        res = chnumb * 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "a" && newuni == "mm2")
                                                    {
                                                        res = chnumb * 100000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "ha" && newuni == "km2")
                                                    {
                                                        res = chnumb / 100;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "ha" && newuni == "a")
                                                    {
                                                        res = chnumb * 100;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "ha" && newuni == "m2")
                                                    {
                                                        res = chnumb * 10000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "ha" && newuni == "dm2")
                                                    {
                                                        res = chnumb * 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "ha" && newuni == "cm2")
                                                    {
                                                        res = chnumb * 100000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "ha" && newuni == "mm2")
                                                    {
                                                        res = chnumb * 10000000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "km2" && newuni == "ha")
                                                    {
                                                        res = chnumb * 100;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "km2" && newuni == "a")
                                                    {
                                                        res = chnumb * 10000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "km2" && newuni == "m2")
                                                    {
                                                        res = chnumb * 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "km2" && newuni == "dm2")
                                                    {
                                                        res = chnumb * 100000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "km2" && newuni == "cm2")
                                                    {
                                                        res = chnumb * 10000000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "km2" && newuni == "mm2")
                                                    {
                                                        res = chnumb * 1000000000000;
                                                        expression = res.ToString();
                                                    }

                                                    //cubic//

                                                    if (bfu == "mm3" && newuni == "m3")
                                                    {
                                                        res = chnumb / 1000000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "mm3" && newuni == "dm3")
                                                    {
                                                        res = chnumb / 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "mm3" && newuni == "cm3")
                                                    {
                                                        res = chnumb / 1000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "mm3" && newuni == "dam3")
                                                    {
                                                        res = chnumb / 1000000000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "mm3" && newuni == "hm3")
                                                    {
                                                        res = chnumb / 1000000000000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "mm3" && newuni == "km3")
                                                    {
                                                        res = chnumb / 1000000000000000000;
                                                        expression = res.ToString();
                                                    }


                                                    if (bfu == "cm3" && newuni == "m3")
                                                    {
                                                        res = chnumb / 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "cm3" && newuni == "mm3")
                                                    {
                                                        res = chnumb * 1000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "cm3" && newuni == "dm3")
                                                    {
                                                        res = chnumb / 1000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "cm3" && newuni == "km3")
                                                    {
                                                        res = chnumb / 1000000000000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "cm3" && newuni == "hm3")
                                                    {
                                                        res = chnumb / 1000000000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "cm3" && newuni == "dam3")
                                                    {
                                                        res = chnumb / 1000000000;
                                                        expression = res.ToString();
                                                    }



                                                    if (bfu == "dm3" && newuni == "m3")
                                                    {
                                                        res = chnumb / 1000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dm3" && newuni == "cm3")
                                                    {
                                                        res = chnumb * 1000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dm3" && newuni == "mm3")
                                                    {
                                                        res = chnumb * 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dm3" && newuni == "dam3")
                                                    {
                                                        res = chnumb / 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dm3" && newuni == "hm3")
                                                    {
                                                        res = chnumb / 1000000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dm3" && newuni == "km3")
                                                    {
                                                        res = chnumb / 1000000000000;
                                                        expression = res.ToString();
                                                    }


                                                    if (bfu == "km3" && newuni == "mm3")
                                                    {
                                                        res = chnumb * 1000000000000000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "km3" && newuni == "cm3")
                                                    {
                                                        res = chnumb * 1000000000000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "km3" && newuni == "dm3")
                                                    {
                                                        res = chnumb * 1000000000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "km3" && newuni == "m3")
                                                    {
                                                        res = chnumb * 1000000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "km3" && newuni == "dam3")
                                                    {
                                                        res = chnumb * 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "km3" && newuni == "hm3")
                                                    {
                                                        res = chnumb * 1000;
                                                        expression = res.ToString();
                                                    }


                                                    if (bfu == "hm3" && newuni == "mm3")
                                                    {
                                                        res = chnumb * 1000000000000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "hm3" && newuni == "cm3")
                                                    {
                                                        res = chnumb * 1000000000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "hm3" && newuni == "dm3")
                                                    {
                                                        res = chnumb * 1000000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "hm3" && newuni == "m3")
                                                    {
                                                        res = chnumb * 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "hm3" && newuni == "dam3")
                                                    {
                                                        res = chnumb * 1000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "hm3" && newuni == "km3")
                                                    {
                                                        res = chnumb / 1000;
                                                        expression = res.ToString();
                                                    }

                                                    if (bfu == "dam3" && newuni == "mm3")
                                                    {
                                                        res = chnumb * 1000000000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dam3" && newuni == "cm3")
                                                    {
                                                        res = chnumb * 1000000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dam3" && newuni == "dm3")
                                                    {
                                                        res = chnumb * 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dam3" && newuni == "m3")
                                                    {
                                                        res = chnumb * 1000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dam3" && newuni == "hm3")
                                                    {
                                                        res = chnumb / 1000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dam3" && newuni == "km3")
                                                    {
                                                        res = chnumb / 1000000;
                                                        expression = res.ToString();
                                                    }


                                                    if (bfu == "m3" && newuni == "dm3")
                                                    {
                                                        res = chnumb * 1000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "m3" && newuni == "cm3")
                                                    {
                                                        res = chnumb * 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "m3" && newuni == "mm3")
                                                    {
                                                        res = chnumb * 1000000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "m3" && newuni == "km3")
                                                    {
                                                        res = chnumb / 1000000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "m3" && newuni == "hm3")
                                                    {
                                                        res = chnumb / 1000000;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "m3" && newuni == "dam3")
                                                    {
                                                        res = chnumb / 1000;
                                                        expression = res.ToString();
                                                    }



                                                    //m ft//
                                                    if (bfu == "km" && newuni == "ft")
                                                    {
                                                        res = chnumb * 3280.8399;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "hm" && newuni == "ft")
                                                    {
                                                        res = chnumb * 328.08399;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dam" && newuni == "ft")
                                                    {
                                                        res = chnumb * 32.808399;
                                                        expression = res.ToString();
                                                    }



                                                    if (bfu == "m" && newuni == "ft")
                                                    {
                                                        res = chnumb * 3.2808399;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "m" && newuni == "ft")
                                                    {
                                                        res = chnumb * 3.2808399;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dm" && newuni == "ft")
                                                    {
                                                        res = chnumb * 0.32808399;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "cm" && newuni == "ft")
                                                    {
                                                        res = chnumb * 0.032808399;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "mm" && newuni == "ft")
                                                    {
                                                        res = chnumb * 0.0032808399;
                                                        expression = res.ToString();
                                                    }

                                                    if (bfu == "ft" && newuni == "km")
                                                    {
                                                        res = chnumb * 0.0003048;
                                                        expression = res.ToString();
                                                    }

                                                    if (bfu == "ft" && newuni == "hm")
                                                    {
                                                        res = chnumb * 0.003048;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "ft" && newuni == "dam")
                                                    {
                                                        res = chnumb * 0.03048;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "ft" && newuni == "m")
                                                    {
                                                        res = chnumb * 0.3048;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "ft" && newuni == "dm")
                                                    {
                                                        res = chnumb * 3.04800;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "ft" && newuni == "cm")
                                                    {
                                                        res = chnumb * 30.4800;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "ft" && newuni == "mm")
                                                    {
                                                        res = chnumb * 304.800;
                                                        expression = res.ToString();
                                                    }

                                                    //in//
                                                    if (bfu == "mm" && newuni == "in")
                                                    {
                                                        res = chnumb * 0.0393700787;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "cm" && newuni == "in")
                                                    {
                                                        res = chnumb * 0.393700787;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dm" && newuni == "in")
                                                    {
                                                        res = chnumb * 3.93700787;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "m" && newuni == "in")
                                                    {
                                                        res = chnumb * 39.3700787;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dam" && newuni == "in")
                                                    {
                                                        res = chnumb * 393.700787;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "hm" && newuni == "in")
                                                    {
                                                        res = chnumb * 3937.00787;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "km" && newuni == "in")
                                                    {
                                                        res = chnumb * 39370.0787;
                                                        expression = res.ToString();
                                                    }

                                                    if (bfu == "in" && newuni == "mm")
                                                    {
                                                        res = chnumb * 25.4;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "in" && newuni == "cm")
                                                    {
                                                        res = chnumb * 2.54;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "in" && newuni == "dm")
                                                    {
                                                        res = chnumb * 0.254;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "in" && newuni == "m")
                                                    {
                                                        res = chnumb * 0.0254;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "in" && newuni == "dam")
                                                    {
                                                        res = chnumb * 0.00254;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "in" && newuni == "hm")
                                                    {
                                                        res = chnumb * 0.000254;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "in" && newuni == "km")
                                                    {
                                                        res = chnumb * 0.0000254;
                                                        expression = res.ToString();
                                                    }

                                                    //m mi//
                                                    if (bfu == "km" && newuni == "mi")
                                                    {
                                                        res = chnumb * 0.621371192;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "hm" && newuni == "mi")
                                                    {
                                                        res = chnumb * 0.0621371192;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dam" && newuni == "mi")
                                                    {
                                                        res = chnumb * 0.00621371192;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "m" && newuni == "mi")
                                                    {
                                                        res = chnumb * 0.000621371192;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "dm" && newuni == "mi")
                                                    {
                                                        res = chnumb * 0.0000621371192;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "cm" && newuni == "mi")
                                                    {
                                                        res = chnumb * 0.00000621371192;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "mm" && newuni == "mi")
                                                    {
                                                        res = chnumb * 0.000000621371192;
                                                        expression = res.ToString();
                                                    }

                                                    if (bfu == "mi" && newuni == "km")
                                                    {
                                                        res = chnumb * 1.609344;
                                                        expression = res.ToString();
                                                    }

                                                    if (bfu == "mi" && newuni == "hm")
                                                    {
                                                        res = chnumb * 16.09344;
                                                        expression = res.ToString();
                                                    }

                                                    if (bfu == "mi" && newuni == "dam")
                                                    {
                                                        res = chnumb * 160.9344;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "mi" && newuni == "m")
                                                    {
                                                        res = chnumb * 1609.344;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "mi" && newuni == "dm")
                                                    {
                                                        res = chnumb * 16093.44;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "mi" && newuni == "cm")
                                                    {
                                                        res = chnumb * 160934.4;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "mi" && newuni == "mm")
                                                    {
                                                        res = chnumb * 1609344;
                                                        expression = res.ToString();
                                                    }

                                                    if (bfu == "mi" && newuni == "in")
                                                    {
                                                        res = chnumb * 63360;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "in" && newuni == "mi")
                                                    {
                                                        res = chnumb * 0.00001578283;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "ft" && newuni == "in")
                                                    {
                                                        res = chnumb * 12;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "in" && newuni == "ft")
                                                    {
                                                        res = chnumb * 0.0833333;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "mi" && newuni == "ft")
                                                    {
                                                        res = chnumb * 5280;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "ft" && newuni == "mi")
                                                    {
                                                        res = chnumb * 0.000189393939;
                                                        expression = res.ToString();
                                                    }


                                                    //time//

                                                    if (bfu == "s" && newuni == "h")
                                                    {
                                                        res = chnumb / 60 / 60;
                                                        expression = res.ToString();
                                                    }

                                                    if (bfu == "s" && newuni == "min")
                                                    {
                                                        res = chnumb / 60;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "h" && newuni == "s")
                                                    {
                                                        res = chnumb * 60 * 60;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "h" && newuni == "min")
                                                    {
                                                        res = chnumb * 60;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "min" && newuni == "h")
                                                    {
                                                        res = chnumb / 60;
                                                        expression = res.ToString();
                                                    }
                                                    if (bfu == "min" && newuni == "s")
                                                    {
                                                        res = chnumb * 60;
                                                        expression = res.ToString();
                                                    }

                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show(notsameuniterr, "Calculator Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show(notsameuniterr, "Calculator Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                        expression = expression.Replace(",", ".");
                                        result = res;
                                    }
                                }
                            }
                            if (!validVariableFound)
                            {
                                MessageBox.Show("Invalid variable in the expression", "Calculator Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show(notsameuniterr, "Calculator Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                //Hyperbolic//

                while (expression.Contains("arctanh("))
                {
                    int startIndex = expression.IndexOf("arctanh(") + 8;
                    int endIndex = expression.IndexOf(")", startIndex);

                    if (startIndex >= 0 && endIndex > startIndex)
                    {
                        CultureInfo culture = CultureInfo.InvariantCulture;
                        string innerExpression = expression.Substring(startIndex, endIndex - startIndex);
                        double innerResult = Convert.ToDouble(new System.Data.DataTable().Compute(innerExpression, ""));

                        double sqrtResult = Math.Atanh(innerResult);


                        expression = expression.Replace($"arctanh({innerExpression})", sqrtResult.ToString(culture));
                        expression = expression.Replace(",", ".");

                        if ((!expression.Contains("arccosh(")) && (!expression.Contains("arcsinh(")) && (!expression.Contains("tanh(")) && (!expression.Contains("cosh(")) && (!expression.Contains("sinh(")) && (!expression.Contains("exp(")) && (!expression.Contains("in(")) && (!expression.Contains("sqrt(")) && (!expression.Contains("cbrt(")) && (!expression.Contains("sin(")) && (!expression.Contains("cos(")) && (!expression.Contains("tan(")) && (!expression.Contains("arcSin(")) && (!expression.Contains("arcCos(")) && (!expression.Contains("arcTan(")))
                        {
                            result = Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
                        }
                    }
                }
                while (expression.Contains("arccosh("))
                {
                    int startIndex = expression.IndexOf("arccosh(") + 8;
                    int endIndex = expression.IndexOf(")", startIndex);

                    if (startIndex >= 0 && endIndex > startIndex)
                    {
                        CultureInfo culture = CultureInfo.InvariantCulture;
                        string innerExpression = expression.Substring(startIndex, endIndex - startIndex);
                        double innerResult = Convert.ToDouble(new System.Data.DataTable().Compute(innerExpression, ""));

                        double sqrtResult = Math.Acosh(innerResult);



                        expression = expression.Replace($"arccosh({innerExpression})", sqrtResult.ToString(culture));
                        expression = expression.Replace(",", ".");

                        if ((!expression.Contains("arcsinh(")) && (!expression.Contains("tanh(")) && (!expression.Contains("cosh(")) && (!expression.Contains("sinh(")) && (!expression.Contains("exp(")) && (!expression.Contains("in(")) && (!expression.Contains("sqrt(")) && (!expression.Contains("cbrt(")) && (!expression.Contains("sin(")) && (!expression.Contains("cos(")) && (!expression.Contains("tan(")) && (!expression.Contains("arcSin(")) && (!expression.Contains("arcCos(")) && (!expression.Contains("arcTan(")))
                        {
                            result = Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
                        }
                    }
                }
                while (expression.Contains("arcsinh("))
                {
                    int startIndex = expression.IndexOf("arcsinh(") + 8;
                    int endIndex = expression.IndexOf(")", startIndex);

                    if (startIndex >= 0 && endIndex > startIndex)
                    {
                        CultureInfo culture = CultureInfo.InvariantCulture;
                        string innerExpression = expression.Substring(startIndex, endIndex - startIndex);
                        double innerResult = Convert.ToDouble(new System.Data.DataTable().Compute(innerExpression, ""));

                        double sqrtResult = Math.Asinh(innerResult);



                        expression = expression.Replace($"arcsinh({innerExpression})", sqrtResult.ToString(culture));
                        expression = expression.Replace(",", ".");

                        if ((!expression.Contains("tanh(")) && (!expression.Contains("cosh(")) && (!expression.Contains("sinh(")) && (!expression.Contains("exp(")) && (!expression.Contains("in(")) && (!expression.Contains("sqrt(")) && (!expression.Contains("cbrt(")) && (!expression.Contains("sin(")) && (!expression.Contains("cos(")) && (!expression.Contains("tan(")) && (!expression.Contains("arcSin(")) && (!expression.Contains("arcCos(")) && (!expression.Contains("arcTan(")))
                        {
                            result = Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
                        }
                    }
                }
                //hyperbolic//
                while (expression.Contains("tanh("))
                {
                    int startIndex = expression.IndexOf("tanh(") + 5;
                    int endIndex = expression.IndexOf(")", startIndex);

                    if (startIndex >= 0 && endIndex > startIndex)
                    {
                        CultureInfo culture = CultureInfo.InvariantCulture;
                        string innerExpression = expression.Substring(startIndex, endIndex - startIndex);
                        double innerResult = Convert.ToDouble(new System.Data.DataTable().Compute(innerExpression, ""));
                        double sqrtResult = Math.Tanh(innerResult);

                        expression = expression.Replace($"tanh({innerExpression})", sqrtResult.ToString(culture));
                        expression = expression.Replace(",", ".");

                        if ((!expression.Contains("cosh(")) && (!expression.Contains("sinh(")) && (!expression.Contains("exp(")) && (!expression.Contains("in(")) && (!expression.Contains("sqrt(")) && (!expression.Contains("cbrt(")) && (!expression.Contains("sin(")) && (!expression.Contains("cos(")) && (!expression.Contains("tan(")) && (!expression.Contains("arcSin(")) && (!expression.Contains("arcCos(")) && (!expression.Contains("arcTan(")))
                        {
                            result = Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
                        }

                    }
                }

                while (expression.Contains("cosh("))
                {
                    int startIndex = expression.IndexOf("cosh(") + 5;
                    int endIndex = expression.IndexOf(")", startIndex);

                    if (startIndex >= 0 && endIndex > startIndex)
                    {
                        CultureInfo culture = CultureInfo.InvariantCulture;
                        string innerExpression = expression.Substring(startIndex, endIndex - startIndex);
                        double innerResult = Convert.ToDouble(new System.Data.DataTable().Compute(innerExpression, ""));
                        double sqrtResult = Math.Cosh(innerResult);


                        expression = expression.Replace($"cosh({innerExpression})", sqrtResult.ToString(culture));
                        expression = expression.Replace(",", ".");

                        if ((!expression.Contains("sinh(")) && (!expression.Contains("exp(")) && (!expression.Contains("in(")) && (!expression.Contains("sqrt(")) && (!expression.Contains("cbrt(")) && (!expression.Contains("sin(")) && (!expression.Contains("cos(")) && (!expression.Contains("tan(")) && (!expression.Contains("arcSin(")) && (!expression.Contains("arcCos(")) && (!expression.Contains("arcTan(")))
                        {
                            result = Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
                        }

                    }
                }

                while (expression.Contains("sinh("))
                {
                    int startIndex = expression.IndexOf("sinh(") + 5;
                    int endIndex = expression.IndexOf(")", startIndex);

                    if (startIndex >= 0 && endIndex > startIndex)
                    {
                        CultureInfo culture = CultureInfo.InvariantCulture;
                        string innerExpression = expression.Substring(startIndex, endIndex - startIndex);
                        double innerResult = Convert.ToDouble(new System.Data.DataTable().Compute(innerExpression, ""));
                        double sqrtResult = Math.Sinh(innerResult);


                        expression = expression.Replace($"sinh({innerExpression})", sqrtResult.ToString(culture));
                        expression = expression.Replace(",", ".");

                        if ((!expression.Contains("exp(")) && (!expression.Contains("in(")) && (!expression.Contains("sqrt(")) && (!expression.Contains("cbrt(")) && (!expression.Contains("sin(")) && (!expression.Contains("cos(")) && (!expression.Contains("tan(")) && (!expression.Contains("arcSin(")) && (!expression.Contains("arcCos(")) && (!expression.Contains("arcTan(")))
                        {
                            result = Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
                        }

                    }
                }

                while (expression.Contains("exp("))
                {
                    int startIndex = expression.IndexOf("exp(") + 4;
                    int endIndex = expression.IndexOf(")", startIndex);

                    if (startIndex >= 0 && endIndex > startIndex)
                    {
                        string innerExpression = expression.Substring(startIndex, endIndex - startIndex);
                        double innerResult = Convert.ToDouble(new System.Data.DataTable().Compute(innerExpression, ""));
                        double sqrtResult = Math.Exp(innerResult);


                        expression = expression.Replace($"exp({innerExpression})", sqrtResult.ToString());
                        expression = expression.Replace(",", ".");

                        if ((!expression.Contains("in(")) && (!expression.Contains("sqrt(")) && (!expression.Contains("cbrt(")) && (!expression.Contains("sin(")) && (!expression.Contains("cos(")) && (!expression.Contains("tan(")) && (!expression.Contains("arcSin(")) && (!expression.Contains("arcCos(")) && (!expression.Contains("arcTan(")))
                        {

                            result = Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
                        }
                    }
                }

                while (expression.Contains("In("))
                {
                    int startIndex = expression.IndexOf("In(") + 3;
                    int endIndex = expression.IndexOf(")", startIndex);

                    if (startIndex >= 0 && endIndex > startIndex)
                    {
                        string innerExpression = expression.Substring(startIndex, endIndex - startIndex);
                        double innerResult = Convert.ToDouble(new System.Data.DataTable().Compute(innerExpression, ""));
                        double sqrtResult = Math.Log(innerResult);

                        expression = expression.Replace($"In({innerExpression})", sqrtResult.ToString());
                        expression = expression.Replace(",", ".");

                        if ((!expression.Contains("sqrt(")) && (!expression.Contains("cbrt(")) && (!expression.Contains("sin(")) && (!expression.Contains("cos(")) && (!expression.Contains("tan(")) && (!expression.Contains("arcsin(")) && (!expression.Contains("arccos(")) && (!expression.Contains("arctan(")))
                        {

                            result = Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
                        }
                    }
                }

                while (expression.Contains("sqrt("))
                {
                    int startIndex = expression.IndexOf("sqrt(") + 5;
                    int endIndex = expression.IndexOf(")", startIndex);

                    if (startIndex >= 0 && endIndex > startIndex)
                    {
                        string innerExpression = expression.Substring(startIndex, endIndex - startIndex);
                        double innerResult = Convert.ToDouble(new System.Data.DataTable().Compute(innerExpression, ""));
                        double sqrtResult = Math.Sqrt(innerResult);

                        expression = expression.Replace($"sqrt({innerExpression})", sqrtResult.ToString());
                        expression = expression.Replace(",", ".");

                        if ((!expression.Contains("cbrt(")) && (!expression.Contains("sin(")) && (!expression.Contains("cos(")) && (!expression.Contains("tan(")) && (!expression.Contains("arcsin(")) && (!expression.Contains("arccos(")) && (!expression.Contains("arctan(")))
                        {

                            result = Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
                        }
                    }
                }
                if ((!expression.Contains("tanh(")) && (!expression.Contains("cosh(")) && (!expression.Contains("sinh(")) && (!expression.Contains("x=")) && (!expression.Contains("cbrt(")) && (!expression.Contains("sin(")) && (!expression.Contains("cos(")) && (!expression.Contains("tan(")) && (!expression.Contains("arcsin(")) && (!expression.Contains("arccos(")) && (!expression.Contains("arctan(")))
                {
                    result = Convert.ToDouble(new System.Data.DataTable().Compute(expression, null));
                }



                while (expression.Contains("cbrt("))
                {
                    int startIndex = expression.IndexOf("cbrt(") + 5;
                    int endIndex = expression.IndexOf(")", startIndex);

                    if (startIndex >= 0 && endIndex > startIndex)
                    {
                        string innerExpression = expression.Substring(startIndex, endIndex - startIndex);
                        double innerResult = Convert.ToDouble(new System.Data.DataTable().Compute(innerExpression, ""));
                        double sqrtResult = Math.Cbrt(innerResult);


                        expression = expression.Replace($"cbrt({innerExpression})", sqrtResult.ToString());
                        expression = expression.Replace(",", ".");

                        if ((!expression.Contains("sin(")) && (!expression.Contains("cos(")) && (!expression.Contains("tan(")) && (!expression.Contains("arcsin(")) && (!expression.Contains("arccos(")) && (!expression.Contains("arctan(")))
                        {
                            result = Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
                        }
                    }
                }


                while (expression.Contains("arccos("))
                {
                    int startIndex = expression.IndexOf("arccos(") + 7;
                    int endIndex = expression.IndexOf(")", startIndex);

                    if (startIndex >= 0 && endIndex > startIndex)
                    {
                        CultureInfo culture = CultureInfo.InvariantCulture;
                        string innerExpression = expression.Substring(startIndex, endIndex - startIndex);
                        double innerResult = Convert.ToDouble(new System.Data.DataTable().Compute(innerExpression, ""));

                        double sqrtResult = Math.Acos(innerResult);

                        double resultDegr;
                        if (raddeg == "degrees")
                        {
                            resultDegr = sqrtResult * (180.0 / Math.PI);
                        }
                        else
                        {
                            resultDegr = sqrtResult;
                        }



                        expression = expression.Replace($"arccos({innerExpression})", resultDegr.ToString(culture));
                        expression = expression.Replace(",", ".");

                        if ((!expression.Contains("arcsin(")) && (!expression.Contains("arctan(")) && (!expression.Contains("cos(")) && (!expression.Contains("tan(")) && (!expression.Contains("sin(")))
                        {
                            result = Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
                        }
                    }
                }

                while (expression.Contains("arcsin("))
                {
                    int startIndex = expression.IndexOf("arcsin(") + 7;
                    int endIndex = expression.IndexOf(")", startIndex);

                    if (startIndex >= 0 && endIndex > startIndex)
                    {
                        CultureInfo culture = CultureInfo.InvariantCulture;
                        string innerExpression = expression.Substring(startIndex, endIndex - startIndex);
                        double innerResult = Convert.ToDouble(new System.Data.DataTable().Compute(innerExpression, ""));

                        double sqrtResult = Math.Asin(innerResult);

                        double resultDegr;
                        if (raddeg == "degrees")
                        {
                            resultDegr = sqrtResult * (180.0 / Math.PI);
                        }
                        else
                        {
                            resultDegr = sqrtResult;
                        }


                        expression = expression.Replace($"arcsin({innerExpression})", resultDegr.ToString(culture));
                        expression = expression.Replace(",", ".");

                        if ((!expression.Contains("arctan(")) && (!expression.Contains("cos(")) && (!expression.Contains("tan(")) && (!expression.Contains("sin(")))
                        {
                            result = Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
                        }
                    }
                }


                while (expression.Contains("arctan("))
                {
                    int startIndex = expression.IndexOf("arctan(") + 7;
                    int endIndex = expression.IndexOf(")", startIndex);

                    if (startIndex >= 0 && endIndex > startIndex)
                    {
                        CultureInfo culture = CultureInfo.InvariantCulture;
                        string innerExpression = expression.Substring(startIndex, endIndex - startIndex);
                        double innerResult = Convert.ToDouble(new System.Data.DataTable().Compute(innerExpression, ""));

                        double sqrtResult = Math.Atan(innerResult);

                        double resultDegr;
                        if (raddeg == "degrees")
                        {
                            resultDegr = sqrtResult * (180.0 / Math.PI);
                        }
                        else
                        {
                            resultDegr = sqrtResult;
                        }


                        expression = expression.Replace($"arctan({innerExpression})", resultDegr.ToString(culture));
                        expression = expression.Replace(",", ".");
                        if ((!expression.Contains("cos(")) && (!expression.Contains("tan(")) && (!expression.Contains("sin(")))
                        {
                            result = Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
                        }
                    }
                }








                while (expression.Contains("sin("))
                {
                    int startIndex = expression.IndexOf("sin(") + 4;
                    int endIndex = expression.IndexOf(")", startIndex);

                    if (startIndex >= 0 && endIndex > startIndex)
                    {
                        CultureInfo culture = CultureInfo.InvariantCulture;
                        string innerExpression = expression.Substring(startIndex, endIndex - startIndex);
                        double innerResult = Convert.ToDouble(new System.Data.DataTable().Compute(innerExpression, ""));
                        double sqrtResult = Math.Sin(innerResult);
                        double resultDegr;
                        if (raddeg == "degrees")
                        {
                            resultDegr = Math.Sin(innerResult * (Math.PI / 180));
                        }
                        else
                        {
                            resultDegr = sqrtResult;
                        }

                        expression = expression.Replace($"sin({innerExpression})", resultDegr.ToString(culture));
                        expression = expression.Replace(",", ".");

                        if ((!expression.Contains("cos(")) && (!expression.Contains("tan(")))
                        {
                            result = Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
                        }
                    }
                }

                while (expression.Contains("cos("))
                {
                    int startIndex = expression.IndexOf("cos(") + 4;
                    int endIndex = expression.IndexOf(")", startIndex);

                    if (startIndex >= 0 && endIndex > startIndex)
                    {
                        CultureInfo culture = CultureInfo.InvariantCulture;
                        string innerExpression = expression.Substring(startIndex, endIndex - startIndex);
                        double innerResult = Convert.ToDouble(new System.Data.DataTable().Compute(innerExpression, ""));
                        double sqrtResult = Math.Cos(innerResult);
                        double resultDegr;
                        if (raddeg == "degrees")
                        {
                            resultDegr = Math.Cos(innerResult * (Math.PI / 180));
                        }
                        else
                        {
                            resultDegr = sqrtResult;
                        }


                        expression = expression.Replace($"cos({innerExpression})", resultDegr.ToString(culture));
                        expression = expression.Replace(",", ".");

                        if (!expression.Contains("tan("))
                        {
                            result = Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
                        }
                    }
                }
                while (expression.Contains("tan("))
                {
                    int startIndex = expression.IndexOf("tan(") + 4;
                    int endIndex = expression.IndexOf(")", startIndex);

                    if (startIndex >= 0 && endIndex > startIndex)
                    {
                        CultureInfo culture = CultureInfo.InvariantCulture;
                        string innerExpression = expression.Substring(startIndex, endIndex - startIndex);
                        double innerResult = Convert.ToDouble(new System.Data.DataTable().Compute(innerExpression, ""));
                        double sqrtResult = Math.Tan(innerResult);
                        double resultDegr;
                        if (raddeg == "degrees")
                        {
                            resultDegr = Math.Tan(innerResult * (Math.PI / 180));
                        }
                        else
                        {
                            resultDegr = sqrtResult;
                        }


                        expression = expression.Replace($"tan({innerExpression})", resultDegr.ToString(culture));
                        expression = expression.Replace(",", ".");
                        result = Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));

                    }
                }


                funcboard.AppendText(text: lineboard.Text + Environment.NewLine);
                funcboard.AppendText(text: "=" + result.ToString() + Environment.NewLine);
                ans = result.ToString();
                if (textcoloring == true)
                {
                    colorans();
                }
                lineboard.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(errorcalc + ex.Message, "Calculator Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
//Finish code//
