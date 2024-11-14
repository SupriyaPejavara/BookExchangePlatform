<h1> Book Exchange Platform </h1>

The book exchange platform provide users with a convenient and efficient way to discover new reading material, share their favorite books with others, and connect with fellow book enthusiasts in their community. The platform aims to promote a reading culture and foster a sense of community among users by facilitating book exchanges.

<h2> Key Features </h2>
<li> Authentication via IdentityServer4 </li>
<li> Post/request books and add to wishlist </li>
<li> Filtered search functionality </li>
<li> Book recommendation system using content-based filtering </li>

<h2> Prerequisites </h2>        
<h3> Backend </h3>
<li> .NET Core SDK 5.0+ </li>
<li> SQL Server </li>
<h3> Frontend </h3>
<li> Node.js (v14+) </li>
<li> Yarn (optional but recommended for dependency management) </li>

<h2>Setup Instructions</h2>

<h4>1. Clone the Repository</h4>

```
git clone https://github.com/SupriyaPejavara/BookExchangePlatform.git
cd BookExchangePlatform
```

<h4>2. Configure SQL Server Database</h4>
Create a new SQL Server database (for example, BookExchangeDB).
Update the connection string in appsettings.json under src/BEP.API:

```
"ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=BookExchangeDB;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;"
}
```

<h4>3. Apply Migrations</h4>h4>
Navigate to the API project directory and apply migrations to set up the database schema:

```
cd src/BEP.Infrastructure
dotnet ef database update
```

<h4>4. Run the Identity Server</h4>
IdentityServer is required for authentication. Start it in development mode:

```
cd ../BEP.IdentityServer
dotnet run
```

<h4>5. Run the API</h4>
Start the API server:

```
cd ../BEP.API
dotnet run
```

The API should now be running at https://localhost:5001.

<h4>6. Run the Frontend Client</h4>        
Navigate to the frontend project:

```
cd ../../BEP.React
```

Install dependencies:
```
npm install or yarn install
```

Start the React application:

```
npm start or yarn start
```
The React client should now be accessible at http://localhost:3000.

<h4>Additional Configuration</h4>
Setting Up .env for React Client
Create a .env file in BEP.React with the following variables:

```
REACT_APP_API_URL=https://localhost:5001/api
REACT_APP_AUTH_URL=https://localhost:5002
```

<h4>API Documentation</h4>
API documentation is available at https://localhost:5001/swagger when the API is running.

<h4>Troubleshooting</h4>
<li>Ensure the SQL Server database is running and the connection string is correct.</li>
<li>Ensure IdentityServer4 is running before logging in from the React app.</li>
<li>If you encounter CORS issues, configure the CORS settings in Startup.cs in the API project.</li>
