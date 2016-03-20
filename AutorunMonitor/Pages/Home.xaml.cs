using AutorunMonitor.TMC;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.IO;
using System.Threading;
using System.Timers;
using System.Xml.Serialization;

namespace AutorunMonitor.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public List<RegisterModel>  RegisterList = null;
        public RegistryKey          RegisterKey = null;

        public Home()
        {
            InitializeComponent();
            this.RegisterList = new List<RegisterModel>();

            this.GenerateNewRows();

        }


        #region Function

        public void GenerateNewRows()
        {
            this.GenerateRegistryKey();
            this.GenerateList();
            this.LoadListToDataGrid(this.RegisterList);
        }



        private void GenerateRegistryKey()
        {
            String Path = ConfigurationManager.AppSettings.Get("RegisterSection");

            this.RegisterKey = Registry.CurrentUser.OpenSubKey(Path, RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
        }



        private void GenerateList()
        {
            //Clear old items
            this.RegisterList.Clear();

            string[] RegisterKeys = this.RegisterKey.GetValueNames();

            int count = 0;

            while (count != RegisterKey.ValueCount)
            {
                string RegKey = null;
                string RegValue = null;

                RegKey = RegisterKeys[count];
                RegValue = RegisterKey.GetValue(RegisterKeys[count]).ToString();

                this.RegisterList.Add(new RegisterModel { Key = RegKey, Value = RegValue });
                count++;
            }
        }



        private void LoadListToDataGrid(List<RegisterModel> List)
        {
            this.RegisterField_DG.ItemsSource = null;
            this.RegisterField_DG.ItemsSource = List;
        }



        private RegisterModel GetSelectedRow()
        {
            return this.RegisterField_DG.SelectedValue as RegisterModel;
        }



        private bool RemoveRegisterField()
        {
            RegisterModel currentRegister = GetSelectedRow();

            if (currentRegister != null)
            {
                this.RegisterKey.DeleteValue(currentRegister.Key);
                MessageBox.Show("Success!");
                return true;
            }
            else
            {
                MessageBox.Show("No Selected Items!");
                return false;
            }
        }



        private bool AddRegisterField()
        {

            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == true)
            {
                this.RegisterKey.CreateSubKey(ofd.FileName);
                this.RegisterKey.SetValue("AUTOLOAD_" + ofd.SafeFileName, '"' + ofd.FileName + '"');

                MessageBox.Show("Success!");

                return true;
            }
            else
            {
                MessageBox.Show("No file selected!");
                return true;
            }

        }



        private void WriteCurrentAutorun()
        {
            XmlSerializer xs = new XmlSerializer(typeof(RegisterModel));

            int i = 0;

            foreach (RegisterModel item in this.RegisterList)
            {
                TextWriter tw = new StreamWriter(@"C:\Users\Yaroslav\Documents\Visual Studio 2013\Projects\AutorunMonitor\Store\store" + i + ".xml");

                xs.Serialize(tw, item);

                tw.WriteLine('\0');
                tw.Close();

                ++i;
            }

        }



        private void CompareAutorun()
        {
            XmlSerializer xs = new XmlSerializer(typeof(RegisterModel));

            try
            {
                for (int i = 0; i < this.RegisterList.Count; i++)
                {
                    TextReader sr = new StreamReader(String.Format(@"C:\Users\Yaroslav\Documents\Visual Studio 2013\Projects\AutorunMonitor\Store\store{0}.xml", i));

                    RegisterModel LastItemAutorun = (RegisterModel)xs.Deserialize(sr);

                    sr.Close();

                    if (this.RegisterList[i].Equals(LastItemAutorun))
                    {
                        Console.WriteLine("Object # " + i + " equal!");
                    }
                    else
                    {
                        Console.WriteLine("Object # " + i + " not equal!");
                        throw new InvalidProgramException();
                    }

                }

                MessageBox.Show("Autorun Equel!");

            }
            catch
            {
                MessageBox.Show("Autorun defferent!");
            }

        }

        #endregion


        #region Event

        private void Add_B_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (this.AddRegisterField())
                {
                    //Refresh data
                    this.GenerateNewRows();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void Remove_B_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (this.RemoveRegisterField())
                {
                    //Refresh data
                    this.GenerateNewRows();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void Refresh_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.GenerateNewRows();
        }



        private void Save_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            WriteCurrentAutorun();
        }



        private void Compare_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.CompareAutorun();
        }




        private void RegisterField_DG_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case System.Windows.Input.Key.D:

                    try
                    {
                        if (this.RemoveRegisterField())
                        {
                            //Refresh data
                            this.GenerateNewRows();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    break;
                case System.Windows.Input.Key.Insert:
                    try
                    {
                        if (this.AddRegisterField())
                        {
                            //Refresh data
                            this.GenerateNewRows();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }

        }

        #endregion

    }
}
