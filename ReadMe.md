# Mindex Coding Challenge

## Nathaniel Angus Solution

I completed both tasks. I also made some minor changes to the original code to fix a bug where all employees had null direct reports.

### Solution Notes

-The only bug I am experiencing is that the ReportingStructure endpoint is returning 1 instead of 4 for John Lennon's numberOfReports in the test
case. However, when I test it locally, it returns the correct number of 4. I am not sure why it is only failing in the test environment. I verified
that in the test environment, 1 is the number of reports for the employee John Lennon. The test data in that environment is initilizing differently
than it does locally or in the other two test environments. All endpoints work as expected when run locally.

- I had to `cd CodeChallenge` before running the `dotnet run` command. Then `cd CodeChallenge.Tests` before running `dotnet test`.

- When documenting the code, I included XML comments for each public method. This is standard practice at my current job and many tools can be used to
  create API documentation from the comments this way.

## What's Provided

A simple [.Net 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) web application has been created and bootstrapped
with data. The application contains information about all employees at a company. On application start-up, an in-memory
database is bootstrapped with a serialized snapshot of the database. While the application runs, the data may be
accessed and mutated in the database without impacting the snapshot.

### How to Run

You can run this by executing `dotnet run` on the command line or in [Visual Studio Community Edition](https://www.visualstudio.com/downloads/).

### How to Use

The following endpoints are available to use:

```
* CREATE
    * HTTP Method: POST
    * URL: localhost:8080/api/employee
    * PAYLOAD: Employee
    * RESPONSE: Employee
* READ
    * HTTP Method: GET
    * URL: localhost:8080/api/employee/{id}
    * RESPONSE: Employee
* UPDATE
    * HTTP Method: PUT
    * URL: localhost:8080/api/employee/{id}
    * PAYLOAD: Employee
    * RESPONSE: Employee
```

The Employee has a JSON schema of:

```json
{
  "type": "Employee",
  "properties": {
    "employeeId": {
      "type": "string"
    },
    "firstName": {
      "type": "string"
    },
    "lastName": {
      "type": "string"
    },
    "position": {
      "type": "string"
    },
    "department": {
      "type": "string"
    },
    "directReports": {
      "type": "array",
      "items": "string"
    }
  }
}
```

For all endpoints that require an "id" in the URL, this is the "employeeId" field.

## What to Implement

Clone or download the repository, do not fork it.

### Task 1

Create a new type, ReportingStructure, that has two properties: employee and numberOfReports.

For the field "numberOfReports", this should equal the total number of reports under a given employee. The number of
reports is determined to be the number of directReports for an employee and all of their direct reports. For example,
given the following employee structure:

```
                    John Lennon
                /               \
         Paul McCartney         Ringo Starr
                               /        \
                          Pete Best     George Harrison
```

The numberOfReports for employee John Lennon (employeeId: 16a596ae-edd3-4847-99fe-c4518e82c86f) would be equal to 4.

This new type should have a new REST endpoint created for it. This new endpoint should accept an employeeId and return
the fully filled out ReportingStructure for the specified employeeId. The values should be computed on the fly and will
not be persisted.

### Task 2

Create a new type, Compensation. A Compensation has the following fields: employee, salary, and effectiveDate. Create
two new Compensation REST endpoints. One to create and one to read by employeeId. These should persist and query the
Compensation from the persistence layer.

## Delivery

Please upload your results to a publicly accessible Git repo. Free ones are provided by Github and Bitbucket.
