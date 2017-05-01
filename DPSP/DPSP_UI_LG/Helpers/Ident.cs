using DPSP_UI_LG.Models;
using System.Web;

namespace DPSP_UI_LG.Helpers
{
    public class Ident
    {
        public static bool IsLogged => HttpContext.Current.Session["TokenModel"] != null && !string.IsNullOrWhiteSpace(Helpers.Ident.Get().access_token);
        public static void Set(TokenModel tokenModel) => HttpContext.Current.Session.Add("TokenModel", tokenModel);
        public static TokenModel Get() => HttpContext.Current.Session["TokenModel"] as TokenModel;
        public static void Clear() => HttpContext.Current.Session["TokenModel"] = null;
    }
}