using Patterns.Structure.MVC.Models;
using Patterns.Structure.MVC.Views;

namespace Patterns.Structure.MVC.Controller
{
    public class PanelController : BaseController<MenuModel, PanelView>
    {
        public void Pause()
        {
            baseView.SetPause(true);
        }

        public void Continue()
        {
            baseView.SetPause(false);
        }
    }
}