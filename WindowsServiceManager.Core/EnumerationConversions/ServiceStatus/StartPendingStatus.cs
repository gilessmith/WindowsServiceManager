namespace WindowsServiceManager.Core.EnumerationConversions.ServiceStatus
{
    using WindowsServiceManager.Core.Domain;

    public class StartPendingStatus : IServiceStatus
    {
        public string StatusId
        {
            get
            {
                return "StartPending";
            }
        }

        public string StatusDisplayName
        {
            get
            {
                return "Start Pending";
            }
        }

        public bool IsChangingStatus
        {
            get
            {
                return true;
            }
        }

        public bool CanStartFromCurrentState
        {
            get
            {
                return false;
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
            return applier.CreateForStartPending(this);
        }
    }
}