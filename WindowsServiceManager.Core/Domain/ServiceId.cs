namespace WindowsServiceManager.Core.Domain
{
    using System;
    using System.ServiceProcess;

    public class ServiceId : IEquatable<ServiceId>
    {
        private readonly string identifier;

        private ServiceId(string identifier)
        {
            this.identifier = identifier;
        }

        public static ServiceId CreateServiceIdFromService(ServiceController service)
        {
            return new ServiceId(service.ServiceName);
        }

        public static ServiceId CreateServiceIdFromServiceName(string serviceName)
        {
            return new ServiceId(serviceName);
        }

        public static bool operator ==(ServiceId left, ServiceId right)
        {
            return ServiceId.Equals(left, right);
        }

        public static bool operator !=(ServiceId left, ServiceId right)
        {
            return !ServiceId.Equals(left, right);
        }

        public string ServiceIdAsString()
        {
            return this.identifier;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var otherServiceId = obj as ServiceId;
            if (otherServiceId == null)
            {
                return false;
            }

            return this.Equals(otherServiceId);
        }

        public bool Equals(ServiceId otherServiceId)
        {
            if (otherServiceId == null)
            {
                return false;
            }

            return this.identifier.Equals(otherServiceId.identifier, StringComparison.InvariantCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return this.identifier != null ? this.identifier.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return string.Format("ServiceId: ({0})", this.identifier);
        }
    }
}