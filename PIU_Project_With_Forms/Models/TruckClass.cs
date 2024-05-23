using System;
using Vehicle;

namespace Truck
{
    public class TruckClass : VehicleClass
    {
        public int CargoCapacity { get; set; }
        public int TowCapacity { get; set; }
        public TruckClass(long _owId,string _brand, string _model, string _year, int _km, int _price, string _condition, int _cargo, int _tow)
            : base(_owId, _brand, _model, _year, _km, _price, _condition, "Truck")
        {
            CargoCapacity = _cargo;
            TowCapacity = _tow;
        }

        public override string FormatDataForFileSave()
        {
            string format = String.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}",
                "_",
                base.OwnerId,
                base.Brand,
                base.Model,
                base.Year,
                base.Km,
                base.Price,
                base.Condition,
                base.Type,
                CargoCapacity,
                TowCapacity);
            return format;
        }

        public override string Info()
        {
            return base.Info() + "Cargo capacity:" + CargoCapacity + "\nTow capacity:" + TowCapacity;
        }
    }
}

