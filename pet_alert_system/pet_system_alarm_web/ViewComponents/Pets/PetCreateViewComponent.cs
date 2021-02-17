using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace pet_system_alarm_web.ViewComponents.Pets
{
    public class PetCreateViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
