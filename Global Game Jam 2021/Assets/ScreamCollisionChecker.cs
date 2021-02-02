using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamCollisionChecker : MonoBehaviour
{
    [SerializeField]
    ScreamHandler myScreamHandler;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<Rigidbody>() == null)
            {

                other.transform.parent.GetComponentInChildren<Rigidbody>().AddForce(transform.forward * myScreamHandler.ScreamDataSet[myScreamHandler.CurrentScreamLevel].PushPower.Value, ForceMode.VelocityChange);
            }
            else
            {
                other.GetComponent<Rigidbody>().AddForce(transform.forward * myScreamHandler.ScreamDataSet[myScreamHandler.CurrentScreamLevel].PushPower.Value, ForceMode.VelocityChange);
            }
        }
    }
}
