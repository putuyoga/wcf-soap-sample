using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using mySOAP.Models;
using mySOAP.Responses;
using mySOAP.Extensions;

namespace mySOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DistributorService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DistributorService.svc or DistributorService.svc.cs at the Solution Explorer and start debugging.
    public class DistributorService : IDistributorService
    {
        public ServiceResponse Add(Distributor item)
        {
            var error = new List<string>();
            ServiceResponse response;

            if (item == null)
            {
                error.Add("You sent us nothing, please send us a Distributor object.");
            }

            if (string.IsNullOrEmpty(item.FullName))
            {
                error.Add("You do not specify the full name.");
            }

            if(item.Status < 1 || item.Status > 3)
            {
                error.Add("The status range should be between 1 and 3.");
            }

            if(error.Count == 0)
            {
                var guid = Guid.NewGuid();
                TestDataSource.DataTable.Rows.Add(guid, item.FullName, item.Status);
                response = ResponsesHelper.CreateSuccessResponse(guid);
            }
            else
            {
                response = ResponsesHelper.CreateErrorResponse(error);
            }
            return response;
        }

        public ServiceResponse GetAll()
        {
            return GetAll(null, null);
        }

        public ServiceResponse GetById(List<Guid> distributorId)
        {
            return GetAll(distributorId, null);
        }

        public ServiceResponse GetByStatus(List<byte> distributorStatus)
        {
            return GetAll(null, distributorStatus);
        }

        public ServiceResponse GetByStatusAndId(
            List<Guid> distributorId,
            List<byte> distributorStatus)
        {
            return GetAll(distributorId, distributorStatus);
        }

        private ServiceResponse GetAll(
            List<Guid> distributorId, 
            List<byte> distributorStatus)
        {
            ServiceResponse response;
            var table = TestDataSource.DataTable.AsEnumerable();
            var result = (from row in table
                select new Distributor
                {
                    Id = row.Field<Guid>("BODS_Id"),
                    FullName = row.Field<string>("BODS_FullName"),
                    Status = row.Field<byte>("BODS_Status")
                });
            
            // distributor id defined
            if(distributorId != null)
            {
                result = result.Where(d => distributorId.Contains(d.Id));
            }

            // distributor status defined
            if(distributorStatus != null)
            {
                result = result.Where(d => distributorStatus.Contains(d.Status));
            }

            if(result.Count() > 0)
            {
                response = ResponsesHelper.CreateSuccessResponse(result.ToList());
            }
            else
            {
                var listError = new List<string> { "Data is empty" };
                response = ResponsesHelper.CreateErrorResponse(listError);
            }
            return response;
        }

        public ServiceResponse Update(List<Distributor> items)
        {
            var error = new List<string>();
            int found = 0;
            int updated = 0;
            if (items == null || items.Count == 0)
            {
                error.Add("You should specify the items you want to updated");
            }
            else
            {
                // loop
                foreach (DataRow row in TestDataSource.DataTable.Rows)
                {
                    var match = items.FirstOrDefault(i => i.Id == row.Field<Guid>("BODS_Id"));
                    if (match != null)
                    {
                        row.SetField("BODS_FullName", match.FullName);
                        // Todo: Check Status Range
                        row.SetField("BODS_Status", match.Status);
                        updated++;
                        found++;
                    }
                }
                if (found == 0)
                {
                    error.Add("We can not find any specified Distributor Id from database");
                }
                else if (found < items.Count && updated > 0)
                {
                    var msg = string.Format("Only updated {0} item(s) from {1} we have found", updated, found);
                    error.Add(msg);
                }
            }
            if(error.Count > 0)
            {
                return ResponsesHelper.CreateErrorResponse(error);
            }
            else
            {
                return ResponsesHelper.CreateSuccessResponse(true);
            }
        }
    }
}
