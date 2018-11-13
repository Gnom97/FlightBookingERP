﻿using System;
using System.ComponentModel;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.Proxys;
using FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys;
using FlighBooking_ThomasZerr.Utils;

namespace FlighBooking_ThomasZerr.Models.FlightBookings
{
    class FlightBookingImpl : IFlightBooking
    {
        private ProxyFlightBooking _proxyFlightBooking;

        public IFlightBookingData FlightBookingData { get; }

        public FlightBookingImpl(ProxyFlightBooking proxyFlightBooking, IFlightBookingData flightBookingData)
        {
            _proxyFlightBooking = proxyFlightBooking;
            FlightBookingData = flightBookingData;
        }

        public void Confirm()
        {
            _proxyFlightBooking.Confirm(FlightBookingData);
            FlightBookingData.Confirmed = true;
        }

        public void Cancel()
        {
            _proxyFlightBooking.Cancel(FlightBookingData);
            FlightBookingData.Cancelled = true;
        }
    }
}
