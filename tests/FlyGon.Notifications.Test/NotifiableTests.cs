using NUnit.Framework;

namespace FlyGon.Notifications.Test
{
    class NotifiableTests
    {
        [Test]
        [Category("Notifiable")]
        public void AddNotifications()
        {
            var customer = new Customer();
            Assert.That(customer.IsInvalid, Is.True);
            Assert.That(customer.Notifications.Count, Is.EqualTo(2));
        }

        [Test]
        [Category("Notifiable")]
        public void ClearNotifications()
        {
            var customer = new Customer();
            customer.Clear();
            Assert.That(customer.IsValid, Is.True);
            Assert.That(customer.Notifications.Count, Is.EqualTo(0));
        }
    }

    internal class Customer : Notifiable
    {
        public Customer()
        {
            Validate();
        }

        private void Validate()
        {
            AddNotification("Email", "Invalid Email");
            AddNotification("Phone", "Invalid Phone");
        }
    }
}