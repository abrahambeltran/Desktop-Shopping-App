using Library.TaskManagement.Models;
using Library.TaskManagement.Services;
using ToDoApplication.UWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ToDoApplication.UWP.Dialogs
{
    public sealed partial class AppointmentDialog : ContentDialog
    {
        public AppointmentDialog()
        {
            this.InitializeComponent();
            this.DataContext = new ItemViewModel();
        }

        public AppointmentDialog(Item selectedItem)
        {
            this.InitializeComponent();
            this.DataContext = selectedItem;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //step 1: coerce datacontext into view model
            var viewModel = DataContext as ItemViewModel;

            //step 2: use a conversion constructor from view model -> todo

            //step 3: interact with the service using models;
            
            ItemService.Current.AddOrUpdate(DataContext as Appointment);
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }
    }
}
