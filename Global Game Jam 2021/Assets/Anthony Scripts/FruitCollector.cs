using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollector : MonoBehaviour
{
    ScreamHandler myScreamHandler;

    [SerializeField]
    FloatReference eatingCooldownTime;

    float eatTimer = 0;
    bool iseating = true;

    // Start is called before the first frame update
    void Start()
    {
        myScreamHandler = GetComponentInParent<ScreamHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (iseating)
        {
            eatTimer += Time.deltaTime;

            if (eatTimer >= eatingCooldownTime.Value)
            {
                iseating = false;
                eatTimer = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BaseFood")
        {
            if (iseating == false)
            {
                if (myScreamHandler.isCoolingDown == false && myScreamHandler.isScreaming == false)
                {
                    iseating = true;
                    Food Temp = other.GetComponent<Food>();
                    myScreamHandler.IncreaseScreamLevel(Temp.PowerValue);
                    Temp.Consume();
                }
            }
            //do any neccessary logic to the food
        }
        else if (other.tag == "SuperFood")
        {
            if (iseating == false)
            {
                if (myScreamHandler.isCoolingDown == false && myScreamHandler.isScreaming == false)
                {
                    iseating = true;
                    Food Temp = other.GetComponent<Food>();
                    myScreamHandler.IncreaseScreamLevel(Temp.PowerValue);
                    Temp.Consume();
                }
            }
            //do any neccessary logic to the food
        }
    }
}
