namespace BullsAndCows
{
    public struct Result
    {
        public Result(int bullsCount, int cowsCount)
        {
            BullsCount = bullsCount;
            CowsCount = cowsCount;
        }

        public int BullsCount { get; }
        public int CowsCount { get; }
        public bool IsWin => BullsCount == 4;

        public override string ToString()
        {
            if (IsWin)
                return "It`s win!!!";
            else
                return $"Bulls: {BullsCount}, Cows {CowsCount}";
        }
    }
}