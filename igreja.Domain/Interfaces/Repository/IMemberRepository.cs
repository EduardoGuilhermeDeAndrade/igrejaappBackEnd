using igreja.Domain.Models;
using Igreja.Domain.Interfaces;
using System;

namespace igreja.Domain.Interfaces
{
    public interface IMemberRepository : IRepository<Member>
    {
        Task<IEnumerable<Member>> GetByChurchIdAsync(Guid churchId);
    }
}
