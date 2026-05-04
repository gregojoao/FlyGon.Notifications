using FlyGon.Notifications.Validations;
using NUnit.Framework;

namespace FlyGon.Notifications.Test.Validations
{
    class ObjectContractTests
    {
        private const string PropertyName = "object";

        [Test]
        [Category("Validations/Object")]
        public void IsNull()
        {
            var message = "Object is not null";
            object obj = 10;
            var wrong = new ValidationContract()
                .IsNull(obj, PropertyName, message);
            Assert.That(wrong.IsInvalid, Is.True);
            Assert.That(wrong.Notifications.Count, Is.EqualTo(1));

            obj = null;
            var right = new ValidationContract()
                .IsNull(obj, PropertyName, message);
            Assert.That(right.IsValid, Is.True);
        }

        [Test]
        [Category("Validations/Object")]
        public void IsNotNull()
        {
            var message = "Object is null";
            object obj = null;
            var wrong = new ValidationContract()
                .IsNotNull(obj, PropertyName, message);
            Assert.That(wrong.IsInvalid, Is.True);
            Assert.That(wrong.Notifications.Count, Is.EqualTo(1));

            obj = 10;
            var right = new ValidationContract()
                .IsNotNull(obj, PropertyName, message);
            Assert.That(right.IsValid, Is.True);
        }

        [Test]
        [Category("Validations/Object")]
        public void AreEqual()
        {
            var message = "Object is not equal";
            object obj = 10;
            object obj1 = 20;
            var wrong = new ValidationContract()
                .AreEquals(obj, obj1, PropertyName, message)
                .AreEquals(20.10, "string", PropertyName, message);
            Assert.That(wrong.IsInvalid, Is.True);
            Assert.That(wrong.Notifications.Count, Is.EqualTo(2));

            obj = 20.10;
            obj1 = 20.10;
            var right = new ValidationContract()
                .AreEquals(obj, obj1, PropertyName, message);
            Assert.That(right.IsValid, Is.True);
        }

        [Test]
        [Category("Validations/Object")]
        public void AreNotEqual()
        {
            var message = "Object is equal";
            object obj = 10;
            object obj1 = 10;
            var wrong = new ValidationContract()
                .AreNotEquals(obj, obj1, PropertyName, message);
            Assert.That(wrong.IsInvalid, Is.True);
            Assert.That(wrong.Notifications.Count, Is.EqualTo(1));

            obj = 10.5;
            obj1 = "string";
            var right = new ValidationContract()
                .AreNotEquals(obj, obj1, PropertyName, message);
            Assert.That(right.IsValid, Is.True);
        }
    }
}