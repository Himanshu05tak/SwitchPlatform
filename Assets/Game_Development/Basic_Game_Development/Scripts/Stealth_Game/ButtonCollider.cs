using UnityEngine;
using UnityEngine.Events;

public class ButtonCollider : MonoBehaviour
{
    public UnityEvent onSpaceBar;
    public UnityEvent onReturn;

    public void OnTriggerStay()
    {
            Debug.Log("Player is in range");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (onSpaceBar != null)
                    onSpaceBar.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (onReturn != null)
                    onReturn.Invoke();
            }
    }
}
