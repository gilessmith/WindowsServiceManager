namespace WindowsServiceManager.WebGui.Models
{
    using WindowsServiceManager.WebGui.ViewModels;

    public interface IHomeModel
    {
        HomeViewModel LoadHomeViewModel();
    }
}