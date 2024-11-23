using emp_system.Models;

namespace emp_system.repositiry
{
    public interface Idoctorrepo
    {
        public void add(doctor doctor);
        public void save();
        public List<doctor> all();
        public doctor get(int id);
        public void delete(int id);
    }
}
