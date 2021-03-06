﻿using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;

namespace FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys
{
    public class ProxyFlightBookingResponse
    {
        public IFlightBookingData FlightBookingData { get; set; }
        public IFlightBookingData[] FlightBookingDatas { get; set; }
        public ReturnCodeProxys ReturnCode { get; set; }
        public string Message { get; set; }
        public string MessageNumber { get; set; }
    }
}
