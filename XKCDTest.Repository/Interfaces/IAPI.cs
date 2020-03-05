using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XKCDTest.DTO.ViewModels;

namespace XKCDTest.Repository.Interfaces
{
    public interface IAPI
    {
        Task<VMComicDetail> GetComicOfDay();
        //[Get("/{id}/info.0.json")]
        Task<VMComicDetail> GetCustomComic(int? id);
        Task<int?> GetFirstComicId();
    }
}
