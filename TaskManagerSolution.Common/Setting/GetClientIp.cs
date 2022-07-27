

using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace TaskManagerSolution.Common.Setting;

public static class GetClientIp
{
    public static string GetPublicIP()
    {
        string direction = "";
        WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
        using (WebResponse response = request.GetResponse())
        using (StreamReader stream = new StreamReader(response.GetResponseStream()))
        {
            direction = stream.ReadToEnd();
        }

        //Search for the ip in the html
        int first = direction.IndexOf("Address: ") + 9;
        int last = direction.LastIndexOf("</body>");
        direction = direction.Substring(first, last - first);
        return direction;

    }
}
