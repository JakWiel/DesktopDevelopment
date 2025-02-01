using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;
using System;

namespace DesktopDevelopment.ViewModels.Single
{
    public class OrderViewModel : BaseCreateViewModel<OrderService, OrdersDto, Order>
    {
        public string CustomerFullName
        {
            get => Model.Customer.FullName;
            set
            {
                if (Model.Customer.FullName != value)
                {
                    Model.Customer.FullName = value;
                    OnPropertyChanged(() => CustomerFullName);
                }
            }
        }

        public int CustomerID
        {
            get => Model.CustomerId;
            set
            {
                if (Model.CustomerId != value)
                {
                    Model.CustomerId = value;
                    OnPropertyChanged(() => CustomerID);
                }
            }
        }

        public int EmployeeID
        {
            get => Model.EmployeeId;
            set
            {
                if (Model.EmployeeId != value)
                {
                    Model.EmployeeId = value;
                    OnPropertyChanged(() => EmployeeID);
                }
            }
        }

        public int StatusID
        {
            get => Model.StatusId;
            set
            {
                if (Model.StatusId != value)
                {
                    Model.StatusId = value;
                    OnPropertyChanged(() => StatusID);
                }
            }
        }

        public DateTime OrderDate
        {
            get => Model.OrderDate;
            set
            {
                if (Model.OrderDate != value)
                {
                    Model.OrderDate = value;
                    OnPropertyChanged(() => OrderDate);
                }
            }
        }

        public decimal TotalAmount
        {
            get => Model.TotalAmount;
            set
            {
                if (Model.TotalAmount != value)
                {
                    Model.TotalAmount = value;
                    OnPropertyChanged(() => TotalAmount);
                }
            }
        }

        public OrderViewModel() : base("Order") { }
    }
}
