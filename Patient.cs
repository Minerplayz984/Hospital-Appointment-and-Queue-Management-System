using Hospital_Appointment_and_Queue_Management_System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Appointment_and_Queue_Management_System
{
    internal class Patient
    {
        private int patientId;
        private string patientName;
        private int patientAge;
        private string patientIllness;
        //constructor
        public Patient(int id, string name, int age, string illness)
        {
            patientId = id;
            patientName = name;
            patientAge = age;
            patientIllness = illness;
        }
        //get variables
        public int getPatientId()
        {
            return patientId;
        }
        public string getpatientName()
        {
            return patientName;
        }
        public int getpatientAge()
        {
            return patientAge;
        }
        public string getpatientIllness()
        {
            return patientIllness;
        }
        public Appointment requestAppointment(Doctor d, DateTime date, int appointmentID)
        {
            Appointment a = new Appointment(appointmentID, patientId, d.GetDoctorId(), date);
            d.AddAppointment(a);
            return a;
        }
        public void cancelAppointment(Appointment a)
        {
            a.Cancel();
        }
    }
}