using System;
using System.Web.Http;
using CalendarManager.DTO.BaseResponse;
using CalendarManager.Infrastructure.Dates;
using CalendarManager.Infrastructure.Enums;
using CalendarManager.Infrastructure.Validators.Enums;

namespace CalendarManager.Controllers
{
    public class ApplicationController : ApiController
    {
        [HttpGet, Route("alive")]
        public IsAliveResponse IsAlive()
        {
            return new IsAliveResponse { IsSuccess = true, Date = DateTime.Now.Date.ToDateString() };
        }

        [HttpGet, Route("date")]
        public DateResponse GetDate()
        {
            return new DateResponse { Date = DateTime.Now.Date.ToDateString() };
        }

        [HttpGet, Route("error-codes")]
        public EnumeratorResponse ErrorCode()
        {
            return new EnumeratorResponse { Enumerator = new EErrorCode().ConvertToCollection() };
        }
    }
}