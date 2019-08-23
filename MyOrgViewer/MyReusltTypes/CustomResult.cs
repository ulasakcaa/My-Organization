using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyOrgViewer.MyReusltTypes
{
    public class CustomResult:ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            string res = @"<table>
                <tr><td>adı</td><td>soyadı</td></tr>
                <tr><td>ibrahim</td><td>yazıcı</td></tr>
                </table>";
            context.RequestContext.HttpContext.Response.Write(res);

        }
    }
}