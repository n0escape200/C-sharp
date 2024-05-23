using System;
using Car;
using Truck;
using Motorcycle;
using Repository;
using System.Collections.Generic;
using Vehicle;
using Authentication;




namespace Project_PIU
{
    enum VehicleOptions
    {
        Car = 1,
        Truck = 2,
        Motorcycle = 3
    }


    internal class Program
    {
        static void AdminMenu(Admin admin)
        {
            Console.WriteLine("Logged in as a ADMIN");
            Console.WriteLine("First name:" + admin.getFirstName() + " Last name:" + admin.getLastName());
            Console.WriteLine("Username:" + admin.getUsername() + " ID:" + admin.getId());
            Console.WriteLine("0)EXIT");
            Console.WriteLine("1)Add a vehicle");
            Console.WriteLine("2)Read all the data");
            Console.WriteLine("3)Read vehicle with id");
            Console.WriteLine("4)Delete vehicle with id ");
            Console.WriteLine("5)Delete repository data");
            Console.WriteLine("6)Add vehicle by id");
            Console.WriteLine("7)Add data from repo to file");
            Console.WriteLine("8)Add data from .txt to repository");

        }

        static void CustomerMenu(Customer customer)
        {
            Console.WriteLine("Logged in as a CUSTOMER");
            Console.WriteLine("First name:" + customer.getFirstName() + " Last name:" + customer.getLastName());
            Console.WriteLine("Username:" + customer.getUsername() + " ID:" + customer.getId());
            Console.WriteLine("Buget:" + customer.GetBuget() + "$");
            Console.WriteLine("0)EXIT");
            Console.WriteLine("1)Read all the data from file");
            Console.WriteLine("2)Read data from repository");
            Console.WriteLine("3)Purches vehicle with id");
            Console.WriteLine("4)Show the purchesed vehicles");
        }

