namespace ClinicModelLibrary
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }=String.Empty;
        public long DoctorNumber { get; set; }
        public string DoctorSpeciality { get; set; } = String.Empty;
        public int DoctorExperience { get; set; }
        public Doctor()
        {
            DoctorNumber = 0;
            DoctorExperience = 0;
        }

        /// <summary>
        /// Construct essential object properties
        /// </summary>
        /// <param name="id">ID of the doctor</param>
        /// <param name="name">name of the doctor</param>
        /// <param name="doctorNumber">Doctor's moblie number</param>
        /// <param name="doctorSpeciality">Doctor's speciality</param>
        /// <param name="doctorExperience">Doctor's experience in years</param>
        public Doctor(int id, string name, long doctorNumber, string doctorSpeciality, int doctorExperience)
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