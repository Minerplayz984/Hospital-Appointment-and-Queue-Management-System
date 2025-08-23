using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hospital_Appointment___Queue_Management_System
{
    internal class Appointment
    {
        private int appointmentId;
        private int patientId;
        private string doctorId;
        private DateTime date;
        private string status;

        //constructor
        public Appointment(int id, int pId, string dId, DateTime date)
        {
            appointmentId = id;
            patientId = pId;
            doctorId = dId;
            this.date = date;
            status = "Booked";
        }

        public int getappointmentId()
        {
            return appointmentId;
        }
        public int getpatientId()
        {
            return patientId;
        }
        public string getdoctorId()
        {
            return doctorId;
        }
        public DateTime getdate()
        {
            return date;
        }
        public string getstatus()
        {
            return status;
        }
        public void Confirm()
        {
            status = "Done";
        }
        public void Cancel()
        {
            status = "Cancelled";
        }
    }
}