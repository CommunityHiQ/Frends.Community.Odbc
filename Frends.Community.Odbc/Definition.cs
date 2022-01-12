#pragma warning disable 1591

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Frends.Community.Odbc
{
    /// <summary>
    /// Return type.
    /// </summary>
    public enum QueryReturnType { Csv, Json, Xml }

    public class QueryParameter
    {
        public dynamic Value { get; set; }
    }

    /// <summary>
    /// Connection information.
    /// </summary>
    public class ConnectionInformation
    {
        /// <summary>
        /// Connection string.
        /// </summary>
        [PasswordPropertyText(true)]
        [DefaultValue("\"DSN=Access\"")]
        public string ConnectionString { get; set; }

        /// <summary>
        /// Timeout.
        /// </summary>
        [DefaultValue(30)] public int TimeoutSeconds { get; set; }
    }

    /// <summary>
    /// Query ODBC.
    /// </summary>
    [DisplayName("Query")]
    public class QueryParameters
    {
        [DefaultValue("\"SELECT * FROM Customers WHERE Id = ?\"")]
        public string Query { get; set; }

        /// <summary>
        /// Parameters.
        /// </summary>
        public QueryParameter[] ParametersInOrder { get; set; }
    }

    public class OutputProperties
    {
        [DefaultValue(QueryReturnType.Xml)]
        public QueryReturnType ReturnType { get; set; }

        /// <summary>
        /// Xml specific output properties.
        /// </summary>
        [UIHint(nameof(ReturnType), "", QueryReturnType.Xml)]
        public XmlOutputProperties XmlOutput { get; set; }

        /// <summary>
        /// Json specific output properties.
        /// </summary>
        [UIHint(nameof(ReturnType), "", QueryReturnType.Json)]
        public JsonOutputProperties JsonOutput { get; set; }

        /// <summary>
        /// Csv specific output properties.
        /// </summary>
        [UIHint(nameof(ReturnType), "", QueryReturnType.Csv)]
        public CsvOutputProperties CsvOutput { get; set; }

        /// <summary>
        /// In case user wants to write results to a file instead of returning them to process.
        /// </summary>
        public bool OutputToFile { get; set; }

        /// <summary>
        /// Output file properties.
        /// </summary>
        [UIHint(nameof(OutputToFile), "", true)]
        public OutputFileProperties OutputFile { get; set; }
    }

    /// <summary>
    /// Xml output specific properties.
    /// </summary>
    public class XmlOutputProperties
    {
        /// <summary>
        /// Xml root element name.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        [DefaultValue("ROWSET")]
        public string RootElementName { get; set; }

        /// <summary>
        /// Xml row element name.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        [DefaultValue("ROW")]
        public string RowElementName { get; set; }
    }

    /// <summary>
    /// Json output specific properties.
    /// </summary>
    public class JsonOutputProperties
    {
        /// <summary>
        /// Specify the culture info to be used when parsing result to JSON.
        /// If this is left empty InvariantCulture will be used.
        /// List of cultures: https://msdn.microsoft.com/en-us/library/ee825488(v=cs.20).aspx
        /// Use the Language Culture Name.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string CultureInfo { get; set; }
    }

    /// <summary>
    /// Csv output specific properties.
    /// </summary>
    public class CsvOutputProperties
    {
        /// <summary>
        /// Include headers in csv output file?
        /// </summary>
        public bool IncludeHeaders { get; set; }

        /// <summary>
        /// Csv separator to use.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        [DefaultValue(";")]
        public string CsvSeparator { get; set; }
    }

    /// <summary>
    /// Properties for when user wants to write the result directly into a file.
    /// </summary>
    public class OutputFileProperties
    {
        /// <summary>
        /// Query output filepath.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        [DefaultValue("c:\\temp\\output.csv")]
        public string Path { get; set; }

        /// <summary>
        /// Output file encoding.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        [DefaultValue("utf-8")]
        public string Encoding { get; set; }
    }

    /// <summary>
    /// Result to be returned from task.
    /// </summary>
    public class Output
    {
        public string Result { get; set; }
    }
}
