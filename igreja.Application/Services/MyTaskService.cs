//using AutoMapper;
//using igreja.Application.DTOs.MyTask;
//using igreja.Application.Interfaces;
//using igreja.Domain.Common;
//using igreja.Domain.Interfaces;
//using igreja.Domain.Interfaces.Repository;
//using igreja.Domain.Models;
//using igreja.Domain.Models.Enums;
//using Igreja.Domain.Interfaces;

//namespace igreja.Application.Services
//{
//    public class MyTaskService : IMyTaskService
//    {
//        private readonly IMyTaskRepository _myTaskRepository;
//        private readonly IMapper _mapper;
//        private readonly IUserContextProvider _userContextProvider;
//        private readonly IUserRepository _userRepository;

//        public MyTaskService(IMyTaskRepository myTaskRepository, IMapper mapper, IUserContextProvider userContextProvider, IUserRepository userRepository)
//        {
//            _myTaskRepository = myTaskRepository;
//            _mapper = mapper;
//            _userContextProvider = userContextProvider;
//            _userRepository = userRepository;
//        }

//        public async Task<ApiResponse<IPagedResult<MyTaskDto>>> GetMyTaskByFilterAsync(string? title, bool? isCompleted, int page, int pageSize)
//        {
//            var userId = _userContextProvider.GetCurrentUserId();
//            if (userId == Guid.Empty)
//                return new ApiResponse<IPagedResult<MyTaskDto>>("Usuário não autenticado.", false);

//            var myTasksResult = await _myTaskRepository.GetMyTaskByFilter(userId, title, isCompleted, page, pageSize);
//            if (!myTasksResult.Items.Any())
//                return new ApiResponse<IPagedResult<MyTaskDto>>("Nenhuma tarefa encontrada.", false);

//            var tasksDtoPaged = _mapper.Map<PagedResult<MyTaskDto>>(myTasksResult);

//            // Retorna a interface para manter a abstração
//            return new ApiResponse<IPagedResult<MyTaskDto>>(tasksDtoPaged, true, "Operação realizada com sucesso.");
//        }

//        public async Task<ApiResponse<IEnumerable<MyTaskDto>>> GetAllMyTasksAsync()
//        {
//            var myTasks = await _myTaskRepository.GetAllAsync();
//            var tasksDto = _mapper.Map<IEnumerable<MyTaskDto>>(myTasks);
//            return new ApiResponse<IEnumerable<MyTaskDto>>(tasksDto, true, "Operação realizada com sucesso.");
//        }

//        public async Task<ApiResponse<MyTaskDto>> GetMyTaskByIdAsync(Guid id)
//        {
//            var myTask = await _myTaskRepository.GetByIdAsync(id);
//            if (myTask == null)
//                return new ApiResponse<MyTaskDto>("Tarefa não encontrada.", false);

//            var taskDto = _mapper.Map<MyTaskDto>(myTask);
//            return new ApiResponse<MyTaskDto>(taskDto, true, "Operação realizada com sucesso.");
//        }

//        public Task<IEnumerable<MyTaskDto>> GetMyTasksByUserAsync(Guid userId)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<ApiResponse<IEnumerable<MyTaskDto>>> GetTasksAssignedToMeAsync()
//        {
//            var userId = _userContextProvider.GetCurrentUserId();
//            if (userId == Guid.Empty)
//                return new ApiResponse<IEnumerable<MyTaskDto>>("Usuário não autenticado.", false);

//            var myTasks = await _myTaskRepository.GetTasksAssignedToMe();
//            if (!myTasks.Any())
//                return new ApiResponse<IEnumerable<MyTaskDto>>("Não existem tarefas para esse usuário.", false);

//            var tasksDto = _mapper.Map<IEnumerable<MyTaskDto>>(myTasks);
//            return new ApiResponse<IEnumerable<MyTaskDto>>(tasksDto, true, "Operação realizada com sucesso.");
//        }

//        public async Task<ApiResponse<IEnumerable<MyTaskDto>>> GetTasksIssuedByMeAsync()
//        {
//            var userId = _userContextProvider.GetCurrentUserId();
//            if (userId == Guid.Empty)
//                return new ApiResponse<IEnumerable<MyTaskDto>>("Usuário não autenticado.", false);

//            var myTasks = await _myTaskRepository.GetTasksIssuedByMe();
//            if (!myTasks.Any())
//                return new ApiResponse<IEnumerable<MyTaskDto>>("Não existem tarefas emitidas por esse usuário.", false);

//            var tasksDto = _mapper.Map<IEnumerable<MyTaskDto>>(myTasks);
//            return new ApiResponse<IEnumerable<MyTaskDto>>(tasksDto, true, "Operação realizada com sucesso.");
//        }

//        public async Task<ApiResponse<bool>> AddMyTaskAsync(MyTaskAddDto myTaskAddDto)
//        {
//            try
//            {
//                var myTask = _mapper.Map<MyTask>(myTaskAddDto);

//                var UserResponsableId = await _userRepository.GetUserByIdIgnoreQueryFilterAsync(myTaskAddDto.UserResponsableId);
                
//                if (UserResponsableId == null)
//                    return new ApiResponse<bool>("Usuário responsável não localizado.", false);

//                myTask.Deleted = false;
//                myTask.Status = EnumStatusTask.Pendente;
                
//                await _myTaskRepository.AddAsync(myTask);

//                return new ApiResponse<bool>( "Tarefa adicionada com sucesso.", true);
//            }
//            catch (Exception ex)
//            {
//                return new ApiResponse<bool>($"Erro ao adicionar tarefa: {ex.Message}", false);
//            }
//        }

//        public async Task<ApiResponse<bool>> UpdateMyTaskAsync(MyTaskUpdateDto myTaskDto)
//        {
//            var myTaskEntity = await _myTaskRepository.GetByIdAsync(myTaskDto.Id);
//            if (myTaskEntity == null)
//                return new ApiResponse<bool>("A tarefa solicitada não foi encontrada.", false);

//            var UserResponsableId = await _userRepository.GetUserByIdIgnoreQueryFilterAsync(myTaskDto.UserResponsableId);
//            if (UserResponsableId == null)
//                return new ApiResponse<bool>("Usuário responsável não localizado.", false);

//            myTaskEntity.Title = myTaskDto.Title;
//            myTaskEntity.Description = myTaskDto.Description;
//            myTaskEntity.Status = myTaskDto.Status;
//            myTaskEntity.Changed = DateTime.Now;
//            myTaskEntity.UserResponsableId = myTaskDto.UserResponsableId;

//            await _myTaskRepository.UpdateAsync(myTaskEntity);
//            return new ApiResponse<bool>("Tarefa atualizada com sucesso.",true);
//        }

//        public async Task<ApiResponse<bool>> DeleteLogicMyTaskAsync(Guid id)
//        {
//            var userId = _userContextProvider.GetCurrentUserId();
//            if (userId == Guid.Empty)
//                return new ApiResponse<bool>("Usuário não autenticado.", false);

//            var myTaskEntity = await _myTaskRepository.GetByIdAsync(id);
//            if (myTaskEntity == null)
//                return new ApiResponse<bool>("A tarefa solicitada não foi encontrada.", false);

//            myTaskEntity.Deleted = true;
//            myTaskEntity.Changed = DateTime.Now;
//            await _myTaskRepository.DeleteLogicalAsync(myTaskEntity);

//            return new ApiResponse<bool>( "Tarefa excluída logicamente com sucesso.",true);
//        }
//    }
//}
