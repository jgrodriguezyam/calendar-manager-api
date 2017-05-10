using System;

namespace CalendarManager.Model.Base
{
    public interface IAuditInfo
    {
        int CreatedBy { get; set; }
        int ModifiedBy { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime ModifiedOn { get; set; }
    }
}