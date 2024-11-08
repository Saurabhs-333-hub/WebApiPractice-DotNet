﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_.Data;
using WebApi_.Models.Domains;
using WebApi_.Models.DTOs;

namespace WebApi_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly Web_DbContext dbContext;

        public RegionsController(Web_DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var regions=dbContext.Regions.ToList();
            var regionDtos = new List<RegionDTO>();
            foreach (var region in regions)
            {
                regionDtos.Add(
                    new RegionDTO
                    {
                        Id = region.Id,
                        Code = region.Code,
                        Name = region.Name,
                        RegionImageUrl = region.RegionImageUrl
                    }
                );
            }
            return Ok(regionDtos);
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public IActionResult GetRegionById([FromRoute]Guid Id)
        {
            //var region = dbContext.Regions.Find(Id);
            var region = dbContext.Regions.FirstOrDefault(e => e.Id == Id);
           
            if (region == null)
            {
                return NotFound();
            }
            var regionDto = new RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };
            return Ok(regionDto);
        }

        [HttpPost]

        public IActionResult CreateRegion([FromBody] AddRegionDTO addRegionDto)
        {
            var region = new Region
            {
                Code = addRegionDto.Code,
                Name = addRegionDto.Name,
                RegionImageUrl = addRegionDto.RegionImageUrl
            };

            dbContext.Regions.Add(region);
            dbContext.SaveChanges();
            var regionDto = new RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };
            return CreatedAtAction(nameof(GetRegionById), new { Id = region.Id }, regionDto);
        }
    }
}
