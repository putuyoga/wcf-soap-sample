using mySOAP.App.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mySOAP.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new DistributorServiceClient();

            // create new Distributor
            var newDistributor = new Distributor
            {
                FullName = "Mr. Hello",
                Status = 1
            };
            var response = client.Add(newDistributor);
            Console.WriteLine(string.Format("create new distributor: {0}", response.Status));

            // update the newly created distributor
            newDistributor.Id = (Guid)response.Data;
            newDistributor.FullName = "Mr. Hello now Updated";
            var response2 = client.Update(new Distributor[] { newDistributor });
            Console.WriteLine(string.Format("update distributor: {0}", response2.Status));

            // get the newly created distributor
            var response3 = client.GetById(new Guid[] { newDistributor.Id });
            var distributor = ((Distributor[])response3.Data).FirstOrDefault();
            Console.WriteLine(string.Format("get the new distributor: {0}", distributor.FullName));
            
            var response4 = client.GetAll();
            Console.WriteLine("get all distributor:");
            foreach (var item in (Distributor[])response4.Data)
            {
                Console.WriteLine(string.Format("ID: {0}", item.Id));
                Console.WriteLine(string.Format("> name: {0}", item.FullName));
                Console.WriteLine(string.Format("> status: {0}", item.Status));
            }
            Console.ReadLine();
        }
    }
}
