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
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _DeviceService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public DeviceController(IDeviceService DeviceService,
            IMapper mapper, 
            ILogger<DeviceController> logger)
        {
            _DeviceService = DeviceService;
            _mapper = mapper;
            _logger = logger;
        }

        
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(DeviceDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var entity = _mapper.Map<Device>(model);
                entity.AddedDate = DateTime.Now;

                var result = await _DeviceService.AddAsync(entity);

                var dto = _mapper.Map<DeviceDto>(result);

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
        public async Task<IActionResult> Update(DeviceDto model) 
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var entity = _mapper.Map<Device>(model);
                entity.ModifiedDate = DateTime.Now;

                var result = await _DeviceService.UpdateDevice(entity);

                var dto = _mapper.Map<DeviceDto>(result);

                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(Constants.ErrorController);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _DeviceService.Delete(new Device { Id = Id });
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
                var result = await _DeviceService.GetByIdAsync(Id);
                var dtoResult = _mapper.Map<DeviceDto>(result);

                return Ok(dtoResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(Constants.ErrorController);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _DeviceService.GetAllAsync();
                var dtoResult = _mapper.Map<List<DeviceDto>>(result);

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
