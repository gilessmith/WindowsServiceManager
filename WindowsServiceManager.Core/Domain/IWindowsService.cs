namespace WindowsServiceManager.Core.Domain
{
    public interface IWindowsService
    {
        string DisplayName { get; }

        string ServiceName { get; }

        IServiceStatus Status { get;  }

        bool CanStart { get; }

        bool CanStop { get; }

        bool CanRefresh { get; }

        ServiceId Id { get; }

        void Start();

        void Restart();

        void Stop();
    }
}