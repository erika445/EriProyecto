using Nuevo_Proyecto.Controllers;
using Nuevo_Proyecto.Model;

namespace Nuevo_Proyecto.Interface
{
    public interface IStoreRepository
    {
        Task<Store> GetStoreByIdAsync(int id);
        Task<IEnumerable<Store>> GetStoresAsync();
        Task<Store> CreateStoreAsync(Store person);
        Task<bool> UpdateStoreAsync(Store person);
        Task<bool> DeleteStoreByIdAsync(int id);
    }
}
