using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _10Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.rpMovies.DataSource = this.Master.VideoDB.GetPopularMovies(10);

        if (Request["type"] != null)
        {
            this.rpMovies.DataSource = this.Master.VideoDB.GetAllMoviesByMovieTypeID
                                       (int.Parse(Request["type"]));
            this.Master.SecretMasterValue = Request["type"];
        }
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        this.rpMovies.DataBind();
    }
}
