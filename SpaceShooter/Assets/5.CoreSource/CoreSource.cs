using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace MYSourceEngine
{
    public static class Ex_Core
    {
        public static T Rand<T>(this T[] p_arr)// where T : class
        {
            if (p_arr.Length <= 0)
            {
                return default(T);
            }

            int rand = UnityEngine.Random.Range(0, p_arr.Length);
            return p_arr[rand];
        }
    }
}


