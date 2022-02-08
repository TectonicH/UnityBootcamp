using UnityEngine;

namespace TigerTail.FPSController
{
    [DisallowMultipleComponent]
    public class Player : MonoBehaviour, IPickerUpper
    {
        [Tooltip("The transform pickups should be parented to for holding/throwing.")]
        [SerializeField] private Transform pickupLocation;

        /// <summary>Currently held pickup.</summary>
        private IPickup pickup;

        [Tooltip("Force to apply to thrown objects. (Mass-dependant)")]
        [Range(500,5000)]
        [SerializeField] private float throwForce = 2000f;

        private void Update()
        {
            HandleThrowing();
        }

        private void HandleThrowing()
        {
            if (Input.GetMouseButtonUp(0) && pickup != null)
            {
                if (pickup is IThrowable)
                {
                    (pickup as IThrowable).Throw(gameObject, pickupLocation.forward * throwForce);
                    pickup = null;
                }
            }
        }

        public void PickupObject(IPickup pickup)
        {
            if (this.pickup != null) // Don't pick up an object if we already have one picked up.
                return;

            pickup.SetParentPoint(pickupLocation);        

            this.pickup = pickup;
        }
    }
}
