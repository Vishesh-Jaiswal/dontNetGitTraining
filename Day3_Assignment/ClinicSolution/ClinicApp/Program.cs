using ClinicBLLibrary;
using ClinicModelLibrary;

namespace ClinicApp
{
    internal class Program
    {
        IClinicService clinicService;

        public Program()
        {
            clinicService = new ClinicService();
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
                        AddDoctor();
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

        void AddDoctor()
        {
            try
            {
                Doctor doctor = TakeDoctorDetails();
                var result = clinicService.AddDoctor(doctor);
                if (result != null)
                {
                    Console.WriteLine("Doctor Added");
                }
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(NotAddedException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        Doctor TakeDoctorDetails()
        {
            Doctor doctor= new Doctor();
            Console.WriteLine("Please enter doctor's name");
            doctor.Name = Console.ReadLine();
            thispoint:
            Console.WriteLine("Please enter doctor's phone no.(10 digits)");
            doctor.DoctorNumber = Convert.ToInt64(Console.ReadLine());
            string numberString = doctor.DoctorNumber.ToString();
            int numberOfDigits = numberString.Length;
            if (numberOfDigits != 10)
            {
                Console.WriteLine("Please enter a valid number");
                goto thispoint;
            }
            Console.WriteLine("Please enter doctor's speciality");
            doctor.DoctorSpeciality = Console.ReadLine();
            Console.WriteLine("Please enter doctor's experience in years");
            doctor.DoctorExperience = Convert.ToInt32(Console.ReadLine());
            return doctor;
        }

        int GetDoctorIdFromUser()
        {
            int id;
            Console.WriteLine("Please enter the doctor id");
            id = Convert.ToInt32(Console.ReadLine());
            return id;
        }

        private void DoctorPhoneUpdate()
        {
            var id = GetDoctorIdFromUser();
            Console.WriteLine("Please enter the new phone number");
            long doctorNumber = Convert.ToInt64(Console.ReadLine());
            Doctor doctor = new Doctor();
            doctor.DoctorNumber = doctorNumber;
            doctor.Id = id;
            try
            {
                var result = clinicService.UpdateContactNumber(id, doctorNumber);
                if (result != null)
                    Console.WriteLine("Updation Complete");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void DoctorExperienceUpdate()
        {
            var id = GetDoctorIdFromUser();
            Console.WriteLine("Please enter the doctor's new experience in years");
            int doctorExperience = Convert.ToInt32(Console.ReadLine());
            Doctor doctor = new Doctor();
            doctor.DoctorExperience = doctorExperience;
            doctor.Id = id;
            try
            {
                var result = clinicService.UpdateExperience(id, doctorExperience);
                if (result != null)
                    Console.WriteLine("Updation Complete");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ShowAllDoctors()
        {
            Console.WriteLine("***********************************");
            var doctors = clinicService.GetDoctor();
            foreach (var item in doctors)
            {
                Console.WriteLine(item);
                Console.WriteLine("-------------------------------");
            }
            Console.WriteLine("***********************************");
        }

        private void RemoveDoctor()
        {
            try
            {
                int id = GetDoctorIdFromUser();
                if (clinicService.Delete(id) != null)
                    Console.WriteLine("Doctor Remove");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }
 
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To The Nirvana Clinic");
            Program home = new Program();
            home.StartAdminActivities();
        }
    }
}