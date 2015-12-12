namespace WindowsServiceManager.Core.Domain
{
    public interface IServiceStatusApplier<T>
    {
        T CreateForStopped(IServiceStatus status);

        T CreateForContinuePending(IServiceStatus status);

        T CreateForStopPending(IServiceStatus status);

        T CreateForStartPending(IServiceStatus startPendingStatus);

        T CreateForRunning(IServiceStatus runningStatus);

        T CreateForPausePending(IServiceStatus pausePendingStatus);

        T CreateForPaused(IServiceStatus pausedStatus);
    }
}