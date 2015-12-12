namespace WindowsServiceManager.Core.EnumerationConversions.ServiceStatus
{
    using WindowsServiceManager.Core.Domain;

    public class PausedStatus : IServiceStatus
    {
        public string StatusId
        {
            get
            {
                return "Paused";
            }
        }

        public string StatusDisplayName
        {
            get
            {
                return "Paused";
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
                return true;
            }
        }

        public T ApplyStatusType<T>(IServiceStatusApplier<T> applier)
        {
            return applier.CreateForPaused(this);
        }
    }
}