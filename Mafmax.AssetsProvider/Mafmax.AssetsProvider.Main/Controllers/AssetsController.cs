using Mafmax.AssetsProvider.BLL.DTOs;
using Mafmax.AssetsProvider.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mafmax.AssetsProvider.Main.Controllers
{
    /// <summary>
    /// Provides API to work with assets
    /// </summary>
    [Route("api/[controller]")]
[ApiController]
    public class AssetsController : Controller
    {
        private readonly IAssetsService service;
        private readonly ILogger<AssetsController> logger;

        /// <summary>
        /// Creates controller
        /// </summary>
        /// <param name="service">Service to gets assets info</param>
        /// <param name="logger">Logger</param>
        public AssetsController(IAssetsService service, ILogger<AssetsController> logger)
        {
            this.service = service;
            this.logger = logger;
        }
        /// <summary>
        /// Gets asset by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Asset full information</returns>
        ///<responce code="200">Returns asset</responce>
        ///<responce code="404">If asset not found</responce>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AssetDto>> GetById(int id)
        {
            var asset = await service.GetByIdAsync(id);
            if (asset is null) return NotFound();
            return asset;
        }
        /// <summary>
        /// Gets asset by identifier
        /// </summary>
        /// <param name="isin">International Securities Identifier Number</param>
        /// <returns>Asset full information</returns>
        ///<responce code="200">Returns asset</responce>
        ///<responce code="404">If asset not found</responce>
        [HttpGet("{isin}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AssetDto>> GetByISIN(string isin)
        {
            var asset = await service.GetByISINAsync(isin);
            if (asset is null) return NotFound();
            return asset;
        }

        /// <summary>
        /// Finds assets
        /// </summary>
        /// <param name="searchQuery">Value to find in ISIN, Name or Ticker</param>
        /// <param name="classFilter">Filter</param>
        /// <returns>Found assets of class</returns>
        ///<responce code="200">Returns found assets</responce>
        ///<responce code="204">If matches not found</responce>
        ///<responce code="400">If search query less then 3 characters long</responce>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{searchQuery}/{classFilter}")]
        public async Task<ActionResult<Dictionary<string, IEnumerable<ShortAssetDto>>>> Find(string searchQuery, string classFilter)
        {
            const int minSearchQueryLength = 3;
            if(searchQuery.Length < minSearchQueryLength)
            {
                return BadRequest();
            }
            var assets = await service.FindAssetsAsync(searchQuery, classFilter);
            if (assets.Count.Equals(0)) return NoContent();
            return assets;
        }

        /// <summary>
        /// Finds assets
        /// </summary>
        /// <param name="searchQuery">Value to find in ISIN, Name or Ticker</param>
        /// <returns>Found assets grouped by class</returns>
        ///<responce code="200">Returns found assets</responce>
        ///<responce code="204">If matches not found</responce>
        ///<responce code="400">If search query less then 3 characters long</responce>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{searchQuery}")]
        public async Task<ActionResult<Dictionary<string, IEnumerable<ShortAssetDto>>>> Find(string searchQuery)
        {
            return await Find(searchQuery, null);
        }
    }
}
