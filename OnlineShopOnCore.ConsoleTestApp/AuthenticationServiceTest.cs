using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using OnlineShopOnCore.Library.Clients.IdentityServer;
using OnlineShopOnCore.Library.Clients.UserManagementService;
using OnlineShopOnCore.Library.Common.Models;
using OnlineShopOnCore.Library.options;
using OnlineShopOnCore.Library.UserManagement.Models;
using OnlineShopOnCore.Library.UserManagement.Requests;

namespace OnlineShopOnCore.ConsoleTestApp
{
    public class AuthenticationServiceTest
    {
        private readonly IdentityServerApiOptions _identityServerOptions;
        private readonly IdentityServerClient _identityServerClient;
        private readonly UsersClient _usersClient;
        private readonly RolesClient _rolesClient;

        public AuthenticationServiceTest(IOptions<IdentityServerApiOptions> options, IdentityServerClient identityServerClient, UsersClient usersClient, RolesClient rolesClient)
        {
            _identityServerClient = identityServerClient;
            _usersClient = usersClient;
            _rolesClient = rolesClient;
            _identityServerOptions = options.Value;
        }

        public async Task<string> RunUsersClientTest(string[] args)
        {
            var token = await _identityServerClient.GetApiToken(_identityServerOptions);
            _usersClient.HttpClient.SetBearerToken(token.AccessToken);

            var userName = "xuz7";
            var roleName = "ShopClient";
            var roleNames = new[] { "ShopClient", "ShopClient3" };

            var addResult = await _usersClient.Add(new CreateUserRequest() { User = new ApplicationUser() { UserName = userName }, Password = "Password_1" });
            Console.WriteLine($"ADD: {addResult.Succeeded}");

            Thread.Sleep(100);

            var changePasswordRequest = await _usersClient.ChangePassword(new UserPasswordChangeRequest() { UserName = userName, CurrentPassword = "Password_1", NewPassword = "Password_2" });
            Console.WriteLine($"CHANGE PASSWORD: {changePasswordRequest.Succeeded}");

            Thread.Sleep(100);

            var getOneRequest = await _usersClient.Get(userName);
            Console.WriteLine($"GET ONE: {getOneRequest.Code}");

            Thread.Sleep(100);

            var userToUpdate = getOneRequest.Payload;
            userToUpdate.DefaultAddress = new Address()
            {
                City = "Warsaw",
                Country = "Poland",
                PostalCode = "00-001",
                AddressLine1 = "Jasna 21",
                AddressLine2 = "34"
            };
            var updateResult = await _usersClient.Update(userToUpdate);
            Console.WriteLine($"UPDATE: {updateResult.Succeeded}");

            Thread.Sleep(100);

            var addToRoleRequest = await _usersClient.AddToRole(new AddRemoveRoleRequest() { UserName = userName, RoleName = roleName });
            Console.WriteLine($"ADD TO ROLE: {addToRoleRequest.Succeeded}");

            Thread.Sleep(100);

            var removeFromRoleRequest = await _usersClient.RemoveFromRole(new AddRemoveRoleRequest() { UserName = userName, RoleName = roleName });
            Console.WriteLine($"REMOVE FROM ROLE: {removeFromRoleRequest.Succeeded}");

            Thread.Sleep(100);

            var addToRolesRequest = await _usersClient.AddToRoles(new AddRemoveRolesRequest() { UserName = userName, RoleNames = roleNames });
            Console.WriteLine($"ADD TO MANY ROLES: {addToRolesRequest.Succeeded}");

            Thread.Sleep(100);

            var removeFromRolesRequest = await _usersClient.RemoveFromRoles(new AddRemoveRolesRequest() { UserName = userName, RoleNames = roleNames });
            Console.WriteLine($"REMOVE FROM MANY ROLES: {removeFromRolesRequest.Succeeded}");

            getOneRequest = await _usersClient.Get(userName);
            Console.WriteLine($"GET ONE: {getOneRequest.Code}");

            Thread.Sleep(100);

            var deleteResult = await _usersClient.Remove(getOneRequest.Payload);
            Console.WriteLine($"DELETE: {deleteResult.Succeeded}");

            Thread.Sleep(100);

            var getAllRequest = await _usersClient.GetAll();
            Console.WriteLine($"GET ALL: {getAllRequest.Code}");

            Thread.Sleep(100);

            return "OK";
        }

        public async Task<string> RunRolesClientTests(string[] args)
        {
            var token = await _identityServerClient.GetApiToken(_identityServerOptions);
            _rolesClient.HttpClient.SetBearerToken(token.AccessToken);

            var roleName = "xyz7";

            var addResult = await _rolesClient.Add(new IdentityRole(roleName));
            Console.WriteLine($"ADD: {addResult.Succeeded}");

            Thread.Sleep(100);

            var getOneRequest = await _rolesClient.Get(roleName);
            Console.WriteLine($"GET ONE: {getOneRequest.Code}");

            Thread.Sleep(100);

            var userToUpdate = getOneRequest.Payload;
            var updateResult = await _rolesClient.Update(userToUpdate);
            Console.WriteLine($"UPDATE: {updateResult.Succeeded}");

            Thread.Sleep(100);

            getOneRequest = await _rolesClient.Get(roleName);
            Console.WriteLine($"GET ONE: {getOneRequest.Code}");

            Thread.Sleep(100);

            //var deleteResult = await _rolesClient.Remove(getOneRequest.Payload);
            //Console.WriteLine($"DELETE: {deleteResult.Succeeded}");

            //Thread.Sleep(100);

            var getAllRequest = await _rolesClient.GetAll();
            Console.WriteLine($"GET ALL: {getOneRequest.Code}");

            Thread.Sleep(100);

            return "OK";
        }


    }
}
