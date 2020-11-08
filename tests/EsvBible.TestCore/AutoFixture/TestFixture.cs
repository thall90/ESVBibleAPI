using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;

namespace EsvBible.TestCore.AutoFixture
{
    public static class TestFixture
    {
        public static IFixture Create(
            int recursionDepth = 1)
        {
            var fixture = new Fixture();

            SetCustomRecursionDepth(fixture, recursionDepth);

            return fixture;
        }

        public static IFixture CreateAutoMockingContainer(
            bool configureMembers = true,
            int recursionDepth = 1)
        {
            var fixture = Create(recursionDepth)
                .AddAutoMockingCustomization(configureMembers);

            return fixture;
        }

        private static void SetCustomRecursionDepth(
            IFixture fixture,
            int recursionDepth = 1)
        {
            fixture.Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));

            fixture.Behaviors.Add(new OmitOnRecursionBehavior(recursionDepth));
        }

        private static IFixture AddAutoMockingCustomization(
            this IFixture fixture,
            bool autoConfigureMembers)
        {
            return fixture.Customize(new AutoMoqCustomization
            {
                ConfigureMembers = autoConfigureMembers
            });
        }
    }
}