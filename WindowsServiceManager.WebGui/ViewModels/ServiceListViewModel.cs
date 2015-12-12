namespace WindowsServiceManager.WebGui.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class ServiceListViewModel
    {
        private readonly IEnumerable<ServiceListItemViewModel> windowsServices;

        public ServiceListViewModel(IEnumerable<ServiceListItemViewModel> windowsServices)
        {
            if (windowsServices == null)
            {
                throw new ArgumentNullException("windowsServices");
            }

            this.windowsServices = windowsServices;
        }

        public IEnumerable<ServiceListItemViewModel> WindowsServices
        {
            get
            {
                return this.windowsServices;
            }
        }
    }
}