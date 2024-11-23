using emp_system.Models;

namespace emp_system.repositiry
{
    public interface Iappointmentrepo
    {
        public void add(appointment appointment);
        public void save();
        public List<appointment> all();
        public appointment get(int id);
        public void delete(int id);
    }
}
