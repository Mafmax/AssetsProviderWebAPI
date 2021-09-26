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
    /// Provides API to work with issuer companies
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class IssuersController : Controller
    {
        private readonly IIssuersService service;
        private readonly ILogger<IssuersService> logger;

        /// <summary>
        /// Creates controller
        /// </summary>
        /// <param name="service">Service to recieve data</param>
        /// <param name="logger">Logger</param>
        public IssuersController(IIssuersService service, ILogger<IssuersService> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        /// <summary>
        /// Gets all issuer companies
        /// </summary>
        /// <returns>Returns list of issuer companies</returns>
        /// <responce code="200">Returns list of issuer companies</responce>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<IssuerDto>>> Get()
        {
            var issuers = await service.GetIssuersAsync();
            return new(issuers);
        }

        /// <summary>
        /// Gets all assets of issuer-company
        /// </summary>
        /// <param name="issuerId">Issuer company identifier</param>
        /// <returns>List of short assets information</returns>
        /// <responce code="200">Returns list of issuers</responce>
        /// <responce code="404">If issuer not found</responce>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{issuerId}")]
        public async Task<ActionResult<IEnumerable<ShortAssetDto>>> GetAssets(int issuerId)
        {
            IEnumerable<ShortAssetDto> assets;
            try
            {
                assets = await service.GetAssetsAsync(issuerId);
            }
            catch (KeyNotFoundException ex)
            {
                logger.LogWarning(ex, "Issuer with id = {0} not found", issuerId);
                return NotFound();
            }

            return new(assets);
        }

    }
}
