using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Alphamplyer.Pong
{
    public static class RandomUtils
    {
        /// <summary>
        /// Return a random direction, pointing to the right, constraint by angle. Angle must be contained between -90 and 90
        /// </summary>
        /// <param name="minAngle">minimum angle</param>
        /// <param name="maxAngle">maximum angle</param>
        /// <returns>A random direction</returns>
        public static Vector3 GetRandomRightDirection(float minAngle, float maxAngle)
        {
            #if UNITY_EDITOR
            if (minAngle > maxAngle)
                throw new Exception("minAngle must be lower than maxAngle");
            if (maxAngle > 90f || maxAngle < -90f || minAngle > 90f || minAngle < -90f)
                throw new Exception("maxAngle or minAngle must be contain between -90 and 90 degrees");
            #endif
            
            var randomAngle = Random.Range(minAngle, maxAngle) * Mathf.Deg2Rad;
            
            var x = Mathf.Cos(randomAngle);
            var y = Mathf.Sin(randomAngle);
            
            return new Vector3(x, y);
        }
        
        /// <summary>
        /// Return one element of the given array
        /// </summary>
        /// <param name="array">The array of elements</param>
        /// <typeparam name="T">The type of array elements</typeparam>
        /// <returns>One element of the given array</returns>
        public static T ReturnOneOf<T> (T[] array)
        {
            #if UNITY_EDITOR
            if (array.Length == 0)
                throw new Exception("The array must not be empty");
            #endif
            
            return array[Random.Range(0, array.Length - 1)];
        }
    }
}