namespace VortexGames.Core.Math
{
    public static class Utils
    {
        public static int CantorPairing(int a, int b)
        {
            return (a + b) * (a + b + 1) / 2 + b;
        }
    }
}