using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using MediatR;
using OP.RememberTheDate.WebService.Commands;
using OP.RememberTheDate.WebService.Filters;
using OP.RememberTheDate.WebService.Queries;

// ReSharper disable once InconsistentNaming

namespace OP.RememberTheDate.WebService.Controllers
{
    public class DateController : ApiController
    {
        private readonly IMediator mediator;

        public DateController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [ValidateModel]
        public IHttpActionResult Register([FromBody]RegisterDate registerDate)
        {
            mediator.Send(registerDate);
            return new StatusCodeResult(HttpStatusCode.Created, Request);
        }

        [HttpGet]
        [ValidateModel]
        public IHttpActionResult GetEventByName([FromUri]DatesByNameQuery datesByNameQuery)
        {
            var queryResult = mediator.Send(datesByNameQuery);
            return Ok(queryResult);
        }

        [HttpGet]
        [ValidateModel]
        public IHttpActionResult GetEventByMonth([FromUri]DatesByMonthQuery datesByMonthQuery)
        {
            var queryResult = mediator.Send(datesByMonthQuery);
            return Ok(queryResult);
        }

        [HttpGet]
        [ValidateModel]
        public IHttpActionResult GetEventByYear([FromUri]DatesByYearQuery datesByYearQuery)
        {
            var queryResult = mediator.Send(datesByYearQuery);
            return Ok(queryResult);
        }

        [HttpGet]
        [ValidateModel]
        public IHttpActionResult GetEventByRange([FromUri]DatesByRangeQuery datesByRangeQuery)
        {
            var queryResult = mediator.Send(datesByRangeQuery);
            return Ok(queryResult);
        }
    }
}
