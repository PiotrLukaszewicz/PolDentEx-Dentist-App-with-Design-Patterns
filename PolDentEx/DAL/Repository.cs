namespace PolDentEx.DAL
{
    public class Repository
    {
        private static Repository _instance;

        public static Repository Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new Repository();

                return _instance;
            }
        }

        public FactoryData Data { get; }

        private Repository()
        {
            var dataSource = System.Configuration.ConfigurationManager.AppSettings["DataSource"];
            if(dataSource == "Database")
                Data = new FactoryData(DataSourceEnum.Database);
            else
                Data = new FactoryData(DataSourceEnum.API);
        }
    }
}