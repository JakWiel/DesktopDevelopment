using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Single
{
    public class OrderDetailViewModel : BaseCreateViewModel<OrderDetailService, OrderDetailsDto, OrderDetail>
    {
        public int OrderID
        {
            get => Model.OrderId;
            set
            {
                if (Model.OrderId != value)
                {
                    Model.OrderId = value;
                    OnPropertyChanged(() => OrderID);
                }
            }
        }

        public int ProductID
        {
            get => Model.ProductId;
            set
            {
                if (Model.ProductId != value)
                {
                    Model.ProductId = value;
                    OnPropertyChanged(() => ProductID);
                }
            }
        }

        public int Quantity
        {
            get => Model.Quantity;
            set
            {
                if (Model.Quantity != value)
                {
                    Model.Quantity = value;
                    OnPropertyChanged(() => Quantity);
                }
            }
        }

        public decimal Price
        {
            get => Model.Price;
            set
            {
                if (Model.Price != value)
                {
                    Model.Price = value;
                    OnPropertyChanged(() => Price);
                }
            }
        }

        public string ProductName
        {
            get => Model.Product.ProductName;
            set
            {
                if (Model.Product.ProductName != value)
                {
                    Model.Product.ProductName = value;
                    OnPropertyChanged(() => ProductName);
                }
            }
        }

        public OrderDetailViewModel() : base("Order Detail")
        {

        }
    }
}
