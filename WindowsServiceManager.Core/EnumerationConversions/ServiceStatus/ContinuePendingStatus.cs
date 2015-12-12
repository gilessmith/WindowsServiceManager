namespace WindowsServiceManager.Core.EnumerationConversions.ServiceStatus
{
    using WindowsServiceManager.Core.Domain;

    public class ContinuePendingStatus : IServiceStatus
    {
        public string StatusId
        {
            get
            {
                return "ContinuePending";
            }
        }

        public string StatusDisplayName
        {
            get
            {
                return "Continue Pending";
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
            return applier.CreateForContinuePending(this);
        }
    }
}