using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CurrentTime
/// </summary>
public static class CurrentTime
{
    private static DateTime timeNow;

    static CurrentTime()
    {
        timeNow = DateTime.Now;
    }

    public static DateTime TimeNow
    {
        get { return timeNow; }
        set { timeNow = value; }
    }
}
