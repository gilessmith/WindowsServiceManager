namespace WindowsServiceManager.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceProcess;

    using WindowsServiceManager.Core.Domain;
    using WindowsServiceManager.Core.EnumerationConversions.ServiceStatus;

    public class ServiceAccess : IServiceAccess
    {
        private readonly IServiceStatusFactory statusFactory;

        public ServiceAccess(IServiceStatusFactory statusFactory)
        {
            this.statusFactory = statusFactory;
        }

        public ICollection<IWindowsService> LoadServices()
        {
            ServiceController[] services = ServiceController.GetServices();

            return services.Select(service => new WindowsService(service, this.statusFactory.CreateServiceStatus(service.Status))).Cast<IWindowsService>().ToList();
        }

        public IWindowsService LoadServiceById(string serviceId)
        {
            var service = ServiceController.GetServices().Single(s => s.ServiceName == serviceId);
            return new WindowsService(service, this.statusFactory.CreateServiceStatus(service.Status));
        }
    }
}
