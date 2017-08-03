using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using CalendarManager.Infrastructure.Enums;
using CalendarManager.Infrastructure.Integers;
using CalendarManager.Infrastructure.Objects;
using CalendarManager.Infrastructure.Strings;
using CalendarManager.Infrastructure.Validators.Enums;

namespace CalendarManager.Infrastructure.Exceptions
{
    public static class ExceptionExtensions
    {
        public static void ThrowExceptionIfIsNull<TException>(this object objectValue, string message) where TException : Exception
        {
            if (objectValue.IsNull())
                ThrowException<TException>(message);
        }

        public static void ThrowExceptionIfIsNullOrEmpty<TException>(this string stringValue, string message) where TException : Exception
        {
            if (stringValue.IsNullOrEmpty())
                ThrowException<TException>(message);
        }

        public static void ThrowExceptionIfIsNotNull<TException>(this object objectValue, string message) where TException : Exception
        {
            if (objectValue.IsNotNull())
                ThrowException<TException>(message);
        }

        public static void ThrowExceptionIfIsNotNullOrEmpty<TException>(this string stringValue, string message) where TException : Exception
        {
            if (stringValue.IsNotNullOrEmpty())
                ThrowException<TException>(message);
        }

        public static void ThrowExceptionIfIsZero(this int intValue)
        {
            if (intValue.IsZero())
                ThrowCustomException(HttpStatusCode.Conflict, EErrorCode.IsZero, "El valor no puede ser cero");
        }

        public static void ThrowExceptionIfIsNotZero(this int intValue)
        {
            if (intValue.IsNotZero())
                ThrowCustomException(HttpStatusCode.Conflict, EErrorCode.IsNotZero, "El valor no es cero");
        }

        private static void ThrowException<TException>(string message) where TException : Exception
        {
            var exceptionType = typeof(TException);
            var exceptionConstructor = exceptionType.GetConstructor(new[] { typeof(string) });
            var exception = (TException)exceptionConstructor.Invoke(new object[] { message });
            throw exception;
        }

        public static void ThrowExceptionIfIsSameValue<TException>(this object objectValue, object valueToCompare) where TException : Exception
        {
            if (objectValue.Equals(valueToCompare))
                ThrowException<TException>("SameValue");
        }

        public static void ThrowExceptionIfIsNull(this object objectValue, HttpStatusCode httpStatusCode, string message)
        {
            if (objectValue.IsNull())
                ThrowCustomException(httpStatusCode, message);
        }

        public static void ThrowCustomException(HttpStatusCode httpStatusCode, string message)
        {
            throw new HttpResponseException(new HttpResponseMessage
            {
                StatusCode = httpStatusCode,
                Content = new StringContent("{\"Message\": \"" + message + "\"}", Encoding.Default, "application/json")
            });
        }

        public static void ThrowExceptionIfIsSameStatus(this bool statusToChange, bool newStatus)
        {
            if (statusToChange.Equals(newStatus))
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Accepted,
                    Content = new StringContent("{\"Message\": \"El registro ya se encuentra " + (newStatus ? "activo" : "inactivo") + "\"}", Encoding.Default, "application/json")
                });
            }
        }

        public static void ThrowExceptionIfIsReference(this bool isRefence)
        {
            if (isRefence)
                ThrowCustomException(HttpStatusCode.PreconditionFailed, EErrorCode.AlreadyReferenced, "Remover previamente las referencias");
        }

        public static void ThrowExceptionIfRecordIsNull(this object objectValue)
        {
            if (objectValue.IsNull())
                ThrowCustomException(HttpStatusCode.NotFound, EErrorCode.NotFound, "Registro no encontrado");
        }

        public static void ThrowCustomException(HttpStatusCode httpStatusCode, EErrorCode errorCode, string message)
        {
            throw new HttpResponseException(new HttpResponseMessage
            {
                StatusCode = httpStatusCode,
                Content = new StringContent("{\"ErrorCode\": " + errorCode.GetValue() + ",\"Message\": \"" + message + "\"}", Encoding.Default, "application/json")
            });
        }

        public static void ThrowCustomConflictException(EErrorCode errorCode, string message)
        {
            ThrowCustomException(HttpStatusCode.Conflict, errorCode, message);
        }
    }
}