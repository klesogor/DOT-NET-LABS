using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.HostingService;

namespace Web.Admins
{
    public partial class AdminForm : System.Web.UI.Page
    {
        private readonly HostingSystemServiceClient _service = new HostingSystemServiceClient();
        private readonly MetricsServiceClient.MetricsServiceClient _metricsServiceClient = new MetricsServiceClient.MetricsServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["ID"];
            if (id != null && !IsPostBack)
            {
                var admin = _service.GetAdminById(Guid.Parse(id));
                adminName.Text = admin.Name;
                adminIp.Text = admin.Ip;
                adminDescription.Text = admin.Description;
                adminId.Value = id;
                Label.Text = "Edit admin";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var admin = new Admin();
            admin.Name = adminName.Text;
            admin.Ip = adminIp.Text;
            admin.Description = adminDescription.Text;
            if (!string.IsNullOrEmpty(adminId.Value))
            {
                admin.Id = Guid.Parse(adminId.Value);
                _service.UpdateAdmin(admin);
                _metricsServiceClient.AddMetrics("Updated admin withd id: " + admin.Id.ToString());
            }
            else
            {
                _service.CreateAdmin(admin);
                _metricsServiceClient.AddMetrics("Created admin");
            }

            Response.Redirect("AdminList");
        }
    }
}