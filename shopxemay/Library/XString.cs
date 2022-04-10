using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace shopxemay.Library
{
    public class XString
    {
        public static string Str_Slug(string s)
        {
            String[][] symbols = {
                       new String[] { "[áàåãaăåååăăâãäáãâ]", "a" },
                       new String[] { "[đ]", "d" },
                       new String[] { "[éèéëêêéèéëệ]", "e" },
                       new String[] { "[iìịĩí]", "i" },
                       new String[] { "[óòọỏõôổồỗộơờớỡởợ]", "o" },
                       new String[] { "[úùůü̟uưừứữu]", "u" },
                       new String[] { "[yýỳỹỵ]", "y"},
                       new String[] { "[\\s'\";,]","-" }
                   };
            s = s.ToLower();
            foreach (var ss in symbols)
            {
                s = Regex.Replace(s, ss[0], ss[1]);
            }
                return s;
         }
    }
}