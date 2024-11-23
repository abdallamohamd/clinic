using emp_system.Models;
using Microsoft.EntityFrameworkCore;

namespace emp_system.repositiry
{
    public class patientrepo : Ipatientrepo
    {
        private readonly appcontext appcontext;

        public patientrepo(appcontext appcontext)
        {
            this.appcontext = appcontext;
        }

        public void add(patient patient)
        {
            appcontext.patients.Add(patient);
        }

        public List<patient> all()
        {
            return appcontext.patients.ToList();
        }

        public void delete(int id)
        {
           patient patient =get(id);
            appcontext.patients.Remove(patient);
        }

        public patient get(int id)
        {
            return appcontext.patients.FirstOrDefault(x => x.Id == id);
        }

        public void save()
        {
            appcontext.SaveChanges();
        }
    }
}
