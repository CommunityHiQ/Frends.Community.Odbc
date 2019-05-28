- [Frends.Community.Odbc](#frendscommunityodbc)
  - [Installing](#installing)
  - [Building](#building)
  - [Contributing](#contributing)
  - [Documentation](#documentation)
    - [Query](#query)
      - [Input](#input)
      - [Options](#options)
      - [Result](#result)
  - [License](#license)

# Frends.Community.Odbc

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
| ReturnType			  | enum           | Specify return type		 | Xml, Json, Dynamic  |
| RootElementName		  | string         | If using xml return type this is the output root			 | ROWSET |
| RowElementName		  | string         | If using xml return type this is the output for row elemtnts			 | ROW |
| ParametersInOrder		  | List<QueryParameter>      | List of parameters used in query in order of usage			 |  |

#### Result
Result [ Dynamic (JToken / string) ]


#### Result


## License
This project is licensed under the MIT License - see the LICENSE file for details
