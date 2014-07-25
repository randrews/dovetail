using FubuCore.Conversion;
using PizzaWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaWeb.Conventions
{
    public class PhoneNumberConverter : StatelessConverter
    {
        public override bool Matches(Type type, ConverterLibrary converter)
        {
            return type.Equals(typeof(PhoneNumber));
        }

        public override object Convert(IConversionRequest request)
        {
            throw new NotImplementedException();
        }

    }
}