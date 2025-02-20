//using igreja.Domain.Common;
//using igreja.Domain.Interfaces;
//using igreja.Domain.Interfaces.Repository;
//using igreja.Domain.Models;
//using igreja.Domain.Models.Enums;
//using igreja.Infrastructure.Data;
//using igreja.Infrastructure.Repositories.General;
//using Microsoft.EntityFrameworkCore;

//namespace igreja.Infrastructure.Repositories
//{
//    public class MyTaskRepository : Repository<MyTask>, IMyTaskRepository
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly IUserContextProvider _userContextProvider;
//        private readonly Guid currentUser;

//        public MyTaskRepository(ApplicationDbContext context, IUserContextProvider userContextProvider) : base(context)
//        {
//            _context = context;
//            _userContextProvider = userContextProvider;
//            currentUser = _userContextProvider.GetCurrentUserId();
//        }

//        public async Task<PagedResult<MyTask>> GetMyTaskByFilter(Guid userId, string? title, bool? isCompleted, int page, int pageSize)
//        {
//            var query = _context.MyTasks.AsQueryable();

//            if (!string.IsNullOrEmpty(title))
//                query = query.Where(t => t.Title.Contains(title));

//            if (isCompleted.HasValue)
//                query = query.Where(t => t.Status == EnumStatusTask.Pendente || t.Status == EnumStatusTask.EmProgresso);

//            // Filtro global já cobre o UserId e Deleted

//            var totalItems = await query.CountAsync();

//            var items = await query
//                .Skip((page - 1) * pageSize)
//                .Take(pageSize)
//                .ToListAsync();

//            return new PagedResult<MyTask>(items, totalItems, page, pageSize);
//        }

//        public async Task<IEnumerable<MyTask>> GetTasksAssignedToMe()
//        {
//            return await _context.MyTasks
//                .IgnoreQueryFilters()
//                .Where(t => t.UserResponsableId == currentUser)
//                .ToListAsync();
//        }

//        public async Task<IEnumerable<MyTask>> GetTasksIssuedByMe()
//        {
//            return await _context.MyTasks
//                .Where(t => t.UserId == currentUser)
//                .ToListAsync();
//        }

//        public async Task<MyTask?> GetUserByIdIgnoreFilterAsync(Guid id)
//        {
//            return await _context.MyTasks
//                .IgnoreQueryFilters()
//                .FirstOrDefaultAsync(t => t.Id == id);
//        }
//    }
//}