﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges;
using FlighBooking_ThomasZerr.Models.Flights;
using FlighBooking_ThomasZerr.Models.Flights.Factorys;
using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;
using FlighBooking_ThomasZerr.Models.OperationResult.Factory;
using FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys;
using FlighBooking_ThomasZerr.Models.Proxys.FlightProxys;
using FlighBooking_ThomasZerr.ViewModels.FlightBookingCreateViewModels;

namespace FlighBooking_ThomasZerr.Views.FlightBookingCreateWindows.Factorys
{
    class FlightBookingCreateWindowFactorySAP : IFlightBookingCreateWindowFactory
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public FlightBookingCreateWindow Create()
        {
            var createViewModel = CreateViewModel();
            return new FlightBookingCreateWindow(createViewModel);
        }

        private IFlightBookingCreateViewModel CreateViewModel()
        {

            var flightFactory = CreateFlightFactory();
            var defaultFlightArgs = CreateDefaultFlightArgs();
            var flightBookingFactory = CreateFlightBookingFactory();
            var defaultFlightBookingArgs = CreateDefaultFlightBookingArgs();
            var operationResultFactory = CreateOperationResultFactory();

            return new FlightBookingCreateViewModelImpl(flightFactory, defaultFlightArgs, 
                flightBookingFactory, defaultFlightBookingArgs, 
                new ObservableCollection<IFlight>(), operationResultFactory);
        }

        private IFlightFactory CreateFlightFactory()
        {
            var proxyFlight = new ProxyFlightSAP
            {
                Username = Username,
                Password = Password
            };
            return new FlightFactoryImpl(proxyFlight);
        }

        private IFlightData CreateDefaultFlightArgs()
        {
            var flighData =  new FlightDataSAP
            {
                AirlineId = "",
                ConnectId = "",
                Planetype = "",
                CurrencyIso = "",
                Price = 0,
            };

            flighData.FlightDateRange.Option = DateRangeOption.Between;
            flighData.FlightDateRange.EarlierDateTime = DateTime.Now;
            flighData.FlightDateRange.LaterDateTime = DateTime.Now;

            return flighData;
        }

        private IFlightBookingFactory CreateFlightBookingFactory()
        {
            var proxyFlightBooking = new ProxyFlightBookingSAP
            {
                Username = Username,
                Password = Password
            };

            return new FlightBookingFactoryImpl(proxyFlightBooking);
        }

        private IFlightBookingData CreateDefaultFlightBookingArgs()
        {
            return new FlightBookingDataSAP
            {
                BookingId = "",
                CustomerId = "",
                Class = "",
                Counter = "",
                AgencyId = "",
                PassagierName = "",
                Reserved = false,
                Cancelled = false,
            };
        }

        private IOperationResultFactory CreateOperationResultFactory()
        {
            return new OperationResultFactorySAP();
        }
    }
}
