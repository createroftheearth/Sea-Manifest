using BAL.Models;
using BAL.Utilities;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BAL.Services
{
    public class UserService
    {
        private static UserService instance = null;

        private UserService()
        {

        }

        public static UserService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserService();
                }
                return instance;
            }
        }

        public List<UserModel> GetUsers(int draw, int displayStart, int displayLength, out int recordsTotal)
        {
            using (var db= new SeaManifestEntities())
            {
                var data = db.tblUserMs.OrderBy(z => z.sUserName).Skip(displayStart).Take(displayLength).Select(z => new UserModel
                {
                    iUserId = z.iUserId,
                    sUsername = z.sUserName,
                    sEmailID = z.sEmailId,
                    sFirstName = z.sFirstName,
                    sLastName = z.sLastName,
                    sRoleName = z.tblRoleM.sRoleName,
                    sPhoneNo = z.sPhoneNumber
                }).ToList();
                recordsTotal = db.tblUserMs.Count();
                return data;
            }
        }

        public object GetRoles()
        {
            using (var db= new SeaManifestEntities())
            {
                return db.tblRoleMs.ToList().Select(z => new 
                {
                    Text = z.sRoleName,
                    Value = z.iRoleId.ToString()
                }).ToList();
            }
        }
        

        public UserModel GetUserById(int iUserId)
        {
            using (var db= new SeaManifestEntities())
            {
                return db.tblUserMs.Where(x => x.iUserId == iUserId).Select(z => new UserModel
                {
                    iUserId = z.iUserId,
                    sUsername = z.sUserName,
                    sEmailID = z.sEmailId,
                    sFirstName = z.sFirstName,
                    sLastName = z.sLastName,
                    sRoleName = z.tblRoleM.sRoleName,
                    sPhoneNo = z.sPhoneNumber,
                    sPassword = z.sPassword,
                    iRoleId = z.iRoleId,
                }).SingleOrDefault();
            }
        }


        public object SaveUser(UserModel model, int iUserId)
        {
            using (var db= new SeaManifestEntities())
            {
                var data = db.tblUserMs.Where(z => z.iUserId == model.iUserId).SingleOrDefault();
                if (data == null)
                {
                    if (db.tblUserMs.Any(z => z.sUserName == model.sUsername))
                    {
                        return new  { Status = false, Message = "User already exists" };
                    }
                    else
                    {
                        data = new tblUserM
                        {
                            sFirstName = model.sFirstName,
                            sLastName = model.sLastName,
                            sPassword = Crypto.Encrypt(model.sPassword),
                            iRoleId = model.iRoleId,
                            sPhoneNumber = model.sPhoneNo,
                            sUserName = model.sUsername,
                            sEmailId = model.sEmailID,
                        };
                        db.tblUserMs.Add(data);
                        db.SaveChanges();
                        return new  { Status = true, Message = "User saved successfully!" };
                    }
                }
                else
                {
                    if (db.tblUserMs.Any(z => z.sUserName == model.sUsername && z.iUserId != model.iUserId))
                    {
                        return new  { Status = false, Message = "User already exists" };
                    }
                    else
                    {
                        data.sFirstName = model.sFirstName;
                        data.sLastName = model.sLastName;
                        data.sPassword = Crypto.Encrypt(model.sPassword);
                        data.iRoleId = model.iRoleId;
                        data.sPhoneNumber = model.sPhoneNo;
                        data.sUserName = model.sUsername;
                        data.sEmailId = model.sEmailID;
                        db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        return new  { Status = true, Message = "User saved successfully!" };
                    }
                }
            }
        }


    }

}
