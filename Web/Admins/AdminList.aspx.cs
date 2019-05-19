using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.HostingService;

namespace Web.Admins
{
    public partial class AdminList : System.Web.UI.Page
    {
        private readonly HostingSystemServiceClient _service = new HostingSystemServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Repeater.DataSource = _service.GetAdmins();
                Repeater.DataBind();
            }
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Update":
                    Response.Redirect("AdminForm?ID=" + e.CommandArgument);
                    break;
            }
        }
        protected void OnClick(object sender, EventArgs e)
        {
            Response.Redirect("AdminForm");
        }
    }
}