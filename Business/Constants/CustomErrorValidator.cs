using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class CustomErrorValidator:IdentityErrorDescriber
    {
        public IdentityError InvalidUserNameOrPasswordMismatch()
        {
            return new IdentityError() { Code = nameof(InvalidUserName), Description = "Kullanıcı adı veya şifre doğru değil." };
        }

        public IdentityError AuthorizationError()
        {
            return new IdentityError
            {
                Code = (nameof(AuthorizationError)),
                Description = "Yetkilendirme Hatası"
            };

        }
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateEmail),
                Description = $"{email} mail adresi bulunmakta."
            };
        }
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresDigit),
                Description = "Şifreler en az bir rakamdan oluşmalıdır (0-9)."
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = "Şifrelerde en az bir alfasayısal olmayan karakter bulunmalıdır. (A-Z)"
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError { Code = nameof(PasswordTooShort), Description = $"Şifre en az {length} karakter uzunluğunda olmalıdır." };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError() { Code = nameof(PasswordRequiresUpper), Description = "Şifrelerde en az bir büyük harf (A-Z) bulunmalıdır." };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError() { Code = nameof(PasswordRequiresLower), Description = "Şifrelerde en az bir küçük harf (a-z) bulunmalıdır." };
        }

        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
        {
            return new IdentityError() { Code = nameof(PasswordRequiresUniqueChars), Description = "Şifrelerde en az 1 özel karakter kullanılmalıdır. 'Örnek : #$&/'" };
        }
    }
}
