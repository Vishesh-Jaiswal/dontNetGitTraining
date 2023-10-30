using ClinicModelLibrary;

namespace ClinicDALLibrary
{
    public class ProjectRepository : IRepository
    {
        Dictionary<int, Doctor> doctors = new Dictionary<int, Doctor>();

        /// <summary>
        /// Adds the given doctor to the dictionary 
        /// </summary>
        /// <param name="doctor">Doctor object that has to be added</param>
        /// <returns>The doctor that has been added</returns>
        public Doctor Add(Doctor doctor)
        {
            int id=GetNextID();
            try
            {
                doctor.Id = id;
                doctors.Add(doctor.Id, doctor);
                return doctor;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("The doctor Id already exists");
                Console.WriteLine(e.Message);
            }
            return null;
        }

        private int GetNextID()
        {
            if (doctors.Count == 0)
                return 1;
            int id = doctors.Keys.Max();
            return ++id;
        }

        /// <summary>
        /// Deletes the doctor from teh dictionary using the id as key
        /// </summary>
        /// <param name="id">The Id of the doctor to be removed</param>
        /// <returns>The removed doctor</returns>

        public Doctor Delete(int id)
        {
            var doctor = doctors[id];
            doctors.Remove(id);
            return doctor;
        }

        public List<Doctor> GetAll()
        {
            var doctorList = doctors.Values.ToList();
            return doctorList;
        }

        public Doctor GetById(int id)
        {
            if (doctors.ContainsKey(id))
                return doctors[id];
            return null;
        }

        public Doctor Update(Doctor doctor)
        {
            doctors[doctor.Id] = doctor;
            return doctors[doctor.Id];
        }
    }
}