using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XKCDTest.DTO.ViewModels;

namespace XKCDTest.Service.Interfaces
{
    public interface IComicService
    {
        Task<VMComicDetail> GetComicOfDay();
    }
}
