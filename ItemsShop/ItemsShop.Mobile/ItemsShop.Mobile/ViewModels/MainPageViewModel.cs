using ItemsShop.Mobile.Models;
using ItemsShop.Mobile.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ItemsShop.Mobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel()
        {
            Initialize();
        }

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set { SetProperty(ref products, value); }
        }

        private ObservableCollection<Product> products;

        private async Task Initialize()
        {
            IsBusy = true;
            HttpResponseMessage response = await HttpClientService.Instance.GetAsync("api/product");
            if (response.IsSuccessStatusCode)
            {
                string rawMessage = await response.Content.ReadAsStringAsync();
                Products = JsonConvert.DeserializeObject<ObservableCollection<Product>>(rawMessage);
            }

            IsBusy = false;
        }
    }
}
