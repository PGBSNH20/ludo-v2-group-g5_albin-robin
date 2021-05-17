using LudoAPI.GameEngine.Interfaces;

namespace LudoAPI.GameEngine.Dice
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
