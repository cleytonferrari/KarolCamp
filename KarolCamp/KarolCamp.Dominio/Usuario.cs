﻿using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace KarolCamp.Dominio
{
    public class Usuario : Entidade, IUser 
    {
        public virtual string UserName { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
        public virtual List<string> Roles { get; private set; }
        public virtual List<IdentityUserClaim> Claims { get; private set; }
        public virtual List<UserLoginInfo> Logins { get; private set; }

        public Usuario()
        {
            this.Claims = new List<IdentityUserClaim>();
            this.Roles = new List<string>();
            this.Logins = new List<UserLoginInfo>();
        }

        public Usuario(string userName)
            : this()
        {
            this.UserName = userName;
        }
    }

    public class IdentityUserClaim : Entidade
    {
        public virtual string UserId { get; set; }
        public virtual string ClaimType { get; set; }
        public virtual string ClaimValue { get; set; }
    }
}
