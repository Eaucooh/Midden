using System;
using System.Reflection;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Forms;

namespace CnBlogs.Youzai.ScreenKeyboard {
    partial class AboutBox : Form {
        public AboutBox() {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.linkCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0) {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "") {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion {
            get {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0) {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0) {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0) {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0) {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        #region Event handlers

        private void LinkCompanyNameOnLinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            RegistryKey regKey = Registry.LocalMachine;
            string key = @"SOFTWARE\Classes\Applications\iexplore.exe\shell\open\command";
            regKey = regKey.OpenSubKey(key, false);

            if (regKey != null) {
                string value = regKey.GetValue(string.Empty, string.Empty).ToString();
                regKey.Close();
                if (!string.IsNullOrEmpty(value)) {
                    int index = value.IndexOf('%');
                    if (index >= 0) {
                        value = value.Substring(0, index);
                        value = value.Replace("\"", string.Empty);
                        Process process = new Process();
                        process.StartInfo.FileName = value.Trim();
                        process.StartInfo.Arguments = this.linkCompanyName.Text.Trim();
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                        try {
                            process.Start();
                        } catch (Exception) {
                        } finally {
                            process.Close();
                        }
                    }
                }
            }
        }

        #endregion
    }
}
