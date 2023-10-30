using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp
{
    internal class DoctorData
    {
        List<Doctors> doctors;

        public DoctorData() {
            doctors = new List<Doctors>();
        }

        int GetNewId()
        {
            if (doctors.Count == 0)
                return 1;
            int id = doctors[doctors.Count-1].Id;
            return ++id;
        }

        void TakeDoctorDetails(Doctors doctor)
        {
            Console.WriteLine("Please enter doctor's name");
            doctor.Name = Console.ReadLine();
            thispoint:
            Console.WriteLine("Please enter doctor's phone no.");
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
        }

        public Doctors Add()
        {
            int id = GetNewId();
            Doctors doctor = new Doctors();
            doctor.Id = id;
            TakeDoctorDetails(doctor);
            doctors.Add(doctor);
            return doctor;
        }

        public List<Doctors> GetDoctors()
        {
            return doctors;
        }

        public Doctors GetDoctorById(int id)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Id == id)
                    return doctors[i];
            }
            return null;
        }
        public Doctors UpdateNUm(int id, Doctors doctor, string choice)
        {
            Doctors clinicDoctor = GetDoctorById(id);
            if (clinicDoctor != null)
            {
                string numberString = doctor.DoctorNumber.ToString();
                int numberOfDigits = numberString.Length;
                if (choice == "num")
                {
                    if (numberOfDigits ==10)
                    {
                        clinicDoctor.DoctorNumber = doctor.DoctorNumber;
                        return clinicDoctor;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }

            }
            Console.WriteLine("Could not update");
            return null;
        }

        public Doctors UpdateExp(int id, Doctors doctor, string choice)
        {
            Doctors clinicDoctor = GetDoctorById(id);
            if (clinicDoctor != null)
            {

                if (choice == "exp")
                {
                    if (doctor.DoctorExperience > 0)
                    {
                        clinicDoctor.DoctorExperience = doctor.DoctorExperience;
                        return clinicDoctor;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }
            Console.WriteLine("Could not update");
            return null;
        }
        public Doctors Delete(int id)
        {
            Doctors clinicDoctor = GetDoctorById(id);
            if (clinicDoctor != null)
            {
                doctors.Remove(clinicDoctor);
                return clinicDoctor;
            }
            return null;

        }

    }
}