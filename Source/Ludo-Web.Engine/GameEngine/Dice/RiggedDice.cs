using Ludo_Web.Engine.Interfaces;

namespace Ludo_Web.Engine.GameEngine.Dice
{
    public class RiggedDice : IDice
    {
        private int[] ResultSeries { get; set; }
        private int Index { get; set; }
        public RiggedDice(int[] resultSeries)
        {
            ResultSeries = resultSeries;
            Index = 0;
        }
        public int Roll()
        {
            if (Index + 1 > ResultSeries.Length) Index = 0;
            var result = ResultSeries[Index];
            Index++;
            return result;
        }
    }
}
