# Giphy 2
The Giphy2 project is a simplified version of the Giphy-Service-API project. Provides the same functionality in a simpler project structure (single project, no lib). The GetRandomGif functionality is here contained in the GiphyService class (IGetRandomGif and GetRandomGif are not created).

### Create project

* New ASP.NET Core Web Aplication -> Empty

### Add and use MVC

* Edit Startup.cs -> AddMvc, UseMvc

### GiphyController

* Add the Controllers folder and the Giphy empty API Controller.

### GetRandomGif

```
public class GiphyController : Controller
{
    private readonly IGiphyService _giphyService;

    public GiphyController(IGiphyService giphyService)
    {
        _giphyService = giphyService;
    }
    
    public async Task<IActionResult> GetRandomGif(string searchCriteria)
    {
        var result = await _giphyService.ReturnRandomGifAsync(searchCriteria);

        return Ok(result);
    }
}
```

### Services

* Add the Services folder, the GiphyService class and the IGiphyService interface 

### Models

* The Giphy API [returns an array of elements called "data"](http://api.giphy.com/v1/gifs/search?q=acdc&api_key=8xCc9oDNGiUKZxXoxYAvwy5bq34JnChj).
* Add the Models folder and the GiphyModel and Data model classes.
* The GiphyModel class has the Data property which is an IEnumerable of Data.
* The Data class has the EmbedUrl string property that corresponds to the embed_url key in the JSON response.

```
public class GiphyModel
{
    public IEnumerable<Data> Data { get; set; }
}

public class Data
{    
    public string EmbedUrl { get; set; }
}
```

### IGiphyService

* Add the declaration for the ReturnRandomGifAsync method in IGiphyService.

```
public interface IGiphyService
{
    Task<GiphyModel> ReturnRandomGifAsync(string searchCriteria);
}
```


### GiphyService

* Implement the IGiphyService interface in the GiphyService class.
* Define the giphyKey string and assign a key [acquired by the Giphy API](https://developers.giphy.com/dashboard/).
* Set a url string according to the Giphy API documentation instructions.
* Await a call to GetAsync on the Http client.
* Read the response content as a string.
* Using Newtonsoft.Json, deserialize the response in order to return the appropriate GiphyModel object.

```
public class GiphyService : IGiphyService
{
    public async Task<GiphyModel> ReturnRandomGifAsync(string searchCriteria)
    {
        const string giphyKey = "8xCc9oDNGiUKZxXoxYAvwy5bq34JnChj";

        using (var client = new HttpClient())
        {
            var url = new Uri($"http://api.giphy.com/v1/gifs/search?api_key=" 
                                        + $"{giphyKey}&q={searchCriteria}&limit=1");
            
            var response = await client.GetAsync(url);

            string json;
            using (var content = response.Content)
            {
                json = await content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<GiphyModel>(json);
        }
    }
}
```



### DataContract for Data

* Set the DataContract and DataMember decorators in the Data class in order to have the DataContractSerializer get the appropriate string from the data object, defined by Name.

```
[DataContract]
public class Data
{
    [DataMember(Name = "embed_url")]
    public string EmbedUrl { get; set; }
}
```

### Set the route

* In GiphyController apply the HttpGet and Route decorators to the GetRandomGif definition. 
* Set the route to "random/{searchCriteria}"

```
[HttpGet]
[Route("random/{searchCriteria}")]
public async Task<IActionResult> GetRandomGif(string searchCriteria)
{
    var result = await _giphyService.ReturnRandomGifAsync(searchCriteria);

    return Ok(result);
}
```


### ConfigureServices

* Implement dependency injection. Bind the IGiphyService interface to the GiphyService class so that it can be injected. This is done by adding a singleton in the ConfigureServices section of the Startup class.

```
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();
    services.AddSingleton<IGiphyService, GiphyService>();
}
```
    


### API usage

Now we can run the project. Our API service is calling the Giphy API and responds to GET requests on the `http://APP_HOST:APP_PORT/random/SEARCH_TERM` route.

#### Example

Request: `GET http://localhost:50833/random/monkey`

Response: 
```
{
    "data": [
        {
            "embed_url": "https://giphy.com/embed/dchERAZ73GvOE"
        }
    ]
}
```