namespace WindowsServiceManager.Core.EnumerationConversions.ServiceStatus
{
    using WindowsServiceManager.Core.Domain;

    public class PausePendingStatus : IServiceStatus
    {
        public string StatusId
        {
            get
            {
                return "PausePending";
            }
        }

        public string StatusDisplayName
        {
            get
            {
                return "Pause Pending";
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
            return applier.CreateForPausePending(this);
        }
    }
}