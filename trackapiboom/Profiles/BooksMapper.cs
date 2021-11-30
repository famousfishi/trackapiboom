using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trackapiboom.DTOs;
using trackapiboom.Models;

namespace trackapiboom.Profiles
{
    public class BooksMapper  : Profile
    {
        public BooksMapper()
        {
            CreateMap<Books, BookDTO>().ReverseMap();
        }
    }
}
