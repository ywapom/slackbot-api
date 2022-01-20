using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Diagnostics;
using System.Text;
using System.Security;

namespace RevnaApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            string choice;
            string result = "";

            if(id == 1)
            {
                result = ExecuteAsAdmin(@"C:\inetpub\wwwroot\Revna\mssqlx64.bat");
                choice = "MSSQLx64";
            }
            else if(id == 2)
            {
                //result = ExecuteAsAdmin(@"C:\inetpub\wwwroot\Revna\mssqlx32.bat");
                choice = "MSSQLx32 -- currently unavailable";
            }
            else if(id == 3)
            {
                result = ExecuteAsAdmin(@"C:\inetpub\wwwroot\Revna\oracle.bat");
                choice = "Oracle";
            }
            else
            {
                return "ERROR";
            }
            return $"{choice} | {result}";
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody] Dictionary<string, string> key)
        {
            var payload = Json(key);
            if (payload != null)
            {

                var response = new HttpResponseMessage(HttpStatusCode.Created);

                return response;
            }
            else
            {
                ExecuteAsAdmin("c:\\test.bat");
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        public string ExecuteAsAdmin(string fileName)
        {
            try
            {
                StringBuilder output = new StringBuilder();
                Process proc = new Process();
                proc.StartInfo.FileName = fileName;
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.Verb = "runas";
                proc.Start();
                //proc.BeginOutputReadLine();
                //proc.WaitForExit();
                //if (!proc.HasExited)
                //{
                //    long peakPagedMem = 0,
                //         peakWorkingSet = 0,
                //         peakVirtualMem = 0;
                //    // Refresh the current process property values.
                //    proc.Refresh();

                //    Debug.WriteLine("");

                //    // Display current process statistics.

                //    Debug.WriteLine($"{proc} -");
                //    Debug.WriteLine("-------------------------------------");

                //    Debug.WriteLine($"  Physical memory usage     : {proc.WorkingSet64}");
                //    Debug.WriteLine($"  Base priority             : {proc.BasePriority}");
                //    Debug.WriteLine($"  Priority class            : {proc.PriorityClass}");
                //    Debug.WriteLine($"  User processor time       : {proc.UserProcessorTime}");
                //    Debug.WriteLine($"  Privileged processor time : {proc.PrivilegedProcessorTime}");
                //    Debug.WriteLine($"  Total processor time      : {proc.TotalProcessorTime}");
                //    Debug.WriteLine($"  Paged system memory size  : {proc.PagedSystemMemorySize64}");
                //    Debug.WriteLine($"  Paged memory size         : {proc.PagedMemorySize64}");
                //    Debug.WriteLine($"  Container                 : {proc.Container}");
                //    Debug.WriteLine($"  Machine name              : {proc.MachineName}");
                //    Debug.WriteLine($"  Process name              : {proc.ProcessName}");


                //    // Update the values for the overall peak memory statistics.
                //    peakPagedMem = proc.PeakPagedMemorySize64;
                //    peakVirtualMem = proc.PeakVirtualMemorySize64;
                //    peakWorkingSet = proc.PeakWorkingSet64;

                //    if (proc.Responding)
                //    {
                //        Debug.WriteLine("Status = Running");
                //    }
                //    else
                //    {
                //        Debug.WriteLine("Status = Not Responding");
                //    }

                //    return output.ToString();
                //}
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            return "Process started";
            
        }

        //[HttpPost]
        //[ActionName("simple")]
        //public HttpResponseMessage PostSimple([FromBody] string value)
        //{
        //    if (value != null)
        //    {

        //        var response = new HttpResponseMessage(HttpStatusCode.Created);

        //        return response;
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //}

        // PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
