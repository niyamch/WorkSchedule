using AutoMapper;
using DataAccess.Entities;
using WorkSchedule.Models.Person;
using WorkSchedule.Models.Position;
using WorkSchedule.Models.Authentication;
using WorkSchedule.Models.Role;
using WorkSchedule.Models.Shift;
using WorkSchedule.Models.ShiftType;
using WorkSchedule.Models.User;

namespace WorkSchedule.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonFormViewModel, Person>();
            CreateMap<PersonListViewModel, Person>();
            CreateMap<PersonNameViewModel, Person>();
            CreateMap<Person, PersonFormViewModel>();
            CreateMap<Person, PersonListViewModel>();
            CreateMap<Person, PersonNameViewModel>();

            CreateMap<PositionFormViewModel, Position>();
            CreateMap<PositionListViewModel, Position>();
            CreateMap<PositionNameViewModel, Position>();
            CreateMap<Position, PositionFormViewModel>();
            CreateMap<Position, PositionListViewModel>();
            CreateMap<Position, PositionNameViewModel>();

            CreateMap<ShiftFormViewModel, Shift>();
            CreateMap<ShiftListViewModel, Shift>();
            CreateMap<ShiftNameViewModel, Shift>();
            CreateMap<Shift, ShiftFormViewModel>();
            CreateMap<Shift, ShiftListViewModel>();
            CreateMap<Shift, ShiftNameViewModel>();

            CreateMap<ShiftTypeFormViewModel, ShiftType>();
            CreateMap<ShiftTypeListViewModel, ShiftType>();
            CreateMap<ShiftTypeNameViewModel, ShiftType>();
            CreateMap<ShiftType, ShiftTypeFormViewModel>();
            CreateMap<ShiftType, ShiftTypeListViewModel>();
            CreateMap<ShiftType, ShiftTypeNameViewModel>();

            CreateMap<UserListViewModel, User>();
            CreateMap<RegisterViewModel, User>();
            CreateMap<LoginViewModel, User>();
            CreateMap<User, LoginViewModel>();
            CreateMap<User, UserListViewModel>();
            CreateMap<User, RegisterViewModel>();

            CreateMap<RoleListViewModel, Role>();
            CreateMap<RoleNameViewModel, Role>();
            CreateMap<Role, RoleNameViewModel>();
            CreateMap<Role, RoleListViewModel>();
        }
    }
}
