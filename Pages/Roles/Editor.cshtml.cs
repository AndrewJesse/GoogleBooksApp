using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GoogleBooksApp.Pages.Roles
{
    public class EditorModel : AdminPageModel
    {
        public UserManager<IdentityUser> UserManager;
        public RoleManager<IdentityRole> RoleManager;

        public EditorModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public IdentityRole Role { get; set; } = new();

        public Task<IList<IdentityUser>> Members() => UserManager.GetUsersInRoleAsync(Role.Name);

        public async Task<IEnumerable<IdentityUser>> NonMembers() =>
            UserManager.Users.ToList().Except(await Members());

        public async Task OnGetAsync(string id)
        {
            Role = await RoleManager.FindByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(string userid, string rolename)
        {
            Role = await RoleManager.FindByNameAsync(rolename);
            IdentityUser user = await UserManager.FindByIdAsync(userid);
            IdentityResult result;

            if (await UserManager.IsInRoleAsync(user, rolename))
            {
                result = await UserManager.RemoveFromRoleAsync(user, rolename);
            }
            else
            {
                result = await UserManager.AddToRoleAsync(user, rolename);
            }

            if (result.Succeeded)
            {
                return RedirectToPage();
            }
            else
            {
                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }

                return Page();
            }
        }
    }
}
