﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingEditViewModels
{
    interface IFlightBookingEditViewModel
    {
        Exception CaughtException { get; }

        IFlightBooking ChosenFlightBooking { get; set; }
        ObservableCollection<IFlightBooking> RetrievedFlightBookings { get; }

        IFlightBookingData Args { get; }

        void DoFlightBookingSearch();
        void DoConfirmFlightBooking();
        void DoCancelFlightBooking();
    }
}