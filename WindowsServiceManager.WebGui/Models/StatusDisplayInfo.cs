namespace WindowsServiceManager.WebGui.Models
{
    public class StatusDisplayInfo  
    {
        private readonly string rowClass;

        private readonly string iconClass;

        public StatusDisplayInfo(string rowClass, string iconClass)
        {
            this.rowClass = rowClass;
            this.iconClass = iconClass;
        }

        public string RowClass
        {
            get
            {
                return this.rowClass;
            }
        }

        public string IconClass
        {
            get
            {
                return this.iconClass;
            }
        }

    }
}