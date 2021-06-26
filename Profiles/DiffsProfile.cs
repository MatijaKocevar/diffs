using AutoMapper;
using base64diffs.DTOs;
using base64diffs.Models;

namespace base64diffs.Profiles
{
    public class DiffsProfile : Profile //inherits
    {
        public DiffsProfile()
        {
            CreateMap<Result, ResultTypeDTO>();
        }
    }
}