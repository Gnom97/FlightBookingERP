﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.ViewModels.FlightBookingEditViewModels;

namespace FlighBooking_ThomasZerr.ViewModels
{
    class FlightBookingEditViewModelImpl : IFlightBookingEditViewModel
    {
        private IFlightBookingFactory flightBookingFactory_;

        public Exception CaughtException { get; private set; }

        public IFlightBooking ChosenFlightBooking { get; set; }
        public ObservableCollection<IFlightBooking> RetrievedFlightBookings { get; }

        public IFlightBookingData Args { get; }

        public void DoFlightBookingSearch()
        {
            try
            {
                IFlightBooking[] flightBookings = flightBookingFactory_.RetrieveAll(Args);
                RetrievedFlightBookings.Clear();
                foreach (var flightBooking in flightBookings)
                {
                    RetrievedFlightBookings.Add(flightBooking);
                }
            }
            catch (Exception e)
            {
                CaughtException = e;
            }
        }

        public void DoConfirmFlightBooking()
        {
            try
            {
                ChosenFlightBooking.Confirm();
            }
            catch (Exception e)
            {
                CaughtException = e;
            }
        }

        public void DoCancelFlightBooking()
        {
            try
            {
                ChosenFlightBooking.Cancel();
                
            }
            catch (Exception e)
            {
                CaughtException = e;
            }
        }
    }
}
