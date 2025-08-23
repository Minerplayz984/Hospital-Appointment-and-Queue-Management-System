using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Hospital_Appointment_and_Queue_Management_System
{
    internal class Admin
    {
        private string adminUsername;
        private string adminPassword;

        //constructor
        public Admin(string username, string password)
        {
            adminUsername = username;
            adminPassword = password;
        }
        public string getadminUsername()
        {
            return adminUsername;
        }
        public string getadminPassword()
        {
            return adminPassword;
        }
        public void addDoctor(Dictionary<string, Doctor> doctors, Doctor d)
        {
            doctors[d.GetDoctorId()] = d;
            Console.WriteLine("Doctor {0} added", d.Getname());
        }
        public void removeDoctor(Dictionary<string, Doctor> doctors, string doctorId)
        {
            if (doctors.Remove(doctorId))
            {
                Console.WriteLine("Doctor removed");
            }
            else
            {
                Console.WriteLine("Doctor not found");
            }
        }
        public void viewAllAppointments(List<Appointment> appointments)
        {
            Console.WriteLine("All appointments:");
            foreach (var a in appointments)
            {
                Console.WriteLine("{0}, Patient {1}, Doctor {2}, {3}, {4}", a.getappointmentId(), a.getpatientId(), a.getdoctorId(), a.getdate(), a.getstatus());
            }
        }
    }
}