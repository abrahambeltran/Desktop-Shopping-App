using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToDoApplication.UWP.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ToDoApplication.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {


        public MainPage()
        {
            this.InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).Refresh();
        }

        private async void Add_Task_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            if (vm != null)
            {
                await vm.Add(ItemType.Task);
            }
        }

        private async void Add_App_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            if (vm != null)
            {
                await vm.Add(ItemType.Appointment);
            }
        }

        private async void Add_Item_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            if (vm != null)
            {
                await vm.Add(ItemType.Item);
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            if (vm != null)
            {
                vm.Remove();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            if (vm != null)
            {
                vm.Update();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).Save();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).Load();
        }
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SecondaryPage));
        }
        private void TotalSort(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).Sort("totalSort");
        }
        private void NameSort(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).Sort("nameSort");
        }
        private void UnitSort(object sender, RoutedEventArgs e)
        {

            (DataContext as MainViewModel).Sort("unitSort");
        }
    }
}
