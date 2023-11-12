using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using context = System.Web.HttpContext;
/// <summary>
/// Summary description for ErrorLogCls
/// </summary>
public class ErrorLogCls
{
    
    public ErrorLogCls()
    {
        
    }

    private static String ErrorlineNo, Errormsg, extype, exurl, hostIp, ErrorLocation,ErrorCode, error;

    public static void SendErrorToText(Exception ex)
    {
        var line = Environment.NewLine + Environment.NewLine;

        ErrorlineNo = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
        Errormsg = ex.GetType().Name.ToString();
        extype = ex.GetType().ToString();
        exurl = context.Current.Request.Url.ToString();
        ErrorLocation = ex.Message.ToString();

        ErrorCode = Convert.ToString(GetErrorCode(ex));
        try
        {
            string filepath = context.Current.Server.MapPath("~/ErrorLog/");  //Text File Path

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            filepath = filepath + DateTime.Today.ToString("dd-MM-yy") + ".txt";   //Text File Name
            if (!File.Exists(filepath))
            {
                File.Create(filepath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(filepath))
            {
                 error = "Log Written Date:" + " " + DateTime.Now.ToString() + line + "Error Line No :" + " " + ErrorlineNo + line + "Error Message:" + " " + Errormsg + line + "Exception Type:" + " " + extype + line + "Error Location :" + " " + ErrorLocation + line + " Error Page Url:" + " " + exurl + line + "User Host IP:" + " " + hostIp + line + "Code:" + " " + ErrorCode;
                sw.WriteLine("-----------Exception Details on " + " " + DateTime.Now.ToString() + "-----------------");
                sw.WriteLine("-------------------------------------------------------------------------------------");
                sw.WriteLine(line);
                sw.WriteLine(error);
                sw.WriteLine("--------------------------------*End*------------------------------------------");
                sw.WriteLine(line);
                sw.Flush();
                sw.Close();
            }
            APIProcedure obj = new APIProcedure();
            obj.ByProcedure("Error.InsertErrorMsg",
            new string[] { "flag", "ErrorMessage", "ErrorLine" },
           new string[] { "0", error,ErrorlineNo }, "dataset");

        }
        catch (Exception e)
        {
            ErrorLogCls.SendErrorToText(e);
        }
    }
    private static int GetErrorCode(Exception ex)
    {
        int errorCode = 0; // Default value

        if (ex is Win32Exception)
        {
            errorCode = ((Win32Exception)ex).ErrorCode;
        }
        else if (ex is SqlException)
        {
            errorCode = ((SqlException)ex).ErrorCode;
        }
        // Add more specific exception types with ErrorCode properties here if needed.

        return errorCode;
    }
}