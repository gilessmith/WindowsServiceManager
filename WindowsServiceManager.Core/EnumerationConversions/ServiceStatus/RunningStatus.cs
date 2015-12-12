namespace WindowsServiceManager.Core.EnumerationConversions.ServiceStatus
{
    using WindowsServiceManager.Core.Domain;

    public class RunningStatus : IServiceStatus
    {
        public string StatusId
        {
            get
            {
                return "Running";
            }
            
        }

        public string StatusDisplayName
        {
            get
            {
                return "Running";
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
                return false;
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
            return applier.CreateForRunning(this);
        }
    }
}