using UnityEngine;

namespace TigerTail
{
    public interface IThrowable
    {
        public void Throw(GameObject thrower, Vector3 forceVector);
    }
}