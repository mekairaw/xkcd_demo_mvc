using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using XKCDTest.DTO.ViewModels;
using XKCDTest.Repository.Interfaces;
using XKCDTest.Repository.Implementations;

namespace XKCDTest.Testing
{
    public class ComicRepoTest
    {
        [Fact]
        public async Task Test_Success_Get_Next_Comic_Id()
        {
            //Arrange
            int id = 587;
            var mockAPI = new Mock<IAPI>();
            mockAPI.Setup(s => s.GetFirstComicId())
                .ReturnsAsync(GetFirstID());
            mockAPI.Setup(s => s.GetComicOfDay())
                .Returns(GetComic(id+2));
            mockAPI.Setup(s => s.GetCustomComic(id+1))
                .Returns(GetComic(id+1));
            var repo = new ComicRepo(mockAPI.Object);

            //Act
            var result = await repo.GetIdOfNextComic(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(id + 1, result);
        }
        [Fact]
        public async Task Test_Success_Get_Previous_Comic_Id()
        {
            //Arrange
            int id = 698;
            var mockAPI = new Mock<IAPI>();
            mockAPI.Setup(s => s.GetFirstComicId())
                .ReturnsAsync(GetFirstID());
            mockAPI.Setup(s => s.GetComicOfDay())
                .Returns(GetComic(id + 2));
            mockAPI.Setup(s => s.GetCustomComic(id - 1))
                .Returns(GetComic(id - 1));
            var repo = new ComicRepo(mockAPI.Object);

            //Act
            var result = await repo.GetIdOfPreviousComic(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(id - 1, result);
        }
        private int GetFirstID()
        {
            return 1;
        }
        private async Task<VMComicDetail> GetComic(int id)
        {
            await Task.Delay(100);
            return new VMComicDetail
            {
                Alt = "Testing",
                day = "04",
                Img = "http://xkcd.com",
                Link = "test.com",
                Month = "03",
                Num = id,
                SafeTitle = "Test Comic",
                Title = "Test Comic",
                Transcript = "Test",
                Yeat = "2020"
            };
        }
    }
}
