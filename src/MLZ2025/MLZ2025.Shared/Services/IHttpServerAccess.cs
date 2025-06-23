using MLZ2025.Core.Model;

namespace MLZ2025.Core.Services;

public interface IHttpServerAccess
{
    Task<IList<ServerAddress>> GetAddressesAsync();
}
