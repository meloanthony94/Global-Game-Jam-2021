using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovementHandler : MonoBehaviour
{
    Vector3 originPos;

    [SerializeField]
    Transform offsetPos;

    float headOffset = 0;

    [SerializeField]
    FloatReference Horizontal;
    [SerializeField]
    FloatReference Vertical;

    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.position;

        headOffset = transform.position.y - offsetPos.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3( offsetPos.position.x, offsetPos.position.y + headOffset, offsetPos.position.z);

        if (Horizontal.Value != 0 || Vertical.Value != 0)
        {
            Vector3 lookDirection = new Vector3(Horizontal.Value, 0, Vertical.Value);
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }
}
