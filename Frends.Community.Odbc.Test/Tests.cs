using System.Threading;
using Xunit;

namespace Frends.Community.Odbc.Test
{
    public class Tests
    {
        [Fact]
        public void ShouldReadFromMsAccessViaOdbc()
        {
            // Configure first ODBC at Control Panel->Administrative Tools->ODBC Data sources (64-bit) to point to \TestFiles\ODBC_testDB.accdb

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
            var result = (string)resultTask.Result;

            Assert.NotNull(result);
            Assert.Contains("<Animal>Bear</Animal>", result);
            Assert.Contains("<Animal>Moose</Animal>", result);
        }
    }
}
