using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Dynamic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

#pragma warning disable 1591

namespace Frends.Community.Odbc
{
    public class OdbcTask
    {
        /// <summary>
        /// ODCB query task
        /// </summary>
        /// <param name="queryParameters"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Object { String Result or Dynamic Result }</returns>
        /// <exception cref="Exception"></exception>
        public static async Task<dynamic> Query([PropertyTab] QueryParameters queryParameters,
            [PropertyTab] ConnectionInformation options, CancellationToken cancellationToken)
        {
            using (var connection = new OdbcConnection(options.ConnectionString))
            {
                await connection.OpenAsync(cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();

                using (var command = connection.CreateCommand())
                {
                    command.CommandTimeout = options.TimeoutSeconds;
                    command.CommandText = queryParameters.Query;
                    command.Parameters.AddRange(queryParameters.ParametersInOrder
                        .Select(x => new OdbcParameter { Value = x.Value }).ToArray());

                    var reader = await command.ExecuteReaderAsync(cancellationToken);
                    cancellationToken.ThrowIfCancellationRequested();

                    var schemaTable = reader.GetSchemaTable();

                    var rows = new List<ExpandoObject>();
                    while (reader.Read())
                    {
                        dynamic rowObj = new ExpandoObject();
                        rows.Add(rowObj);
                        var rowObjAsDict = (IDictionary<string, object>)rowObj;
                        foreach (DataRow schemaRow in schemaTable.Rows)
                        {
                            rowObjAsDict[schemaRow[0].ToString()] = reader[schemaRow[0].ToString()];
                        }
                    }

                    dynamic container = new ExpandoObject();
                    ((IDictionary<string, object>)container)[queryParameters.RowElementName] = rows;

                    var json = JsonConvert.SerializeObject(container);
                    switch (queryParameters.ReturnType)
                    {
                        case QueryReturnType.Xml:
                            return new Output { Result = JsonConvert.DeserializeXNode(json, queryParameters.RootElementName).ToString() };
                        case QueryReturnType.Json:
                            return new Output { Result = json };
                        case QueryReturnType.Dynamic:
                            return new Output { Result = container };
                        default:
                            throw new Exception("Unsupported DataReturnType.");
                    }
                }
            }
        }
    }
}