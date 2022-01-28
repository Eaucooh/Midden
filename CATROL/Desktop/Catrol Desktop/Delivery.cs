using System;
using System.Configuration;

namespace Catrol_Desktop
{
    public class Delivery
    {
        //ExeConfigurationFileMap map = new ExeConfigurationFileMap();
        //Configuration config;
        
        public int Chorme_Navigater_Width_Minimize = 40;
        public int Chorme_Navigater_Width_Maximize = 200;
        public int Chrome_Navigater_MissionList_SearchBar_Holder_Height_Minimize = 0;
        public int Chrome_Navigater_MissionList_SearchBar_Holder_Height_Maximize = 40;
        public int Chrome_Width_Increace = 200;
        public int Chrome_Height_Increace = 100;
        public double Chrome_Opacity_Minimize = 0.0;
        public double Chrome_Opacity_Maximize = 1.0;

        public bool IsCloserToClose = true;
        public string Maximizer_Content = "";
        public string Restorer_Content = "";
        public double LastLocation_Top = 10;
        public double LastLocation_Left = 10;
        public double Width = 1020;
        public double Height = 620;

        public Delivery()
        {
            Chorme_Navigater_Width_Minimize = Convert.ToInt32(ConfigurationManager.AppSettings["Chrome_Navigater_Width_Minimize"]);
            Chorme_Navigater_Width_Maximize = Convert.ToInt32(ConfigurationManager.AppSettings["Chrome_Navigater_Width_Maximize"]);
            LastLocation_Top = Convert.ToDouble(ConfigurationManager.AppSettings["Top"]);
            LastLocation_Left = Convert.ToDouble(ConfigurationManager.AppSettings["Left"]);
            Width = Convert.ToDouble(ConfigurationManager.AppSettings["Width"]);
            Height = Convert.ToDouble(ConfigurationManager.AppSettings["Height"]);
        }

        //public Delivery(string config_path)
        //{
        //    map.ExeConfigFilename = config_path;
        //    config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
        //    //string connstr = config.ConnectionStrings.ConnectionStrings["connStr"].ConnectionString;
        //    //string key = config.AppSettings.Settings["key"].Value;

        //    Chorme_Navigater_Width_Minimize = Convert.ToInt32(config.ConnectionStrings.ConnectionStrings["Chrome_Navigater_Width_Minimize"].ConnectionString);
        //    Chorme_Navigater_Width_Maximize = Convert.ToInt32(config.ConnectionStrings.ConnectionStrings["Chorme_Navigater_Width_Maximize"].ConnectionString);
        //    LastLocation_Top = Convert.ToDouble(config.ConnectionStrings.ConnectionStrings["Top"].ConnectionString);
        //    LastLocation_Left = Convert.ToDouble(config.ConnectionStrings.ConnectionStrings["Left"].ConnectionString);
        //}

        public void Dispose()
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings["Top"].Value = LastLocation_Top.ToString();
            cfa.AppSettings.Settings["Left"].Value = LastLocation_Left.ToString();
            cfa.AppSettings.Settings["Chrome_Navigater_Width_Minimize"].Value = Chorme_Navigater_Width_Minimize.ToString();
            cfa.AppSettings.Settings["Chrome_Navigater_Width_Maximize"].Value = Chorme_Navigater_Width_Maximize.ToString();
            cfa.AppSettings.Settings["Chrome_Navigater_MissionList_SearchBar_Holder_Height_Minimize"].Value = Chrome_Navigater_MissionList_SearchBar_Holder_Height_Minimize.ToString();
            cfa.AppSettings.Settings["Chrome_Navigater_MissionList_SearchBar_Holder_Height_Maximize"].Value = Chrome_Navigater_MissionList_SearchBar_Holder_Height_Maximize.ToString();
            cfa.AppSettings.Settings["Width"].Value = Width.ToString();
            cfa.AppSettings.Settings["Height"].Value = Height.ToString();
            cfa.Save(ConfigurationSaveMode.Minimal);
        }
    }
}