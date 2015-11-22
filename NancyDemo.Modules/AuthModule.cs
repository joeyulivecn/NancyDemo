using Nancy;
using Nancy.Authentication.Token;
using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NancyDemo.Modules
{
    public class AuthModule : NancyModule
    {
        public AuthModule(ITokenizer tokenizer)
            : base("/auth")
        {
            Post["/"] = x =>
            {
                var userName = this.Request.Form.UserName;
                var password = this.Request.Form.Password;

                var userIdentity = new UserIdentity();

                var token = tokenizer.Tokenize(userIdentity, Context);

                return new
                {
                    Token = token
                };
            };

            Get["/validation"] = _ =>
            {
                this.RequiresAuthentication();
                return "Yay! You are authenticated!";
            };

            Get["/admin"] = _ =>
            {
                this.RequiresClaims(new[] { "admin" });
                return "Yay! You are authorized!";
            };
        }
    }

    public class UserIdentity : IUserIdentity
    {

        public IEnumerable<string> Claims
        {
            get { return new string[] { "admin" }; }
        }

        public string UserName
        {
            get { return "joe"; }
        }
    }
}
