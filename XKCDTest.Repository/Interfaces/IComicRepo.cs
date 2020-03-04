using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XKCDTest.DTO.ViewModels;

namespace XKCDTest.Repository.Interfaces
{
    public interface IComicRepo
    {
        Task<VMComicDetail> GetComicOfDay(int? id = null);
        Task<int?> GetIdOfLastComic();
        Task<int?> GetIdOfFirstComic();
    }
}
