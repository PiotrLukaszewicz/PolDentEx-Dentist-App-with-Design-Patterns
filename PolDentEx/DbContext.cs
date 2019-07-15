using PolDentEx.Models;

namespace PolDentEx
{
    public class DbContext
    {
        public ApplicationDbContext ApplicationDbContext { get; }

        private static DbContext _instance;

        public static DbContext Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new DbContext();
                return _instance;
            }
        }


        private DbContext()
        {
            ApplicationDbContext = new ApplicationDbContext();
        }
    }
}