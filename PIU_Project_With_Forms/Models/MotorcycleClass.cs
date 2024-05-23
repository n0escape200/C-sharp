using System;
using Vehicle;

namespace Motorcycle
{
    public class MotorcycleClass : VehicleClass
    {
        public int CC {  get; set; }
        public string Type { get; set; }

        public MotorcycleClass(long _owId,string _brand, string _model, string _year, int _km, int _price, string _condition, int cc, string type)
            : base(_owId, _brand, _model, _year, _km, _price, _condition, "Motorcycle")
        {
            CC = cc;
            Type = type;
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
                CC,
                Type);
            return format;
        }

        public override string Info()
        {
            return base.Info() + "CC:" + CC + "\nType:" + Type;
        }
    }
}
