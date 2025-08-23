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