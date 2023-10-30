using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp
{
    internal class Doctors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long DoctorNumber { get; set; }
        public string DoctorSpeciality { get; set; }
        public int DoctorExperience { get; set; }

        public Doctors() { 
            DoctorNumber = 0;
            DoctorExperience = 0;
        }
        public Doctors(int id, string name, long doctorNumber, string doctorSpeciality, int doctorExperience)
        {
            Id = id;
            Name = name;
            DoctorNumber = doctorNumber;
            DoctorSpeciality = doctorSpeciality;
            DoctorExperience = doctorExperience;
        }

        public override string ToString()
        {
            return $"Doctor Id : {Id}\nDoctor Name : {Name}\nDoctor's Phone No.: {DoctorNumber}\nDoctor's Speciality : {DoctorSpeciality}" +
                $"\nDoctor's Experience : {DoctorExperience}";
        }
    }
}
