using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;
using Vehicle;
using Car;
using Truck;
using Motorcycle;
using Authentication;

namespace Repository
{
    public class RepositoryClass : VehicleClass
    {
        List<VehicleClass> repository;
        List<VehicleClass> customerRepository;
       
        VehicleClass vehicleClass = new VehicleClass();

        string carFile = "../../../Repository/Car.txt";
        string truckFile = "../../../Repository/Truck.txt";
        string motorcycleFile = "../../../Repository/Motorcycle.txt";

        public int ok = 1;


        public RepositoryClass()
        {
            repository = new List<VehicleClass>();
            customerRepository = new List<VehicleClass>();
        }

        public int GetSize()
        {
            return repository.Count;
        }


        //Methods designed to be used by the ADMIN role
        public void Add(VehicleClass v)
        {
            repository.Add(v);
        }

        public List<VehicleClass> GetAll()
        {
            if(repository.Count > 0)
            {
                return repository;
            }
            return new List<VehicleClass>();
        }

        public VehicleClass GetById(int id)
        {
            for (int i = 0; i < repository.Count; i++)
            {
                if (repository[i].Id == id)
                {
                    return repository[i];
                }
            }

            return new VehicleClass();
        }

        public void UpdateByIndex(int index, VehicleClass v)
        {
            repository[index] = v;
        }

        public bool DeleteById(int id)
        {
            for (int i = 0; i < repository.Count; i++)
            {
               if(repository[i].Id == id)
                {
                    repository.Remove(repository[i]);
                    return true;
                }
            }
            return false;
        }

        public void DeleteRepositoryData()
        {
            repository.Clear();
            vehicleClass.setLatId(0);
            
        }

        public bool AddByIdToFile(int id)
        {
            VehicleClass vehicle = GetById(id);
            if (vehicle.Id != -1 && repository.Count > 0)
            {
                using(StreamWriter sw = new StreamWriter(vehicle.Type.ToUpper() == "CAR" ? carFile 
                    : vehicle.Type.ToUpper() == "TRUCK" ? truckFile : vehicle.Type.ToUpper() == "MOTORCYCLE" ? motorcycleFile :"",true))
                {
                    if (vehicle is CarClass)
                    {
                        CarClass aux = (CarClass)vehicle;
                        sw.WriteLine(aux.FormatDataForFileSave());
                    }
                    else if (vehicle is TruckClass)
                    {
                        TruckClass aux = (TruckClass)vehicle;
                        sw.WriteLine(aux.FormatDataForFileSave());
                    }
                    else if (vehicle is MotorcycleClass)
                    {
                        MotorcycleClass aux = (MotorcycleClass)vehicle;
                        sw.WriteLine(aux.FormatDataForFileSave());
                    }
                    sw.Close();
                    repository.Remove(vehicle);
                    vehicleClass.setLatId(getLastId() - 1);
                    return true;
                }
            }
            return false;
        }

        public void AddRepoToFile()
        { 
           if(repository.Count > 0)
            {
                foreach (VehicleClass vehicle in repository)
                {

                    using (StreamWriter sw = new StreamWriter(vehicle.Type.ToUpper() == "CAR" ? carFile 
                        : vehicle.Type.ToUpper() == "TRUCK" ? truckFile : vehicle.Type.ToUpper() == "MOTORCYCLE" ? motorcycleFile : "", true))
                    {
                        if (vehicle is CarClass)
                        {
                            CarClass aux = (CarClass)vehicle;
                            sw.WriteLine(aux.FormatDataForFileSave());
                        }
                        else if (vehicle is TruckClass)
                        {
                            TruckClass aux = (TruckClass)vehicle;
                            sw.WriteLine(aux.FormatDataForFileSave());
                        }
                        else if (vehicle is MotorcycleClass)
                        {
                            MotorcycleClass aux = (MotorcycleClass)vehicle;
                            sw.WriteLine(aux.FormatDataForFileSave());
                        }
                        sw.Close();
                    }

                }
                DeleteRepositoryData();
            }
        }

