using Patterns.Structure.MVC.Models;
using Patterns.Structure.MVC.Views;

namespace Patterns.Structure.MVC.Controller
{
    public class ButtonsController : BaseController<MenuModel, ButtonsView>
    {
        public override void Initialize()
        {
            base.Initialize();
        }

        public void Pause()
        {
            baseView.SetPause(true);
        }

        public void Continue()
        {
            baseView.SetPause(false);
        }
        
        public override void Close()
        {
            base.Close();
        }
    }
}