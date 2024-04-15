using Patterns.Structure.MVC.Models;
using Patterns.Structure.MVC.Views;

namespace Patterns.Structure.MVC.Controller
{
    public class ButtonsController : BaseController<ButtonModel, ButtonsView>
    {
        public override void Initialize()
        {
            base.Initialize();
        }

        public void Pause()
        {
            baseView.SetPause(true);
        }

        public void UnPause()
        {
            baseView.SetPause(false);
        }
        
        public override void Close()
        {
            base.Close();
        }
    }
}