using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using XKCDTest.DTO.ViewModels;
using XKCDTest.Repository.Interfaces;
using XKCDTest.Service.Implementations;

namespace XKCDTest.Testing
{
    public class ComicServiceTest
    {
        [Fact]
        public async Task Test_Success_Get_Next_Comic()
        {
            //Arrange
            int id = 362;
            var mockRepo = new Mock<IComicRepo>();
            mockRepo.Setup(s => s.GetIdOfFirstComic())
                .ReturnsAsync(GetFirstID());
            mockRepo.Setup(s => s.GetIdOfLastComic())
                .ReturnsAsync(GetLastID(id));
            mockRepo.Setup(s => s.GetIdOfNextComic(id))
                .ReturnsAsync(GetNextId(id));
            mockRepo.Setup(s => s.GetComicOfDay(id + 1))
                .Returns(GetComic(id + 1));

            var service = new ComicService(mockRepo.Object);

            //Act
            var result = await service.GetCustomComic(id + 1);

            //Assert
            Assert.NotNull(result.Comic);
            Assert.Equal(id + 1, result.Comic.Num);
            Assert.Equal("Test Comic", result.Comic.SafeTitle);
        }
        [Fact]
        public async Task Test_Success_Get_Previous_Comic()
        {
            //Arrange
            int id = 982;
            var mockRepo = new Mock<IComicRepo>();
            mockRepo.Setup(s => s.GetIdOfFirstComic())
                .ReturnsAsync(GetFirstID());
            mockRepo.Setup(s => s.GetIdOfLastComic())
                .ReturnsAsync(GetLastID(id));
            mockRepo.Setup(s => s.GetIdOfPreviousComic(id))
                .ReturnsAsync(GetPreviousId(id));
            mockRepo.Setup(s => s.GetComicOfDay(id - 1))
                .Returns(GetComic(id - 1));
            var service = new ComicService(mockRepo.Object);

            //Act
            var result = await service.GetCustomComic(id - 1);

            //Assert
            Assert.NotNull(result.Comic);
            Assert.Equal(id - 1, result.Comic.Num);
            Assert.Equal("Testing", result.Comic.Alt);
        }

        private int GetFirstID()
        {
            return 1;
        }

        private int GetLastID(int id)
        {
            return id;
        }

        private int GetNextId(int id)
        {
            return id + 1;
        }

        private int GetPreviousId(int id)
        {
            return id - 1;
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
