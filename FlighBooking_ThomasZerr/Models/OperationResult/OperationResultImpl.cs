﻿using FlighBooking_ThomasZerr.Models.OperationResult.ReturnCodes;

namespace FlighBooking_ThomasZerr.Models.OperationResult
{
    class OperationResultImpl : IOperationResult
    {
        public string Message { get;}
        public ReturnCode ReturnCode { get;}

        public OperationResultImpl(string message, ReturnCode returnCode)
        {
            Message = message;
            ReturnCode = returnCode;
        }
    }
}
