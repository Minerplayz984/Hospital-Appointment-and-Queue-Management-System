using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Hospital_Appointment_and_Queue_Management_System
{
    internal class Doctor
    {


        private string doctorId;
        private string doctorName;
        private string doctorSpecialty;
        private List<Appointment> appointments = new List<Appointment>();
        public Doctor(string Id, string name, string specialty)
        {
            doctorId = Id;
            doctorName = name;
            doctorSpecialty = specialty;
        }
        public string GetDoctorId()
        {
            return doctorId;
        }
        public string Getname()
        {
            return doctorName;
        }
        public string Getspecialty()
        {
            return doctorSpecialty;
        }
        public void AddAppointment(Appointment a)
        {
            appointments.Add(a);
        }
        public void ViewAppointments()
        {
            Console.WriteLine("Appointments for Dr.{0}", doctorName);
            foreach (var a in appointments)
            {
                Console.WriteLine("Apointment " + a.getappointmentId() + "-Patient " + a.getpatientId() + " on " + a.getdate() + " [" + a.getstatus() + "]");
            }
        }
        public void Takeemergencypatient(Queue<Patient> q, List<Appointment> allAppointments, ref int appointmentCounter)
        {
            if (q.Count > 0)
            {
                Patient p = q.Dequeue();
                Appointment a = new Appointment(++appointmentCounter, p.getPatientId(), doctorId, DateTime.Now);
                appointments.Add(a);
                allAppointments.Add(a);
                Console.WriteLine("Emergency patient {0} assigned to Dr.{1}", p.getpatientName(), doctorName);
            }
            else
            {
                Console.WriteLine("No patients in emergency queue");
            }
        }
        public string viewdoctorinfo()
        {
            return doctorId + "-" + doctorName + "-" + doctorSpecialty;
        }
    }
}