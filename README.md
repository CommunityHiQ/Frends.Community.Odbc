- [Frends.Community.Odbc](#frendscommunityodbc)
  - [Installing](#installing)
  - [Building](#building)
  - [Contributing](#contributing)
  - [Documentation](#documentation)
    - [Query](#query)
      - [Input](#input)
      - [Options](#options)
      - [Result](#result)
  - [Change Log](#change-log)
  - [License](#license)

# Frends.Community.Odbc

This task requires ODBC drivers to be istalled on FRENDS Agent machine. 

## Installing
You can install the task via FRENDS UI Task view, by searching for packages. You can also download the latest NuGet package from https://www.myget.org/feed/frends/package/nuget/Frends.Community.Odbc and import it manually via the Task view.

## Building
Requirements

`NET Core SDK 2.1 or later`

Clone a copy of the repo

`git clone https://github.com/CommunityHiQ/Frends.Community.Odbc.git`

Restore dependencies

`dotnet restore`

Build the solution

`dotnet build`

Run Tests

`dotnet test Frends.Community.Odbc.Test`

Create a nuget package

`dotnet pack Frends.Community.Odbc`

## Contributing
When contributing to this repository, please first discuss the change you wish to make via issue, email, or any other method with the owners of this repository before making a change.

1. Fork the repo on GitHub
2. Clone the project to your own machine
3. Commit changes to your own branch
4. Push your work back up to your fork
5. Submit a Pull request so that we can review your changes

NOTE: Be sure to merge the latest from "upstream" before making a pull request!

## Documentation

### Query 

Query ODBC

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

#### Result
Object { string Result }


## Change Log

| Version | Changes |
| ----- | ----- |
| 1.0.0 | Initial version of Query Task |

## License
This project is licensed under the MIT License - see the LICENSE file for details
