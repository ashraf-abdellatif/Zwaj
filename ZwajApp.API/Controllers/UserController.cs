using Microsoft.AspNetCore.Mvc;
using ZwajApp.API.Data;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ZwajApp.API.DTOs;
using System.Collections.Generic;

namespace ZwajApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        IRepositoryWrapper _IRepositoryWrapper;
        private IMapper _mapper;

        public UserController(IRepositoryWrapper IRepositoryWrapper , IMapper mapper)
        {
            _IRepositoryWrapper = IRepositoryWrapper;
            _mapper = mapper;
        }
        [HttpGet("GetAllUsers")]
        public ActionResult GetAllUsers()
        {
           var Users =  _IRepositoryWrapper.User.FindAll().Include(a=>a.Photos);
           var usersforreturn = _mapper.Map<IEnumerable<UserForListDTO>>(Users);
           return Ok(usersforreturn);
        }
        [HttpGet("GetByID/{id}")]
        public ActionResult GetByID(int id)
        {
           var User =  _IRepositoryWrapper.User.GetByID(id);
           var userforreturn = _mapper.Map<UserForDetailsDTO>(User);
           return Ok(userforreturn);
        }
        }
}