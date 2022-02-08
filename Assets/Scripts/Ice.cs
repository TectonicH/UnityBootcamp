using System.Collections;
using System.Collections.Generic;
using TigerTail.FPSController;
using UnityEngine;

namespace TigerTail
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider))]
    public class Ice : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out FPSMovement movement))
            {
                movement.IsSliding = true;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out FPSMovement movement))
            {
                movement.IsSliding = false;
            }
        }
    }
}
