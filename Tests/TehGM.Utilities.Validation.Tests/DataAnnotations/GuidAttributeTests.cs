using System.ComponentModel.DataAnnotations;

namespace TehGM.Utilities.Validation.DataAnnotations.Tests
{
    [TestFixture]
    [TestOf(typeof(GuidAttribute))]
    public class GuidAttributeTests : TestBase
    {
        [Test]
        [TestCase("4884bb94-d21e-4cb1-adf2-d0e3590abc36")]
        [TestCase("4884BB94-D21E-4CB1-ADF2-D0E3590ABC36")]
        [Category(nameof(GuidAttribute.IsValid))]
        public void IsValid_ValidStringGuid_ReturnsTrue(string value)
        {
            GuidAttribute attribute = new GuidAttribute();

            bool result = attribute.IsValid(value);

            result.Should().BeTrue();
        }

        [Test, AutoNSubstituteData]
        [Repeat(2)]
        [Category(nameof(GuidAttribute.IsValid))]
        public void IsValid_ValidGuid_ReturnsTrue(Guid value)
        {
            GuidAttribute attribute = new GuidAttribute();

            bool result = attribute.IsValid(value);

            result.Should().BeTrue();
        }

        [Test, AutoNSubstituteData]
        [Repeat(2)]
        [Category(nameof(GuidAttribute.IsValid))]
        public void IsValid_ValidNullableGuid_ReturnsTrue(Guid? value)
        {
            GuidAttribute attribute = new GuidAttribute();

            bool result = attribute.IsValid(value);

            result.Should().BeTrue();
        }

        [Test]
        [TestCase("4884bb94-d21e-4cb1-adf2-d0e359")]
        [TestCase("4884bb94-d21e-4cb1-adf2-d0e3590abc36fdgfdg")]
        [TestCase("4884bb94-d21e-4cb1-adf2-d0e3590&bc36")]
        [TestCase("")]
        [TestCase("    ")]
        [Category(nameof(GuidAttribute.IsValid))]
        public void IsValid_InvalidStringInput_ReturnsFalse(string value)
        {
            GuidAttribute attribute = new GuidAttribute();

            bool result = attribute.IsValid(value);

            result.Should().BeFalse();
        }

        [Test]
        [TestCase(12)]
        [Category(nameof(GuidAttribute.IsValid))]
        public void IsValid_InvalidType_ReturnsFalse(object value)
        {
            GuidAttribute attribute = new GuidAttribute();

            bool result = attribute.IsValid(value);

            result.Should().BeFalse();
        }
    }
}