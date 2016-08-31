using mySOAP.Responses;
using System.Collections.Generic;

namespace mySOAP.Extensions
{
    public static class ResponsesHelper
    {

        public static ServiceResponse CreateErrorResponse(List<string> errorMessages)
        {
            return new ServiceResponse
            {
                Data = null,
                Status = StatusFlag.Error,
                ErrorMessages = errorMessages
            };
        }

        public static ServiceResponse CreateSuccessResponse(object data)
        {
            return new ServiceResponse
            {
                Data = data,
                Status = StatusFlag.Success,
                ErrorMessages = null
            };
        }
    }
}