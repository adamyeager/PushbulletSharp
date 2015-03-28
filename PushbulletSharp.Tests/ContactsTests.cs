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
                        name = "Some Person",
                        email = "some.person@aninternetwebsite.com"
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

                var contact = contacts.contacts.Where(o => o.email == "some.person@aninternetwebsite.com").FirstOrDefault();
                Assert.IsNotNull(contact);

                UpdateContactRequest request = new UpdateContactRequest()
                {
                    name = "Not A Real Person",
                    contact_iden = contact.iden
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

                var contact = contacts.contacts.Where(o => o.email == "some.person@aninternetwebsite.com").FirstOrDefault();
                Assert.IsNotNull(contact);

                DeleteContactRequest request = new DeleteContactRequest()
                {
                    contact_iden = contact.iden
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