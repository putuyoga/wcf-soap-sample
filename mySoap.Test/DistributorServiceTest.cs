using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mySOAP;
using mySOAP.Models;
using System.Collections.Generic;
using System.Linq;
using mySOAP.Responses;

namespace mySoap.Test
{
    [TestClass]
    public class DistributorServiceTest
    {
        [TestMethod]
        public void GetAll_ShouldReturnItems()
        {
            // The Order is Matter! this method should be on top.
            IDistributorService service = new DistributorService();
            var response = service.GetAll();
            Assert.IsTrue(response.Status == StatusFlag.Success);

            // We know from TestDataSource.cs
            var dataList = (List<Distributor>)response.Data;
            Assert.AreEqual(3, dataList.Count);
        }

        public void GetAllWithSpecificId_ShouldReturnCorrectItems()
        {
            IDistributorService service = new DistributorService();

            var specificId = new List<Guid> { Guid.Parse("617dba9d-391b-4ca7-aeeb-0703ca526709") };
            var response = service.GetById(specificId);
            Assert.IsTrue(response.Status == StatusFlag.Success);

            // We know from TestDataSource.cs
            var distributor = ((List<Distributor>)response.Data).FirstOrDefault();
            Assert.AreEqual("My Website", distributor.FullName);
            Assert.AreEqual(1, distributor.Status);
        }

        public void GetAllWithSpecificStatus_ShouldReturnCorrectItems()
        {
            IDistributorService service = new DistributorService();

            var specificStatus = new List<byte> { 3 };
            var response = service.GetByStatus(specificStatus);
            Assert.IsTrue(response.Status == StatusFlag.Success);

            // We know from TestDataSource.cs
            var distributor = ((List<Distributor>)response.Data).FirstOrDefault();
            Assert.AreEqual("About Australia", distributor.FullName);
            Assert.AreEqual(Guid.Parse("5df458a8-a743-4e81-bf0d-bd874f6f0cd3"), distributor.Id);
        }

        [TestMethod]
        public void InsertNewRecord_ShouldReturnCorrectItem()
        {
            var newItem = new Distributor
            {
                FullName = "I Putu Yoga Permana",
                Status = 1
            };
            IDistributorService service = new DistributorService();
            var response = service.Add(newItem);
            var guid = (Guid)response.Data;

            // Get the newly created item
            var distributorResponse = service.GetById(new List<Guid> { guid });
            var distributorCollection = (List<Distributor>)distributorResponse.Data;

            Assert.AreEqual(distributorCollection.FirstOrDefault().FullName, newItem.FullName);
            Assert.AreEqual(distributorCollection.FirstOrDefault().Status, newItem.Status);
        }

        [TestMethod]
        public void InsertNewRecordWithEmptyFullName_ShouldError()
        {
            var newItem = new Distributor
            {
                FullName = null,
                Status = 2
            };
            IDistributorService service = new DistributorService();
            var response = service.Add(newItem);
            Assert.IsTrue(response.Status == StatusFlag.Error);
        }

        [TestMethod]
        public void InsertNewRecordWithOutrangeStatus_ShouldError()
        {
            var newItem = new Distributor
            {
                FullName = "Mikocok",
                Status = 127
            };
            IDistributorService service = new DistributorService();
            var response = service.Add(newItem);
            Assert.IsTrue(response.Status == StatusFlag.Error);
        }

        [TestMethod]
        public void EditOneRecord_ShouldBeUpdated()
        {
            var updatedItem = new Distributor
            {
                // specific id from TestDataSource.cs
                Id = Guid.Parse("617dba9d-391b-4ca7-aeeb-0703ca526709"),
                FullName = "Zombie Killer",
                Status = 3
            };
            IDistributorService service = new DistributorService();
            var response = service.Update(new List<Distributor> { updatedItem });
            Assert.IsTrue(response.Status == StatusFlag.Success);

            // Make sure the data already be updated
            var distResponse = service.GetById(new List<Guid> { updatedItem.Id });
            var distributor = ((List<Distributor>)distResponse.Data).FirstOrDefault();
            Assert.AreEqual(updatedItem.FullName, distributor.FullName);
            Assert.AreEqual(updatedItem.Status, distributor.Status);
        }

        [TestMethod]
        public void EditMultipleRecord_ShouldBeUpdated()
        {
            var listUpdatedItem = new List<Distributor>
            {
                new Distributor
                {
                    // specific id from TestDataSource.cs
                    Id = Guid.Parse("617dba9d-391b-4ca7-aeeb-0703ca526709"),
                    FullName = "Zombie Killer",
                    Status = 3
                },
                new Distributor
                {
                    // specific id from TestDataSource.cs
                    Id = Guid.Parse("bee3c0be-ccbf-4882-ad5a-d288f5677a51"),
                    FullName = "Ninja Master",
                    Status = 2
                }
            };

            IDistributorService service = new DistributorService();
            var response = service.Update(listUpdatedItem);
            Assert.IsTrue(response.Status == StatusFlag.Success);

            // Make sure the data already be updated
            var updatedItemId = listUpdatedItem.Select(i => i.Id).ToList();
            var distResponse = service.GetById(updatedItemId);
            var distributor = (List<Distributor>)distResponse.Data;

            for(int i = 0; i < 2; i++)
            {
                Assert.AreEqual(listUpdatedItem[i].FullName, distributor[i].FullName);
                Assert.AreEqual(listUpdatedItem[i].Status, distributor[i].Status);
            }
        }

        [TestMethod]
        public void EditRecordWithEmptyItem_ShouldError()
        {
            var listItem = new List<Distributor>();
            IDistributorService service = new DistributorService();
            var response = service.Update(listItem);
            Assert.IsTrue(response.Status == StatusFlag.Error);

            var response2 = service.Update(null);
            Assert.IsTrue(response.Status == StatusFlag.Error);
        }
    }
}
