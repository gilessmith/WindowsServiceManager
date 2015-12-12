namespace WindowsServiceManager.Core
{
    using System.Collections.Generic;

    using WindowsServiceManager.Core.Domain;

    public interface IServiceAccess
    {
        ICollection<IWindowsService> LoadServices();

        IWindowsService LoadServiceById(string serviceId);
    }
}