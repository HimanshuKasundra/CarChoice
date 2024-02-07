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
            //         try
            //         {
            //             Console.WriteLine(_HttpContextAccessor.HttpContext.Session.GetString("CustomerID"));

            //             if (_HttpContextAccessor.HttpContext.Session.GetString("CustomerID") != null)
            //             {
            //		Console.WriteLine(_HttpContextAccessor.HttpContext.Session.GetString("CustomerID"));

            //		return Convert.ToInt32(_HttpContextAccessor.HttpContext.Session.GetString("CustomerID"));

            //	}
            //	else
            //                 return 0;

            //}catch(Exception ex)
            //         {
            //             return null;    
            //         }
            Console.WriteLine(_HttpContextAccessor.HttpContext.Session.GetString("CustomerID"));
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
        
        public static string? ImageURL()
		{
			string? ImageURL = null;
			if (_HttpContextAccessor.HttpContext.Session.GetString("ImageURL") != null)
			{
				ImageURL =
			   _HttpContextAccessor.HttpContext.Session.GetString("ImageURL");
			}

			return ImageURL;
		}
	}
}
