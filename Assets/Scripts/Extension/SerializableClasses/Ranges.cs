namespace Extension.SerializableClasses.Mathematics
{
    using UnityEngine;

    [System.Serializable]
    public class IntRange
    {
        public int min;
        public int max;

        public IntRange(int min = 0, int max = 1)
        {
            max = Mathf.Max(min, max);
            min = Mathf.Min(min, max);

            this.min = min;
            this.max = max;
        }

        public int Random()
        {
            return UnityEngine.Random.Range(min, max + 1);
        }
    }

    [System.Serializable]
    public class FloatRange
    {
        public float min;
        public float max;

        public FloatRange(float min = 0, float max = 1)
        {
            max = Mathf.Max(min, max);
            min = Mathf.Min(min, max);

            this.min = min;
            this.max = max;
        }

        public float Random()
        {
            return UnityEngine.Random.Range(min, max + 1);
        }
    }
}
