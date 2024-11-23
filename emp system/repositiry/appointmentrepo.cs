using emp_system.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace emp_system.repositiry
{
    public class appointmentrepo : Iappointmentrepo
    {
        private readonly appcontext appcontext;

        public appointmentrepo( appcontext appcontext)
        {
            this.appcontext = appcontext;
        }

        public void add(appointment appointment)
        {
            appcontext.appointments.Add(appointment);
        }

        public List<appointment> all()
        {
           return appcontext.appointments.Include(x=>x.specialtys).OrderByDescending(x=>x.appointmentdate).ToList();
        }

        public void delete(int id)
        {
           appointment appointment= get(id);
            appcontext.appointments.Remove(appointment);
        }

        public appointment get(int id)
        {
           return  appcontext.appointments.FirstOrDefault(x => x.Id == id);
        }

        public void save()
        {
            appcontext.SaveChanges();
        }
    }
}
