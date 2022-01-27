using Application.Abstract;
using Application.ModelOperations.UserModelOperations;
using Application.ValidationRules;
using Application.ValidationRules.UserValidationRules;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers() //Tüm kullanıcıların getirildi
        {
            GetUsers getUsers = new GetUsers(_userService, _mapper); 
            var result = await getUsers.Handle(); //Map'leme işlemi yapıldı

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id) //Id'ye göre kullanıcılar getirildi
        {
            GetUserById getUser = new GetUserById(_userService, _mapper);
            GetUserByIdValidator validator = new GetUserByIdValidator();
            getUser.Id = id;

            await validator.ValidateAndThrowAsync(getUser);//Validasyon işlemi yapıldı
            var result = await getUser.Handle();//Map'leme işlemi yapıldı

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] CreateUserModel user)//Yeni kullanıcı ekleme
        {
            AddUser addUser = new AddUser(_userService, _mapper);
            AddUserValidator validator = new AddUserValidator();
            addUser.createUserModel = user;

            await validator.ValidateAndThrowAsync(user);//Validasyon işlemi yapıldı
            await addUser.Handle();//Map'leme işlemi yapıldı

            return Ok("User added.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserViewModel user)//Kullanıcı güncelleme
        {
            UpdateUser updateUser = new UpdateUser(_userService);
            UpdateUserValidator validator = new UpdateUserValidator();
            updateUser.user = user;
            updateUser.Id = id;

            await validator.ValidateAndThrowAsync(updateUser);//Validasyon işlemi yapıldı
            await updateUser.Handle();//Map'leme işlemi yapıldı

            return Ok("User updated.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int Id)//Kullanıcı silme
        {
            DeleteUser deleteUser = new DeleteUser(_userService);
            DeleteUserValidator validator = new DeleteUserValidator();
            deleteUser.Id = Id;

            await validator.ValidateAndThrowAsync(deleteUser);//Validasyon işlemi yapıldı
            await deleteUser.Handle();//Map'leme işlemi yapıldı

            return Ok("User deleted.");
        }
    }
}
