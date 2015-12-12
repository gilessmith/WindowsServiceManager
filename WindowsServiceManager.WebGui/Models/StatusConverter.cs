namespace WindowsServiceManager.WebGui.Models
{
    using WindowsServiceManager.Core.Domain;

    public class StatusConverter : IServiceStatusApplier<StatusDisplayInfo>
    {
        public StatusDisplayInfo CreateForStopped(IServiceStatus status)
        {
            return new StatusDisplayInfo(Bootstrap.Tables.BackGroundWarning, Bootstrap.Icons.Stop);
        }

        public StatusDisplayInfo CreateForContinuePending(IServiceStatus status)
        {
            return new StatusDisplayInfo(Bootstrap.Tables.BackGroundChanging, Bootstrap.Icons.Refresh);
        }

        public StatusDisplayInfo CreateForStopPending(IServiceStatus status)
        {
            return new StatusDisplayInfo(Bootstrap.Tables.BackGroundChanging, Bootstrap.Icons.Refresh);
        }

        public StatusDisplayInfo CreateForStartPending(IServiceStatus startPendingStatus)
        {
            return new StatusDisplayInfo(Bootstrap.Tables.BackGroundChanging, Bootstrap.Icons.Refresh);
        }

        public StatusDisplayInfo CreateForRunning(IServiceStatus runningStatus)
        {
            return new StatusDisplayInfo(Bootstrap.Tables.BackGroundOk, Bootstrap.Icons.Play);
        }

        public StatusDisplayInfo CreateForPausePending(IServiceStatus pausePendingStatus)
        {
            return new StatusDisplayInfo(Bootstrap.Tables.BackGroundChanging, Bootstrap.Icons.Refresh);
        }

        public StatusDisplayInfo CreateForPaused(IServiceStatus pausedStatus)
        {
            return new StatusDisplayInfo(Bootstrap.Tables.BackGroundWarning, Bootstrap.Icons.Pause);
        }
    }
}