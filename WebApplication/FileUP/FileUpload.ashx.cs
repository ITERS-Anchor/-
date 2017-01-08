using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WebApplication.FileUP
{
    /// <summary>
    /// Summary description for FileUpload
    /// </summary>
    public class FileUpload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            HttpPostedFile file= context.Request.Files["fileName"];
            if (file==null)
            {
                context.Response.Write("please select a file");
            }
            else
            {
               string fileName= Path.GetFileName(file.FileName);//file.FileName里不仅包括文件名，还有扩展名以及路径
                string fileExten=Path.GetExtension(fileName);
                if (fileExten==".jpg")
                {
                    file.SaveAs(context.Request.MapPath("/Image/"+fileName));
                    string p="/Image/"+fileName;
                    string filePath = context.Request.MapPath("FileUpload.html");
                    string fileContent = File.ReadAllText(filePath);
                    fileContent = fileContent.Replace("$souce",p );
                    context.Response.Write(fileContent);
                }
                else
                {
                    context.Response.Write("File format error");
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}