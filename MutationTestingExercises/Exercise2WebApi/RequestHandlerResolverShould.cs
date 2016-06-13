using System.Net.Http;
using NUnit.Framework;

namespace MutationTestingExercises.Exercise2WebApi
{
    [TestFixture]
    public class RequestHandlerResolverShould
    {
        private RequestHandlerResolver _requestHandlerResolver;

        [SetUp]
        public void SetUp()
        {
            _requestHandlerResolver = new RequestHandlerResolver();
        }

        [Test]
        public void Resolve_a_create_kitten_request()
        {
            var requestHandler = _requestHandlerResolver.Resolve(HttpMethod.Post, "kittens/");

            Assert.That(requestHandler, Is.TypeOf<CreateKittenRequestHandler>());
        }

        [Test]
        public void Resolve_a_retrieve_kitten_request()
        {
            var requestHandler = _requestHandlerResolver.Resolve(HttpMethod.Get, "kittens/fluffles");

            Assert.That(requestHandler, Is.TypeOf<RetrieveKittenRequestHandler>());
        }

        [Test]
        public void Resolve_a_not_found_handler_for_an_unrecognised_request()
        {
            var requestHandler = _requestHandlerResolver.Resolve(HttpMethod.Put, "puppies/");

            Assert.That(requestHandler, Is.TypeOf<NotFoundHandler>());
        }
    }


}