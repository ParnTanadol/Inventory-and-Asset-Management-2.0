using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inventory_and_Asset_Management_2._0.Repositories;
using Inventory_and_Asset_Management_2._0.Models;
using Inventory_and_Asset_Management_2._0;

namespace Test_Inventory.Test_Model
{
    /// <summary>
    /// Summary description for Test_MailAPI
    /// </summary>
    [TestClass]
    public class Test_MailAPI
    {
        private Appendix appendixA = new Appendix();


        [TestCleanup]
        public void cleanup()
        {
            appendixA.deleteReport();
            appendixA.deleteItemOwner();
            appendixA.deleteItem();
            appendixA.deleteCAMTUser();
            appendixA.addCAMTUser();
            appendixA.addItem();
            appendixA.addItemOwner();
            appendixA.addReport();
        }

        //-----------------insertItemOwner------------
        [TestMethod]
        public void testSendMail1()
        {
            // Arrange
            MailAPI mailAPI = new MailAPI();
            //Act
            var actual = mailAPI.Send("se542115021.developer@gmail.com", "Test", "Test");
            //Assert
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void testSendMail2()
        {
            // Arrange
            MailAPI mailAPI = new MailAPI();
            //Act
            var actual = mailAPI.Send(null, "Test", "Test");
            //Assert
            Assert.IsFalse(actual);
        }

    }
}
