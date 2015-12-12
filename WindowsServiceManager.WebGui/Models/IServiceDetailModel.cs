namespace WindowsServiceManager.WebGui.Models
{
    using WindowsServiceManager.WebGui.ViewModels;

    public interface IServiceDetailModel
    {
        ServiceListViewModel LoadHomeViewModel();

        ServiceListItemViewModel GetServiceInfo(string serviceId);
    }
}