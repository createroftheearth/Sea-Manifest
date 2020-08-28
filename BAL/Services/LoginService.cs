using BAL.Models;
using BAL.Utilities;
using DAL;
using System.Linq;

namespace BAL.Services
{
    public class LoginService
    {
        private static LoginService instance = null;

        private LoginService()
        {
        }

        public static LoginService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginService();
                }
                return instance;
            }
        }

        public UserModel ValidateUser(LoginModel model)
        {
            using (var db= new SeaManifestEntities())
            {
                model.Password = Crypto.Encrypt(model.Password);
                if (db.tblUserMs.Any(x => x.sUserName == model.Username && x.sPassword == model.Password))
                {
                    return db.tblUserMs.Where(x => x.sUserName == model.Username).Select(x => new UserModel
                    {
                        iRoleId = x.iRoleId ,
                        iUserId = x.iUserId,
                        sEmailID = x.sEmailId,
                        sFirstName = x.sFirstName,
                        sLastName = x.sLastName,
                        sPassword = x.sPassword,
                        sRoleName = x.tblRoleM.sRoleName,
                        sUsername = x.sUserName,
                    }).SingleOrDefault();
                }
                else
                    return null;
            }
        }

        public bool ValidateUsername(string Username)
        {
            using (var db= new SeaManifestEntities())
            {
                return db.tblUserMs.Any(x => x.sUserName == Username);
            }
        }
    }

}
