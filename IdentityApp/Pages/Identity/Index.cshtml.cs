using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Pages.Identity
{
    public class IndexModel : UserPageModel
    {
        public UserManager<IdentityUser> UserManager{ get; set; }
        public IndexModel(UserManager<IdentityUser> userManager)
        {
            UserManager = userManager;
        }
        public string Email { get; set; }
        public string Phone { get; set; }
        public async Task OnGetAsync()
        {
            IdentityUser CurrentUser = await UserManager.GetUserAsync(User);
            Email = CurrentUser?.Email ?? "(No Value)";
            Phone = CurrentUser?.PhoneNumber ?? "(No Value)";
        }
    }
}