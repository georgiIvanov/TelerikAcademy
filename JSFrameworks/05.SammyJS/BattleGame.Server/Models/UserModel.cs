using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BattleGame.Server.Models
{
    [DataContract]
    public class UserLoginModel
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "authCode")]
        public string AuthCode { get; set; }
    }


    [DataContract]
    public class UserRegisterModel : UserLoginModel
    {
        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }
    }

    [DataContract]
    public class UserModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }

        [DataMember(Name = "score")]
        public decimal Score { get; set; }
    }

    [DataContract]
    public class UserLoggedModel
    {
        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }

        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }
    }

    [DataContract(Name="User")]
    public class UserInGameModel
    {
        [DataMember(Name="nickname")]
        public string Nickname { get; set; }

        [DataMember(Name = "units")]
        public IEnumerable<UnitModel> Units { get; set; }
    }
}