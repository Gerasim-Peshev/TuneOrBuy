using Microsoft.EntityFrameworkCore;
using TuneOrBuy.Web.Data;

namespace TuneOrBuy.Tests.Mocks
{
    public static class DatabaseMock
    {
        public static TuneOrBuyDbContext Context
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<TuneOrBuyDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;

                return new TuneOrBuyDbContext(dbContextOptions);
            }
        }
    }
}
