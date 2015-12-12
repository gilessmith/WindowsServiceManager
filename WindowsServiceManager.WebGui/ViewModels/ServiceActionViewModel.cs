namespace WindowsServiceManager.WebGui.ViewModels
{
    public class ServiceActionViewModel
    {
        public ServiceActionViewModel(string actionMethod, string actionIconClass, string actionDescription, string actionDisplayName, string expectedCompletionStatus)
        {
            this.ActionDescription = actionDescription;
            this.ActionDisplayName = actionDisplayName;
            this.ExpectedCompletionStatus = expectedCompletionStatus;
            this.ActionIconClass = actionIconClass;
            this.ActionMethod = actionMethod;
        }

        public string ActionMethod { get; private set; }

        public string ActionIconClass { get; private set; }

        public string ActionDescription { get; private set; }

        public string ActionDisplayName { get; private set; }

        public string ExpectedCompletionStatus { get; private set; }
    }
}