namespace WindowsServiceManager.Core.EnumerationConversions.ServiceStatus
{
    using WindowsServiceManager.Core.Domain;

    public class StoppedStatus : IServiceStatus
    {
        public string StatusId
        {
            get
            {
                return "Stopped";
            }
        }

        public string StatusDisplayName
        {
            get
            {
                return "Stopped";
            }
        }

        public bool IsChangingStatus
        {
            get
            {
                return false;
            }
        }

        public bool CanStartFromCurrentState
        {
            get
            {
                return true;
            }
        }

        public bool CanStopServiceFromCurrentState
        {
            get
            {
                return false;
            }
        }

        public T ApplyStatusType<T>(IServiceStatusApplier<T> applier)
        {
            return applier.CreateForStopped(this);
        }
    }
}