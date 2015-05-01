﻿namespace KerbalEngineer.VesselSimulator
{
    using System.Collections.Generic;

    public class Pool<T> where T : new()
    {
        private static List<T> available = new List<T>();
        private static List<T> inUse = new List<T>();

        public static int PoolCount
        {
            get
            {
                return available.Count + inUse.Count;
            }
        }

        public static T GetPoolObject()
        {
            T obj;
            if (available.Count > 0)
            {
                obj = available[0];
                available.RemoveAt(0);
            }
            else
            {
                obj = new T();
            }

            inUse.Add(obj);
            return obj;
        }

        public static void Release(T obj)
        {
            if (inUse.Contains(obj))
            {
                inUse.Remove(obj);
                available.Add(obj);
            }
        }

        public static void ReleaseAll()
        {
            for (int i = 0; i < inUse.Count; ++i)
            {
                available.Add(inUse[i]);
            }
            inUse.Clear();
        }
    }
}