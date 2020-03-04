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
            int? lastId = await GetIdOfLastComic();
            if(firstId == null || lastId == null)
            {
                return null;
            }
            int? previousId = null;
            for(int i = comicId - 1; i <= lastId && i >= firstId; i--)
            {
                var comic = await _api.GetCustomComic(i);
                if(comic != null)
                {
                    previousId = comic.Num;
                    break;
                }
            }

            return previousId;
        }
        public async Task<int?> GetIdOfNextComic(int comicId)
        {
            int? lastId = await GetIdOfLastComic();
            int? firstId = await GetIdOfFirstComic();
            if(lastId == null || firstId == null)
            {
                return null;
            }
            int? nextId = null;
            for(int i = comicId + 1; i <= lastId && i >= firstId; i++)
            {
                var comic = await _api.GetCustomComic(i);
                if(comic != null)
                {
                    nextId = comic.Num;
                    break;
                }
            }

            return nextId;
        }
    }
}
