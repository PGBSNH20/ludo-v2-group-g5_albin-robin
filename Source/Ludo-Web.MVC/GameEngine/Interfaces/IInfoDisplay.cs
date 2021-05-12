using Ludo_Web.MVC.GameEngine;
using Ludo_Web.MVC.Models; using static Ludo_Web.MVC.Models.ModelEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo_Web.MVC.GameEngine.Interfaces
{
    public interface IInfoDisplay
    {
        void Update(string newString);
        public void UpdateDiceRoll(Player player, int result);
        public void UpdateDiceRoll(Stephan stephan, int result);
    }
}
