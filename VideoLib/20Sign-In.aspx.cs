using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal;

public partial class _20Sign_In : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        this.PreHomePhone.Items.Add(new ListItem("02", "02"));
        this.PreHomePhone.Items.Add(new ListItem("03", "03"));
        this.PreHomePhone.Items.Add(new ListItem("04", "04"));
        this.PreHomePhone.Items.Add(new ListItem("07", "07"));
        this.PreHomePhone.Items.Add(new ListItem("08", "08"));
        this.PreHomePhone.Items.Add(new ListItem("09", "09"));
        this.PreHomePhone.Items.Add(new ListItem("077", "077"));
        this.PreMobilePhone.Items.Add(new ListItem("050", "050"));
        this.PreMobilePhone.Items.Add(new ListItem("052", "052"));
        this.PreMobilePhone.Items.Add(new ListItem("054", "054"));
        this.PreMobilePhone.Items.Add(new ListItem("057", "057"));
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (Request["change"] == "true")
        {
            this.signInBut.Text = "Change Details";

            Member m = this.Master.VideoDB.GetMember_MemberID
                       (this.Master.LoggedInUser.memberID);
            this.FirstName.Text = m.FirstName;
            this.LastName.Text = m.LastName;
            this.ID.Text = m.ID.ToString();
            if (m.BirthDate.HasValue)
            {
                this.BirthDate.Text = m.BirthDate.Value.ToShortDateString();
            }
            this.Street.Text = m.Street;
            this.City.Text = m.City;
            if (m.HouseNumber.HasValue)
            {
                this.HouseNumber.Text = m.HouseNumber.Value.ToString();
            }
            if (m.HomePhone.HasValue)
            {
                for (int i = 0; i < this.PreHomePhone.Items.Count; i++)
                {
                    if (this.PreHomePhone.Items[i].Value == 
                        m.HomePhone.Value.ToString().Substring(0, 2))
                    {
                        this.PreHomePhone.Items[i].Selected = true;
                    }
                }
                this.HomePhone.Text = m.HomePhone.Value.ToString().Substring(2);
            }

            for (int i = 0; i < this.PreMobilePhone.Items.Count; i++)
            {
                if (this.PreMobilePhone.Items[i].Value == 
                    m.MobilePhone.ToString().Substring(0, 2))
                {
                    this.PreMobilePhone.Items[i].Selected = true;
                }
            }
            this.MobilePhone.Text = m.MobilePhone.ToString().Substring(2);
            this.EMail.Text = m.Email;
            this.Password1.Text = m.Password;
            this.Password2.Text = m.Password;
        }
    }
    protected void cusBirthDate_ServerValidate(object source, ServerValidateEventArgs args)
    {
        DateTime d = default(DateTime);
        string[] details = args.Value.Split(',','.','/','-');
        DateTime.TryParse(string.Format("{0}/{1}/{2}", int.Parse(details[2]), 
                                                       int.Parse(details[1]), 
                                                       int.Parse(details[0])), out d);
        if (d == default(DateTime))
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
    protected void cusID_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (this.IDChecker(args.Value))
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }

    protected void signInBut_Click(object sender, EventArgs e)
    {
        //if (Page.IsValid)
        //{
        //    DateTime birthDate = default(DateTime);
        //    int memberID = 0;
        //    string street = "";
        //    string city = "";
        //    short houseNumber = 0;
        //    int homeNumber = 0;

        //    Member m = new Member
        //    {
        //        MemberLevel = 1,
                
        //    };
        //    if (Request["change"] == "true")
        //    {
        //        m = this.Master.VideoDB.GetMember_MemberID
        //            (this.Master.LoggedInUser.memberID);
        //    }
        //    else
        //    {

        //    }
        //}
    }
    protected void cancelBut_Click(object sender, EventArgs e)
    {
        Response.Redirect("10Default.aspx");
    }

    public bool IDChecker(string ID)
    {
        string theID = ID;
        while (theID.Length < 9)
        {
            string temp = '0' + theID;
            theID = temp;
        }
        ID = theID;

        string[] details = new string[theID.Length];
        for (int i = 0; i < theID.Length; i++)
        {
            details[i] = theID[i].ToString();
        }

        for (int i = 1; i < theID.Length; i += 2)
        {
            details[i] = (int.Parse(details[i]) * 2).ToString();
            int x = 0;
            foreach (char a in details[i])
            {
                x += int.Parse(a.ToString());
            }
            details[i] = x.ToString();
        }

        int result = 0;
        foreach (var a in details)
        {
            result += int.Parse(a);
        }

        if ((result % 10) == 0)
        {
            return true;
        }
        return false;
    }
}
