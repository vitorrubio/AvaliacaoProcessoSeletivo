using AvaliacaoProcessoSeletivo.Api.Controllers;
using AvaliacaoProcessoSeletivo.Api.Infra.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AvaliacaoProcessoSeletivo.Test
{
    [TestClass]
    public class ContaControllerTest
    {

        #region private fields

        //usado apenas para in memory
        private static SqliteConnection _sqliteConnection;
        private static Contexto _contexto;

        #endregion


        #region test context

        private TestContext testContextInstance;


        /// <summary>
        ///  Gets or sets the test context which provides
        ///  information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        #endregion

        #region initialize

        [AssemblyInitialize]
        public static void IniciaAssembly(TestContext ctx)
        {
            Trace.WriteLine("Inicia uma vez cada vez que o assembly de testes é carregado (uma vez por assembly)");
        }

        [ClassInitialize]
        public static void IniciaClasse(TestContext ctx)
        {
            Trace.WriteLine("Inicia cada vez que esta classe de testes é usada (uma vez por classe de testes)");
        }


        [TestInitialize]
        public void IniciaTeste()
        {
            Trace.WriteLine("Inicia toda vez que um método de teste é executado (uma vez por método de teste)");
        }

        #endregion



        #region tests
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

        #endregion


        #region métodos privados estáticos

        private static SqliteConnection CriaConexao(string connStr = "DataSource=:memory:")
        {
            //usar apenas para sqlite in memory
            if (_sqliteConnection == null)
            {
                _sqliteConnection = new SqliteConnection(connStr);
                _sqliteConnection.Open();
            }
            return _sqliteConnection;
        }

        private static Contexto CriaContexto()
        {
            if (_contexto == null)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                var configuration = builder.Build();


                var options = new DbContextOptionsBuilder<Contexto>()
                        //varios tipos de conexão, descomentar e experimentar cada um

                        .UseSqlServer(configuration.GetConnectionString("AvaliacaoProcessoSeletivo")) //para usar sql server e pegar connection string do appSettings
                        //.UseSqlite(configuration.GetConnectionString("AvaliacaoProcessoSeletivo")) //para usar sqlite e pegar connection string do appSettings
                        //.UseSqlite(CriaConexao(configuration.GetConnectionString("AvaliacaoProcessoSeletivo"))) //para usar sqlite in memory
                        //.UseInMemoryDatabase(databaseName: "Avaliacao") //para usar in memory provider
                        .Options;

                _contexto = new Contexto(options);

                //_contexto.Database.EnsureDeleted(); //para deletar em cada teste
                //_contexto.Database.EnsureCreated(); //se não existir cria
                if(!_contexto.Database.IsInMemory())
                {
                    _contexto.Database.Migrate(); //se já existir (for de arquivo ou sql server) e estiver desatualizado, faz a migração
                }
            }

            return _contexto;
        }


        private static void FechaConexao()
        {
            if(_contexto != null)
            {
                if (!_contexto.Database.IsInMemory())
                {
                    _contexto.Database.CloseConnection();
                }
                _contexto.Dispose();
                _contexto = null;
            }

            if(_sqliteConnection != null)
            {
                _sqliteConnection.Close();
                _sqliteConnection.Dispose();
                _sqliteConnection = null;
            }
        }

        #endregion



        #region cleanup

        [AssemblyCleanup]
        public static void FinalizaAssembly()
        {
            Trace.WriteLine("Executa uma vez cada vez que o assembly de testes é descarregado, no final de todos os testes desse assembly");
        }

        [ClassCleanup]
        public static void FinalizaClasse()
        {
            Trace.WriteLine("Executa ao final da classe de testes, quando ela deixa de ser usada e todos seus testes já foram executados");
            FechaConexao();
        }


        [TestCleanup]
        public void FinalizaTeste()
        {
            Trace.WriteLine("Executa após cada teste");

        }

        #endregion
    }
}
