using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Nuevo_Proyecto.Interface;
using Nuevo_Proyecto.Model;

namespace Nuevo_Proyecto.Data
{
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDbContext _context;

        public StoreRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Store> GetStoreByIdAsync(int id) => await _context.Sales.FindAsync(id) ?? throw new InvalidOperationException("Store not found.");

        public async Task<IEnumerable<Store>> GetStoresAsync() => await _context.Sales.Take(100).ToListAsync();

        //create
        public async Task<Store> CreateStoreAsync(Store person) // Fixed method name to match interface
        {
            _context.Sales.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<bool> UpdateStoreAsync(Store person)
        {
            _context.Entry(person).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(person.BusinessEntityID))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteStoreByIdAsync(int id)
        {
            var person = await _context.Sales.FindAsync(id);
            if (person == null)
            {
                return false;
            }

            _context.Sales.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool StoreExists(int id)
        {
            return _context.Sales.Any(e => e.BusinessEntityID == id);
        }
    }
}
