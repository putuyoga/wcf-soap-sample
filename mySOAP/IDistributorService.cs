using mySOAP.Models;
using mySOAP.Responses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace mySOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDistributorService" in both code and config file together.
    [ServiceContract]
    [ServiceKnownType(typeof(List<Distributor>))]
    public interface IDistributorService
    {
        /// <summary>
        /// Get distributor(s) by both Id and status
        /// </summary>
        /// <param name="distributorId">filter parameter by list of distributor id</param>
        /// <param name="distributorStatus">filter parameter by list of distributor status</param>
        /// <returns></returns>
        [OperationContract]
        ServiceResponse GetByStatusAndId(
            List<Guid> distributorId,
            List<byte> distributorStatus);

        /// <summary>
        /// Get all distributor(s) entity
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        ServiceResponse GetAll();

        /// <summary>
        /// Get distributor(s) by Id
        /// </summary>
        /// <param name="distributorId">Specific id as filter</param>
        /// <returns></returns>
        [OperationContract]
        ServiceResponse GetById(List<Guid> distributorId);

        /// <summary>
        /// Get distributor by status
        /// </summary>
        /// <param name="distributorStatus">specific status as filter</param>
        /// <returns></returns>
        [OperationContract]
        ServiceResponse GetByStatus(List<byte> distributorStatus);

        /// <summary>
        /// Add distributor to data table
        /// </summary>
        /// <param name="item">distributor entity want to be added</param>
        /// <returns></returns>
        [OperationContract]
        ServiceResponse Add(Distributor item);

        /// <summary>
        /// Update distributor from data table
        /// </summary>
        /// <param name="items">bulks item want to be updated</param>
        /// <returns></returns>
        [OperationContract]
        ServiceResponse Update(List<Distributor> items);

    }
}
