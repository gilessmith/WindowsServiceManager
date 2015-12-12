namespace WindowsServiceManager.WebGui.ViewModels
{
    public class HomeViewModel
    {
        public string EnvironmentName { get; private set; }

        public string CurrentlyLoggedInUser { get; private set; }

        public HomeViewModel(string environmentName, string currentlyLoggedInUser)
        {
            this.EnvironmentName = environmentName;
            this.CurrentlyLoggedInUser = currentlyLoggedInUser;
        }
    }
}