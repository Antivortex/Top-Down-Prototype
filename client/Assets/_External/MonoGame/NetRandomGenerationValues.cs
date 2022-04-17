namespace Lidgren.Network
{
    public struct NetRandomGenerationValues
    {
        public readonly uint MX;
        public readonly uint MY;
        public readonly uint MZ;
        public readonly uint MW;

        public NetRandomGenerationValues(uint mx, uint my, uint mz, uint mw)
        {
            MX = mx;
            MY = my;
            MZ = mz;
            MW = mw;
        }

        public bool Equals(NetRandomGenerationValues other)
        {
            return MX == other.MX 
                && MY == other.MY 
                && MZ == other.MZ 
                && MW == other.MW;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) MX;
                hashCode = (hashCode*397) ^ (int) MY;
                hashCode = (hashCode*397) ^ (int) MZ;
                hashCode = (hashCode*397) ^ (int) MW;
                return hashCode;
            }
        }

        public override string ToString()
        {
            return MX + ", " + MY + ", " + MZ + ", " + MW;
        }
    }
}
