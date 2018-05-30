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


### 09 GiphyService

* Implement the IGiphyService interface in the GiphyService class.
* The GetRandomGifBasedOnSearchCriteria implementation now calls the ReturnRandomGifBasedOnTag method from the IGetRandomGif interface (not implemented yet). 


### 10 IGetRandomGif

* Add the declaration for the ReturnRandomGifBasedOnTag method in IGetRandomGif.


### 11 GetRandomGif

* Create the GetRandomGif class that implements the IGetRandomGif interface.
* Define the giphyKey string and assign a key [acquired by the Giphy API](https://developers.giphy.com/dashboard/).
* Set a url string according to the Giphy API documentation instructions.
* Await a call to GetAsync on the Http client.
* Read the response content as a string.
* Using Newtonsoft.Json, deserialize the response in order to return the appropriate GiphyModel object.


### 12 DataContract for Data

* Set DataContract and DataMember decorators in the Data class in order to have the DataContractSerializer get the appropriate string from the data object, defined by Name.


### 13 Set the route 

* In GiphyController add the HttpGet and Route decorators to the GetRandomGif call. 
* Set the route to "random/{searchCriteria}"