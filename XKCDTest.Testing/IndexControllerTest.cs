using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using XKCDTest.DTO.ViewModels;
using XKCDTest.Service.Interfaces;
using XKCDTest.Controllers;

namespace XKCDTest.Testing
{
    public class IndexControllerTest
    {
        [Fact]
        public async Task Test_Success_In_View_When_Getting_Comic_By_Id()
        {
            //Arrange
            int id = 500;
            var mockService = new Mock<IComicService>();
            mockService.Setup(s => s.GetCustomComic(id))
                .ReturnsAsync(GetComicById(id));
            var controller = new HomeController(mockService.Object);
            //Act
            var result = await controller.Index(id);
            //Assert
            var view = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<VMComic>(view.Model);
            Assert.NotNull(model.Comic);
            Assert.Equal(id, model.Comic.Num);
            Assert.Equal(id, model.FirstComicId);
            Assert.Equal(id, model.LastComicId);
        }

        private VMComic GetComicById(int id)
        {
            return new VMComic
            {
                Comic = new VMComicDetail
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
                },
                FirstComicId = id,
                LastComicId = id,
                NextComicId = null,
                PreviousComicId = null
            };
        }
    }
}
