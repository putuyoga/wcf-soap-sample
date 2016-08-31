using mySOAP.Models;
using System.Collections.Generic;

namespace mySoap.Test
{
    public class SampleDistributorList : List<Distributor>
    {
        public SampleDistributorList()
        {
            Add(new Distributor
            {
                FullName = "I Putu Yoga Permana",
                Status = 1
            });

            Add(new Distributor
            {
                FullName = "Google is Your Friend",
                Status = 2
            });

            Add(new Distributor
            {
                FullName = "Microsoft Master Race",
                Status = 3
            });
        }
    }
}
