using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToDoApplication.UWP.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ToDoApplication.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SecondaryPage : Page
    {
        private string fileName;

        public SecondaryPage()
        {
            this.InitializeComponent();
            DataContext = new CartViewModel();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as CartViewModel).Refresh();
        }

        private async void Add_Task_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as CartViewModel;
            if (vm != null)
            {
                await vm.Add(ItemType.Item);
            }
        }

        private async void Add_App_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as CartViewModel;
            if (vm != null)
            {
                await vm.Add(ItemType.Appointment);
            }
        }

        private async void Add_Item_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as CartViewModel;
            if (vm != null)
            {
                await vm.Add(ItemType.Item);
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as CartViewModel;
            if (vm != null)
            {
                vm.Remove();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as CartViewModel;
            if (vm != null)
            {
                vm.Update();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as CartViewModel).Save(fileName);
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as CartViewModel).Load(fileName);
        }
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        private void TotalSort(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).Refresh();     //Sort("totalSort");
        }
        private void NameSort(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).Refresh();     //Sort("nameSort");
        }
        
    }
}
