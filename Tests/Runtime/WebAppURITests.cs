using NUnit.Framework;
using System.Linq;

namespace Agava.TelegramGameTemplate.Tests
{
    public class WebAppURITests
    {
        [Test]
        public void ConstructWebAppUri_ParametersExist_URLConstructed()
        {
            QueryParam[] parameters = new QueryParam[]
            {
                new QueryParam("userId", "234234"), new QueryParam("currencyAmount", "100"), new QueryParam("oneTime", "True")
            };

            string uri = WebAppURI.ConstructWebAppUri("Vasya", "Carousel", parameters);
            string expectedUri = "https://t.me/Vasya/Carousel?userId=234234&currencyAmount=100&oneTime=True";

            Assert.AreEqual(expectedUri, uri);
        }

        [Test]
        public void ConstructWebAppUri_ParametersAreNull_URLConstructed()
        {
            string uri = WebAppURI.ConstructWebAppUri("Vasya", "Carousel", null);
            string expectedUri = "https://t.me/Vasya/Carousel";

            Assert.AreEqual(expectedUri, uri);
        }

        [Test]
        public void ConstructWebAppUri_ParametersAreEmpty_URLConstructed()
        {
            string uri = WebAppURI.ConstructWebAppUri("Vasya", "Carousel", new QueryParam[0]);
            string expectedUri = "https://t.me/Vasya/Carousel";

            Assert.AreEqual(expectedUri, uri);
        }

        [Test]
        public void TryExtractQueryParams_QueryStringExists_ParamsExtracted()
        {
            WebAppURI.TryExtractQueryParams("https://t.me/Vasya/Carousel?userId=234234&currencyAmount=100&oneTime=True", out QueryParam[] result);

            QueryParam[] expectedResult = new QueryParam[]
            {
                new QueryParam("userId", "234234"), new QueryParam("currencyAmount", "100"), new QueryParam("oneTime", "True")
            };

            bool resultsEqual = expectedResult.ToHashSet().SetEquals(result.ToHashSet());
            Assert.IsTrue(resultsEqual);
        }

        [Test]
        public void TryExtractQueryParams_QueryStringNotExists_ReturnsFalse()
        {
            bool result = WebAppURI.TryExtractQueryParams("https://t.me/Vasya/Carousel?", out QueryParam[] _);
            Assert.IsFalse(result);
        }

        [Test]
        public void TryExtractQueryParams_WebAppUriIsNull_ReturnsFalse()
        {
            bool result = WebAppURI.TryExtractQueryParams(null, out QueryParam[] _);
            Assert.IsFalse(result);
        }

        [Test]
        public void TryExtractQueryParams_WebAppUriIsEmpty_ReturnsFalse()
        {
            bool result = WebAppURI.TryExtractQueryParams(string.Empty, out QueryParam[] _);
            Assert.IsFalse(result);
        }
    }
}
