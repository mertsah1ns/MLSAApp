using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class ErrorMessages
    {
        public static string NO_CONTENT => "İçerik Bulunmadı.";
        public static string BAD_REQUEST => "Hatalı İstek.";

        public static string UNAUTHORIZED => "Yetkisiz İşlem.";
        public static string USER_ALREADY_EXISTS => "Kullanıcı adı zaten mevcut.";
    }
}