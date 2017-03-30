﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GH.WebUI.Persistence.Repositories;
using System.Data.Entity;
using GH.WebUI.Core.Models;
using Moq;
using GH.WebUI.Persistence;
using GH.Tests.Extensions;
using FluentAssertions;
using System.Linq;
using System.Collections.Generic;

namespace GH.Tests.Persistence.Repositories
{
    [TestClass]
    public class NotificationRepositoryTests
    {
        private NotificationRepository _repository;
        private Mock<DbSet<UserNotification>> _mockNotifications;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockNotifications = new Mock<DbSet<UserNotification>>();

            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(c => c.UserNotifications).Returns(_mockNotifications.Object);

            _repository = new NotificationRepository(mockContext.Object);
        }

        [TestMethod]
        public void GetNewNotificationsFor_NotificationIsForADifferentUser_ShouldNotBeReturned()
        {
            var notification = Notification.GigCanceled(new Gig());
            var user = new ApplicationUser { Id = "1" };
            var userNotification = new UserNotification(user, notification);

            _mockNotifications.SetSource(new[] { userNotification });

            var notifications = _repository.GetNewNotificationsFor(user.Id + "-");

            notifications.Should().BeEmpty();
        }

        [TestMethod]
        public void GetNewNotificationsFor_NotificationIsRead_ShouldBeReturned()
        {
            var notification = Notification.GigCanceled(new Gig());
            var user = new ApplicationUser { Id = "1" };
            var userNotification = new UserNotification(user, notification);
            userNotification.Read();

            _mockNotifications.SetSource(new[] { userNotification });

            var notifications = _repository.GetNewNotificationsFor(user.Id);

            notifications.Should().BeEmpty();
        }

        //[TestMethod]
        //public void GetNewNotificationsFor_NewNotificationForTheGivenUser_ShouldBeReturned()
        //{
        //    var notification = Notification.GigCanceled(new Gig());
        //    var user = new ApplicationUser { Id = "1" };
        //    var userNotification = new UserNotification(user, notification);

        //    _mockNotifications.SetSource(new List<UserNotification> { userNotification });

        //    var notifications = _repository.GetNewNotificationsFor(user.Id);

        //    notifications.Should().HaveCount(1);
        //    notifications.First().Should().Be(notification);
        //}
    }
}
