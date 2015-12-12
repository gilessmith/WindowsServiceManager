namespace WindowsServiceManager.Core.EnumerationConversions.ServiceStatus
{
    using System;
    using System.ServiceProcess;

    using WindowsServiceManager.Core.Domain;

    public class ServiceStatusFactory : IServiceStatusFactory
    {
        public IServiceStatus CreateServiceStatus(ServiceControllerStatus status)
        {
            switch (status)
            {
                case ServiceControllerStatus.ContinuePending:
                    return new ContinuePendingStatus();
                case ServiceControllerStatus.Paused:
                    return new PausedStatus();
                case ServiceControllerStatus.PausePending:
                    return new PausePendingStatus();
                case ServiceControllerStatus.Running:
                    return new RunningStatus();
                case ServiceControllerStatus.StartPending:
                    return new StartPendingStatus();
                case ServiceControllerStatus.Stopped:
                    return new StoppedStatus();
                case ServiceControllerStatus.StopPending:
                    return new StopPendingStatus();
                default:
                    throw new ArgumentOutOfRangeException("status", "Unknown status: " + status);
            }
        }
        
    }
}