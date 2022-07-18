using Library.TaskManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Mobile.Dialogs;
using Xamarin.Forms;

namespace ToDoApplication.Mobile
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public ObservableCollection<Item> Items { get; set; }
        public string Query { get; set; }
        public MainPage()
        {
            InitializeComponent();
            Items = new ObservableCollection<Item>();
            BindingContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Search_Clicked(object sender, EventArgs e)
        {
            Items.Add(new ToDo { Name = Query, Description = "TEST"});
            Query = null;
            NotifyPropertyChanged("Query");
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ToDoDialog());
        }
    }
}
