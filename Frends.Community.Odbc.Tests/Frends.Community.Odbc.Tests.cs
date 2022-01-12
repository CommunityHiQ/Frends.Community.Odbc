using NUnit.Framework;
using System.Threading;

namespace Frends.Community.Odbc.Tests
{
    [TestFixture]
    class TestClass
    {
        [Test]
        public void ShouldReadFromMsAccessViaOdbc()
        {
            // Configure first ODBC at Control Panel->Administrative Tools->ODBC Data sources (64-bit) to point to \TestFiles\ODBC_testDB.accdb, and ensure that the data source name equals ODBC_testDB
            
            var conn = new ConnectionInformation
            {
                ConnectionString = "DSN=ODBC_testDB",
                TimeoutSeconds = 30
            };

            var odbcQuery = new QueryParameters
            {
                Query = "SELECT Animal FROM AnimalTypes WHERE Animal = ? OR Animal = ?",
                ParametersInOrder = new[] { new QueryParameter { Value = "Bear" }, new QueryParameter { Value = "Moose" } },
            };

            var output = new OutputProperties
            {
                ReturnType = QueryReturnType.Xml,
                XmlOutput = new XmlOutputProperties
                {
                    RootElementName = "ROW",
                    RowElementName = "ROWSET",
                }
            };
            var resultTask = OdbcTask.Query(odbcQuery, output, conn, new CancellationToken());

            resultTask.Wait();
            var result = resultTask.Result.Result;

            Assert.NotNull(result);
            Assert.That(result, Contains.Substring("<Animal>Bear</Animal>"));
            Assert.That(result, Contains.Substring("<Animal>Moose</Animal>"));
        }

    }
}
