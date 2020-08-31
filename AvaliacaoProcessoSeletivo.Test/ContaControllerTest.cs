using AvaliacaoProcessoSeletivo.Api.Controllers;
using AvaliacaoProcessoSeletivo.Api.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace AvaliacaoProcessoSeletivo.Test
{
    [TestClass]
    public class ContaControllerTest
    {

        public Contexto CriaContexto()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var connectionString = $"Data Source=C:\\Users\\vitor\\Documents\\Visual Studio 2019\\Projects\\AvaliacaoProcessoSeletivo\\AvaliacaoProcessoSeletivo.Test\\Avaliacao.db";

            var options = new DbContextOptionsBuilder<Contexto>()
                    .UseSqlite(connectionString)
                    .Options;

            return new Contexto(options);
        }

        [TestMethod]
        public void GetTest()
        {
            var cont = new ContaController(null, CriaContexto());
            var lista = cont.Get();

            Assert.IsNotNull(lista);


            cont.Post(new Api.Domain.Conta
            {
                Nome = "zeh",
                Descricao = "maneh"
            });

            lista = cont.Get();
            Assert.AreNotEqual(0, lista.Count());
        }

        [TestMethod]
        public void PostTest()
        {
            var cont = new ContaController(null, CriaContexto());

            var result = cont.Post(new Api.Domain.Conta
            {
                Nome = "yossef",
                Descricao = "manuelph"
            });

            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Id);

            var ob = cont.Get().FirstOrDefault(x => x.Id == result.Id);

            Assert.AreEqual(result.Id, ob.Id);
            Assert.AreEqual("yossef", ob.Nome);
            Assert.AreEqual("manuelph", ob.Descricao);

        }


        [TestMethod]
        public void DeleteTest()
        {
            var cont = new ContaController(null, CriaContexto());

            var result = cont.Post(new Api.Domain.Conta
            {
                Nome = "trazíbulo",
                Descricao = "pedro"
            });

            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Id);


            var ob = cont.Get().FirstOrDefault(x => x.Id == result.Id);
            Assert.IsNotNull(ob);

            cont.Delete(result.Id);

            ob = cont.Get().FirstOrDefault(x => x.Id == result.Id);


            Assert.IsNull(ob);

        }
    }
}
