using Car4U.Data.Infrastructure;
using Car4U.Infrastructure.Data.Common;

namespace Car4U.Tests.Mocks
{
    public static class RepositoryMock
    {
        public static Repository Instance(Car4UDbContext _context)
        {
            return new Repository(_context);
        }

    }
}
