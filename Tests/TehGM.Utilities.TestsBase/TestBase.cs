using AutoFixture;
using AutoFixture.AutoNSubstitute;
using NUnit.Framework;

namespace TehGM
{
    public abstract class TestBase
    {
        protected IFixture Fixture { get; set; }

        [SetUp]
        public virtual void SetUp()
        {
            this.Fixture = new Fixture()
                .Customize(new AutoNSubstituteCustomization()
                {
                    ConfigureMembers = true,
                    GenerateDelegates = true
                });
        }
    }
}