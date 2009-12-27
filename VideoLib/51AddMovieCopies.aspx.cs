using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Dal;

public partial class _51AddMovieCopies : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void addBut_Click(object sender, EventArgs e)
    {
        short d = -1;
        if (short.TryParse(this.Copies.Text, out d))
        {
            if (d <= 0)
            {
                this.errorLabel.Text = "Bigger Then 0";
                return;
            }

            Movie m = this.Master.VideoDB.GetMovie_MovieID(this.MovieID.Text);
            if (m == null)
            {
                this.errorLabel.Text = "Movie Not Found";
                return;
            }

            this.Master.VideoDB.AddCopies(m.MovieID, d);
            this.errorLabel.ForeColor = Color.Blue;
            this.errorLabel.Text = string.Format("{0} {1} Now Have {2} Copies",
                                   m.MovieID,m.MovieName,m.Copies);

        }
        else
        {
            this.errorLabel.Text = "Numbers Only";
        }
    }
}
