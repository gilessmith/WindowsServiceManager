namespace WindowsServiceManager.WebGui.Models
{
    public interface IServiceActionModel
    {
        void StopService(string serviceName);

        void StartService(string serviceName);

        void RestartService(string serviceName);
    }
}