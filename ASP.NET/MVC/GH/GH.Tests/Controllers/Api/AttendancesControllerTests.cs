using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GH.WebUI.Controllers.Api;
using GH.WebUI.Core.Repositories;
using Moq;
using GH.WebUI.Core;
using GH.Tests.Extensions;
using GH.WebUI.Core.Dtos;
using FluentAssertions;
using System.Web.Http.Results;
using GH.WebUI.Core.Models;

namespace GH.Tests.Controllers.Api
{
    [TestClass]
    public class AttendancesControllerTests
    {
        private string _userId;
        private AttendancesController _controller;
        private Mock<IAttendanceRepository> _mockReposotory;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockReposotory = new Mock<IAttendanceRepository>();
            var mockUoW = new Mock<IUnitOfWork>();

            mockUoW.SetupGet(u => u.Attendances).Returns(_mockReposotory.Object);

            _controller = new AttendancesController(mockUoW.Object);

            _userId = "1";
            _controller.MockCurrentUser(_userId, "user1@domain.com");
        }

        [TestMethod]
        public void Attend_AddNewAttendance_ShouldReturnOk()
        {
            var attendance = new AttendanceDto { GigId = 1 };

            var result = _controller.Attend(attendance);

            result.Should().BeOfType<OkResult>();
        }

        [TestMethod]
        public void Attend_AttendanceAlreadyExists_ShouldReturnBadRequest()
        {
            var attendance = new Attendance();
            _mockReposotory.Setup(r => r.GetAttendance(_userId, 1)).Returns(attendance);
            var attendanceDto = new AttendanceDto { GigId = 1 };
           
            var result = _controller.Attend(attendanceDto);

            result.Should().BeOfType<BadRequestErrorMessageResult>();
        }

        [TestMethod]
        public void DeleteAttendance_NoAttendanceWthSuchIdExists_ShouldReturnNotFound()
        {
            var result = _controller.DeleteAttendance(1);

            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void DeleteAttendance_UserDeletesExistingAttendance_ShouldReturnOk()
        {
            var attendance = new Attendance();
            _mockReposotory.Setup(r => r.GetAttendance(_userId, 1)).Returns(attendance);

            var result = (OkNegotiatedContentResult<int>)_controller.DeleteAttendance(1);

            result.Content.Should().Be(1);
        }

    }
}
