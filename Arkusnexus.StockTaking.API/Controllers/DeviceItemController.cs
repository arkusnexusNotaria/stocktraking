using Arkusnexus.StockTaking.API.Dtos;
using Arkusnexus.StockTaking.ApplicationCore.Application.Interfaces;
using Arkusnexus.StockTaking.ApplicationCore.Core.Entities;
using Arkusnexus.StockTaking.Infrastructure.Commun;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Arkusnexus.StockTaking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DeviceItemController : ControllerBase
    {
        private readonly IDeviceItemService _DeviceItemService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public DeviceItemController(IDeviceItemService DeviceItemService,
            IMapper mapper,
            ILogger<DeviceItemController> logger)
        {
            _DeviceItemService = DeviceItemService;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(DeviceItemDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var entity = _mapper.Map<DeviceItem>(model);
                entity.AddedDate = DateTime.Now;

                var result = await _DeviceItemService.AddAsync(entity);

                var dto = _mapper.Map<DeviceItemDto>(result);

                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(Constants.ErrorController);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(DeviceItemDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var entity = _mapper.Map<DeviceItem>(model);
                entity.ModifiedDate = DateTime.Now;

                var result = await _DeviceItemService.UpdateDeviceItem(entity);

                var dto = _mapper.Map<DeviceItemDto>(result);

                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(Constants.ErrorController);
            }
        }


        [HttpPut]
        [Route("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus([FromRoute]int DeviceItemId, [FromRoute] int StatusId)
        {
            try
            {
                await _DeviceItemService.ChangeStatus(DeviceItemId, StatusId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(Constants.ErrorController);
            }
        }

        //[HttpGet]
        //[Route("GetByStatus")]
        //public async Task<IActionResult> GetByStatus([FromQuery] int Status) 
        //{
        //    try
        //    {
        //        await _DeviceItemService.GetByStatusAsync(Status);    
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.ToString());
        //        return BadRequest(Constants.ErrorController);
        //    }
        //}

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _DeviceItemService.Delete(new DeviceItem { Id = Id });
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(Constants.ErrorController);
            }
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                var result = await _DeviceItemService.GetByIdAsync(Id);
                var dtoResult = _mapper.Map<DeviceItemDto>(result);

                return Ok(dtoResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(Constants.ErrorController);
            }
        }

        //[HttpGet]
        //[Route("GetAll")]
        //public async Task<IActionResult> GetAll()
        //{
        //    try
        //    {
        //        var result = await _DeviceItemService.GetAllAsync();
        //        var dtoResult = _mapper.Map<List<DeviceItemDto>>(result);

        //        return Ok(dtoResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.ToString());
        //        return BadRequest(Constants.ErrorController);
        //    }
        //}

        [HttpGet]
        [Route("GetByFilters")]
        public async Task<IActionResult> GetByFilters([FromQuery]int? DeviceId, 
                                                [FromQuery] string? SerialNumber, 
                                                [FromQuery] string? Brand,
                                                [FromQuery] string? Model,
                                                [FromQuery] int? Status)
        {
            try
            {
                var result = await _DeviceItemService.GetByFilters(DeviceId,SerialNumber,Brand,Model,Status);
                var dtoResult = _mapper.Map<List<DeviceItemDto>>(result);

                return Ok(dtoResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(Constants.ErrorController);
            }
        }

    }
}
