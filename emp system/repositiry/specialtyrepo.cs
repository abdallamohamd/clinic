using emp_system.Models;

namespace emp_system.repositiry
{
    public class specialtyrepo : Ispecialtyrepo
    {
        private readonly appcontext appcontext;

        public specialtyrepo(appcontext appcontext)
        {
            this.appcontext = appcontext;
        }

        public void add(specialty specialty)
        {
            appcontext.specialties.Add(specialty);
        }

        public List<specialty> all()
        {
            return appcontext.specialties.ToList(); 
        }

        public void delete(int id)
        {
            specialty specialty =get(id);
            appcontext.specialties.Remove(specialty);
        }

        public specialty get(int id)
        {
            return appcontext.specialties.FirstOrDefault(x => x.specialtyid == id);
        }

        public void save()
        {
            appcontext.SaveChanges();
        }
    }
}
