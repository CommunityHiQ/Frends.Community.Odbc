using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#pragma warning disable 1591

namespace Frends.Community.Odbc
{
    /// <summary>
    /// Return type
    /// </summary>
    public enum QueryReturnType { Xml, Json, Dynamic }

    public class QueryParameter
    {
        public dynamic Value { get; set; }
    }

    /// <summary>
    /// Connection information
    /// </summary>
    public class ConnectionInformation
    {
        /// <summary>
        /// Connection string
        /// </summary>
        [PasswordPropertyText(true)]
        [DefaultValue("\"DSN=Access\"")]
        public string ConnectionString { get; set; }

        /// <summary>
        /// Timeout
        /// </summary>
        [DefaultValue(30)] public int TimeoutSeconds { get; set; }
    }

    /// <summary>
    /// Query ODBC
    /// </summary>
    [DisplayName("Query")]
    public class QueryParameters
    {
        [DefaultValue("\"SELECT * FROM Customers WHERE Id = ?\"")]
        public string Query { get; set; }

        /// <summary>
        /// Return type
        /// </summary>
        [DefaultValue(QueryReturnType.Xml)]
        public QueryReturnType ReturnType { get; set; }

        /// <summary>
        /// Root element name
        /// </summary>
        [DefaultValue("\"ROWSET\"")]
        [UIHint(nameof(ReturnType), "", QueryReturnType.Xml)]
        public string RootElementName { get; set; }

        /// <summary>
        /// Row element name
        /// </summary>
        [DefaultValue("\"ROW\"")]
        [UIHint(nameof(ReturnType), "", QueryReturnType.Xml)]
        public string RowElementName { get; set; }

        /// <summary>
        /// Parameters
        /// </summary>
        public QueryParameter[] ParametersInOrder { get; set; }
    }

    /// <summary>
    /// Return object
    /// </summary>
    public class Output
    {
        /// <summary>
        /// Request result
        /// </summary>
        public dynamic Result { get; set; }
    }
}
