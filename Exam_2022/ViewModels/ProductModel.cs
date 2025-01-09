using Exam_2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_2022.ViewModels
{
    public class ProductModel
    {
        private readonly Product _product;

        public ProductModel(Product product)
        {
            _product = product;
        }

        public Product Product => _product;

        public int ProductId 
        {

            get
            {
                return _product.ProductId;
            }
            set
            {
                _product.ProductId = value;
            }


        }

        public string ProductName {
            get => _product.ProductName;
            set => _product.ProductName = value;
        }

        public string? QuantityPerUnit
        {
            get => _product.QuantityPerUnit;
            set => _product.QuantityPerUnit = value;
        }

        public virtual string ContactName
        {
            get => _product.Supplier.ContactName;
            set => _product.Supplier.ContactName = value;
        }


    }
}
