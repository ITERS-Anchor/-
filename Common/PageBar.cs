using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class PageBar
    {
        public static string GetPageBar(int pageIndex,int pageCount)
        {
            if (pageCount==1)
            {
                return string.Empty;
            }
            int start = pageIndex - 3;//显示6个页码数字6/2=3
            if (start<1)
            {
                start = 1;
            }
            int end = start + 5;//2*3-1，按第5个的时候变
            if (end>pageCount)
            {
                end = pageCount;
                start = end - 5 > 0 ? end - 5 : 1;

            }
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<ul class='pagination'>");
            if (pageIndex>1)
            {
                //sb.Append(string.Format("<li><a href='Index.aspx?page={0}'>«</a></li>", pageIndex-1));
                sb.Append(string.Format("<li><a class='pgbar' href='?page={0}'>«</a></li>", pageIndex - 1));
            }
            for (int i = start; i <= end; i++)
            {
                if (i==pageIndex)
                {
                    //sb.Append(string.Format("<li><a class='active' href='Index.aspx?page={0}'>{0}</a></li>", i));
                    sb.Append(string.Format("<li><a class='active' href='?page={0}'>{0}</a></li>", i));
                }
                else
                {
                    // sb.Append(string.Format("<li><a href='Index.aspx?page={0}'>{0}</a></li>",i));
                    sb.Append(string.Format("<li><a class='pgbar' href='?page={0}'>{0}</a></li>", i));
                }
            }
            if (pageIndex < pageCount)
            {
                //sb.Append(string.Format("<li><a href='Index.aspx?page={0}'>»</a></li>", pageIndex+1));
                sb.Append(string.Format("<li><a class='pgbar' href='?page={0}'>»</a></li>", pageIndex + 1));
            }
            sb.AppendFormat("</ul>");
            return sb.ToString();
        }
    }
}
