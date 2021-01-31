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
        if (other.tag == "BaseFood")
        {
            if (myScreamHandler.isCoolingDown == false && myScreamHandler.isScreaming == false)
            {
                Food Temp = other.GetComponent<Food>();
                myScreamHandler.IncreaseScreamLevel(Temp.PowerValue);
            }
            //do any neccessary logic to the food
        }
        else if (other.tag == "SuperFood")
        {
            if (myScreamHandler.isCoolingDown == false && myScreamHandler.isScreaming == false)
            {
                Food Temp = other.GetComponent<Food>();
                myScreamHandler.IncreaseScreamLevel(Temp.PowerValue);
                Temp.Consume();
            }
            //do any neccessary logic to the food
        }
    }
}
