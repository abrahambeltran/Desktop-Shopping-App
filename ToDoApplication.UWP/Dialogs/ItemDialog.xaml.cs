using Library.TaskManagement.Services;
using ToDoApplication.UWP.ViewModels;
using Windows.UI.Xaml.Controls;


// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ToDoApplication.UWP.Dialogs
{
    public sealed partial class ItemDialog : ContentDialog
    {
        public ItemDialog()
        {
            this.InitializeComponent();

            this.DataContext = new ItemViewModel();
        }

        public ItemDialog(ItemViewModel ivm)
        {
            this.InitializeComponent();
            this.DataContext = ivm;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //step 1: coerce datacontext into view model
            var viewModel = DataContext as ItemViewModel;

            //step 2: use a conversion constructor from view model -> todo

            //step 3: interact with the service using models;
            ItemService.Current.AddOrUpdate(viewModel.BoundItem);
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
