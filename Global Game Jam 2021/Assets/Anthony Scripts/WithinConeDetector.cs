using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithinConeDetector : MonoBehaviour
{
    //[SerializeField]
    //DictionaryTransformFloatReference CurrentTargetsInCone;

    [SerializeField]
    FloatReference Horizontal;
    [SerializeField]
    FloatReference Vertical;

    [SerializeField]
    bool isActive = false;
    public bool IsActive { get => isActive; set => isActive = value; }

    [Header("Cone Settings")]
    [SerializeField]
    public float viewRadius;

    [SerializeField]
    public float viewAngle;

    [Header("Physics Masks")]
    [SerializeField]
    LayerMask targetMask;
    [SerializeField]
    LayerMask obstacleMask;

    ScreamHandler myScreamHandler;

    List<Transform> OutofBoundsList = new List<Transform>();

    [SerializeField]
    GameObject cone;
    [SerializeField]
    Collider coneCollider;

    [SerializeField]
    GameObject[] ConeSizes;

    private void Awake()
    {
        //CurrentTargetsInCone.Value.Clear();
        myScreamHandler = GetComponentInParent<ScreamHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        ConeCheck(isActive);
    }

    public void ConeCheck(bool value)
    {
        if(value == false)
        {
            for (int i = 0; i < ConeSizes.Length; i++)
            {
                ConeSizes[i].SetActive(false);
            }
        }
        else
        {
            ConeSizes[myScreamHandler.CurrentScreamLevel].SetActive(true);
        }
    }

    void ConeSizeChange()
    {

        //cone.transform.localScale = new Vector3(cone.transform.localScale.x, cone.transform.localScale.y, myScreamHandler.ScreamDataSet[myScreamHandler.CurrentScreamLevel].screamRadius.Value);
    }

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

    void FindVisibleTarget() 
    {
        viewRadius = myScreamHandler.ScreamDataSet[myScreamHandler.CurrentScreamLevel].screamRadius.Value;
        viewAngle = myScreamHandler.ScreamDataSet[myScreamHandler.CurrentScreamLevel].screamAngle.Value;


        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            //print(targetsInViewRadius[i].name);
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            //Check if inside cone
            float ang = Vector3.Angle(transform.forward, dirToTarget);
            print(ang);
            if (ang <= viewAngle)
            {
                print(targetsInViewRadius[i].name);
                float distToTarget = Vector3.Distance(transform.position, target.position);

                //blocked by obstacle
                if (Physics.Raycast(transform.position, dirToTarget, distToTarget, obstacleMask))
                {
                   
                }

                Vector3 dir = new Vector3(Horizontal.Value, 0, Vertical.Value);
                targetsInViewRadius[i].GetComponent<Rigidbody>().AddForce(transform.forward * myScreamHandler.ScreamDataSet[myScreamHandler.CurrentScreamLevel].PushPower.Value, ForceMode.VelocityChange);
                //
            }
        }
        //
    }
}
