using NUnit.Framework;

namespace MutationTestingExercises.Exercise3PostageCalculator
{
    [TestFixture]
    public class CalculatorShould
    {
        private const decimal SmallPackagePrice = 120m;

        private Calculator _calculator;

        [SetUp]
        public void SetUp() => _calculator = new Calculator();

        [TestCase(1, 1, 1, 1)]
        public void Charge_a_flat_rate_for_a_small_package(int weight, int height, int width, int depth)
        {
            Assert.That(_calculator.Calculate(weight, height, width, depth, Currency.Gbp),
                Is.EqualTo(new Money(Currency.Gbp, SmallPackagePrice)));
        }

        [TestCase(61, 230, 163, 26)]
        public void Price_a_medium_package_by_weight(int weight, int height, int width, int depth)
        {
            Assert.That(_calculator.Calculate(weight, height, width, depth, Currency.Gbp),
                Is.EqualTo(new Money(Currency.Gbp, weight * 4)));
        }

        [TestCase(7550, 325, 230, 101)]
        public void Price_a_large_heavy_package_by_weight(int weight, int height, int width, int depth)
        {
            Assert.That(_calculator.Calculate(weight, height, width, depth, Currency.Gbp),
                Is.EqualTo(new Money(Currency.Gbp, weight * 6)));
        }

        [TestCase(501, 325, 230, 101)]
        public void Price_a_large_light_package_by_volume(int weight, int height, int width, int depth)
        {
            Assert.That(_calculator.Calculate(weight, height, width, depth, Currency.Gbp),
                Is.EqualTo(new Money(Currency.Gbp, (height*width*depth/1000m)*6)));
        }

        [TestCase(Currency.Eur, 1.25)]
        [TestCase(Currency.Chf, 1.36)]
        public void Add_commission_for_currency_other_than_gbp(Currency currency, decimal exchangeRate)
        {
            Assert.That(_calculator.Calculate(20, 20, 20, 20, currency), 
                Is.EqualTo(new Money(currency, (SmallPackagePrice + 200m) * exchangeRate)));
        }
    }
}