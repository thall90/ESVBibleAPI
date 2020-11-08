using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using ESVBible.Read.Query.EsvBible;
using ESVBible.Read.Query.Transport.EsvBible.Input;
using ESVBible.Read.Query.Transport.EsvBible.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThriveNextGen.Read.Query.Mapping.EsvBible;
using ThriveNextGen.Shared.Infrastructure.Read.Query;

namespace ESVBible.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EsvBibleController : ControllerBase
    {
        private readonly IQueryPublisher queryPublisher;
        
        public EsvBibleController(
            IQueryPublisher queryPublisher)
        {
            this.queryPublisher = queryPublisher;
        }

        /// <summary>
        /// Returns a list of all books in the Bible
        /// in the order that they appear in the Bible.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>List of Bible books with number of chapters in each book.</returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("GetBookNamesInBiblicalOrder")]
        public async Task<ActionResult<ICollection<GetEsvBookNamesInBiblicalOrderQueryResultDTO>>> GetBookNamesInBiblicalOrder(
            CancellationToken cancellationToken)
        {
            var query = new GetEsvBookNamesInBiblicalOrderQuery();
            var result = await queryPublisher.Publish(query, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Returns a list of all books in the Bible
        /// in alphabetical order, based on input sort direction.
        /// </summary>
        /// <param name="inputDTO"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>List of Bible books with number of chapters in each book.</returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("GetBookNamesInAbcOrder")]
        public async Task<ActionResult<ICollection<GetEsvBookNamesInBiblicalOrderQueryResultDTO>>> GetBookNamesInAbcOrder(
            [FromQuery] GetEsvBookNamesInAlphabeticalOrderInputDTO inputDTO,
            CancellationToken cancellationToken)
        {
            var query = inputDTO.ToQuery();
            var result = await queryPublisher.Publish(query, cancellationToken);
            return Ok(result);
        }
    }
}