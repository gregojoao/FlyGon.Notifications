using FlyGon.Notifications.Validations;
using NUnit.Framework;

namespace FlyGon.Notifications.Test.Validations
{
    class UrlValidationContractTests
    {
        private const string Property = "Url";
        private const string Message = "Invalid Url";

        [Test]
        [Category("Validations/Url")]
        public void Url()
        {
            var wrong = new ValidationContract()
                .IsUrl("invalidurl", Property, Message);
            Assert.That(wrong.IsInvalid, Is.True);
            Assert.That(wrong.Notifications.Count, Is.EqualTo(1));

            var right = new ValidationContract()
                .IsUrl("https://gmail.com", Property, Message)
                .IsUrl("http://gmail.com", Property, Message);
            Assert.That(right.IsValid, Is.True);
        }

        [Test]
        [Category("Validations/Url")]
        public void UrlOrEmpty()
        {
            var right = new ValidationContract()
                .IsUrlOrEmpty("", Property, Message);
            Assert.That(right.IsValid, Is.True);
        }
    }
}