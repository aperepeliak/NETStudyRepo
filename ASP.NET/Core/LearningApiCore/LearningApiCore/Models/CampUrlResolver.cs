﻿using AutoMapper;
using LearningApiCore.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCodeCamp.Data.Entities;

namespace LearningApiCore.Models
{
    public class CampUrlResolver : IValueResolver<Camp, CampModel, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CampUrlResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Resolve(Camp source,
                              CampModel destination,
                              string destMember,
                              ResolutionContext context)
        {
            var url = (IUrlHelper)_httpContextAccessor.HttpContext.Items[BaseController.URLHELPER];
            return url.Link("CampGet", new { id = source.Id });
        }
    }
}
