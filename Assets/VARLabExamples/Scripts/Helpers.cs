using System.Collections.Generic;
using UnityEngine;

namespace TigerTail
{
    public static class Helpers
    {
        public static bool TryGetInterfaces<T>(out List<T> resultList, GameObject objectToSearch) where T : class
        {
            MonoBehaviour[] list = objectToSearch.GetComponents<MonoBehaviour>();
            resultList = new List<T>();
            var found = false;
            foreach (MonoBehaviour mb in list)
            {
                if (mb is T)
                {
                    resultList.Add((T)((System.Object)mb));
                    found = true;
                }
            }

            return found;
        }

        public static bool TryGetInterface<T>(out T result, GameObject objectToSearch) where T : class
        {
            MonoBehaviour[] list = objectToSearch.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour mb in list)
            {
                if (mb is T)
                {
                    result = (T)((System.Object)mb);
                    return true;
                }
            }

            result = null;
            return false;
        }
    }
}
