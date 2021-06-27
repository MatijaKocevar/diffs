using AutoMapper;
using Diffing.DTOs;
using Diffing.Models;

namespace Diffing.Profiles
{
    public class DiffsProfile : Profile //inherits
    {
        public DiffsProfile()
        {
            CreateMap<Result, ResultTypeDTO>();
        }
    }
}