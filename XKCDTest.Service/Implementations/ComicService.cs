﻿using System;
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
        public async Task<VMComic> GetComicOfDay()
        {
            var comicOfDay = await _comicRepo.GetComicOfDay();
            var navegation = await GetNavigationById(comicOfDay?.Num);
            return new VMComic { Comic = comicOfDay, NextComicId = navegation?.NextComicId, PreviousComicId = navegation?.PreviousComicId };
        }
        public async Task<VMComic> GetCustomComic(int comicId)
        {
            var comic = await _comicRepo.GetComicOfDay(comicId);
            var navegation = await GetNavigationById(comic?.Num);
            return new VMComic { Comic = comic, NextComicId = navegation?.NextComicId, PreviousComicId = navegation?.PreviousComicId };
        }
        public async Task<VMNavigation> GetNavigationById(int? comicId)
        {
            if(comicId != null)
            {
                return new VMNavigation { NextComicId = await _comicRepo.GetIdOfNextComic(comicId.Value), PreviousComicId = await _comicRepo.GetIdOfPreviousComic(comicId.Value) };
            }
            return new VMNavigation { NextComicId = null, PreviousComicId = null };
        }
    }
}
