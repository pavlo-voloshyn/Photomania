using AutoMapper;
using PVI.KR.DataAccess.Entities;
using PVI.KR.Models;

namespace PVI.KR.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserRegister, User>();
        }
    }
}
