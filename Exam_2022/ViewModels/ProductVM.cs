using Exam_2022.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Exam_2022.ViewModels
{
    public class ProductVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private NorthwindContext dc = new NorthwindContext();
        private ProductModel _productSelected;
        private ObservableCollection<ProductModel> _productsList;
        private DelegateCommand modifyCommand;
        private ObservableCollection<KeyValuePair<int, decimal>> totalSalePerProduct;

        public ProductModel Product
        {
            get { return _productSelected; }
            set
            {
                _productSelected = value;
                OnPropertyChanged("Product");
            }
        }

        public ObservableCollection<ProductModel> ProductsList
        {
            get
            {
                if (_productsList == null)
                {
                    _productsList = LoadProducts();
                }
                return _productsList;
            }
        }

        private ObservableCollection<ProductModel> LoadProducts()
        {
            ObservableCollection<ProductModel> localCollection = new ObservableCollection<ProductModel>();
            foreach (var item in dc.Products)
            {
                localCollection.Add(new ProductModel(item));
            }
            return localCollection;
        }

        public DelegateCommand ModifyCommand
        {
            get
            {
                return modifyCommand = modifyCommand ?? new DelegateCommand(ModifyProduct);
            }
        }

        private void ModifyProduct()
        {
            if (Product != null)
            {
                // Récupérer le produit de la base
                var productEntity = dc.Products.FirstOrDefault(p => p.ProductId == Product.ProductId);
                if (productEntity != null)
                {
                    // Mettre à jour les propriétés modifiables
                    productEntity.ProductName = Product.ProductName;
                    productEntity.QuantityPerUnit = Product.QuantityPerUnit;

                    // Sauvegarder les changements
                    dc.SaveChanges();
                }
            }
        }

        public ObservableCollection<KeyValuePair<int, decimal>> TotalSalePerProduct
        {
            get
            {
                if( totalSalePerProduct == null )
                {
                    totalSalePerProduct = loadTotal();
                }
                return totalSalePerProduct;
            }
        }
        private ObservableCollection<KeyValuePair<int, decimal>> loadTotal()
        {
            var totalSales = dc.OrderDetails
                .GroupBy(od => od.ProductId) // 
                .Select(g => new KeyValuePair<int, decimal>(
                    g.Key,
                    g.Sum(od => od.UnitPrice * od.Quantity))) 
                .ToList();

            return new ObservableCollection<KeyValuePair<int, decimal>>(totalSales);
        }

    }
}
