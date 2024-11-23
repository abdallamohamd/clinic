using emp_system.Models;
using Microsoft.EntityFrameworkCore;

namespace emp_system.repositiry
{
    public class doctorrepo : Idoctorrepo
    {
        private readonly appcontext appcontext;

        public doctorrepo(appcontext appcontext)
        {
            this.appcontext = appcontext;
        }

        public void add(doctor doctor)
        {
            appcontext.doctors.Add(doctor);
        }

        public List<doctor> all()
        {
            return appcontext.doctors.Include(x=>x.specialty).ToList();
        }

        public void delete(int id)
        {
            doctor doctor=get(id);
            appcontext.Remove(doctor);
        }

        public doctor get(int id)
        {
            return appcontext.doctors.FirstOrDefault(x => x.DoctorId==id);
        }

        public void save()
        {
            appcontext.SaveChanges();
        }
    }
}
