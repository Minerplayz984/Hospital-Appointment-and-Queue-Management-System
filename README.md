🏥 Hospital Appointment & Queue Management System

A simple C# console application to manage hospital operations such as patient registration, doctor management, appointment scheduling, and emergency queue handling.

✨ Features

👨‍⚕️ Doctor Management (Admin)

Add new doctors

Remove doctors

View all scheduled appointments

🧑‍🤝‍🧑 Patient Management

Register patient details (Name, Age, Illness)

Request appointments with doctors

Join emergency queue

📅 Appointments

Book and manage appointments with specific doctors

Emergency queue assignment handled by doctors

Appointment status: Booked, Done, or Cancelled

💾 Data Persistence

Doctors, Patients, and Appointments are saved in text files:

doctors.txt

patients.txt

appointments.txt

📂 Project Structure
Hospital_Appointment_and_Queue_Management_System/
│
├── Program.cs          # Main program with menus and flow
├── Patient.cs          # Patient class (registration & requests)
├── Doctor.cs           # Doctor class (appointments & emergencies)
├── Appointment.cs      # Appointment class (status handling)
├── Admin.cs            # Admin class (manage doctors & view all appointments)
│
├── doctors.txt         # Saved doctor data
├── patients.txt        # Saved patient data
├── appointments.txt    # Saved appointment data

🚀 How to Run

Clone the repository:

git clone https://github.com/your-username/Hospital-Appointment-and-Queue-Management-System.git
cd Hospital-Appointment-and-Queue-Management-System


Open the project in Visual Studio or VS Code with the C# extension.

Build and run the project:

dotnet run

🖥️ Usage

When you start the program, you’ll be asked who you are:

I am a :
1-Patient
2-Doctor
3-Admin
4-Exit
Choose from 1 to 4 :


Patient: Register → Request Appointment / Join Emergency Queue

Doctor: Login with Doctor ID → View Appointments / Take Emergency Patient

Admin: Login with username admin and password 1234 → Manage Doctors / View All Appointments

Exit: Saves all data to text files before closing

🔑 Default Credentials

Admin Username: admin

Admin Password: 1234

🛠️ Technologies

Language: C#

Framework: .NET (Console App)

Storage: Plain text files (.txt)
