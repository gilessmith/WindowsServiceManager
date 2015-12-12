namespace WindowsServiceManager.WebGui.Models
{
    using WindowsServiceManager.Core;

    public class ServiceActionModel : IServiceActionModel
    {
        private readonly IServiceAccess serviceAccess;

        public ServiceActionModel(IServiceAccess serviceAccess)
        {
            this.serviceAccess = serviceAccess;
        }

        public void StopService(string serviceName)
        {
            var service = this.serviceAccess.LoadServiceById(serviceName);
            service.Stop();
        }

        public void StartService(string serviceName)
        {
            var service = this.serviceAccess.LoadServiceById(serviceName);
            service.Start();
        }

        public void RestartService(string serviceName)
        {
            var service = this.serviceAccess.LoadServiceById(serviceName);
            service.Restart();
        }
    }
}