using System.Net.Http;
using System.Text.RegularExpressions;

namespace MutationTestingExercises.Exercise2WebApi
{
    public class RequestHandlerResolver
    {
        public RequestHandler Resolve(HttpMethod httpMethod, string path)
        {
            if (httpMethod == HttpMethod.Post && path == "kittens/")
                return new CreateKittenRequestHandler();

            if (httpMethod == HttpMethod.Get && new Regex("^kittens/\\w+$").IsMatch(path))
                return new RetrieveKittenRequestHandler();

            return new NotFoundHandler();
        }
    }

    public interface RequestHandler
    {
    }

    public class CreateKittenRequestHandler : RequestHandler
    {
    }

    public class RetrieveKittenRequestHandler : RequestHandler
    {
    }

    public class NotFoundHandler : RequestHandler
    {
    }
}