using System.Collections.Generic;
using GH.WebUI.Core.Models;

namespace GH.WebUI.Core.Repositories
{
    public interface IAttendanceRepository
    {
        Attendance GetAttendance(string userId, int gigId);
        IEnumerable<Attendance> GetFutureAttendances(string userId);
        void Add(Attendance attendance);
        void Remove(Attendance attendance);
    }
}