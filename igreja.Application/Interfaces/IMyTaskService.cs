//using igreja.Application.DTOs.MyTask;
//using igreja.Domain.Common;
//using igreja.Domain.Interfaces;

//namespace igreja.Application.Interfaces
//{
//    public interface IMyTaskService
//    {
//        Task<ApiResponse<IPagedResult<MyTaskDto>>> GetMyTaskByFilterAsync(string? title, bool? isCompleted, int page, int pageSize);
//        Task<ApiResponse<IEnumerable<MyTaskDto>>> GetAllMyTasksAsync();
//        Task<ApiResponse<MyTaskDto>> GetMyTaskByIdAsync(Guid id);
//        Task<ApiResponse<IEnumerable<MyTaskDto>>> GetTasksAssignedToMeAsync();
//        Task<ApiResponse<IEnumerable<MyTaskDto>>> GetTasksIssuedByMeAsync();
//        Task<ApiResponse<bool>> AddMyTaskAsync(MyTaskAddDto myTaskAddDto);
//        Task<ApiResponse<bool>> UpdateMyTaskAsync(MyTaskUpdateDto myTaskDto);
//        Task<ApiResponse<bool>> DeleteLogicMyTaskAsync(Guid id);
//    }
//}