        static void Main(string[] args)
        {
            //Base class values
            string brand, model, year, condition;
            int km, price;

            //Car values
            int nrDoors, cp;
            string body;

            //Truck values
            int cargo, tow;

            //Motorcycle values 
            int cc;
            string type;

            RepositoryClass repository = new RepositoryClass();

            string opr = String.Empty;

            int login = 0;

           
            Customer customer = new Customer();
            Admin admin = new Admin();
            HandleUsers handleUsers = new HandleUsers();


            long currentUserId = -1;

            while (login != 1)
            {
                Console.Clear();
                Console.WriteLine("1)Login");
                Console.WriteLine("2)Register");
                Console.WriteLine(">>>"); opr = Console.ReadLine().ToUpper();
                switch(opr)
                {
                    case "1":
                        {
                            Console.WriteLine("Username:");
                            string username = Console.ReadLine();

                            Console.WriteLine("Password:");
                            string password = Console.ReadLine();

                            Console.WriteLine("Admin code (optional):");
                            int code = Int32.Parse(Console.ReadLine());


                            currentUserId =  handleUsers.Login(username,password,code);

                            if(currentUserId == -1)
                            {
                                Console.WriteLine("Error...");
                            }else if(currentUserId == 0)
                            {
                                Console.WriteLine("User not found");
                            }
                            else
                            {
                                Console.WriteLine("User loged in");
                                User aux = handleUsers.getUserById(currentUserId);
                                if(aux is Admin)
                                {
                                    admin = (Admin)aux;
                                }
                                else
                                {
                                    customer = (Customer)aux;
                                }
                                login = 1;
                            }

                        }
                        break;
                    case "2":
                        {
                            Console.WriteLine("First name:");
                            string fname = Console.ReadLine();

                            Console.WriteLine("Last name:");
                            string lname = Console.ReadLine();

                            Console.WriteLine("Username:");
                            string username = Console.ReadLine(); 
                            
                            Console.WriteLine("Password:");
                            string password = Console.ReadLine();

                            Console.WriteLine("Admin Code (optional):");
                            int adminCode = Int32.Parse(Console.ReadLine());

                            if (adminCode == admin.getCode())
                            {
                                Console.WriteLine("User will be registered in as a ADMIN");
                                admin = new Admin(fname, lname, username, password);    
                                handleUsers.Register(admin);
                            }
                            else
                            {
                                Console.WriteLine("User will be registered in as a CUSTOMER");
                                Console.WriteLine("What is your current buget:");
                                int buget = Int32.Parse(Console.ReadLine());
                                customer = new Customer(fname, lname,username, password, buget);
                                handleUsers.Register(customer);
                            }

                           
                            Console.WriteLine("User registered");
                        }
                        break;  
                    default:
                        Console.WriteLine("Option unknown");
                        break;
                }
                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }

            User currentUserInfo = handleUsers.getUserById(currentUserId);
            
            if (repository.ok == 1)
                {
                    if(currentUserInfo.getType() == "ADMIN")
                {
                    do
                    {
                        Console.Clear();
                        AdminMenu(admin);
                        Console.WriteLine(">>>"); opr = Console.ReadLine().ToUpper();

                        switch (opr)
                        {
                            case "0":
                                break;

                            case "1":
                                {

                                    Console.WriteLine("Type of vehicle: \nCar = 1\nTruck = 2\nMotocycle = 3\n");
                                    int vehicle = Int32.Parse(Console.ReadLine());

                                    if (vehicle >= 1 && vehicle <= 3)
                                    {
                                        Console.WriteLine("Brand:");
                                        brand = Console.ReadLine();

                                        Console.WriteLine("Model:");
                                        model = Console.ReadLine();

                                        Console.WriteLine("Year:");
                                        year = Console.ReadLine();

                                        Console.WriteLine("Condition:");
                                        condition = Console.ReadLine();

                                        Console.WriteLine("Km:");
                                        km = Int32.Parse(Console.ReadLine());

                                        Console.WriteLine("Price:");
                                        price = Int32.Parse(Console.ReadLine());

                                        switch (vehicle)
                                        {
                                            case (int)VehicleOptions.Car:
                                                {
                                                    Console.WriteLine("Number of doors:");
                                                    nrDoors = Int32.Parse(Console.ReadLine());
                                                    

                                                    Console.WriteLine("Engine horse power:");
                                                    cp = Int32.Parse(Console.ReadLine());
                                                    

                                                    Console.WriteLine("Body type:");
                                                    body = Console.ReadLine();
                                                    

                                                    repository.Add(new CarClass(currentUserId, brand, model, year, km, price, condition, nrDoors, cp, body));
                                                }
                                                break;
                                            case (int)VehicleOptions.Truck:
                                                {
                                                    Console.WriteLine("Cargo capacity:");
                                                    cargo = Int32.Parse(Console.ReadLine());
                                                    

                                                    Console.WriteLine("Tow capacity:");
                                                    tow = Int32.Parse(Console.ReadLine());
                                                    
                                                    repository.Add(new TruckClass(currentUserId, brand, model, year, km, price, condition, cargo, tow));
                                                }
                                                break;
                                            case (int)VehicleOptions.Motorcycle:
                                                {
                                                    Console.WriteLine("Cylinder capacity:");
                                                    cc = Int32.Parse(Console.ReadLine());
                                                    

                                                    Console.WriteLine("Motorcycle type:");
                                                    type = Console.ReadLine();
                                                    
                                                    repository.Add(new MotorcycleClass(currentUserId, brand, model, year, km, price, condition, cc, type));
                                                }
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Type unknown...");
                                    }
                                }
                                break;

                            case "2":
                                {
                                    List<VehicleClass> list = repository.GetAll();
                                    if (list.Count != 0)
                                    {
                                        for (int i = 0; i < list.Count; i++)
                                        {
                                            Console.WriteLine("--------------------");
                                            Console.WriteLine(list[i].Info());
                                            Console.WriteLine("--------------------\n");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Repository is empty");
                                    }
                                }
                                break;

                            case "3":
                                {
                                    int id;
                                    Console.WriteLine("Get the vehicle at Id:");
                                    id = Int32.Parse(Console.ReadLine());
                                    VehicleClass aux = repository.GetById(id);
                                    if (aux.Type == "undefined")
                                    {
                                        Console.WriteLine($"Vehicle with id:{id} doesn't exist");
                                    }
                                    else
                                    {
                                        Console.WriteLine(aux.Info());
                                    }
                                }
                                break;
                            case "4":
                                {
                                    int id;
                                    Console.WriteLine("Delete the vehicle at Id:");
                                    id = Int32.Parse(Console.ReadLine());
                                    if (repository.DeleteById(id) == true)
                                    {
                                        Console.WriteLine("Vehicle deleted");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Vehicle not found");
                                    }
                                }
                                break;
                            case "5":
                                {
                                    repository.DeleteRepositoryData();
                                    if(repository.GetSize() > 0)
                                    {
                                        Console.WriteLine("Data from repository has been deleted");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Repository is already empty");
                                    }
                                }
                                break;
                            case "6":
                                {
                                    int id;
                                    Console.WriteLine("Add the vehicle at Id in .txt:");
                                    id = Int32.Parse(Console.ReadLine());
                                    if (repository.AddByIdToFile(id) == true)
                                    {
                                        Console.WriteLine("Vehicle added to file");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Vehicle not found");
                                    }
                                }
                                break;
                            case "7":
                                {
                                    if (repository.GetSize() != 0)
                                    {
                                        repository.AddRepoToFile();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Repository is empty");
                                    }
                                }
                                break;
                            case "8":
                                {
                                    repository.GetDataFromFileById(currentUserId);
                                    Console.WriteLine("Data added to repository");
                                }
                                break;
                            default:
                                Console.WriteLine("Option unknown");
                                break;
                        }

                        Console.WriteLine("Press any key ...");
                        Console.ReadKey();

                    } while (opr != "0");
                }
                else
                {
                    int ok = 0;
                    do
                    {
                        Console.Clear();
                        CustomerMenu(customer);
                        Console.WriteLine(">>>"); opr = Console.ReadLine().ToUpper();
                        

                        switch (opr)
                        {
                            case "0":
                                {
                                    Console.WriteLine(":D");
                                }
                                break;
                            case "1":
                                {
                                    if(ok == 0)
                                    {
                                        repository.GetDataFromFile();
                                        ok = 1;
                                        if (repository.GetSize() == 0)
                                        {
                                            Console.WriteLine("There is no data inside the databse");
                                        }
                                        else
                                        {
                                            foreach (VehicleClass vehicle in repository.GetAll())
                                            {
                                                Console.WriteLine("\n-------------------");
                                                Console.WriteLine(vehicle.Info());
                                                Console.WriteLine("-------------------\n");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Data was already added to the repository");
                                    }
                                }
                                break;
                            case "2":
                                {
                                    if(ok == 0)
                                    {
                                        Console.WriteLine("Data wa not added yet");
                                    }
                                    else
                                    {
                                        foreach (VehicleClass vehicle in repository.GetAll())
                                        {
                                            Console.WriteLine("\n-------------------");
                                            Console.WriteLine(vehicle.Info());
                                            Console.WriteLine("-------------------\n");
                                        }
                                    }
                                }
                                break;
                            case "3":
                                {
                                    int id;
                                    Console.WriteLine("ID of the vehicle u want to purchase:");
                                    id = Int32.Parse(Console.ReadLine());

                                    VehicleClass buffer = repository.GetById(id);
                                    if(buffer.Id == -1)
                                    {
                                        Console.WriteLine("Vehicle with id " + id + " is not in the repository");
                                    }
                                    else
                                    {
                                        if(repository.PurchesCar(customer, buffer))
                                        {
                                            Console.WriteLine("Vehicle purchesed");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Not enough money");
                                        }
                                        
                                    }
                                }
                                break;
                            case "4":
                                {
                                    if(repository.GetPurchesedCarCount() < 0)
                                    {
                                        Console.WriteLine("You haven't purchesed any vehicles yet");
                                    }
                                    else
                                    {
                                        foreach(VehicleClass vehicle in repository.GetPurchesedCars())
                                        {
                                            Console.WriteLine("\n-------------------");
                                            Console.WriteLine(vehicle.Info());
                                            Console.WriteLine("\n-------------------");
                                        }
                                    }
                                }
                                break;
                            default:
                                Console.WriteLine("Option unknown");
                                break;
                        }

                        Console.WriteLine("Press any key ...");
                        Console.ReadKey();

                    } while (opr != "0");
                }
                }
           
            
        }
    }
}
