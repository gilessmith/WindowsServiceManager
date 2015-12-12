namespace WindowsServiceManager.Core.Domain
{
    using System;
    using System.ServiceProcess;

    using WindowsServiceManager.Core.EnumerationConversions.ServiceStatus;

    public class WindowsService : IWindowsService
    {
        private readonly ServiceController serviceObject;

        private IServiceStatus status;

        public WindowsService(ServiceController serviceObject, IServiceStatus serviceStatus)
        {
            if (serviceObject == null)
            {
                throw new ArgumentNullException("serviceObject");
            }

            this.serviceObject = serviceObject;
            this.status = serviceStatus;
        }

        public ServiceId Id
        {
            get
            {
                return ServiceId.CreateServiceIdFromService(this.serviceObject);
            }
        }

        public string DisplayName
        {
            get
            {
                return this.serviceObject.DisplayName;
            }
        }

        public string ServiceName
        {
            get
            {
                return this.serviceObject.ServiceName;
            }
        }

        public IServiceStatus Status
        {
            get
            {
                return this.status;
            }
        }

        public bool CanStart
        {
            get
            {
                return this.status.CanStartFromCurrentState;
            }
        }

        public bool CanStop
        {
            get
            {
                return this.status.CanStopServiceFromCurrentState && this.serviceObject.CanStop;
            }
        }

        public bool CanRefresh
        {
            get
            {
                return this.status.CanStopServiceFromCurrentState && this.serviceObject.CanStop;
            }
        }

        public void Start()
        {
            this.serviceObject.Start();
        }

        public void Restart()
        {
            this.serviceObject.Refresh();
        }

        public void Stop()
        {
            this.serviceObject.Stop();
        }
    }
}