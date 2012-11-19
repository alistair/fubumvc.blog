using System.Security.Cryptography;
using System.Text;

namespace Blog.Core.Domain
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string EmailAddress { get; set; }
        private string _gravatarEmailAddress;
        public string GravatarEmailAddress
        {
            get { return _gravatarEmailAddress; }
            set
            {
                _gravatarEmailAddress = value;

                if (!string.IsNullOrEmpty(_gravatarEmailAddress))
                {
                    var hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(value));
                    var stringBuilder = new StringBuilder();

                    for (var i = 0; i < hash.Length; i++)
                    {
                        stringBuilder.Append(hash[i].ToString("x2"));
                    }

                    GravatarHash = stringBuilder.ToString();
                }
            }
        }

        public string GravatarHash { get; set; }

        public string Description { get; set; }
    }
}