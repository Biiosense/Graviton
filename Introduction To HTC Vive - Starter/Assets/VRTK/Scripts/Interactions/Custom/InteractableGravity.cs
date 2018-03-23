using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
    public class InteractableGravity : VRTK_InteractableObject
    {


        /// <summary>
        /// The StartUsing method is called automatically when the object is used initially. It is also a virtual method to allow for overriding in inherited classes.
        /// </summary>
        /// <param name="currentUsingObject">The object that is currently using this object.</param>
        public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
        {
            GameObject currentUsingGameObject = (currentUsingObject != null ? currentUsingObject.gameObject : null);
            ToggleEnableState(true);
            if (IsUsing() && !IsUsing(currentUsingGameObject))
            {
                ResetUsingObject();
            }
            OnInteractableObjectUsed(SetInteractableObjectEvent(currentUsingGameObject));
            usingObject = currentUsingObject;

            GetComponent<Rigidbody>().useGravity = false;

        }
    }
}
