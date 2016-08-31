using System;
using System.Runtime.Serialization;

namespace mySOAP.Models
{
    [DataContract]
    public class Distributor
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string FullName { get; set; }

        /// <summary>
        /// Status of distributor :
        /// 1 = Active
        /// 2 = Inactive
        /// 3 = Archived
        /// </summary>
        [DataMember]
        public byte Status { get; set; }
    }
}