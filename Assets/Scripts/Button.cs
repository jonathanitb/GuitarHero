using UnityEngine;
using UnityEngine.Events;

namespace Interactables
{
    [System.Serializable]
    public class OnButtonEvent : UnityEvent { }

    public class Button : MonoBehaviour
    {
        [SerializeField] private OnButtonEvent onEnter;
        [SerializeField] private OnButtonEvent onExit;
  


 

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
            
                onEnter.Invoke();
               
            }
         
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            onExit.Invoke();
        }
    }
}
