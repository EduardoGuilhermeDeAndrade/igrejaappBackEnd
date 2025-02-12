using igreja.Infrastructure.Data;
using Igreja.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace igreja.Infrastructure.Repositories.General
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var existingEntity = await _dbSet.FindAsync(GetEntityKey(entity));
            if (existingEntity == null)
                throw new KeyNotFoundException("A entidade solicitada para atualização não foi encontrada.");

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            _dbSet.Update(existingEntity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Apaga o registro do banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Não elimina o registro, somente marca como deletado
        /// A entidade tem de vir com IsDeleted = true e com data de deleção
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task DeleteLogicalAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        private object GetEntityKey(T entity)
        {
            var keyProperty = typeof(T).GetProperty("Id"); // Considera que a propriedade chave é `Id`
            if (keyProperty == null)
                throw new InvalidOperationException($"A entidade do tipo {typeof(T).Name} não possui uma propriedade 'Id'.");

            return keyProperty.GetValue(entity);
        }
    }
}