        public void AddVehicleToFile(VehicleClass vehicle)
        {
            using (StreamWriter sw = new StreamWriter(vehicle.Type.ToUpper() == "CAR" ? carFile 
                : vehicle.Type.ToUpper() == "TRUCK" ? truckFile : vehicle.Type.ToUpper() == "MOTORCYCLE" ? motorcycleFile : "", true))
            {
                if (vehicle is CarClass)
                {
                    CarClass aux = (CarClass)vehicle;
                    sw.WriteLine(aux.FormatDataForFileSave());
                }
                else if (vehicle is TruckClass)
                {
                    TruckClass aux = (TruckClass)vehicle;
                    sw.WriteLine(aux.FormatDataForFileSave());
                }
                else if (vehicle is MotorcycleClass)
                {
                    MotorcycleClass aux = (MotorcycleClass)vehicle;
                    sw.WriteLine(aux.FormatDataForFileSave());
                }
                sw.Close();
            }
        }

        public void GetDataFromFileById(long OwnerId)
        {

            using(StreamReader sw = new StreamReader(carFile))
            {
                string line;
                while((line = sw.ReadLine()) != null) {
                    string[] aux = line.Split('_');
                    if (long.Parse(aux[0]) == OwnerId)
                    {
                       
                        repository.Add(new CarClass(OwnerId, aux[1], aux[2], aux[3], Int32.Parse(aux[4]), Int32.Parse(aux[5]), aux[6],
                            Int32.Parse(aux[8]), Int32.Parse(aux[9]), aux[10]));
                    }
                    
                }
                sw.Close();
            }

            using (StreamReader sw = new StreamReader(truckFile))
            {
                string line;
                while ((line = sw.ReadLine()) != null)
                {
                    string[] aux = line.Split('_');
                    if (long.Parse(aux[0]) == OwnerId)
                    {
                        repository.Add(new TruckClass(long.Parse(aux[0]), aux[1], aux[2],
                        aux[3], Int32.Parse(aux[4]), Int32.Parse(aux[5]), aux[6], Int32.Parse(aux[8]), Int32.Parse(aux[9])));
                    }
                }
                sw.Close();
            }

            using (StreamReader sw = new StreamReader(motorcycleFile))
            {
                string line;
                while ((line = sw.ReadLine()) != null)
                {
                    string[] aux = line.Split('_');
                    if (long.Parse(aux[0]) == OwnerId)
                    {
                        repository.Add(new MotorcycleClass(long.Parse(aux[0]), aux[1], aux[2],
                        aux[3], Int32.Parse(aux[4]), Int32.Parse(aux[5]), aux[6], Int32.Parse(aux[8]), aux[9]));
                    }
                }
                sw.Close();
            }
        }

        //Methods designed to be used by the CUSTOMER role

        public bool PurchesCar(Customer customer, VehicleClass v)
        {
            if(customer.GetBuget() - v.Price >= 0)
            {
                customerRepository.Add(v);
                repository.Remove(v);
                customer.SetBuget(customer.GetBuget() - v.Price);
                return true;
            }
            return false;
        }

        public List<VehicleClass> GetPurchesedCars()
        {
            return this.customerRepository;
        }
        
        public int GetPurchesedCarCount()
        {
            return customerRepository.Count;
        }

        public void GetDataFromFile()
        {

            using (StreamReader sw = new StreamReader(carFile))
            {
                string line;
                while ((line = sw.ReadLine()) != null)
                {
                    string[] aux = line.Split('_');
                    repository.Add(new CarClass(OwnerId, aux[1], aux[2], aux[3], Int32.Parse(aux[4]), Int32.Parse(aux[5]), aux[6],
                            Int32.Parse(aux[8]), Int32.Parse(aux[9]), aux[10]));
                }
                sw.Close();
            }

            using (StreamReader sw = new StreamReader(truckFile))
            {
                string line;
                while ((line = sw.ReadLine()) != null)
                {
                    string[] aux = line.Split('_');
                    repository.Add(new TruckClass(long.Parse(aux[0]), aux[1], aux[2],
                     aux[3], Int32.Parse(aux[4]), Int32.Parse(aux[5]), aux[6], Int32.Parse(aux[8]), Int32.Parse(aux[9])));
                }
                sw.Close();
            }

            using (StreamReader sw = new StreamReader(motorcycleFile))
            {
                string line;
                while ((line = sw.ReadLine()) != null)
                {
                    string[] aux = line.Split('_');
                    repository.Add(new MotorcycleClass(long.Parse(aux[0]), aux[1], aux[2],
                    aux[3], Int32.Parse(aux[4]), Int32.Parse(aux[5]), aux[6], Int32.Parse(aux[8]), aux[9]));
                }
                sw.Close();
            }
        }
    }
}
