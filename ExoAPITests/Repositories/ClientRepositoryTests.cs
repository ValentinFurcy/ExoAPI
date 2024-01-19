using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExoAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExoAPI.Context;
using ExoAPI.Models;

namespace ExoAPI.Repositories.Tests
{
    [TestClass()]
    public class ClientRepositoryTests
    {
        [TestMethod()]
        public async Task GetClientByIdAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ExoAPIContext>().UseInMemoryDatabase("client");

            var context = new ExoAPIContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Clients.Add(new Client { Id = 1, Name = "toto", Age = 10 });
            context.Clients.Add(new Client { Id = 2, Name = "tutu", Age = 12 });

            context.SaveChanges();

            ClientRepository clientRepository = new ClientRepository(context);

            //Act
            var clients = await clientRepository.GetClientByIdAsync(2);

            //Assert
            Assert.AreEqual(2, clients.Id = 2);

        }

        [TestMethod()]
        public async Task GetAllAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ExoAPIContext>().UseInMemoryDatabase("client");

            var context = new ExoAPIContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Clients.Add(new Client { Id = 1, Name = "toto", Age = 10 });
            context.Clients.Add(new Client { Id = 2, Name = "tutu", Age = 12 });

            context.SaveChanges();

            ClientRepository clientRepository = new ClientRepository(context);

            //Act
            var clients = await clientRepository.GetAllAsync();

            //Assert
            Assert.AreEqual("toto", clients.First().Name);
        }
    }
}