using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Media;

namespace netwatch.Gadget
{
    public partial class SelectAdaptorDialog
    {
        public ObservableCollection<AdaptorItem> ListOfAllAdaptors = new ObservableCollection<AdaptorItem>();

        public SelectAdaptorDialog()
        {
            InitializeComponent();

            NetworkInterface[] listOfAllIntefaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface _interface in listOfAllIntefaces)
            {
                if (_interface.OperationalStatus == OperationalStatus.Up &&
                    !_interface.Name.ToLower().Contains("loopback"))
                    GetListOfAdaptors.Add(new AdaptorItem(_interface.Name, _interface));
            }
        }

        public ObservableCollection<AdaptorItem> GetListOfAdaptors
        {
            get { return ListOfAllAdaptors; }
        }

        private void BtnCancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnOkClick(object sender, RoutedEventArgs e)
        {
            List<NetworkInterface> displayList = (from object currentItem in lstBoxInterfaces.Items
                                                  select currentItem as AdaptorItem
                                                  into item
                                                  where item != null && item.IsSelected
                                                  select item.NetInterface).ToList();
            if (displayList.Count == 0)
            {
                lblHint.Foreground = Brushes.Tomato;
                return;
            }

            var gadget = new DesktopGadget();

            //Generate String for Title!
            string title = displayList.Aggregate("", (current, @interface) => current + (@interface.Description + ", "));

            title = title.Remove(title.Length - 1);
            title = title.Remove(title.Length - 1);

            gadget.Title = title;

            if (chkBox_TopMost.IsChecked == true)
                gadget.Topmost = true;

            gadget.DoStart(displayList);

            gadget.Show();
            Close();
        }
    }
}