using Examen_Janv_2023.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Janv_2023.ViewModel
{
    public class ProductModel : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); // On notifie que la propriété a changé
            }
        }

        private readonly Product _myProduct;

        public ProductModel(Product myProduct)
        {
            _myProduct = myProduct;
        }

        public Product Product
        {
            get { return _myProduct; }
        }

        public int ProductId { 
            get { return _myProduct.ProductId; } 
            set { _myProduct.ProductId = value;  }
        
        }

        public string ProductName
        {
            get { return _myProduct.ProductName; }
            set { _myProduct.ProductName = value; }
        }

        public string CategoryName
        {
            get
            {
                return _myProduct.Category.CategoryName;
            }
            set { _myProduct.Category.CategoryName = value; }
        }

        public string ContactName
        {
            get
            {
                return _myProduct.Supplier.ContactName;
            }
            set { _myProduct.Supplier.ContactName = value; }
        }




    }

}
