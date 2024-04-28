namespace RiverLoggerApi.DBContext
{
    public class RiverLoggerRepository : IRiverLoggerRepository
    {
        private readonly DapperContext _dapperContext;

        public RiverLoggerRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
    }
}
