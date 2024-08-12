using Application.Features.CQRS.Commands.BannerComands;
using Application.Features.CQRS.Handlers.BannerHandlers;
using Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly GetBannerQueryHandler _getbannerqueryhandler;
        private readonly GetBannerByIdQueryHandler _getbanneridhandler;
        private readonly CreateBannerCommandHandler _createbannercommandhandler;
        private readonly UpdateBannerCommandHandler _updatebannercommandhandler;
        private readonly RemoveBannerCommandHandler _removebannercommandhandler;

        public BannersController(GetBannerQueryHandler getbannerqueryhandler, GetBannerByIdQueryHandler getbanneridhandler, CreateBannerCommandHandler createbannercommandhandler, UpdateBannerCommandHandler updatebannercommandhandler, RemoveBannerCommandHandler removebannercommandhandler)
        {
            _getbannerqueryhandler = getbannerqueryhandler;
            _getbanneridhandler = getbanneridhandler;
            _createbannercommandhandler = createbannercommandhandler;
            _updatebannercommandhandler = updatebannercommandhandler;
            _removebannercommandhandler = removebannercommandhandler;
        }

        [HttpGet]
        public async Task<IActionResult> Bannerlist()
        {
            var values = await _getbannerqueryhandler.Handle();
            return Ok(values);

        }

        [HttpGet]
        [Route("BannerId/{id}")]
        public async Task<IActionResult> GetBannerById(int id)
        {
            var values = await _getbanneridhandler.Handle(new GetBannerByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _createbannercommandhandler.Handle(command);
            return Ok("Bilgi Eklendi");

        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteBanner(int id)
        {
            await _removebannercommandhandler.Handle(new RemoveBannerCommand(id));
            return Ok("Silme islemi basarili"); 

        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _updatebannercommandhandler.Handle(command);
            return Ok("Guncelleme Basarili");
        }

    }
}
