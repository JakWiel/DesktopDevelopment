﻿using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Single
{
    public class ProductViewModel : BaseCreateViewModel<ProductService, ProductDto, Product>
    {
        public ProductViewModel() : base("New Product")
        {
        }
        public string ProductName
        {
            get => Model.ProductName;
            set
            {
                if (Model.ProductName != value)
                {
                    Model.ProductName = value.Trim();
                    OnPropertyChanged(() => ProductName);
                }
            }
        }
        public decimal Price
        {
            get => Model.Price;
            set
            {
                if (Model.Price != value && Model.Price > 0)
                {
                    Model.Price = value;
                    OnPropertyChanged(() => Price);
                }
            }
        }
        public string Description
        {
            get => Model.Description;
            set
            {
                if (Model.Description != value && Model.Description.Length > 0)
                {
                    Model.Description = value;
                    OnPropertyChanged(() => Description);
                }
            }
        }
    }
}
