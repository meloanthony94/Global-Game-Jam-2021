using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollector : MonoBehaviour
{
    ScreamHandler myScreamHandler;

    [SerializeField]
    FloatReference eatingCooldownTime;

    // Start is called before the first frame update
    void Start()
    {
        myScreamHandler = GetComponentInParent<ScreamHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BaseFood" || other.tag == "Test1")
        {
            myScreamHandler.IncreaseScreamLevel(1);
            //do any neccessary logic to the food
        }
        else if (other.tag == "SuperFood" || other.tag == "Test2")
        {
            myScreamHandler.IncreaseScreamLevel(2);
            //do any neccessary logic to the food
        }
    }
}
