using ClinicDALLibrary;
using ClinicModelLibrary;


namespace ClinicBLLibrary
{
    public class ClinicService : IClinicService
    {
        IRepository repository;

        public ClinicService()
        {
            repository = new ProjectRepository();
        }

        public Doctor AddDoctor(Doctor doctor)
        {
            var result = repository.Add(doctor);
            if (result != null)
                return result;
            throw new NotAddedException();
        }

        public Doctor Delete(int id)
        {
            var doctor = GetDoctor(id);
            if (doctor != null)
            {
                repository.Delete(id);
                return doctor;
            }
            throw new NoSuchDoctorException();
        }

        public Doctor GetDoctor(int id)
        {
            var result = repository.GetById(id);
            return result ?? throw new NoSuchDoctorException();

        }

        public List<Doctor> GetDoctor()
        {
            var doctors = repository.GetAll();
            if (doctors.Count != 0)
                return doctors;
            throw new NoDoctorsAvailableException();
        }

        public Doctor UpdateContactNumber(int id, long phnum)
        {
            var doctor =GetDoctor(id);
            if (doctor != null)
            {
                string numberString = doctor.DoctorNumber.ToString();
                int numberOfDigits = numberString.Length;
                if (numberOfDigits == 10)
                {
                    doctor.DoctorNumber = phnum;
                    var result=repository.Update(doctor);
                        return doctor;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }
            throw new NoSuchDoctorException();
        }
        public Doctor UpdateExperience(int id, int docexp)
        {
            var doctor = GetDoctor(id);
            if (doctor != null)
            {
                if (doctor.DoctorExperience > 0)
                {
                    doctor.DoctorExperience = docexp;
                    var result = repository.Update(doctor);
                    return doctor;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }
            throw new NoSuchDoctorException();
        }
    }
}