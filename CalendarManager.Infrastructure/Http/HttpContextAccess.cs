
using System.Linq;
using System.Web;
using CalendarManager.Infrastructure.Constants;
using CalendarManager.Infrastructure.Enums;
using CalendarManager.Infrastructure.Validators.Enums;

namespace CalendarManager.Infrastructure.Http
{
    public static class HttpContextAccess
    {
        public static string GetPublicKey()
        {
            return HttpContext.Current.Request.Headers[GlobalConstants.PublicKey];
        }

        public static Enumerator GetLoginType()
        {
            var headerLoginType = HttpContext.Current.Request.Headers[GlobalConstants.LoginType];
            var loginType = new LoginType().ConvertToCollection().FirstOrDefault(loginTp => loginTp.Value == int.Parse(headerLoginType));
            return loginType;
        }
    }
}