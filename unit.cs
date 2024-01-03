
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
    public partial class unit : Form
    {
        private Main form2;
        private string differenterr = "Muutettava arvo ja uusi arvo evät voi olla samat";
        private string valerr = "Valitse arvot";
        public unit(Main form2)
        {
            InitializeComponent();
            loadLang();
            this.form2 = form2;
            quantsel.SelectedIndexChanged += quantsel_SelectedIndexChanged;
            quantsel.SelectedIndex = 0;
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void loadLang()
        {
            string fileName = "settings.xml"; 
            XmlDocument document = LoadXmlFileFromIsolatedStorage(fileName);
            XmlElement lang = document.SelectSingleNode("/settings/language") as XmlElement;
            if(lang.InnerText == "En")
            {
                label1.Text = "Unit conversion";
                label4.Text = "Quantity";
                label2.Text = "From";
                label3.Text = "To";

                //quantity sel//
                quantsel.Items.Clear();
                quantsel.Items.Add("Measure");
                quantsel.Items.Add("Square");
                quantsel.Items.Add("Cube");
                quantsel.Items.Add("Time");
                closebtn.Text = "Close";
                differenterr = "New unit cannot be same as old unit";
                valerr = "Select values";
            }
            if (lang.InnerText == "Es")
            {
                label1.Text = "Conversión de unidades";
                label4.Text = "Cantidad";
                label2.Text = "De";
                label3.Text = "A";

                //quantity sel//
                quantsel.Items.Clear();
                quantsel.Items.Add("Medida");
                quantsel.Items.Add("Cuadrado");
                quantsel.Items.Add("Cubo");
                quantsel.Items.Add("Tiempo");
                closebtn.Text = "Cerca";
                differenterr = "La nueva unidad no puede ser igual a la antigua";
                valerr = "Seleccionar valores";
            }
        }

        private void quantsel_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (quantsel.SelectedIndex == 0)
            {
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();

                comboBox1.Items.Add("mm");
                comboBox1.Items.Add("cm");
                comboBox1.Items.Add("dm");
                comboBox1.Items.Add("m");
                comboBox1.Items.Add("dam");
                comboBox1.Items.Add("hm");
                comboBox1.Items.Add("km");
                comboBox1.Items.Add("mi");
                comboBox1.Items.Add("ft");
                comboBox1.Items.Add("in");

                comboBox2.Items.Add("mm");
                comboBox2.Items.Add("cm");
                comboBox2.Items.Add("dm");
                comboBox2.Items.Add("m");
                comboBox2.Items.Add("dam");
                comboBox2.Items.Add("hm");
                comboBox2.Items.Add("km");
                comboBox2.Items.Add("mi");
                comboBox2.Items.Add("ft");
                comboBox2.Items.Add("in");
            }
            if (quantsel.SelectedIndex == 1)
            {
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();

                comboBox2.Items.Add("mm2");
                comboBox2.Items.Add("cm2");
                comboBox2.Items.Add("dm2");
                comboBox2.Items.Add("m2");
                comboBox2.Items.Add("a");
                comboBox2.Items.Add("ha");
                comboBox2.Items.Add("km2");

                comboBox1.Items.Add("mm2");
                comboBox1.Items.Add("cm2");
                comboBox1.Items.Add("dm2");
                comboBox1.Items.Add("m2");
                comboBox1.Items.Add("a");
                comboBox1.Items.Add("ha");
                comboBox1.Items.Add("km2");
            }
            if (quantsel.SelectedIndex == 2)
            {
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();

                comboBox2.Items.Add("mm3");
                comboBox2.Items.Add("cm3");
                comboBox2.Items.Add("dm3");
                comboBox2.Items.Add("m3");
                comboBox2.Items.Add("dam3");
                comboBox2.Items.Add("hm3");
                comboBox2.Items.Add("km3");


                comboBox1.Items.Add("mm3");
                comboBox1.Items.Add("cm3");
                comboBox1.Items.Add("dm3");
                comboBox1.Items.Add("m3");
                comboBox1.Items.Add("dam3");
                comboBox1.Items.Add("hm3");
                comboBox1.Items.Add("km3");
            }
            if (quantsel.SelectedIndex == 3)
            {
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();

                comboBox1.Items.Add("s");
                comboBox1.Items.Add("min");
                comboBox1.Items.Add("h");

                comboBox2.Items.Add("s");
                comboBox2.Items.Add("min");
                comboBox2.Items.Add("h");
            }

        }

        private void okbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
                {
                    if (comboBox1.SelectedItem.ToString() != comboBox2.SelectedItem.ToString())
                    {
                        string fuReplacement = comboBox1.SelectedItem.ToString();
                        string suReplacement = comboBox2.SelectedItem.ToString();

                        string unitc = "unit(fu_ans=su)";

                        unitc = unitc.Replace("fu", fuReplacement);
                        unitc = unitc.Replace("su", suReplacement);

                        form2.LineboardValue = unitc;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(differenterr);
                    }
                }
                else
                {
                    MessageBox.Show(valerr);
                }
            }
            catch
            {
                MessageBox.Show(valerr);
            }
        }

    }
}
