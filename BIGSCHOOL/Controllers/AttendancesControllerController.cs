﻿using BIGSCHOOL.DTOs;
using BIGSCHOOL.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BIGSCHOOL.Controllers
{
    [Authorize]
    public class AttendancesControllerController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendancesControllerController()
        {
            _dbContext = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
                return BadRequest("The Attendance already axists!");
            var attendance = new Attendance
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = User.Identity.GetUserId()
            };

            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
