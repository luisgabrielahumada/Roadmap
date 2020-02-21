using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class SMTPConfiguration
{
    public string Server { get; set; }
    public int Port { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool EnableSSL { get; set; }
}
