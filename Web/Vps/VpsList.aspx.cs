using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.HostingService;

namespace Web.Vps
{
    public partial class VpsList : System.Web.UI.Page
    {
        private readonly HostingSystemServiceClient _service = new HostingSystemServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Repeater.DataSource = _service.GetVps();
                Repeater.DataBind();
            }
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Update":
                    Response.Redirect("VpsForm?ID=" + e.CommandArgument);
                    break;
            }
        }
        protected void OnClick(object sender, EventArgs e)
        {
            Response.Redirect("VpsForm");
        }
    }
}