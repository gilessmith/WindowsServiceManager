namespace WindowsServiceManager.WebGui.ViewModels
{
    using System.Collections.Generic;
        
    using WindowsServiceManager.Core.Domain;
    using WindowsServiceManager.WebGui.Models;

    public class ServiceListItemViewModel
    {
        private readonly IWindowsService service;

        private readonly StatusDisplayInfo serviceStatus;

        private readonly ICollection<ServiceActionViewModel> serviceActions;

        private readonly ICollection<string> tags;

        public ServiceListItemViewModel(IWindowsService service, StatusDisplayInfo serviceStatus, ICollection<ServiceActionViewModel> serviceActions, List<string> tags)
        {
            this.service = service;
            this.serviceStatus = serviceStatus;
            this.serviceActions = serviceActions;
            this.tags = tags;
        }

        public string ServiceId
        {
            get
            {
                return this.service.Id.ServiceIdAsString();
            }
        }

        public string DisplayName
        {
            get
            {
                return this.service.DisplayName;
            }
        }

        public string Name
        {
            get
            {
                return this.service.ServiceName;
            }
        }

        public string StatusId
        {
            get
            {
                return this.service.Status.StatusId;
            }
        }

        public string StatusDisplayName
        {
            get
            {
                return this.service.Status.StatusDisplayName;
            }
        }

        public string StatusRowClass
        {
            get
            {
                return serviceStatus.RowClass;
            }
        }

        public string StatusIconClass
        {
            get
            {
                return serviceStatus.IconClass;
            }
        }

        public ICollection<ServiceActionViewModel> ServiceActions
        {
            get
            {
                return this.serviceActions;
            }
        }

        public ICollection<string> Tags
        {
            get
            {
                return this.tags;
            }
        }
    }
}