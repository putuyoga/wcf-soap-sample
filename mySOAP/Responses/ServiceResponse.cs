using mySOAP.Models;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace mySOAP.Responses
{
    [DataContract]
    public class ServiceResponse
    {
        /// <summary>
        /// The output result based on each request
        /// </summary>
        [DataMember]
        public object Data { get; set; }

        /// <summary>
        /// Flag to define the response is success or error
        /// </summary>
        [DataMember]
        public StatusFlag Status { get; set; }

        /// <summary>
        /// Error message collection when status flag is error
        /// </summary>
        [DataMember]
        public List<string> ErrorMessages { get; set; }
    }
}