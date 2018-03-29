using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Doandinhduong.Common
{
    public static class VietNamChar
    {
        private static string[] VietnamChar = new string[]
       {
           "aAeEoOuUiIdDyY-",
           "áàạảãâấầậẩẫăắằặẳẵ",
           "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
           "éèẹẻẽêếềệểễ",
           "ÉÈẸẺẼÊẾỀỆỂỄ",
           "óòọỏõôốồộổỗơớờợởỡ",
           "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
           "úùụủũưứừựửữ",
           "ÚÙỤỦŨƯỨỪỰỬỮ",
           "íìịỉĩ",
           "ÍÌỊỈĨ",
           "đ",
           "Đ",
           "ýỳỵỷỹ",
           "ÝỲỴỶỸ",
           " "
       };
        public static string ReplaceUnicode(string strInput)
        {
            for (int i = 1; i < VietnamChar.Length; i++)
            {
                for (int j = 0; j < VietnamChar[i].Length; j++)
                {
                    strInput = strInput.Replace(VietnamChar[i][j], VietnamChar[0][i - 1]);
                }
            }
            return strInput;
        }
    }
   
}