using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GoogleBooksApp.Pages.Users
{
    public class EditorModel : AdminPageModel
    {
        public UserManager<IdentityUser> UserManager;

        public EditorModel(UserManager<IdentityUser> usrManager)
        {
            UserManager = usrManager;
        }

        [BindProperty]
        public string Id { get; set; } = string.Empty;

        [BindProperty]
        public string UserName { get; set; } = string.Empty;

        [BindProperty]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            IdentityUser? user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                // Handle the situation when the user is not found
                return NotFound();
            }
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                IdentityUser? user = await UserManager.FindByIdAsync(Id);
                if (user == null)
                {
                    // Handle the situation when the user is not found
                    return NotFound();
                }

                user.UserName = UserName;
                user.Email = Email;

                IdentityResult result = await UserManager.UpdateAsync(user);

                if (result.Succeeded && !string.IsNullOrEmpty(Password))
                {
                    await UserManager.RemovePasswordAsync(user);
                    result = await UserManager.AddPasswordAsync(user, Password);
                }

                if (result.Succeeded)
                {
                    return RedirectToPage("List");
                }

                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }

            return Page();
        }
    }
}
