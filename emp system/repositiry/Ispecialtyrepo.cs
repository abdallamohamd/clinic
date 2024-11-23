using emp_system.Models;

namespace emp_system.repositiry
{
    public interface Ispecialtyrepo
    {
        public void add(specialty specialty);
        public void save();
        public List<specialty> all();
        public specialty get(int id);
        public void delete(int id);
    }
}
