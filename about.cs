using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FuncMatic
{
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
            loadLang();
            iconslink.LinkClicked += new LinkLabelLinkClickedEventHandler(iconslink_LinkClicked);
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

        private void iconslink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var parameter = new ProcessStartInfo { Verb = "open", FileName = "explorer", Arguments = "https://icons8.com" };
            Process.Start(parameter);
        }
        private void loadLang()
        {
            string fileName = "settings.xml"; // The filename in isolated storage
            XmlDocument document = LoadXmlFileFromIsolatedStorage(fileName);
            XmlElement lang = document.SelectSingleNode("/settings/language") as XmlElement;
            if (lang.InnerText == "En")
            {
                label4.Text = "Information";
                label3.Text = "-FuncMatic is lisensed under GPL -license\r\n\r\n-FuncMatic is completely free calculator\r\n\r\n-Maintaner of this calculator is KAKE \r\n";
                label1.Text = "All icons";
            }
            if (lang.InnerText == "Es")
            {
                label4.Text = "información";
                label3.Text = "-FuncMatic tiene licencia GPL -licencia\r\n\r\n-FuncMatic es una calculadora\r\n completamente gratuita\r\n\r\n-La aplicación es mantenida y actualizada\r\n por KAKE \r\n\r\n";
                label1.Text = "Todos los iconos";
            }
        }
    }
}
