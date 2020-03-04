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
        public async Task<VMComicDetail> GetComicOfDay(int? id)
        {
            try
            {
                if(id != null)
                {
                    return await _api.GetCustomComic(id);
                }
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
        public Task<int?> GetIdOfFirstComic()
        {
            try
            {
                return Task.Run(() => (int?)1);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<int?> GetIdOfPreviousComic(int comicId)
        {
            int? firstId = await GetIdOfFirstComic();
            if(firstId != null && (comicId - 1 < firstId))
            {
                return null;
            }
            return comicId - 1;
        }
        public async Task<int?> GetIdOfNextComic(int comicId)
        {
            int? lastId = await GetIdOfLastComic();
            if(lastId != null && (comicId + 1 > lastId))
            {
                return null;
            }
            return comicId + 1;
        }
    }
}
