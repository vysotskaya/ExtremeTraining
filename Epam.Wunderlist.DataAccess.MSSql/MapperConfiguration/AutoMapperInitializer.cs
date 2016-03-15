using AutoMapper;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataAccess.MSSqlDbModel;

namespace Epam.Wunderlist.DataAccess.MSSql.MapperConfiguration
{
    public class AutoMapperInitializer
    {
        static AutoMapperInitializer()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TodoListDbModel, TodoList>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.TodoListName, opt => opt.MapFrom(src => src.TodoListName))
                    .ForMember(dest => dest.UserProfileRefId, opt => opt.MapFrom(src => src.UserProfileRefId))
                    .ForSourceMember(x => x.TodoTasks, y => y.Ignore())
                    .ForSourceMember(x => x.UserProfile, y => y.Ignore());
                cfg.CreateMap<TodoList, TodoListDbModel>()
                    .ForSourceMember(x => x.Id, y => y.Ignore());

                cfg.CreateMap<UserProfileDbModel, UserProfile>()
                    .ForMember(x => x.UserName, y => y.MapFrom(s => s.Name));
                cfg.CreateMap<UserProfile, UserProfileDbModel>()
                    .ForSourceMember(x => x.Id, y => y.Ignore())
                    .ForMember(x => x.Name, y => y.MapFrom(s => s.UserName)); ;
            });
        }
    }
}
