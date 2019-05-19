using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.HostingService;

namespace Web.Users
{
    public partial class UserList : System.Web.UI.Page
    {
        private readonly HostingSystemServiceClient service = new HostingSystemServiceClient();
        protected global::System.Web.UI.WebControls.Repeater repeater;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                repeater.DataSource = service.GetUsers();
                repeater.DataBind();
            }
        }


        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Update":
                    Response.Redirect("userForm?ID=" + e.CommandArgument);
                    break;
            }
        }
        protected void OnClick(object sender, EventArgs e)
        {
            Response.Redirect("userForm");
        }
    }
}