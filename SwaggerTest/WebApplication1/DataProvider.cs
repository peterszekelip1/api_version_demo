namespace SwaggerTest.WebApplication1;

public static class DataProvider
{
    private static readonly string[] Summaries = new[]
                                                 {
                                                     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy"
                                                   , "Hot", "Sweltering", "Scorching"
                                                 };

    public static IEnumerable<WeatherForecast> GetData(int count)
    {
        return Enumerable.Range(1, count)
                         .Select(index => new WeatherForecast
                                          {
                                              Date = DateTime.Now.AddDays(index)
                                            , TemperatureC = Random.Shared.Next(-20, 55)
                                            , Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                                          });
    }
}
