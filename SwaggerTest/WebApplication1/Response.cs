namespace SwaggerTest.WebApplication1;

public record Response<T>(IEnumerable<T> Data, string Version);
