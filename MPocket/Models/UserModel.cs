using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using EntityDatabase.Models;
using EntityDatabase.Repository.Operation;
using EntityDatabase.Context;
using MPocketCommon.Cryptography;

namespace MPocket.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Login is required")]
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }

        public User Get(UserModel model)
        {
            User usermodel = new User();

            using (var c = new EntityContext())
            {                
                UsersOperation operation = new UsersOperation();
                usermodel = operation.GetByLogin(model.Login, c);
            }
               
            return usermodel;
        }

        public void Register(UserModel model)
        {
            ICommandPassword password = new PasswordGenerator();
            User user = AutoMapper.Mapper.Map<UserModel, User>(model);
            user.CreationDate = DateTime.Now;
            user.Password = password.Generate();

            using (var c = new EntityContext())
            {
                UsersOperation operation = new UsersOperation();
                operation.Add(user, c);
            }
        }

        public void UpdateUser(User model)
        {
            using (var c = new EntityContext())
            {
                UsersOperation operation = new UsersOperation();
                operation.Update(model, c);
            }
        }
    }
}