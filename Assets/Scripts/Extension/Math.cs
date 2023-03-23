namespace Extension.Mathematics
{
    using UnityEngine;

    /// <summary>
    /// This class is an extension methods holder abount math calculations.
    /// </summary>
    public static class Math
    {
        /// <summary>
        /// Return the percent of the number based on the max number given
        /// </summary>
        /// <param name="n">number</param>
        /// <param name="max">max number</param>
        /// <returns>percentage</returns>
        public static float Percent(float n, float max)
        {
            return (n / max) * 100f;
        }

        public static float AsPercentOf(this float n, float max)
        {
            return (n / max) * 100f;
        }

        public static bool RollAChance(uint probability, uint possibilities)
        {
            return Random.Range(0, possibilities) >= (possibilities - probability);
        }

        public static bool IsApproximatelyEqual(float a, float b, float tollerance)
        {
            a = Mathf.Max(a, b);
            b = Mathf.Min(a, b);

            return (a - b < tollerance);
        }

        public static bool IsApproximatelyEqualTo(this float myNumber, float number, float tollerance)
        {
            myNumber = Mathf.Max(myNumber, number);
            number = Mathf.Min(myNumber, number);

            return (myNumber - number < tollerance);
        }
    }
}
