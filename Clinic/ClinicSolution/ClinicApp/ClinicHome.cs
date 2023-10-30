namespace ClinicApp
{
    internal class ClinicHome
    {
        DoctorData doctorData;

        public ClinicHome()
        {
            doctorData = new DoctorData();
        }
        void DisplayAdminMenu()
        {
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. Modify Doctor's Phone No.");
            Console.WriteLine("3. Modify Doctor's Experiece");
            Console.WriteLine("4. Show all doctors");
            Console.WriteLine("5. Delete Doctor Profile");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Enter Your Choice:");
        }

        void StartAdminActivities()
        {
            int choice;
            do
            {
                DisplayAdminMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Get Well Soon");
                        break;
                    case 1:
                        doctorData.Add();
                        break;
                    case 2:
                        DoctorPhoneUpdate();
                        break;
                    case 3:
                        DoctorExperienceUpdate();
                        break;
                    case 4:
                        ShowAllDoctors();
                        break;
                    case 5: 
                        RemoveDoctor();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }

        private void DoctorPhoneUpdate()
        {
            var id = GetDoctorIdFromUser();
            Console.WriteLine("Please enter the new phone number");
            long doctorNumber = Convert.ToInt64(Console.ReadLine());
            Doctors doctor = new Doctors();
            doctor.DoctorNumber = doctorNumber;
            doctor.Id = id;
            var result = doctorData.UpdateNUm(id, doctor, "num");
            if (result != null)
                Console.WriteLine("Updation Complete");
        }

        private void DoctorExperienceUpdate()
        {
            var id = GetDoctorIdFromUser();
            Console.WriteLine("Please enter the doctor's new experience in years");
            int doctorExperience = Convert.ToInt32(Console.ReadLine());
            Doctors doctor = new Doctors();
            doctor.DoctorExperience = doctorExperience;
            doctor.Id = id;
            var result = doctorData.UpdateExp(id, doctor, "exp");
            if (result != null)
                Console.WriteLine("Updation Complete");
        }

        private void ShowAllDoctors()
        {
            Console.WriteLine("***********************************");
            var doctors = doctorData.GetDoctors();
            foreach (var item in doctors)
            {
                Console.WriteLine(item);
                Console.WriteLine("-------------------------------");
            }
            Console.WriteLine("***********************************");
        }

        private void RemoveDoctor()
        {
            int id = GetDoctorIdFromUser();
            if (doctorData.Delete(id) != null)
                Console.WriteLine("Doctor deleted");
        }
        int GetDoctorIdFromUser()
        {
            int id;
            Console.WriteLine("Please enter the doctor id");
            id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To The Nirvana Clinic");
            ClinicHome home = new ClinicHome();
            home.StartAdminActivities();
        }
    }
}