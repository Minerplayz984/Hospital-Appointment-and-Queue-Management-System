using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Hospital_Appointment___Queue_Management_System
{
    internal class Program
    {
        static Dictionary<string, Doctor> doctors = new Dictionary<string, Doctor>();
        static List<Appointment> appointments = new List<Appointment>();
        static Queue<Patient> Addemergency = new Queue<Patient>();
        static List<Patient> patients = new List<Patient>();
        static int appointmentCounter = 0;
        static void Patientmenu()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("===== Patient Menu =====");
                int id = patients.Count + 1;
                Console.Write("Enter patient Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter patient Age: ");
                if (!int.TryParse(Console.ReadLine(), out int age))
                {
                    Console.WriteLine("Invalid age entered.");
                    return;
                }
                Console.Write("Enter patient Illness: ");
                string illness = Console.ReadLine();

                Patient p = new Patient(id, name, age, illness);
                patients.Add(p);

                Console.WriteLine("1-Request appointment\n2-Join emergency queue");
                if (!int.TryParse(Console.ReadLine(), out int c))
                {
                    Console.WriteLine("Invalid option.");
                    return;
                }

                switch (c)
                {
                    case 1:
                        Console.Write("Enter doctor Name: ");
                        string docName = Console.ReadLine();

                        Doctor chosenDoctor = null;
                        foreach (Doctor d in doctors.Values)
                        {
                            if (d.Getname().Equals(docName, StringComparison.OrdinalIgnoreCase))
                            {
                                chosenDoctor = d;
                                break;
                            }
                        }

                        if (chosenDoctor != null)
                        {
                            Console.Write("Enter appointment date (yyyy-mm-dd): ");
                            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
                            {
                                Console.WriteLine("Invalid date format.");
                                return;
                            }

                            Appointment a = p.requestAppointment(chosenDoctor, date, ++appointmentCounter);
                            appointments.Add(a);
                            Console.WriteLine("Appointment booked");
                        }
                        else
                        {
                            Console.WriteLine("Doctor not found");
                        }

                        break;
                    case 2:
                        Addemergency.Enqueue(p);
                        Console.WriteLine("You are added to emergency queue");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Patient Menu: " + ex.Message);
            }
        }

        static void Doctormenu()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("===== Doctor Menu =====");
                Console.Write("Enter doctor ID: ");
                string id = Console.ReadLine();

                if (doctors.ContainsKey(id))
                {
                    Doctor d = doctors[id];
                    Console.Write("1-View appointments\n2-Take emergency patient\nChoice: ");
                    if (!int.TryParse(Console.ReadLine(), out int c))
                    {
                        Console.WriteLine("Invalid input.");
                        return;
                    }

                    switch (c)
                    {
                        case 1:
                            d.ViewAppointments();
                            break;
                        case 2:
                            d.Takeemergencypatient(Addemergency, appointments, ref appointmentCounter);
                            break;
                        default:
                            Console.WriteLine("Invalid number");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Doctor not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Doctor Menu: " + ex.Message);
            }
        }

        static void Adminmenu()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("===== Admin Menu =====");
                Admin admin = new Admin("admin", "1234");

                Console.WriteLine("1-Add doctor\n2-Remove doctor\n3-View all appointments");
                if (!int.TryParse(Console.ReadLine(), out int c))
                {
                    Console.WriteLine("Invalid option.");
                    return;
                }

                switch (c)
                {
                    case 1:
                        Console.Write("Doctor ID: ");
                        string did = Console.ReadLine();
                        Console.Write("Doctor name: ");
                        string name = Console.ReadLine();
                        Console.Write("Doctor specialty: ");
                        string speciality = Console.ReadLine();
                        Doctor d = new Doctor(did, name, speciality);
                        admin.addDoctor(doctors, d);
                        break;
                    case 2:
                        Console.Write("Doctor ID to remove: ");
                        string IDR = Console.ReadLine();
                        admin.removeDoctor(doctors, IDR);
                        break;
                    case 3:
                        admin.viewAllAppointments(appointments);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Admin Menu: " + ex.Message);
            }
        }

        static void Savetofile()
        {
            try
            {
                Console.Clear();
                List<string> doctorLines = new List<string>();
                foreach (Doctor d in doctors.Values)
                {
                    doctorLines.Add(d.GetDoctorId() + "," + d.Getname() + "," + d.Getspecialty());
                }
                File.WriteAllLines("doctors.txt", doctorLines.ToArray());

                List<string> patientLines = new List<string>();
                foreach (Patient p in patients)
                {
                    patientLines.Add(p.getPatientId() + "," + p.getpatientName() + "," + p.getpatientAge() + "," + p.getpatientIllness());
                }
                File.WriteAllLines("patients.txt", patientLines.ToArray());

                List<string> appointmentLines = new List<string>();
                foreach (Appointment a in appointments)
                {
                    appointmentLines.Add(a.getappointmentId() + "," + a.getpatientId() + "," + a.getdoctorId() + "," + a.getdate() + "," + a.getstatus());
                }
                File.WriteAllLines("appointments.txt", appointmentLines.ToArray());

                Console.WriteLine("================== Data saved to files ==================");
                Environment.Exit(0);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while saving to file: " + ex.Message);
            }
        }

        static void Main(string[] args)
        {
            try
            {
                if (!(File.Exists("doctors.txt"))) File.Create("doctors.txt").Close();
                if (!(File.Exists("patients.txt"))) File.Create("patients.txt").Close();
                if (!(File.Exists("appointments.txt"))) File.Create("appointments.txt").Close();

                bool running = true;
                while (running)
                {
                    Console.Clear();
                    Console.WriteLine("I am a :\n1-Patient\n2-Doctor\n3-Admin\n4-Exit");
                    Console.Write("Choose from 1 to 4 : ");

                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.WriteLine("Invalid input. Please enter a number from 1 to 4.");
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            Patientmenu();
                            break;
                        case 2:
                            Doctormenu();
                            break;
                        case 3:
                            Console.WriteLine("Enter username and password ");
                            string str = Console.ReadLine();
                            string pass = Console.ReadLine();

                            if (str == "admin" && pass == "1234")
                            {
                                Adminmenu();
                            }
                            else
                            {
                                Console.WriteLine("Username or password is incorrect");
                            }
                            break;
                        case 4:
                            Savetofile();
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Number inputted must be from 1 to 4");
                            break;
                    }

                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Critical Error: " + ex.Message);
            }
        }
    }
}