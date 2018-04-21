using UnityEngine;

namespace code.util
{
    public static class Noise
    {
        public static float ExpRand(float randNum, float max)
        {
            var scale = 1 / Mathf.Log(0.5f * (max + 2.0f));

            return -scale * Mathf.Log(0.5f * randNum + 1.0f) + 1.0f;
        }
    }
}