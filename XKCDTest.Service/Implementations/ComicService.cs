using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XKCDTest.DTO.ViewModels;
using XKCDTest.Service.Interfaces;
using XKCDTest.Repository.Interfaces;

namespace XKCDTest.Service.Implementations
{
    public class ComicService: IComicService
    {
        private readonly IComicRepo _comicRepo;

        public ComicService(IComicRepo comicRepo)
        {
            _comicRepo = comicRepo;
        }
        public async Task<VMComicDetail> GetComicOfDay()
        {
            var comicOfDay = await _comicRepo.GetComicOfDay();
            return comicOfDay;
        }
    }
}
