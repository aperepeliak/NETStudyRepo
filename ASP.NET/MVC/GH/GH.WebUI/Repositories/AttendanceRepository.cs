﻿using GH.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GH.WebUI.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private ApplicationDbContext _context;
        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.Attendances
                   .Where(a => a.AttendeeId == userId && a.Gig.DateTime > DateTime.Now)
                   .ToList();
        }

        public Attendance GetAttendance(string userId, int gigId)
        {
            return _context.Attendances
                   .SingleOrDefault(a => a.GigId == gigId && a.AttendeeId == userId);
        }
    }
}