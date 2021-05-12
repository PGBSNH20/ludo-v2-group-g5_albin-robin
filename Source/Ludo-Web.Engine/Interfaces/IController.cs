using System;

namespace Ludo_Web.Engine.Interfaces
{
    public interface IController
    {
        public void Activate();

        public event Action SelectionUpEvent;
        public event Action SelectionDownEvent;
        public event Action TakeOutTwoPressEvent;
        public event Action OnConfirmEvent;
    }
}
