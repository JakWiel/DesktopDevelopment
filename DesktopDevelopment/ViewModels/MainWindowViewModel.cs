using CommunityToolkit.Mvvm.Messaging;
using DesktopDevelopment.Helpers;
using DesktopDevelopment.ViewModels.Many;
using DesktopDevelopment.ViewModels.Single;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace DesktopDevelopment.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region TopAndSideMenuCommand

        public ICommand OpenProductViewCommand { get => new BaseCommand(() => CreateView(new ProductsViewModel())); }
        public ICommand OpenCustomerViewCommand { get => new BaseCommand(() => CreateView(new CustomerViewModel())); }
        public ICommand OpenCustomersViewCommand { get => new BaseCommand(() => CreateView(new CustomersViewModel())); }
        public ICommand OpenEmployeesViewCommand { get => new BaseCommand(() => CreateView(new EmployeesViewModel())); }
        public ICommand OpenCategoriesViewCommand { get => new BaseCommand(() => CreateView(new CategoriesViewModel())); }
        public ICommand OpenShipmentMethodsViewCommand { get => new BaseCommand(() => CreateView(new ShipmentMethodsViewModel())); }
        public ICommand OpenOrderStatusesViewCommand { get => new BaseCommand(() => CreateView(new OrderStatusesViewModel())); }
        public ICommand OpenPaymentStatusViewCommand { get => new BaseCommand(() => CreateView(new PaymentMethodsViewModel())); }
        public ICommand OpenUserRolesViewCommand { get => new BaseCommand(() => CreateView(new UserRolesViewModel())); }
        public ICommand OpenTransactionsViewCommand { get => new BaseCommand(() => CreateView(new TransactionsViewModel())); }
        public ICommand OpenOrdersViewCommand { get => new BaseCommand(() => CreateView(new OrdersViewModel())); }
        public ICommand OpenRepairTicketsViewCommand { get => new BaseCommand(() => CreateView(new RepairTicketsViewModel())); }
        public ICommand OpenPromotionsViewCommand { get => new BaseCommand(() => CreateView(new PromotionsViewModel())); }
        public ICommand OpenOrderDetailsViewCommand { get => new BaseCommand(() => CreateView(new OrderDetailsViewModel())); }
        public ICommand OpenServiceOfferedViewCommand { get => new BaseCommand(() => CreateView(new ServicesOfferedViewModel())); }

        public ICommand OpenSuppliersViewCommand { get => new BaseCommand(() => CreateView(new SuppliersViewModel())); }
        public ICommand OpenCustomersReviewsViewCommand { get => new BaseCommand(() => CreateView(new CustomersReviewsViewModel())); }

        #endregion


        public MainWindowViewModel()
        {
            Commands = new(CreateCommands());
            Workspaces = new();
            Workspaces.CollectionChanged += OnWorkspacesChanged;
            WeakReferenceMessenger.Default.Register<OpenViewMessage>(this, (recipent, message) => OpenView(message));
        }

        #region Buttons in side bar

        public ReadOnlyCollection<CommandViewModel> Commands { get; set; }

        private List<CommandViewModel> CreateCommands()
        {
            return new()
            {
                //new ("Add new Product", OpenNewProductViewCommand),
                new ("Products", OpenProductViewCommand, "#003049", "/Models/Icons/inventoryIcon.png"),
                new ("Customers", OpenCustomersViewCommand, "#362E41", "/Models/Icons/groupsIcon.png"),
                new ("Employees", OpenEmployeesViewCommand, "#6B2C39", "/Models/Icons/employeeIcon.png"),
                new ("Orders", OpenOrdersViewCommand, "#862B35", "/Models/Icons/orderIcon.png"),
                new ("Categories", OpenCategoriesViewCommand, "#862B35", "/Models/Icons/categoryIcon.png"),
                new ("Shipment", OpenShipmentMethodsViewCommand, "#A12A31", "/Models/Icons/shipmentIcon.png"),
                new ("Order Status", OpenOrderStatusesViewCommand, "#D62828", "/Models/Icons/orderStatusIcon.png"),
                new ("Payment Methods", OpenPaymentStatusViewCommand, "#003049", "/Models/Icons/paymentMethodIcon.png"),
                new ("User Roles", OpenUserRolesViewCommand, "#362E41", "/Models/Icons/userRole.png"),
                new ("Transactions", OpenTransactionsViewCommand, "#6B2C39", "/Models/Icons/transactionsIcon.png"),
                new ("Repair Tickets", OpenRepairTicketsViewCommand, "#862B35", "/Models/Icons/repairIcon.png"),
                new ("Promotions", OpenPromotionsViewCommand, "#A12A31", "/Models/Icons/promotionsIcon.png"),
                new ("Order Details", OpenOrderDetailsViewCommand, "#D62828", "/Models/Icons/orderDetailsIcon.png"),
                new ("Service Offered", OpenServiceOfferedViewCommand, "#003049", "/Models/Icons/serviceOfferedIcon.png"),
                new ("Suppliers", OpenSuppliersViewCommand, "#362E41", "/Models/Icons/supplierIcon.png"),
                new ("Customers Reviews", OpenCustomersReviewsViewCommand, "#6B2C39", "/Models/Icons/reviewsIcon.png")
                //new ("Add new Customer", OpenCustomerViewCommand)
            };
        }


        #endregion

        #region Tabs

        public ObservableCollection<WorkspaceViewModel> Workspaces { get; set; }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += onWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= onWorkspaceRequestClose;
        }

        private void onWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel? workspace = sender as WorkspaceViewModel;
            if (workspace != null)
            {
                Workspaces.Remove(workspace);
            }
        }

        #endregion

        #region Helepers

        private void OpenView(OpenViewMessage message)
        {
            CreateView(message.ViewModelToBeOpened);
        }

        private void CreateView(WorkspaceViewModel workspace)
        {
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }

        private void CreateListView<WorkspaceViewModelType>() where WorkspaceViewModelType : WorkspaceViewModel, new()
        {
            WorkspaceViewModel? workspace = Workspaces.FirstOrDefault(vm => vm is WorkspaceViewModelType);
            if (workspace == null)
            {
                workspace = new WorkspaceViewModelType();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }

        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        #endregion
    }
}
