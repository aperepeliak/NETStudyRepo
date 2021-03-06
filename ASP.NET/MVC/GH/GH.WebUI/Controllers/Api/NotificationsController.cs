﻿using AutoMapper;
using GH.WebUI.Core.Dtos;
using GH.WebUI.Core.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using GH.WebUI.Core;
using WebGrease.Css.Extensions;

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
            var notifications = _unitOfWork.Notifications
                .GetNewNotificationsFor(User.Identity.GetUserId());

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var notifications = _unitOfWork.UserNotifications
                .GetUserNotificationsFor(User.Identity.GetUserId());

            notifications.ForEach(n => n.Read());
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
