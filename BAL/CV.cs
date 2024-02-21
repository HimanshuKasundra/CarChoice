namespace CarChoice.BAL
{
    public class CV
    {
        private static IHttpContextAccessor _HttpContextAccessor;
        static CV()
        {
             _HttpContextAccessor = new HttpContextAccessor();
        }

        public static int? CustomerID()
        {
            return Convert.ToInt32(_HttpContextAccessor.HttpContext.Session.GetString("CustomerID"));
        }

        public static string? UserName()
        {
            return _HttpContextAccessor.HttpContext.Session.GetString("UserName");

        }

        public static string? FirstName()
        {
            return _HttpContextAccessor.HttpContext.Session.GetString("FirstName");
        }
        public static string LastName()
        {
            return _HttpContextAccessor.HttpContext.Session.GetString("LastName");
        }
        
        public static string? IsAdmin()
        {
            return _HttpContextAccessor.HttpContext.Session.GetString("IsAdmin");
        }

        public static string? CustomerImageURL()
		{
			string? ImageURL = null;
			if (_HttpContextAccessor.HttpContext.Session.GetString("CustomerImageURL") != null)
			{
				ImageURL =
			   _HttpContextAccessor.HttpContext.Session.GetString("CustomerImageURL");
			}

			return ImageURL;
		}
	}
}
