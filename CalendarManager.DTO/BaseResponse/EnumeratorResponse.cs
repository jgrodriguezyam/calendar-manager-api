using System.Collections.Generic;
using CalendarManager.Infrastructure.Enums;

namespace CalendarManager.DTO.BaseResponse
{
    public class EnumeratorResponse
    {
        public EnumeratorResponse()
        {
            Enumerator = new List<Enumerator>();
        }

        public List<Enumerator> Enumerator { get; set; }
    }
}