using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class LoginErrorMessages
    {
        public static string WRONG_NICK_OR_PASSWORD => "Kullanıcı Adınız veya Şifreniz Hatalı";
        public static string EMPTY_NICK_OR_PASSWORD => "Kullanıcı Adınız veya Şifreniz Boş Olamaz";
    }

    public static class RegisterErrorMessages
    {
        public static string PASSWORD_6_CHARACTERS=> "Şifre en az 6 karakter olmalıdır.";
        public static string PASSWORD_ALPHANUMERIC => "Şifrelerde en az bir alfasayısal olmayan karakter bulunmalıdır.";
        public static string PASSWORD_ONE_DIGIT => "Şifreler en az bir rakamdan oluşmalıdır ('0'-'9').";
        public static string PASSWORD_ONE_LOWERCASE => "Şifrelerde en az bir küçük harf ('a'-'z') bulunmalıdır.";
        public static string PASSWORD_ONE_UPPERCASE => "Şifrelerde en az bir küçük harf ('a'-'z') bulunmalıdır.";
        public static string PASSWORD_DIFFERENT_CHARACTERS => "Şifrelerde en az 1 farklı karakter kullanılmalıdır.";
    }
}
