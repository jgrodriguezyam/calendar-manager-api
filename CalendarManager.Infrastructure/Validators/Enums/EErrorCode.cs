namespace CalendarManager.Infrastructure.Validators.Enums
{
    public enum EErrorCode
    {
        NotFound = 1,
        InvalidCredential = 2,
        UnauthorizedChangePassword = 3,
        Conflict = 4,
        InvalidKey = 5,
        InvalidTimespan = 6,
        InvalidSerial = 7,
        InvalidDate = 8,
        IsZero = 9,
        IsNotZero = 10,
        AlreadyReferenced = 12
    }
}