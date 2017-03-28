using System.Collections.Generic;
using GH.WebUI.Models;

namespace GH.WebUI.Repositories
{
    public interface IAttendanceRepository
    {
        Attendance GetAttendance(string userId, int gigId);
        IEnumerable<Attendance> GetFutureAttendances(string userId);
    }
}