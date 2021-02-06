using Microsoft.AspNetCore.Mvc;
using ZwajApp.API.Data;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ZwajApp.API.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

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
        [Authorize]
        [HttpGet("GetAllUsers")]
        public ActionResult GetAllUsers()
        {
           var Users =  _IRepositoryWrapper.User.FindAll().Include(a=>a.Photos);
           var usersforreturn = _mapper.Map<IEnumerable<UserForListDTO>>(Users);
           return Ok(usersforreturn);
        }
        [Authorize]
        [HttpGet("GetByID/{id}")]
        public ActionResult GetByID(int id)
        {
           var User =  _IRepositoryWrapper.User.FindByCondition(x=>x.Id == id).Include(a=>a.Photos).FirstOrDefault();
           var userforreturn = _mapper.Map<UserForDetailsDTO>(User);
           return Ok(userforreturn);
        }

        [Authorize]
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id , UserForUpdateDTo userForUpdateDTo)
        {
            var UserFromRepos = _IRepositoryWrapper.User.GetByID(id);
            _mapper.Map(userForUpdateDTo , UserFromRepos);
            _IRepositoryWrapper.User.Update(UserFromRepos);
            _IRepositoryWrapper.Save();
            return NoContent();
        }
    }
    }