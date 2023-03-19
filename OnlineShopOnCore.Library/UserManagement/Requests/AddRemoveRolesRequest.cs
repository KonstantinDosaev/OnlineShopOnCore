namespace OnlineShopOnCore.Library.UserManagement.Requests
{
    public class AddRemoveRolesRequest
    {
        public string UserName { get; set; }

        public string[] RoleNames { get; set; }
    }
}
