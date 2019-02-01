using Microsoft.EntityFrameworkCore;

namespace BabysitterKata.Data.Tests
{
    internal class TestBabysitterDbContext: BabysitterDBContext
    {
        //private readonly 
        //    DbContextOptions options = new DbContextOptionsBuilder<TestBabysitterDbContext>()
        //                        .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
        //                        .Options;

        public TestBabysitterDbContext()
            : base(Options())
        {
        }

        private static DbContextOptions Options()
        {
        return  new DbContextOptionsBuilder<TestBabysitterDbContext>()
                              .UseInMemoryDatabase(databaseName: "TestBabysitterDb")
                              .Options;
        }
    }
}
