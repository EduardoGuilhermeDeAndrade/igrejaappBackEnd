//using AutoMapper;
//using igreja.Application.DTOs.MyTask;
//using igreja.Domain.Models;

//namespace igreja.Application.Mappings
//{
//    public class MyTaskMapping : Profile
//    {
//        public MyTaskMapping()
//        {
//            // Mapeamento bidirecional entre MyTask e MyTaskDto
//            CreateMap<MyTask, MyTaskDto>().ReverseMap();
//            CreateMap<MyTask, MyTaskAddDto>().ReverseMap();
//            CreateMap<MyTask, MyTaskUpdateDto>().ReverseMap();

//            // Ignora propriedades específicas durante a conversão de entrada
//            CreateMap<MyTaskDto, MyTask>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ForMember(dest => dest.Created, opt => opt.Ignore())
//                .ForMember(dest => dest.Changed, opt => opt.Ignore());

//        }

//    }
//}
