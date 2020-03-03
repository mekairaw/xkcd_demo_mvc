using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XKCDTest.DTO.ViewModels;

namespace XKCDTest.Repository.Interfaces
{
    public interface IComicRepo
    {
        Task<VMComicDetail> GetComicOfDay();
    }
}
