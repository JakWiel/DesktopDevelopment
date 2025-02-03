﻿using CommunityToolkit.Mvvm.Messaging;
using DesktopDevelopment.Helpers;
using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;
using DesktopDevelopment.ViewModels.Single;
using System;

namespace DesktopDevelopment.ViewModels.Many
{
    public class ServicesOfferedViewModel : BaseManyViewModel<ServicesOfferedService, ServicesOfferedDto, ServicesOffered>
    {
        public ServicesOfferedViewModel() : base("Services Offered")
        {
        }
        protected override void CreateNew()
        {
            WeakReferenceMessenger.Default.Send<OpenViewMessage>(new OpenViewMessage()
            {
                Sender = this,
                ViewModelToBeOpened = new ServiceOfferedViewModel()
            });
        }
        protected override void HandleSelect()
        {
            if (SelectedModel != null)
            {
                WeakReferenceMessenger.Default.Send<OpenViewMessage>(new OpenViewMessage()
                {
                    Sender = this,
                    ViewModelToBeOpened = new ServiceOfferedViewModel(SelectedModel.Id)
                });
            }
        }
        public DateTime? CreatedFrom
        {
            get => Service.CreatedFrom;
            set
            {
                if (value != Service.CreatedFrom)
                {
                    Service.CreatedFrom = value;
                    OnPropertyChanged(() => CreatedFrom);
                }
            }
        }
        public DateTime? CreatedTo
        {
            get => Service.CreatedTo;
            set
            {
                if (value != Service.CreatedTo)
                {
                    Service.CreatedTo = value;
                    OnPropertyChanged(() => CreatedTo);
                }
            }
        }
        protected override void ClearFilters()
        {
            SearchInput = null;
            CreatedFrom = null;
            CreatedTo = null;
            Refresh();
        }
    }
}
