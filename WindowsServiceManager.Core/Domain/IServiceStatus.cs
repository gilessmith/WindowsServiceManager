namespace WindowsServiceManager.Core.Domain
{
    using WindowsServiceManager.Core.EnumerationConversions.ServiceStatus;

    public interface IServiceStatus
    {
        string StatusId { get; }

        string StatusDisplayName { get; }

        bool IsChangingStatus { get; }

        bool CanStartFromCurrentState { get; }

        bool CanStopServiceFromCurrentState { get; }

        T ApplyStatusType<T>(IServiceStatusApplier<T> applier);
    }
}