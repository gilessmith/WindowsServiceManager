namespace WindowsServiceManager.Core.EnumerationConversions.ServiceStatus
{
    using WindowsServiceManager.Core.Domain;

    public class StopPendingStatus : IServiceStatus
    {
        public string StatusId
        {
            get
            {
                return "StopPending";
            }
        }

        public string StatusDisplayName
        {
            get
            {
                return "Stop Pending";
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
            return applier.CreateForStopPending(this);
        }
    }
}