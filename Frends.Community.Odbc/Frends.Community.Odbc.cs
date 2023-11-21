using System;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable 1591

namespace Frends.Community.Odbc
{
    public static class OdbcTask
    {
        /// <summary>
        /// ODBC query task.
        /// </summary>
        /// <param name="queryParameters"></param>
        /// <param name="output"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Object { String Result or Dynamic Result }</returns>
        /// <exception cref="Exception"></exception>
        public static async Task<dynamic> Query([PropertyTab] QueryParameters queryParameters, [PropertyTab] OutputProperties output, [PropertyTab] ConnectionInformation options, CancellationToken cancellationToken)
        {
            try
            {
                using (var connection = new OdbcConnection(options.ConnectionString))
                {
                    await connection.OpenAsync(cancellationToken);
                    cancellationToken.ThrowIfCancellationRequested();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = options.TimeoutSeconds;
                        command.CommandText = queryParameters.Query;
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddRange(queryParameters.ParametersInOrder.Select(x => new OdbcParameter { Value = x.Value }).ToArray());

                        string queryResult;

                        switch (output.ReturnType)
                        {
                            case QueryReturnType.Xml:
                                queryResult = await command.ToXmlAsync(output, cancellationToken);
                                break;
                            case QueryReturnType.Json:
                                queryResult = await command.ToJsonAsync(output, cancellationToken);
                                break;
                            case QueryReturnType.Csv:
                                queryResult = await command.ToCsvAsync(output, cancellationToken);
                                break;
                            default:
                                throw new ArgumentException("Task 'Return Type' was invalid! Check task properties.");
                        }

                        return new Output { Result = queryResult };
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                OdbcConnection.ReleaseObjectPool();
            }
        }
    }
}
