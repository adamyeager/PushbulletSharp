using Microsoft.VisualStudio.TestTools.UnitTesting;
using PushbulletSharp.Models.Requests;
using System;
using System.Linq;

namespace PushbulletSharp.Tests
{
    [TestClass]
    public class ContactsTests : TestBase
    {
        /// <summary>
        /// Pushbullets the get contacts test.
        /// </summary>
        [TestMethod]
        public void PushbulletGetContactsTest()
        {
            try
            {
                var contacts = Client.CurrentUsersContacts();
                Assert.IsNotNull(contacts);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        /// <summary>
        /// Pushbullets the get active contacts test.
        /// </summary>
        [TestMethod]
        public void PushbulletGetActiveContactsTest()
        {
            try
            {
                var contacts = Client.CurrentUsersContacts(true);
                Assert.IsNotNull(contacts);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        /// <summary>
        /// Pushbullets the create contact test.
        /// </summary>
        [TestMethod]
        public void PushbulletCreateContactTest()
        {
            try
            {
                CreateContactRequest request = new CreateContactRequest()
                {
                    Name = "Some Person",
                    Email = "some.person@aninternetwebsite.com"
                };

                var result = Client.CreateNewContact(request);
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        /// <summary>
        /// Pushbullets the update contact test.
        /// </summary>
        [TestMethod]
        public void PushbulletUpdateContactTest()
        {
            try
            {
                var contacts = Client.CurrentUsersContacts();
                Assert.IsNotNull(contacts);

                var contact = contacts.Contacts.Where(o => o.Email == "some.person@aninternetwebsite.com").FirstOrDefault();
                Assert.IsNotNull(contact);

                UpdateContactRequest request = new UpdateContactRequest()
                {
                    Name = "Not A Real Person",
                    ContactIden = contact.Iden
                };

                var result = Client.UpdateContact(request);
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        /// <summary>
        /// Pushbullets the delete contact test.
        /// </summary>
        [TestMethod]
        public void PushbulletDeleteContactTest()
        {
            try
            {
                var contacts = Client.CurrentUsersContacts();
                Assert.IsNotNull(contacts);

                var contact = contacts.Contacts.Where(o => o.Email == "some.person@aninternetwebsite.com").FirstOrDefault();
                Assert.IsNotNull(contact);

                DeleteContactRequest request = new DeleteContactRequest()
                {
                    ContactIden = contact.Iden
                };

                Client.DeleteContact(request);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}