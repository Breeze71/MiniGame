using System;
using UnityEngine;

namespace V.Core
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class InteractableBase : MonoBehaviour
    {
        private const string Player = "Player";

        [SerializeField] protected Collider2D coll;
        //[SerializeField] protected GameObject icon;

        protected Movement playerMovement;

        private bool canInteract;

        protected virtual void Update() 
        {
            if(!canInteract)    return;

            Interact();
        }

        public abstract void Interact();
        public virtual void ExitTrigger() { }

        protected virtual void OnTriggerEnter2D(Collider2D _other)
        {
            if(_other.gameObject.tag == Player)
            {
                //icon.SetActive(true);
                playerMovement = _other.GetComponent<Movement>();
                canInteract = true;
            }
        }
        protected virtual void OnTriggerExit2D(Collider2D _other) 
        {
            if(_other.gameObject.tag == Player)
            {
                //icon.SetActive(false);
                canInteract = false;

                ExitTrigger();
            }
        }
    }
}