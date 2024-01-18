using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoAPITests.Repositories.Tests
{
    [TestClass()]
    public class ClientRepositoryTests
    {
        [TestMethod()]
        public async void GetAllClient()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<ClientDbContext>().UseInMemoryDatabase("client");

            var context = new ClientDbContext(builder.Options);
        }
    }
}
