using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Refit;
using XKCDTest.DTO.ViewModels;
using XKCDTest.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace XKCDTest.Repository.Implementations
{
    public class ComicRepo: IComicRepo
    {
        private readonly IAPI _api;

        [ActivatorUtilitiesConstructor]
        public ComicRepo()
        {
            _api = RestService.For<IAPI>("https://xkcd.com");
        }
        public async Task<VMComicDetail> GetComicOfDay()
        {
            try
            {
                return await _api.GetComicOfDay();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<int?> GetIdOfLastComic()
        {
            try
            {
                var lastComic = await _api.GetComicOfDay();
                return lastComic.Num;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
