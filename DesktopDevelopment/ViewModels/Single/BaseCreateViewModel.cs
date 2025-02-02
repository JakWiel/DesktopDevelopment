using DesktopDevelopment.Helpers;
using DesktopDevelopment.Models.Services;
using System.Windows.Input;

namespace DesktopDevelopment.ViewModels.Single
{
    public class BaseCreateViewModel<ServiceType, DtoType, ModelType>
        : BaseServiceViewModel<ServiceType, DtoType, ModelType>
        where ServiceType : BaseService<DtoType, ModelType>, new()
        where DtoType : class
        where ModelType : class, new()
    {
        private ModelType _Model;
        public ModelType Model
        {
            get => _Model;
            set
            {
                if (_Model != value)
                {
                    _Model = value;
                    OnPropertyChanged(() => Model);
                }
            }
        }
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public BaseCreateViewModel(string displayName) : base(displayName)
        {
            _Model = Service.CreateModel();
            SaveCommand = new BaseCommand(() => Save());
            CancelCommand = new BaseCommand(() => Cancel());
        }
        public BaseCreateViewModel(int id, string displayName) : base(displayName)
        {
            _Model = Service.GetModel(id);
            SaveCommand = new BaseCommand(() => Save());
            CancelCommand = new BaseCommand(() => Cancel());
        }
        public virtual void Save()
        {
            Service.AddModel(Model);
            OnRequestClose();
        }
        public void Cancel()
        {
            OnRequestClose();
        }
    }
}
