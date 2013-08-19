using Forum.DataLayer;
using Forum.Models;
using Forum.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Forum.Services.Controllers
{
    public class UsersController : BaseApiController
    {
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;
        private const string ValidUsernameCharacters = "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_.";
        private const string ValidNicknameCharacters = "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_. -";

        private const string SessionKeyChars = "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";

        private static readonly Random rng = new Random();

        private const int SessionKeyLength = 50;

        private const int Sha1Length = 40;

        public UsersController()
        {

        }

        /*
        {  "username": "DonchoMinkov",
           "nickname": "Doncho Minkov",
           "authCode":   "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e" }
        */

        [ActionName("register")]
        [HttpPost]
        public HttpResponseMessage PostRegisterUser(UserModel model)
        {
            var responceMsg = this.PerformOperationAndHandleExceptions(() =>
                {

                    var context = new ForumDbContext();
                    using (context)
                    {
                        this.ValidateUsername(model.Username);
                        this.ValidateNickname(model.Nickname);
                        this.ValidateAuthCode(model.AuthCode);

                        var usernameToLower = model.Username.ToLower();
                        var nicknameToLower = model.Nickname.ToLower();

                        var user = context.Users.FirstOrDefault(usr =>
        usr.Username == usernameToLower || usr.Nickname.ToLower() == nicknameToLower);

                        if (user != null)
                        {
                            throw new InvalidOperationException("User Exists");
                        }

                        user = new User()
                        {
                            Username = usernameToLower,
                            Nickname = model.Nickname,
                            AuthCode = model.AuthCode
                        };

                        context.Users.Add(user);
                        context.SaveChanges();

                        user.SessionKey = this.GenerateSessionKey(user.Id);
                        context.SaveChanges();

                        var loggedModel = new LoggedUserModel()
                        {
                            SessionKey = user.SessionKey,
                            Nickname = user.Nickname
                        };

                        var responce = this.Request.CreateResponse(HttpStatusCode.Created, loggedModel);

                        return responce;

                    }
                });

            return responceMsg;
        }

        [ActionName("login")]
        [HttpPost]
        public HttpResponseMessage PostLoginUser(UserModel model)
        {
            var responceMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new ForumDbContext();
                using (context)
                {
                    this.ValidateUsername(model.Username);
                    this.ValidateAuthCode(model.AuthCode);

                    var usernameToLower = model.Username.ToLower();
                    var authCode = model.AuthCode;

                    var user = context.Users.FirstOrDefault(usr =>
    usr.Username == usernameToLower && usr.AuthCode == authCode);


                    if (user == null)
                    {
                        throw new InvalidOperationException("Ivalid username or password");
                    }

                    if (user.SessionKey == null)
                    {
                        user.SessionKey = this.GenerateSessionKey(user.Id);
                        context.SaveChanges();
                    }

                    var loggedModel = new LoggedUserModel()
                    {
                        SessionKey = user.SessionKey,
                        Nickname = user.Nickname
                    };

                    var responce = this.Request.CreateResponse(HttpStatusCode.OK, loggedModel);

                    return responce;

                }
            });

            return responceMsg;
        }

        [ActionName("logout")]
        [HttpPut]
        public HttpResponseMessage PutLogoutUser(LoggedUserModel model)
        {
            var responceMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new ForumDbContext();
                using (context)
                {
                    var sessionKey = model.SessionKey;

                    var user = context.Users.FirstOrDefault(usr =>
    usr.SessionKey == sessionKey);


                    if (user == null)
                    {
                        throw new InvalidOperationException("Something went terribly wrong");
                    }


                    user.SessionKey = null;
                    context.SaveChanges();
                    
                    var responce = this.Request.CreateResponse(HttpStatusCode.NoContent);

                    return responce;

                }
            });

            return responceMsg;
        }

        // GET api/users
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/users/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/users
        public void Post([FromBody]string value)
        {
        }

        // PUT api/users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/users/5
        public void Delete(int id)
        {
        }

        private void ValidateUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null");
            }
            else if (username.Length < MinUsernameLength)
            {
                throw new ArgumentOutOfRangeException(string.Format("Username must be at least {0} characters long",
                    MinUsernameLength));
            }
            else if (username.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be less than {0} characters long",
                    MaxUsernameLength));
            }
            else if (username.Any(ch => !ValidUsernameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Username must contain only Latin letters, digits .,_");
            }
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null || authCode.Length != Sha1Length)
            {
                throw new ArgumentOutOfRangeException("Password should be encrypted");
            }
        }

        private void ValidateNickname(string nickname)
        {
            if (nickname == null)
            {
                throw new ArgumentNullException("Nickname cannot be null");
            }
            else if (nickname.Length < 2)
            {
                throw new ArgumentOutOfRangeException(string.Format("Nickname must be at least {0} characters long",
                    2));
            }
            else if (nickname.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Nickname must be less than {0} characters long",
                    MaxUsernameLength));
            }
            else if (nickname.Any(ch => !ValidNicknameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Nickname must contain only Latin letters, digits .,_ or space");
            }
        }

        private string GenerateSessionKey(int userId)
        {
            StringBuilder skeyBuilder = new StringBuilder(SessionKeyLength);
            skeyBuilder.Append(userId);
            while (skeyBuilder.Length < SessionKeyLength)
            {
                var index = rng.Next(SessionKeyChars.Length);
                skeyBuilder.Append(SessionKeyChars[index]);
            }
            return skeyBuilder.ToString();
        }
    }
}
