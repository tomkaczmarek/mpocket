using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using EntityDatabase.Models;
using EntityDatabase.Repository.Operation;
using EntityDatabase.Context;
using MPocketCommon.Cryptography;
using MPocketCommon.Helpers;
using MPocketCommon.Comunication;

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
        public string ConfirmPassword { get; set; }

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
            if(model.Password == model.ConfirmPassword)
            {
                ICommandPassword password = new PasswordGenerator();
                User user = AutoMapper.Mapper.Map<UserModel, User>(model);
                user.CreationDate = DateTime.Now;

                using (var c = new EntityContext())
                {
                    UsersOperation operation = new UsersOperation();
                    ICryptography crypto = new PasswordManager();
                    user.Password = crypto.Encrypt(model.Password);
                    operation.Add(user, c);
                }
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

        public User GetById(int id)
        {
            User user;
            using (var c = new EntityContext())
            {
               UsersOperation operation = new UsersOperation();
               user = operation.Get(id, c);
            }
            return user;
        }

        private Mail GenerateRegisterMessage(User user)
        {
            Mail m = new Mail();
            m.To = user.Login;
            m.From = user.Name;
            m.Subject = PageConstant.MESSAGE_SUBJECT;
            m.Body = string.Format("{0}{1}{2}{1}{3}", PageConstant.MESSAGE_BODY, Environment.NewLine, user.Login, user.Password);
            return m;
        }
    }
}