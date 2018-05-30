## [ASP.NET Core 2.0: Implementing a 3rd Party Web API](https://www.youtube.com/watch?v=3J9Cs9ybZDg)

by [Daniel Donbavand](https://danieldonbavand.com/)


### 01 Create project

* New ASP.NET Core Web Aplication -> Empty

### 02 Add and use MVC

* Edit Startup.cs -> AddMvc, UseMvc


### 03 GiphyController

* Add the Controllers folder and the Giphy empty API Controller.

### 04 GetRandomGif

### 05 Giphy.Libs

* Add a .NET Core Class Library project

### 06 Services

* Add the Services folder, the GiphyService class and the IGiphyService interface 
* In the GiphyService dependencies, add a reference to the Giphy.Libs

### 07 Models

* The Giphy API [returns an array of elements called "data"](http://api.giphy.com/v1/gifs/search?q=acdc&api_key=8xCc9oDNGiUKZxXoxYAvwy5bq34JnChj).
* Add the Models folder and the GiphyModel and Data model classes.
* The GiphyModel class has the Data property which is an IEnumerable of Data.
* The Data class has the EmbedUrl string property that corresponds to the embed_url key in the JSON response.

### 08 IGiphyService

* Add the declaration for the GetRandomGifBasedOnSearchCriteria method in IGiphyService.
