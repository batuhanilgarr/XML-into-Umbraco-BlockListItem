# WarrantyWeb

WarrantyWeb is an application developed to load data from XML files into the Umbraco Content Management System (CMS).

## Features

- Load content from XML files
- Integration with Umbraco CMS
- Create and update content
- Import process available via `/api/xml/import`

## Requirements

- .NET 6.0 or higher
- Umbraco CMS
- Newtonsoft.Json library

## Installation

1. **Clone the Repository**:

   ```bash
   git clone https://github.com/your_username/WarrantyWeb.git
   cd WarrantyWeb
   ```

2. **Install Dependencies**:

   ```bash
   dotnet restore
   ```

3. **Run the Application**:

   ```bash
   dotnet run
   ```

## Usage

Follow the instructions in the code to load your XML file into Umbraco. You can use the import endpoint by sending a request to `/api/xml/import` with your XML data.

### Importing XML Data

To import XML data, send a POST request to the `/api/xml/import` endpoint with the XML file in the body. Ensure that the XML structure matches the expected format for the Umbraco CMS.

## License

This project is licensed under the MIT License.
