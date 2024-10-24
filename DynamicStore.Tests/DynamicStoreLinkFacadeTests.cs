using DynamicStore.Controllers;
using DynamicStore.Facades;
using DynamicStore.Facades.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Reflection.PortableExecutable;

namespace DynamicStore.Tests
{
    public class DynamicStoreLinkFacadeTests
    {
        private readonly DynamicLinkFacade _dynamicLinkFacade;

        public DynamicStoreLinkFacadeTests()
        {
            _dynamicLinkFacade = new DynamicLinkFacade();
        }
        [Fact]
        public async Task SendStoreLinkAsync_ReturnsOkToAndroid_WithCorrectLink()
        {
            // Arrange
            var headers = new HeaderDictionary
            {
                { "User-Agent", "Android" }
            };
            var teste = _dynamicLinkFacade.GetStoreLinkByOperationSystem(headers);

            Assert.Equal("https://play.google.com/store/apps/details?id=com.gm.chevrolet.nomad.ownership&gl=co", teste);
        }
        [Fact]
        public async Task SendStoreLinkAsync_ReturnsOkToiphone_WithCorrectLink()
        {
            // Arrange
            var headers = new HeaderDictionary
            {
                { "User-Agent", "iPhone" }
            };
            var teste = _dynamicLinkFacade.GetStoreLinkByOperationSystem(headers);

            Assert.Equal("https://apps.apple.com/co/app/mychevrolet/id398596699", teste);
        }
        [Fact]
        public async Task SendStoreLinkAsync_ReturnsOkToPC_WithCorrectLink()
        {
            // Arrange
            var headers = new HeaderDictionary
            {
                { "User-Agent", "Windows" }
            };
            var teste = _dynamicLinkFacade.GetStoreLinkByOperationSystem(headers);

            Assert.Equal("https://www.chevrolet.com.br/eletrico/para-voce/app-my-chevrolet", teste);
        }
        [Fact]
        public async Task SendStoreLinkAsync_ReturnsNotOk_WithCorrectLink()
        {
            // Arrange
            var headers = new HeaderDictionary
            {
                
            };
            var teste = _dynamicLinkFacade.GetStoreLinkByOperationSystem(headers);

            Assert.Equal("https://www.chevrolet.com.br/eletrico/para-voce/app-my-chevrolet", teste);
        }

    }
}
 