using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Dal;

/// <summary>
/// Summary description for LoggedInUser
/// </summary>
public class LoggedInUser
{
    public int memberID { get; private set; }
    public int memberLevel { get; private set; }
    public string memberName { get; private set; }
    public int currentlyRented { get; private set; }
    public int pastDueDate { get; private set; }
    public int dayBalance { get; private set; }

    private DataCache videoDB;
    private HttpSessionState session;

    public LoggedInUser(DataCache videoDB, HttpSessionState session)
    {
        this.videoDB = videoDB;
        this.session = session;

        if (this.session["UserInfo"] != null)
        {
            LoggedInUser l = (LoggedInUser)this.session["UserInfo"];
            this.memberID = l.memberID;
            this.memberName = l.memberName;
            this.memberLevel = l.memberLevel;
            this.pastDueDate = l.pastDueDate;
            this.currentlyRented = l.currentlyRented;
            this.dayBalance = l.dayBalance;
            this.session["UserInfo"] = this;
        }
        else
        {
            this.memberID = 0;
        }
    }

    public void UpdateStatistics()
    {
        Member m = this.videoDB.GetMember_MemberID(this.memberID);
        this.memberLevel = m.MemberLevel;
        this.memberName = m.FullName;
        this.pastDueDate = m.PastDueDateCount(CurrentTime.TimeNow);
        this.currentlyRented = m.CurrentlyRentedCount;
        this.dayBalance = m.DaysBalance;
        this.session["UserInfo"] = this;
    }

    public void Login(int memberID)
    {
        this.memberID = memberID;
        this.UpdateStatistics();
        this.session["UserInfo"] = this;
    }

    public void Logout()
    {
        this.session["UserInfo"] = null;
        this.memberID = 0;
    }

    public bool IsLoggedIn()
    {
        return this.memberID != 0;
    }
}
