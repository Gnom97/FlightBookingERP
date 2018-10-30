﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.Dates;
using FlighBooking_ThomasZerr.Utils.DateConverters;

namespace FlighBooking_ThomasZerr.Models.Flights.FlightDatas
{
    class FlightDataSAP : IFlightData
    {
        public string AirlineId { get; set; }
        public string ConnectId { get; set; }
        public IDate Flightdate { get; }
        public IDateRange FlightDateRange { get; }
        public string Planetype { get; set; }
        public string CurrencyIso { get; set; }
        public decimal Price { get; set; }

        public FlightDataSAP()
        {
            IDateConverter dateConverter = new DateConverterSAP();
            Flightdate = new DateImpl(dateConverter);
            FlightDateRange = new DateRangeImpl(dateConverter);
        }
    }
}
