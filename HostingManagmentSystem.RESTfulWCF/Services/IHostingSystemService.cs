using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using HostingManagmentSystem.Domain.Model;
using System.ServiceModel.Web;
using System.Text;

namespace HostingManagmentSystem.RESTfulWCF.Services
{

    [ServiceContract]
    public interface IHostingSystemService
    {
        #region Users
        [OperationContract]
        [WebInvoke(
                Method = "POST",
                UriTemplate = "users",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json)]
        bool CreateUser(User user);
        [OperationContract]
        [WebInvoke(
                Method = "PUT",
                UriTemplate = "/users",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json)]
        bool UpdateUser(User user);
        [OperationContract]
        [WebInvoke(
                Method = "GET",
                UriTemplate = "users",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json)]
        IEnumerable<User> GetUsers();
        [OperationContract]
        [WebInvoke(
                Method = "GET",
                UriTemplate = "users/{id}",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json)]
        User GetUserById(Guid id);
        #endregion
        #region Admins
        [OperationContract]
        [WebInvoke(
                Method = "POST",
                UriTemplate = "admins",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json)]
        bool CreateAdmin(Admin admin);
        [OperationContract]
        [WebInvoke(
                Method = "PUT",
                UriTemplate = "admins",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json)]
        bool UpdateAdmin(Admin admin);
        [OperationContract]
        [WebInvoke(
                Method = "GET",
                UriTemplate = "users",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json)]
        IEnumerable<Admin> GetAdmins();
        [OperationContract]
        [WebInvoke(
                Method = "GET",
                UriTemplate = "users/{id}",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json)]
        Admin GetAdminById(Guid id);
        #endregion
        #region VPS
        [OperationContract]
        [WebInvoke(
                 Method = "POST",
                 UriTemplate = "vps",
                 ResponseFormat = WebMessageFormat.Json,
                 RequestFormat = WebMessageFormat.Json)]
        bool CreateVps(VPS vps);
        [OperationContract]
        [WebInvoke(
                Method = "PUT",
                UriTemplate = "vps",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json)]
        bool UpdateVps(VPS vps);
        [OperationContract]
        [WebInvoke(
                Method = "GET",
                UriTemplate = "vps",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json)]
        IEnumerable<VPS> GetVps();
        [OperationContract]
        [WebInvoke(
                Method = "GET",
                UriTemplate = "vps/{id}",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json)]
        VPS GetVpsById(Guid id);
        #endregion
    }
}
