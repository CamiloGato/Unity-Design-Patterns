using Patterns.Structure.MVC.Models;
using Patterns.Structure.MVC.Views;

namespace Patterns.Structure.MVC.Controller
{
    public class PanelController : BaseController<MenuModel, PanelView>
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