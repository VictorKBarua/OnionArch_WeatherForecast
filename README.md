 <h2># EuroNext WeatherForecast application (.Net core onion architecture)</h2>
<h4>Weatherforecast is an api interface based .net core project where onion architecture has been used. We can start api integration from the first day without spending time on creating skeleton of the project.</h4> <br/>

 ![OnionArchitecture](https://github.com/VictorKBarua/Webcast-Euronext_Assignment/assets/57985914/d25f4cc3-feb0-43c4-a147-f8e4599f16b3)
<br/> <h3>Advantages of having Onion Architecture. </h3> 
<li>- Testibility: Unit test can be created for separate layers without an effect of other modules of the application. </li>
<li>- Loose Coupling: Loosely coupled application as the outer layer of the application always communicates with the inner layer via interfaces. </li>
<li>- Maintainable: Provides better maintainability as all the codes depend on layers or the center. </li>
<li>- Domain entities are core and center part. It can have access to both the database and UI layers. </li>
<li>- Internal layers never depend on the external layer. The code that may have changed should be part of an external layer.</li>

<br/><h3>EuroNext WeatherForecast application is having below layers W.R.T Onion architecture.</h3>

<li><b>WeatherForecast.Domain:</b> This layer is core layer of the application which is not dependent on any layer. It holds the database properties. It is the center part of the architecture. It holds all application domain objects. </li>

<li><b>WeatherForecast.Dal/ Repository:</b> This layer will handle persistence mechanisms (databases, files, etc.). It holds a generic repository class with its interface implementation. It also holds a DbContext class. The Entity Framework Code First data access approach needs to create a data access context class that inherits from the DbContext class.</li>

<li> <b>WeatherForecast.UtilitiesService/ Service:</b> This layer will contain application services and business logic.It holds business logic and interfaces. As it communicates via interfaces, it builds applications that are loosely coupled.</li>

<li> <b>WeatherForecast.API:</b> It’s the most external layer. It could be the web application or Web API. This layer has an implementation of the Dependency Inversion Principle so that the application builds a loosely coupled application. It communicates to the internal layer via interfaces.</li>
<li> <b>WeatherForecast.UnitTest:</b> This layer is created to unit tests the functionalities/ business logics of service layers.</li>

 
 <br/><h4>This application has been developed based on below business requirements.</h4>
<h5>Business Requirements:</h5>
<li>- As a weatherman I want to store weather forecasts per day. </li>
<li>- As a user I want to retrieve the weather forecast for a week in a human readable way (like 
      "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"). </li>
Validations:
<li>- Input forecasts cannot be in the past. </li>
<li>- Temperature cannot be more than +60 and cannot be less than -60 degrees.</li>

<h2>How to use and run this application.</h2>
<li>We will need postman to make api calls.</li>
<li>We will need Visual Studio 2022 for supporting .Net 6.</li>
<li>We will need a SQL server database.</li>
<li>We will need a SQL server management studio to access the database.</li>
<li><b>Sql server 2019</b> has been used for this project.</li>
<li>After opening the project configure our database connection string in appsetings.json file(API layer)</li>
<li>Open <b>Package manager console</b> under DAL/Repository layer the type <b>update-database</b> command for migration.</li>
<li>It will create our database and empty table according to connection string.</li>
<li>Run the application</li>
<li>We need to first insert weather forecast into table. For this we need to make first api Post call (from postman)(/api/WeatherForecast/AddWeatherForecast) with payload as below: </li>
<br/>

![Capture](https://github.com/VictorKBarua/Webcast-Euronext_Assignment/assets/57985914/01d0dbab-555f-44e3-8b3c-5d0439311a85)


<li>We will receive 200 status code on successfull insertion of data to database. We need make multiple calls so that we can have sufficient data to retrive.</li>
<li>We need to make a another call to retrive data of 7 days. For this we need to make a GET call to api (/api/WeatherForecast/GetAllWeatherForecast). </li>

<h2>Technologies implemented:</h2>
<li>.Net 6.</li>
<li>Entityframework core 6(Code first approach).</li>
<li>Followed Domain driven design.</li 
<li>Dependency Injection.</li>
<li>Followed Seperation of Concern mechanism.</li>
<li>Implemented Unit test cases for relevant parts(Service layers). </li>
<li>Implemented customized validations in Service layers.</li>
<li>Implemented const qualifier for error messages through out the application. </li>
<li>Implemented try catch for error handling.</li>
<li>browse <b>http://localhost:7259/swagger/index.html</b> for api.</li>
