namespace WindowsServiceManager.WebGui.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using WindowsServiceManager.Core;
    using WindowsServiceManager.Core.Domain;
    using WindowsServiceManager.WebGui.ViewModels;

    public class ServiceDetailModel : IServiceDetailModel
    {
        private readonly IServiceAccess serviceAccess;

        private readonly ICachedTagRepository tagRepository;

        private readonly IServiceStatusApplier<StatusDisplayInfo> statusApplier;

        public ServiceDetailModel(IServiceAccess serviceAccess, ICachedTagRepository tagRepository, IServiceStatusApplier<StatusDisplayInfo> statusApplier)
        {
            this.serviceAccess = serviceAccess;
            this.tagRepository = tagRepository;
            this.statusApplier = statusApplier;
        }

        public ServiceListViewModel LoadHomeViewModel()
        {
            var services = this.serviceAccess.LoadServices();
            var serviceListItemViewModels = services.Select(this.MapServiceToViewModel);
            return new ServiceListViewModel(serviceListItemViewModels);
        }

        public ServiceListItemViewModel GetServiceInfo(string serviceId)
        {
            var service = this.serviceAccess.LoadServiceById(serviceId);

            return this.MapServiceToViewModel(service);
        }

        private ServiceListItemViewModel MapServiceToViewModel(IWindowsService service)
        {
            var tags = this.tagRepository.TagsForService(service.Id);
            return new ServiceListItemViewModel(service, service.Status.ApplyStatusType(this.statusApplier), this.CreateActionsForService(service), tags.Select(t => t.TagText).ToList());
        }

        private ICollection<ServiceActionViewModel> CreateActionsForService(IWindowsService windowsService)
        {
            var actions = new List<ServiceActionViewModel>();

            if (windowsService.CanStart)
            {
                actions.Add(new ServiceActionViewModel("StartService", Bootstrap.Icons.Play, "Start the service.", "started", "Running"));
            }

            if (windowsService.CanStop)
            {
                actions.Add(new ServiceActionViewModel("StopService", Bootstrap.Icons.Stop, "Stop the service.", "stopped", "Stopped"));
            }

            if (windowsService.CanStop)
            {
                actions.Add(new ServiceActionViewModel("RestartService", Bootstrap.Icons.Refresh, "Restart the service.", "restarted", "Running"));
            }

            return actions;
        }
    }
}