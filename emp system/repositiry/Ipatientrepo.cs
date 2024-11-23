using emp_system.Models;

namespace emp_system.repositiry
{
    public interface Ipatientrepo
    {
        public void add(patient patient);
        public void save();
        public List<patient> all();
        public patient get(int id);
        public void delete(int id);
    }
}
