using DesktopDevelopment.Helpers;
using DesktopDevelopment.Models.Services;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopDevelopment.ViewModels.Many
{
    public class BaseManyViewModel<ServiceType, DtoType, ModelType> 
        : BaseServiceViewModel<ServiceType, DtoType, ModelType>
        where ServiceType : BaseService<DtoType, ModelType>, new()
        where DtoType : class
        where ModelType : new()
    {
        private ObservableCollection<DtoType> _Models;
        public ObservableCollection<DtoType> Models {
            get => _Models; 
            set
            {
                if(_Models != value)
                {
                    _Models = value;
                    OnPropertyChanged(() => Models);
                }
            }
        }
        public ICommand RefreshCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public string? SearchInput { 
            get => Service.SearchInput;
            set
            {
                if(Service.SearchInput != value)
                {
                    Service.SearchInput = value;
                    OnPropertyChanged(() => SearchInput);
                    Refresh();
                }
            }
        }
        private DtoType? _SelectedModel;
        public DtoType? SelectedModel {
            get => _SelectedModel;
            set
            {
                if(_SelectedModel != value)
                {
                    _SelectedModel = value;
                    OnPropertyChanged(() => SelectedModel);
                }
            }
        }
        public BaseManyViewModel(string displayName) : base(displayName)
        {
            _Models = default!;
            Refresh();
            RefreshCommand = new BaseCommand(() => Refresh());
            DeleteCommand = new BaseCommand(() => Delete());
        }
        private void Refresh()
        {
            Models = new ObservableCollection<DtoType>(Service.GetModels());
        }
        private void Delete()
        {
            if(SelectedModel != null)
            {
                Service.DeleteModel(SelectedModel);
                Models.Remove(SelectedModel);
            }
        }
    }
}
