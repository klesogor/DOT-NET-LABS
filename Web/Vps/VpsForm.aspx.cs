using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.HostingService;

namespace Web.Vps
{
    public partial class VpsForm : System.Web.UI.Page
    {
        private readonly HostingSystemServiceClient _service = new HostingSystemServiceClient();
        private readonly MetricsServiceClient.MetricsServiceClient _metricsServiceClient = new MetricsServiceClient.MetricsServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            VPS vps = null;
            var id = Request.QueryString["ID"];
            if (id != null)
            {
                vps = _service.GetVpsById(Guid.Parse(id));
                vpsOs.Text = vps.OperatingSystem;
                vpsCpu.Text = vps.CPU;
                vpsRam.Text = vps.RAM;
                vpsId.Value = id;
                Label.Text = "Edit vps";
            }
            var userOptions = _service.GetUsers().Select(u => new ListItem()
            {
                Text = u.Name,
                Value = u.Id.ToString(),
                Selected = u.Id == vps?.OwnerId
            }).ToList();
            userOptions.Insert(0, new ListItem() { Text = "", Value = "" });
            vpsOwner.DataSource = userOptions;
            vpsOwner.SelectedValue = vps?.OwnerId.ToString();
            vpsOwner.DataBind();
            var adminOptions = _service.GetAdmins().Select(a => new ListItem()
            {
                Text = a.Name,
                Value = a.Id.ToString(),
                Selected = a.Id == vps?.AdminId
            }).ToList();
            adminOptions.Insert(0, new ListItem() { Text = "", Value = "" });
            vpsAdmin.DataSource = adminOptions;
            vpsAdmin.SelectedValue = vps?.AdminId.ToString();
            vpsAdmin.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var vps = new VPS();
            vps.OperatingSystem = vpsOs.Text;
            vps.CPU = vpsCpu.Text;
            vps.RAM = vpsRam.Text;
            var success = Guid.TryParse(vpsOwner.SelectedValue, out Guid ownerId);
            vps.OwnerId = !success ? null : (Guid?)ownerId;
            success = Guid.TryParse(vpsAdmin.SelectedValue, out Guid adminId);
            vps.AdminId = !success ? null : (Guid?)adminId;
            if (!string.IsNullOrEmpty(vpsId.Value))
            {
                vps.Id = Guid.Parse(vpsId.Value);              
                _service.UpdateVps(vps);
                _metricsServiceClient.AddMetrics("Updated vps with id: " + vps.Id.ToString());
            }
            else
            {
                _service.CreateVps(vps);
                _metricsServiceClient.AddMetrics("Created vps");
            }

            Response.Redirect("VpsList");
        }
    }
}