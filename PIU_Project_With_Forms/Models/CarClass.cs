using System;
using System.Diagnostics;
using System.Reflection;
using Vehicle;

namespace Car
{
    public class CarClass : VehicleClass
    {
        public int NrOfDoors { get; set; }
        public int CP { get; set; }
        public string Body { get; set; }

        public CarClass(long _owId,string _brand, string _model, string _year, int _km, int _price, string _condition, int _nrDoors, int _cp, string _body)
            : base(_owId,_brand, _model, _year, _km, _price, _condition, "Car")
        {
            NrOfDoors = _nrDoors;
            CP = _cp;
            Body = _body;
        }

        public override string FormatDataForFileSave()
        {
            string format = String.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{0}{11}",
                "_",
                base.OwnerId,
                base.Brand,
                base.Model,
                base.Year,
                base.Km,
                base.Price,
                base.Condition,
                base.Type,
                NrOfDoors,
                CP,
                Body);
            return format;
        }

        public override string Info()
        {
            return base.Info() + "Number of doors:" + NrOfDoors + "\nCP:" + CP + "\nBody:" + Body;
        }
    }
}
