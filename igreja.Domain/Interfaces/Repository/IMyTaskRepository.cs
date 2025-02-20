//using igreja.Domain.Common;
//using igreja.Domain.Models;
//using Igreja.Domain.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace igreja.Domain.Interfaces.Repository
//{
//    public interface IMyTaskRepository : IRepository<MyTask>
//    {
//        Task<PagedResult<MyTask>> GetMyTaskByFilter(Guid userId, string? title, bool? isCompleted, int page, int pageSize);
//        Task<IEnumerable<MyTask>> GetTasksAssignedToMe();
//        Task<IEnumerable<MyTask>> GetTasksIssuedByMe();
//        Task<MyTask?> GetUserByIdIgnoreFilterAsync(Guid id);
//    }
//}