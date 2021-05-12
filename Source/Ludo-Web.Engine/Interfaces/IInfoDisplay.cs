namespace Ludo_Web.Engine.Interfaces
{
    public interface IInfoDisplay
    {
        void Update(string newString);
        public void UpdateDiceRoll(Player player, int result);
        public void UpdateDiceRoll(Stephan stephan, int result);
    }
}
