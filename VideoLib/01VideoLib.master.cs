using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Dal;

public partial class _01VideoLib : System.Web.UI.MasterPage
{
    protected DataCache videoDB;
    protected LoggedInUser loggedInUser;
    protected Cart cart;

    public DataCache VideoDB
    {
        get
        {
            return this.videoDB;
        }
    }

    public LoggedInUser LoggedInUser
    {
        get
        {
            return this.loggedInUser;
        }
    }

    public Cart Cart
    {
        get
        {
            return this.cart;
        }
    }

    public string SecretMasterValue
    {
        get { return this.a.Text; }
        set { this.a.Text = value; }
    }

    public HtmlGenericControl LoginDiv
    {
        get
        {
            return this.loginDiv;
        }
    }

    public HtmlGenericControl LogoutDiv
    {
        get
        {
            return this.logoutDiv;
        }
    }

    public Label ErrorLabel
    {
        get
        {
            return this.errorLabel;
        }
    }

    public Menu MainMenu
    {
        get
        {
            return this.mainMenu;
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        this.videoDB = new DataCache();
        this.loggedInUser = new LoggedInUser(this.videoDB, Session);
        this.cart = new Cart(this.videoDB, Request, Response);

        if (!Page.IsPostBack)
        {
            this.categoryMenu.Items.Add(new MenuItem("Top 10", "", "", "~/10Default.aspx"));
            foreach (var a in this.videoDB.GetAllMovieTypes())
            {
                MenuItem m = new MenuItem(a.MovieTypeName, a.MovieTypeID.ToString());
                m.NavigateUrl = "~/10Default.aspx?type=" + a.MovieTypeID;
                this.categoryMenu.Items.Add(m);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.loggedInUser.IsLoggedIn())
        {
            this.loginDiv.Visible = false;
            this.logoutDiv.Visible = true;
            this.mainMenu.Items[1].Enabled = true;
            if (this.loggedInUser.memberLevel == 2)
            {
                this.mainMenu.Items[2].Enabled = true;
            }
        }
    }
    protected void loginBut_Click(object sender, EventArgs e)
    {
        if (this.PageIsValid())
        {
            this.loggedInUser.Login(int.Parse(this.MemberID.Text));
            this.loginDiv.Visible = false;
            this.logoutDiv.Visible = true;
            this.mainMenu.Items[1].Enabled = true;
            this.UpdateCartFromWaitingList();
            if (this.loggedInUser.memberLevel == 2)
            {
                this.mainMenu.Items[2].Enabled = true;
            }
        }
        else
        {
            this.errorLabel.Visible = true;
        }
    }
    protected void logoutBut_Click(object sender, EventArgs e)
    {
        this.loggedInUser.Logout();
        this.loginDiv.Visible = true;
        this.logoutDiv.Visible = false;
        this.mainMenu.Items[1].Enabled = false;
        this.mainMenu.Items[2].Enabled = false;
        this.cart.RemoveAll();
    }

    public bool PageIsValid()
    {
        int memberID = -1;
        if (!int.TryParse(this.MemberID.Text, out memberID))
        {
            this.errorLabel.Text = "Illegal Member ID";
            return false;
        }

        Member m = this.videoDB.GetMember_MemberID(memberID);
        if (m == null)
        {
            this.errorLabel.Text = "Illegal Member ID";
            return false;
        }
        m.Password = m.Password.Trim();
        if (m.Password != this.Password.Text)
        {
            this.errorLabel.Text = "Illegal Password";
            return false;
        }
        return true;
    }

    public void UpdateCartFromWaitingList()
    {
        IEnumerable<WaitingList> waitingList = this.videoDB.GetMemberWaitingList
                                               (this.loggedInUser.memberID);
        foreach (var a in waitingList)
        {
            if (a.InStock == "Yes")
            {
                this.cart.AddMovie(a.Movie, CurrentTime.TimeNow.AddDays(2),
                                            "Waiting Agent","");
                this.videoDB.RemoveFromWaitingList(a.MemberID, a.MovieID);
            }
        }
        this.cart.UpdateCart();
    }
    protected void changeTimeCalender_SelectionChanged(object sender, EventArgs e)
    {
        CurrentTime.TimeNow = this.changeTimeCalender.SelectedDate;
        this.changeTimeDiv.Visible = false;
    }
    protected void changeTimeBut_Click(object sender, EventArgs e)
    {
        this.changeTimeDiv.Visible = true;
    }
}
