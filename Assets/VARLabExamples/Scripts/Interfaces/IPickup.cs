using UnityEngine;

namespace TigerTail
{
    public interface IPickup
    {
        public void Pickup(GameObject obj);
        public void SetParentPoint(Transform point);
    }
}