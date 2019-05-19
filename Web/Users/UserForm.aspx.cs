using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.HostingService;

namespace Web.Users
{
    public partial class UserForm : System.Web.UI.Page
    {
        private readonly HostingSystemServiceClient _service = new HostingSystemServiceClient();
        private readonly MetricsServiceClient.MetricsServiceClient _metricsServiceClient = new MetricsServiceClient.MetricsServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["ID"];
            if (id != null && !IsPostBack)
            {
                var user = _service.GetUserById(Guid.Parse(id));
                userName.Text = user.Name;
                userSurname.Text = user.Surname;
                userPhone.Text = user.Phone;
                userSecret.Text = user.Secret;
                userId.Value = id;
                Label.Text = "Edit user";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var user = new User();
            user.Name = userName.Text;
            user.Surname = userSurname.Text;
            user.Phone = userPhone.Text;
            user.Secret = userSecret.Text;
            if (!string.IsNullOrEmpty(userId.Value))
            {
                user.Id = Guid.Parse(userId.Value);
                _service.UpdateUser(user);
                _metricsServiceClient.AddMetrics("Updated user withd id: " + user.Id.ToString());
            }
            else {
                _service.CreateUser(user);
                _metricsServiceClient.AddMetrics("Created user");
            }

            Response.Redirect("UserList");
        }
    }
}