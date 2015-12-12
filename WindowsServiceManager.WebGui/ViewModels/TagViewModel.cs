namespace WindowsServiceManager.WebGui.ViewModels
{
    using WindowsServiceManager.Core.Domain;

    public class TagViewModel
    {
        public TagViewModel(Tag tag)
        {
            this.TagText = tag.TagText;
        }

        public string TagText { get; private set; }
    }
}