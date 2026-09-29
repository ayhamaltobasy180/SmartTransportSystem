using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTransportSystem.classes
{
    public abstract  class Vehicle
    {
      
	public int VehicleId { get; set; }
        public string Model  { get; set; }
        public string PlateNumber  { get; set; }
        public int  Capacity  { get; set; }
        public double BaseFare  { get; set; }
        public bool IsAvailable { get; set; }
        public Vehicle() { }
        public Vehicle(int vehicleId=0, string model="Unknow", string  plateNumber=null , int capacity=1, double baseFare=0.0, bool isAvailable=true)
        {
            VehicleId = vehicleId;
            Model = model;
            PlateNumber = plateNumber;
            Capacity = capacity;
            BaseFare = baseFare;
            IsAvailable = isAvailable;
        }
        public abstract double CalculateFare(double distance);
        public virtual void DisplayVehicleDetails()
        {
            string status = IsAvailable ? "Available" : "Unavailable";
            Console.WriteLine($"Vehicle ID: {VehicleId} | Model: {Model} | Plate: {PlateNumber} | Capacity: {Capacity} | Base Fare: {BaseFare:C} | Status: {status}");
        }

        public void StartMaintenance()
        {
            if (!IsAvailable)
            {
                Console.WriteLine($"Vehicle #{VehicleId} ({Model}) is already in maintenance or busy.");
            }
            else
            {
                IsAvailable = false;
                Console.WriteLine($"Vehicle #{VehicleId} ({Model}) has entered maintenance.");
            }
        }
        public void EndMaintenance()
        {
            {
                if (IsAvailable)
                {
                    Console.WriteLine($"Vehicle #{VehicleId} ({Model}) is already available.");
                }
                else
                {
                    IsAvailable = true;
                    Console.WriteLine($"Vehicle #{VehicleId} ({Model}) maintenance is completed and is now Available.");
                }
            }
        }

    }
}
