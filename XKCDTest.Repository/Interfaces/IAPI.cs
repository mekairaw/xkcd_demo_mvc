using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Refit;
using XKCDTest.DTO.ViewModels;

namespace XKCDTest.Repository.Interfaces
{
    public interface IAPI
    {
        [Get("/info.0.json")]
        Task<VMComicDetail> GetComicOfDay();
    }
}
