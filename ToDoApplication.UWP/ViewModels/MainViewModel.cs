using Library.TaskManagement.Models;
using Library.TaskManagement.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ToDoApplication.UWP.Dialogs;
using Windows.UI.Xaml.Controls;

namespace ToDoApplication.UWP.ViewModels
{
    /*public class CombineViewModel
    {
        public MainViewModel A { get; set; }
        public CartViewModel B { get; set; }
    }*/
    public class MainViewModel : INotifyPropertyChanged
    {

        public string Query { get; set; }
        public ItemViewModel SelectedItem { get; set; }
        private ItemService _itemService;
        public bool IsSortByName { get; set; }
        
        public ObservableCollection<ItemViewModel> Items
        {
            get
            {
                IEnumerable<ItemViewModel> returnList = null; 
                if (_itemService == null)
                {
                    return new ObservableCollection<ItemViewModel>();
                }

                if(string.IsNullOrEmpty(Query))
                {
                    returnList = _itemService.Items.Select(i => new ItemViewModel(i));
                } else
                {
                    returnList = _itemService.Items.Where(i => i.Name.ToUpper().Contains(Query.ToUpper())
                            || i.Description.ToUpper().Contains(Query.ToUpper()))
                        .Select(i => new ItemViewModel(i));
                }
                
                if(IsSortByName)
                {
                    return new ObservableCollection<ItemViewModel>(returnList.OrderBy(i => i.Name));
                }

                return new ObservableCollection<ItemViewModel>(returnList);
            }
        }

        public ObservableCollection<ItemViewModel> GetList
        {
            get { return ObservableCollection<ItemViewModel> Items; }
        }

        public MainViewModel()
        {
            _itemService = ItemService.Current;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task Add(ItemType iType)
        {
            ContentDialog diag = null;
            if(iType == ItemType.Task)
            {
                diag = new ToDoDialog();
            } else if(iType == ItemType.Appointment)
            {
                diag = new AppointmentDialog();
            } else if (iType == ItemType.Item)
            {
                diag = new ItemDialog();
            }else
            {
                throw new NotImplementedException();
            }

            await diag.ShowAsync();
            NotifyPropertyChanged("Items");
        }

        public void Remove()
        {
            var id = SelectedItem?.Id ?? -1;
            if(id >= 1)
            {
                _itemService.Delete(SelectedItem.Id);
            }
            NotifyPropertyChanged("Items");
        }

        public async void Update()
        {
            if(SelectedItem != null)
            {
                ContentDialog diag = new ItemDialog(SelectedItem);
                if(SelectedItem.IsToDo)
                {
                    diag = new ToDoDialog(SelectedItem.BoundToDo);
                } else if(SelectedItem.IsAppointment)
                {
                    diag = new AppointmentDialog(SelectedItem.BoundAppointment);
                }

                await diag.ShowAsync();
                NotifyPropertyChanged("Items");
            }

        }

        public void Save()
        {
            string filename = null;
            
            ContentDialog diag = new ItemDialog(SelectedItem);
            
            _itemService.Save(filename);
        }

        public void Load()
        {
            _itemService.Load(null);
            NotifyPropertyChanged("Items");
        }

        public void Refresh()
        {
            NotifyPropertyChanged("Items");
        }
        public void Sort(String s)
        {
            if(s == null)
            {
                return;
            }
            if(s == "totalSort")
            {

            }
            if(s == "unitSort")
            {

            }
            if(s == "nameSort")
            {

            }
        }
    }
    

        /**/
        public enum ItemType{
        Task, Appointment, Item
    }
}