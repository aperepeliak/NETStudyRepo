using AutoMapper;
using GH.WebUI.Core.Dtos;
using GH.WebUI.Core.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GH.WebUI.Persistence;
using GH.WebUI.Core;

namespace GH.WebUI.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public NotificationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {

            var notifications = _unitOfWork.UserNotifications
                    .GetNewNotifications(User.Identity.GetUserId());

            //var notifications = _context.UserNotifications
            //        .Where(un => un.UserId == userId && !un.IsRead)
            //        .Select(un => un.Notification)
            //        .Include(n => n.Gig.Artist)
            //        .ToList();

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);                    
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                        .Where(un => un.UserId == userId && !un.IsRead)
                        .ToList();

            notifications.ForEach(n => n.Read());

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
