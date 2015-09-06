using System;

namespace Task1
{
    abstract class Equipment
    {
        private string _vendor;

        private double _value;

        public string Vendor
        {
            get{ return _vendor; }
        }

        public double Value
        {
            get{return _value; }
        }

        public Equipment(string vendor, double value)
        {
            if(vendor == null)
            {
                throw new ArgumentNullException();
            }
            else if(vendor.Length == 0 || value < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                _vendor = vendor;
                _value = value;
            }
        }
    }
}
