using System;

namespace BitsOrchestraTest.Service
{
    public class DataValidation
    {
        public bool StringToInt(string value) 
        {
            return int.TryParse(value, out _);
        }

        public bool StringToDateTime(string value)
        {
            return DateTime.TryParse(value, out _);
            
        }

        public bool StringToDecimal(string value)
        {
            return decimal.TryParse(value, out _);
        }

        public bool StringToBoolean(string value)
        {
            return bool.TryParse(value, out _);
        }
    }
}
