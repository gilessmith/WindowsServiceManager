namespace WindowsServiceManager.Core.EnumerationConversions.ServiceStatus
{
    using System.ServiceProcess;

    using WindowsServiceManager.Core.Domain;

    public interface IServiceStatusFactory
    {
        IServiceStatus CreateServiceStatus(ServiceControllerStatus status);
    }
}