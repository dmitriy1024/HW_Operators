using System;
using System.Collections.Generic;

namespace Task1
{
    class Computer
    {
        string _hostName;
        string _description;
        List<CPU> _cpus = new List<CPU>();
        List<HDD> _hdds = new List<HDD>();
        List<RAM> _rams = new List<RAM>();

        public string HostName
        {
            get{ return _hostName; }
        }

        public string Description
        {
            get{ return _description; }
        }

        public CPU Cpu
        {
            get
            {
                double commonCpu = 0;
                foreach (var item in _cpus)
                {
                    commonCpu += item.Value;
                }

                return new CPU(_cpus[0].Vendor, commonCpu);
            }
        }

        public HDD Hdd
        {
            get
            {
                double commonHdd = 0;
                foreach (var item in _hdds)
                {
                    commonHdd += item.Value;
                }

                return new HDD(_hdds[0].Vendor, commonHdd);
            }
        }

        public RAM Ram
        {
            get
            {
                double commonRam = 0;
                foreach (var item in _rams)
                {
                    commonRam += item.Value;
                }

                return new RAM(_rams[0].Vendor, commonRam);
            }
        }

        public Computer(string hostName, string description, CPU cpu, HDD hdd, RAM ram)
        {
            if(hostName == null || description == null || cpu == null || hdd == null || ram == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _hostName = hostName;
                _description = description;
                _cpus.Add(cpu);
                _hdds.Add(hdd);
                _rams.Add(ram);
            }
        }

        private Computer() { }

        public void AddComputer(Computer comp)
        {
            if (CheckСompatibility(this, comp))
            {
                _cpus.Add(comp.Cpu);
                _hdds.Add(comp.Hdd);
                _rams.Add(comp.Ram);
                _description = String.Format("{0} / {1}", _description, comp.Description);
                _hostName = String.Format("{0} + {1}", _hostName, comp.HostName);
            }
            else
            {
                throw new ComputersCompatibilityException("Vendors are different!");
            }
        }

        public Computer Clone()
        {
            return (Computer)MemberwiseClone();
        }

        public Computer DeepClone()
        {
            var comp = new Computer();
            comp._cpus = new List<CPU>();
            foreach (var item in _cpus)
            {
                comp._cpus.Add(new CPU(String.Copy(item.Vendor), item.Value));
            }

            comp._hdds = new List<HDD>();
            foreach (var item in _hdds)
            {
                comp._hdds.Add(new HDD(String.Copy(item.Vendor), item.Value));
            }

            comp._rams = new List<RAM>();
            foreach (var item in _rams)
            {
                comp._rams.Add(new RAM(String.Copy(item.Vendor), item.Value));
            }

            comp._hostName = String.Copy(_hostName);
            comp._description = String.Copy(_description);

            return comp;
        }

        public override string ToString()
        {
            return String.Format("HostName: {0,-6} Description: {1,-7} CPU: {2,-3}MHz,{3,-5} RAM: {4,-4}MB, {5,-5} HDD: {6,-4}GB, {7,-5}",
                _hostName, _description, Cpu.Value, Cpu.Vendor, Ram.Value, Ram.Vendor, Hdd.Value, Hdd.Vendor);
        }

        private static bool CheckСompatibility(Computer comp1, Computer comp2)
        {
            if (String.Compare(comp1.Cpu.Vendor, comp2.Cpu.Vendor, true) == 0 &&
                String.Compare(comp1.Hdd.Vendor, comp2.Hdd.Vendor, true) == 0 &&
                 String.Compare(comp1.Ram.Vendor, comp2.Ram.Vendor, true) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Computer operator +(Computer comp1, Computer comp2)
        {
            comp1.AddComputer(comp2);
            return comp1;
        }
    }
}
