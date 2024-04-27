using Car4U.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Car4U.Tests.Mocks
{
    public static class DatabaseMock
    {
        public static Car4UDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<Car4UDbContext>()
                    .UseInMemoryDatabase("Car4UInMemoryDb"
                    + Guid.NewGuid().ToString())
                    .Options;

                return new Car4UDbContext(dbContextOptions, false);
            }
        }


    }
}
