using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamRing : MonoBehaviour
{
    [SerializeField]
    float growSpeed = 0;

    [SerializeField]
    float travelspeed = 0;

    [SerializeField]
    float lifeTime = 0;
    float Timer = 0;

    [SerializeField]
    Vector3 origin;

    [SerializeField]
    ScreamHandler myScreamHandle;

    // Start is called before the first frame update
    void Start()
    {
        //origin = transform.localPosition;
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Timer = 0;
        transform.localPosition = origin;
        transform.localScale = Vector3.one * 0.1f;

        switch (myScreamHandle.CurrentScreamLevel)
        {
            case 0:
                lifeTime = 0.1f;
                break;

            case 1:
                lifeTime = 0.18f;
                break;

            case 2:
                lifeTime = 0.3f;
                break;

            case 3:
                lifeTime = 0.42f;
                break;

            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (travelspeed * Time.deltaTime));
        transform.localScale += (Vector3.one * growSpeed);

        Timer += Time.deltaTime;
        if (Timer >= lifeTime)
        {
            gameObject.SetActive(false);
        }
    }
}
