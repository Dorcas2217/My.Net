using Examen_Janv_2023.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Examen_Janv_2023.ViewModel
{
    public class ProductVm  : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); // On notifie que la propriété a changé
            }
        }

        private NorthwindContext dc = new NorthwindContext();
        private ObservableCollection<ProductModel> _ProductList;
        private ProductModel _SelectedProduct;
        private DelegateCommand _RemoveCommand;
        private ObservableCollection<KeyValuePair<string, int>> _productPerCountry;

        public ObservableCollection<ProductModel> ProductList
        {
            get
            {
                if (_ProductList == null)
                {
                    _ProductList = loadProduct();
                }
                return _ProductList;
            }
        }

        public ObservableCollection<KeyValuePair<string, int>> ProductPerCountry
        {
            get
            {
                if (_productPerCountry == null)
                {
                    _productPerCountry = loadProductPerCountry();
                }
                return _productPerCountry;
            }
        }

        private ObservableCollection<KeyValuePair<string, int>> loadProductPerCountry()
        {
            var query = from p in dc.Products
                        where p.OrderDetails.Count >= 1
                        group p by p.Supplier.Country into g
                        orderby g.Count() descending
                        select new KeyValuePair<string, int>(g.Key, g.Count());

            return new ObservableCollection<KeyValuePair<string, int>>(query);
        }


        private ObservableCollection<ProductModel> loadProduct()
        {
            ObservableCollection<ProductModel> localCollection = new ObservableCollection<ProductModel>();
            foreach (var item in dc.Products)
            {
                if(item.Discontinued == true)
                localCollection.Add(new ProductModel(item));

            }

            return localCollection;
        }

        public ProductModel SelectedProduct
        {
            get
            {
                return _SelectedProduct;
            }
            set
            {
                _SelectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        public DelegateCommand RemoveCommand
        {
            get { return _RemoveCommand = _RemoveCommand ?? new DelegateCommand(RemoveProduct); }
        }

        private void RemoveProduct()
        {
            _SelectedProduct.Product.Discontinued = true;
            _ProductList.Remove(_SelectedProduct);
            OnPropertyChanged("ProductList");
            dc.SaveChanges();

        }


    }
}
