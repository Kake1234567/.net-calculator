
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FuncMatic
{
    public partial class Settings : Form
    {
        private Main form2;
        private string fontsizerr = "Fontti koon täytyy olla suurempi kuin 0";
        public Settings(Main form2)
        {
            InitializeComponent();
            Load += settings_Load;
            this.form2 = form2;
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
                    return null; // File does not exist
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
                    // Handle the case when the file doesn't exist
                    // You might want to throw an exception, create a new file, or take appropriate action.
                }
            }
        }
        private void settings_Load(object sender, EventArgs e)
        {
            string fileName = "settings.xml"; // The filename in isolated storage
            XmlDocument document = LoadXmlFileFromIsolatedStorage(fileName);
            XmlElement fontsizefele = document.SelectSingleNode("/settings/fontsizefboard") as XmlElement;
            XmlElement keyboardElement = document.SelectSingleNode("/settings/keyboard") as XmlElement;
            XmlElement textcolor = document.SelectSingleNode("/settings/iscoloron") as XmlElement;
            XmlElement themecolor = document.SelectSingleNode("/settings/calbackground") as XmlElement;
            XmlElement lang = document.SelectSingleNode("/settings/language") as XmlElement;
            int fontval = int.Parse(fontsizefele.InnerText);
            fontsize.Value = fontval;
            if (lang.InnerText == "En")
            {
                label4.Text = "Settings";
                label1.Text = "Font size";
                label2.Text = "Keyboard";
                label3.Text = "Text color";
                label5.Text = "Theme";
                label6.Text = "Language";
                closebtn.Text = "Close";
                fontsizerr = "Font size must be bigger than 0";

                //keyboardsel//
                keyboardsel.Items.Clear();
                keyboardsel.Items.Add("On");
                keyboardsel.Items.Add("Off");

                //text color//
                colorsel.Items.Clear();
                colorsel.Items.Add("On");
                colorsel.Items.Add("Off");

                //theme//
                themesel.Items.Clear();
                themesel.Items.Add("White");
                themesel.Items.Add("Purple");
                themesel.Items.Add("Green");
                themesel.Items.Add("Blue");
                themesel.Items.Add("Dark");
                themesel.Items.Add("Sand");

                //language//
                langsel.Items.Clear();
                langsel.Items.Add("Finnish");
                langsel.Items.Add("English");
                langsel.Items.Add("Spanish");
            }
            if (lang.InnerText == "Es")
            {
                label4.Text = "Ajustes";
                label1.Text = "Tamaño de fuente";
                label2.Text = "Teclado";
                label3.Text = "Color de texto";
                label5.Text = "Tema";
                label6.Text = "Idioma";
                closebtn.Text = "Cerca";
                fontsizerr = "El tamaño de fuente debe ser mayor que 0";

                //keyboardsel//
                keyboardsel.Items.Clear();
                keyboardsel.Items.Add("En");
                keyboardsel.Items.Add("Apagado");

                //text color//
                colorsel.Items.Clear();
                colorsel.Items.Add("En");
                colorsel.Items.Add("Apagado");

                //theme//
                themesel.Items.Clear();
                themesel.Items.Add("Blanco");
                themesel.Items.Add("Morado");
                themesel.Items.Add("Verde");
                themesel.Items.Add("Azul");
                themesel.Items.Add("Oscuro");
                themesel.Items.Add("Arena");

                //language//
                langsel.Items.Clear();
                langsel.Items.Add("Finlandés");
                langsel.Items.Add("Inglés");
                langsel.Items.Add("Español");
            }
            if (keyboardElement.InnerText == "On")
            {
                keyboardsel.SelectedIndex = 0;
            }
            else
            {
                keyboardsel.SelectedIndex = 1;
            }
            if (textcolor.InnerText == "On")
            {
                colorsel.SelectedIndex = 0;
            }
            else
            {
                colorsel.SelectedIndex = 1;
            }
            if (themecolor.InnerText == "white")
            {
                themesel.SelectedIndex = 0;
            }
            if (themecolor.InnerText == "purple")
            {
                themesel.SelectedIndex = 1;
            }
            if (themecolor.InnerText == "green")
            {
                themesel.SelectedIndex = 2;
            }
            if (themecolor.InnerText == "blue")
            {
                themesel.SelectedIndex = 3;
            }
            if (themecolor.InnerText == "dark")
            {
                themesel.SelectedIndex = 4;
            }
            if (themecolor.InnerText == "sand")
            {
                themesel.SelectedIndex = 5;
            }
            if (lang.InnerText == "En")
            {
                langsel.SelectedIndex = 1;
            }
            if (lang.InnerText == "Fin")
            {
                langsel.SelectedIndex = 0;
            }
            if (lang.InnerText == "Es")
            {
                langsel.SelectedIndex = 2;
            }
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = "settings.xml"; // The filename in isolated storage
                XmlDocument document = LoadXmlFileFromIsolatedStorage(fileName);
                XmlElement fontsizefele = document.SelectSingleNode("/settings/fontsizefboard") as XmlElement;
                XmlElement keyboardElement = document.SelectSingleNode("/settings/keyboard") as XmlElement;
                XmlElement textcolor = document.SelectSingleNode("/settings/iscoloron") as XmlElement;
                XmlElement themecolor = document.SelectSingleNode("/settings/calbackground") as XmlElement;
                XmlElement lang = document.SelectSingleNode("/settings/language") as XmlElement;

                if (themesel.SelectedIndex == 0)
                {
                    themecolor.InnerText = "white";
                    form2.setTheme("white");
                }
                if (themesel.SelectedIndex == 1)
                {
                    themecolor.InnerText = "purple";
                    form2.setTheme("purple");
                }
                if (themesel.SelectedIndex == 2)
                {
                    themecolor.InnerText = "green";
                    form2.setTheme("green");
                }
                if (themesel.SelectedIndex == 3)
                {
                    themecolor.InnerText = "blue";
                    form2.setTheme("blue");
                }
                if (themesel.SelectedIndex == 4)
                {
                    themecolor.InnerText = "dark";
                    form2.setTheme("dark");
                }
                if (themesel.SelectedIndex == 5)
                {
                    themecolor.InnerText = "sand";
                    form2.setTheme("sand");
                }
                if (langsel.SelectedIndex == 0)
                {
                    lang.InnerText = "Fin";
                    form2.setLang("Fin");
                }
                if (langsel.SelectedIndex == 1)
                {
                    lang.InnerText = "En";
                    form2.setLang("En");
                }
                if (langsel.SelectedIndex == 2)
                {
                    lang.InnerText = "Es";
                    form2.setLang("Es");
                }


                if (fontsize.Value > 0)
                {

                    string fontval = fontsize.Value.ToString();
                    fontsizefele.InnerText = fontval;

                    if (keyboardsel.SelectedIndex == 0)
                    {
                        if (keyboardsel.SelectedIndex == 0 && keyboardElement.InnerText != "On")
                        {
                            form2.keyboardseton = true.ToString();
                        }
                        keyboardElement.InnerText = "On";
                    }
                    if (keyboardsel.SelectedIndex == 1)
                    {
                        if (keyboardsel.SelectedIndex == 1 && keyboardElement.InnerText != "Off")
                        {
                            form2.keyboardseton = true.ToString();
                        }
                        keyboardElement.InnerText = "Off";
                    }

                    if (colorsel.SelectedIndex == 0)
                    {
                        textcolor.InnerText = "On";
                    }
                    if (colorsel.SelectedIndex == 1)
                    {
                        textcolor.InnerText = "Off";
                    }
                    if (colorsel.SelectedIndex == 0)
                    {
                        form2.TextColorapplied = true.ToString();
                    }
                    if (colorsel.SelectedIndex == 1)
                    {
                        form2.TextColorapplied = false.ToString();
                    }
                    int exportnewfont = Convert.ToInt32(fontval);
                    Font newFont = new Font("Arial", exportnewfont, FontStyle.Regular); // Example font
                    form2.SetFuncBoardFont(newFont);
                    UpdateXmlFileInIsolatedStorage(document, fileName);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(fontsizerr, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            catch
            {

            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
