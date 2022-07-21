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
    public class CartViewModel : INotifyPropertyChanged
    {
        public string Query { get; set; }
        public string fileName { get; set; }
        public int Amount { get; set; }
        public ItemViewModel SelectedItem { get; set; }
        private ItemService _itemService;
        public bool IsSortByName { get; set; }
        MainViewModel inventoryInstance = new MainViewModel();

        public ObservableCollection<ItemViewModel> Cart
        {
            get
            {
                IEnumerable<ItemViewModel> returnList = null;
                if (_itemService == null)
                {
                    return new ObservableCollection<ItemViewModel>();
                }

                if (string.IsNullOrEmpty(Query))
                {
                    returnList = _itemService.Cart.Select(i => new ItemViewModel(i));
                }
                else
                {
                    returnList = _itemService.Cart.Where(i => i.Name.ToUpper().Contains(Query.ToUpper())
                            || i.Description.ToUpper().Contains(Query.ToUpper()))
                        .Select(i => new ItemViewModel(i));
                }

                if (IsSortByName)
                {
                    return new ObservableCollection<ItemViewModel>(returnList.OrderBy(i => i.Name));
                }
                return new ObservableCollection<ItemViewModel>(returnList);
            }
        }

        public ObservableCollection<ItemViewModel> inventoryList {
            get
            {
                return inventoryInstance.GetList;
            }
        }



        public CartViewModel()
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
            
            if (iType == ItemType.Item)
            {
                diag = new AddToCartDialog(SelectedItem);
            }
            else
            {
                throw new NotImplementedException();
            }

            await diag.ShowAsync();
            NotifyPropertyChanged("Cart");
            NotifyPropertyChanged("Items");
        }

        public void Remove()
        {
            var id = SelectedItem?.Id ?? -1;
            if (id >= 1)
            {
                _itemService.DeleteFromCart(SelectedItem.Id);
            }
            NotifyPropertyChanged("Cart");
        }

        public async void Update()
        {
            if (SelectedItem != null)
            {
                ContentDialog diag = new ItemDialog(SelectedItem);
                //if(SelectedItem.IsToDo)
                //{
                //    diag = new ToDoDialog(SelectedItem.BoundToDo);
                //} else if(SelectedItem.IsAppointment)
                //{
                //    diag = new AppointmentDialog(SelectedItem.BoundAppointment);
                //}



                await diag.ShowAsync();
                NotifyPropertyChanged("Cart");
            }
        }

        public void Save(String s)
        {

            ContentDialog diag = new ItemDialog(SelectedItem);
            fileName = s;
            _itemService.SaveCart(fileName);
        }

        public void Load(String fileName)
        {
            _itemService.LoadCart(fileName);
            NotifyPropertyChanged("Cart");
        }

        public void Refresh()
        {
            NotifyPropertyChanged("Cart");
        }
        public void Sort(String s)
        {
            IEnumerable<ItemViewModel> returnListish = null;
            if (s == null)
            {
                return;
            }
            if (s == "totalSort")
            {
                returnListish = _itemService.Cart.Where(i => i.Name.ToUpper().Contains(Query.ToUpper())
                            || i.Description.ToUpper().Contains(Query.ToUpper()))
                        .Select(i => new ItemViewModel(i));
            }
            if (s == "nameSort")
            {

            }
        }
    }
    
}
