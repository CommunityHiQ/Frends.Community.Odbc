# Frends.Community.Odbc

This task requires ODBC drivers to be istalled on FRENDS Agent machine. 

![MyGet](https://img.shields.io/myget/frends-community/v/Frends.Community.Odbc) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT) 

- [Installing](#installing)
- [Tasks](#tasks)
     - [OdbcTask](#OdbcTask)
- [Building](#building)
- [Contributing](#contributing)
- [Change Log](#change-log)

# Installing

You can install the Task via frends UI Task View or you can find the NuGet package from the following NuGet feed
https://www.myget.org/F/frends-community/api/v3/index.json and in Gallery view in MyGet https://www.myget.org/feed/frends-community/package/nuget/Frends.Community.Odbc

# Tasks

## OdbcTask

Query ODBC

### Properties

#### ConnectionInformation

| Property        | Type                          | Description                  | Example                  |
|-----------------|-------------------------------|------------------------------|--------------------------|
| ConnectionString            | string			  | Connection string			 | DSN=ODBC_testDB       |
| TimeoutSeconds			  | int               | query timeout				 | 30 |

#### QueryParameters

| Property                | Type           | Description                                    | Example                  |
|-------------------------|----------------|------------------------------------------------|--------------------------|
| Query					  | string         | Qyery string			 | SELECT * FROM Customers WHERE Id = ? |
| ParametersInOrder		  | List<QueryParameter>      | List of parameters used in query in order of usage			 |  |

#### Output
| Property    | Type       | Description     | Example |
| ------------| -----------| --------------- | ------- |
| Return type | enum<Json, Xml, Csv> | Data return type format | `Json` |
| OutputToFile | bool | true to write results to a file, false to return results to executin process | `true` |

##### Xml Output
| Property    | Type       | Description     | Example |
| ------------| -----------| --------------- | ------- |
| RootElementName | string | Xml root element name | `items` |
| RowElementName |string | Xml row element name | `item` |

##### Json Output
| Property    | Type       | Description     | Example |
| ------------| -----------| --------------- | ------- |
| Culture info | string | Specify the culture info to be used when parsing result to JSON. If this is left empty InvariantCulture will be used. [List of cultures](https://msdn.microsoft.com/en-us/library/ee825488(v=cs.20).aspx) Use the Language Culture Name. | `fi-FI` |

##### Csv Output
| Property    | Type       | Description     | Example |
| ------------| -----------| --------------- | ------- |
| IncludeHeaders | bool | Include field names in the first row | `true` |
| CsvSeparator | string | Csv separator to use in headers and data items. Note that if you want tu use tabulator as a separator, you need to change the parameter type to expression and specify tabulator by @"	" (note the tabulator between quotes) or "\u0009".  | `;` |

##### Output File
| Property    | Type       | Description     | Example |
| ------------| -----------| --------------- | ------- |
| Path | string | Output path with file name | `c:\temp\output.json` |
| Encoding | string | Encoding to use for the output file | `utf-8` |

### Options


### Returns

Object { string Result }

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| Result | `string` | Output file path or query result | `c:\temp\output.json` |

Usage:
To fetch result use syntax:

`#result.Replication`

# Building

Clone a copy of the repository.

`git clone https://github.com/CommunityHiQ/Frends.Community.Odbc.git`

Build the project.

`dotnet build`

Run tests.

`dotnet test`

Create a NuGet package.

`dotnet pack --configuration Release`

# Contributing
When contributing to this repository, please first discuss the change you wish to make via issue, email, or any other method with the owners of this repository before making a change.

1. Fork the repository on GitHub
2. Clone the project to your own machine
3. Commit changes to your own branch
4. Push your work back up to your fork
5. Submit a Pull request so that we can review your changes

NOTE: Be sure to merge the latest from "upstream" before making a pull request!

# Change Log

| Version | Changes |
| ----- | ----- |
| 1.0.0 | Initial version of Query Task |
| 1.0.1 | Multitargeting .net standard 2.0, .net 471 |
