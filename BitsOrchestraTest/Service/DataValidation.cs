using System;

namespace BitsOrchestraTest.Service
{
    public class DataValidation
    {
        public bool StringToInt(string value) 
        {
            int intValue;
            return int.TryParse(value, out intValue);
        }

        public bool StringToDateTime(string value)
        {
            DateTime dateTime;
            return DateTime.TryParse(value, out dateTime);
            
        }

        public bool StringToDecimal(string value)
        {
            decimal decimalValue;
            return decimal.TryParse(value, out decimalValue);
        }

        public bool StringToBoolean(string value)
        {
            bool boolValue;
            return bool.TryParse(value, out boolValue);
        }
    }
}
