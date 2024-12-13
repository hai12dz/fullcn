using Microsoft.AspNetCore.Mvc;
using temfullcn.Models;

namespace ttem2.ViewComponents
{
    public class TranDauViewComponent : ViewComponent
    {
        QlgiaiBongDaContext db = new QlgiaiBongDaContext();
        public TranDauViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

          var matrandaus = db.Trandaus.Take(8).ToList();


            return View("TranDau", matrandaus);
        }

    }
}