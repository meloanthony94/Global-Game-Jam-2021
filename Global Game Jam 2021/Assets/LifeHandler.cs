using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeHandler : MonoBehaviour
{
    public int ID;

    [SerializeField]
    UnityEvent deathEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hazard")
        {
            deathEvent.Invoke();
            EventManager.TriggerEvent("PlayerDied", ID);
            //transform.parent.gameObject.SetActive(false);
        }
    }
}
