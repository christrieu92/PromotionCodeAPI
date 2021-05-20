using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromotionCodeAPI.Domain;
using PromotionCodeAPI.Dtos;
using PromotionCodeAPI.Services;
using System;
using System.Collections.Generic;

namespace PromotionCodeAPI.Controllers
{
    [Authorize]
    [Route("api/services")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        
        private readonly IMapper _mapper;

        public ServiceController(IServiceService serviceService, IMapper mapper)
        {
            _serviceService = serviceService ?? throw new ArgumentNullException(nameof(_serviceService));

            _mapper = mapper;
        }

        /// Get: api/services
        /// <summary>
        /// Gets all Services 
        /// </summary>
        /// <returns>A list of Service dto's</returns>
        [HttpGet]
        public ActionResult<IEnumerable<ServiceDto>> GetAllServices()
        {
            IEnumerable<Service> services = _serviceService.GetAllServices();

            IEnumerable<ServiceDto> servicesDto = _mapper.Map<IEnumerable<ServiceDto>>(services);

            return Ok(servicesDto);
        }

        /// Get: api/services/{name}
        /// <summary>
        /// Gets Services by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A list of Service dto's</returns>
        [HttpGet("{name}")]
        public ActionResult<IEnumerable<ServiceDto>> GetServiceByName(string name)
        {
            IEnumerable<Service> service = _serviceService.GetServiceByName(name);

            IEnumerable<ServiceDto> serviceDto = _mapper.Map<IEnumerable<ServiceDto>>(service);

            return Ok(serviceDto);
        }

        /// <summary>
        /// Adds a bonus entry to know Service is activated
        /// </summary>
        /// <param name="bonusDto"></param>
        /// <returns></returns>
        [HttpPost("bonus")]
        public ActionResult<IEnumerable<BonusDto>> AddServiceBonus(BonusDto bonusDto)
        {
            Bonus bonusMap = _mapper.Map<Bonus>(bonusDto);

            _serviceService.AddServiceBonus(bonusMap);

            BonusDto bonusDtoMap = _mapper.Map<BonusDto>(bonusMap);

            IEnumerable<Bonus> getBonus = _serviceService.GetServiceBonusById(bonusDtoMap.BonusId);

            return Ok(getBonus);
        }
    }
}
