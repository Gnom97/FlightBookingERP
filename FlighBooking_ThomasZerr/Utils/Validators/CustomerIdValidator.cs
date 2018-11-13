﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlighBooking_ThomasZerr.Utils.Validators
{
    class CustomerIdValidator : IValidator
    {
        public int MaxLength { get; set; }

        public object ExtraParam { get; set; }
        public void IsValid(object value)
        {
            if (value is string customerId)
            {
                if (customerId.Length == 0)
                    throw new Exception("Kundennummer darf nicht leer sein");

                if (customerId.Length > MaxLength)
                    throw new Exception("Kundennummer darf nur maximal 8 Ziffern lang sein");

                if (!Regex.IsMatch(customerId, "^[0-9]*$"))
                    throw new Exception("Kundennummer darf nur Ziffern enthalten");

                return;
            }

            throw new ArgumentException();
        }
    }
}
