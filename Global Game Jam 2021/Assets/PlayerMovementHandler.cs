using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHandler : MonoBehaviour
{
    [SerializeField]
    int playerIndex = 0;

    [SerializeField]
    float speed = 2;


    Rigidbody myRB;

    [SerializeField]
    FloatReference HorizontalReference;
    [SerializeField]
    FloatReference VerticalReference;

    [SerializeField]
    BoolReference inputlock;

    Vector2 moveValue;

    // Start is called before the first frame update
    void Awake()
    {

        myRB = GetComponent<Rigidbody>();
    }

    public int GetIndex()
    {
        return playerIndex;
    }

    void Move()
    {
        //Vector2 m = new Vector2(HorizontalReference.Value, VerticalReference.Value) * Time.deltaTime;
        //transform.Translate(m * speed, Space.World);

        Vector3 dir = new Vector3(HorizontalReference.Value, 0, VerticalReference.Value);
        myRB.AddForce(dir * speed, ForceMode.Impulse);
    }

    public void Move(Vector2 value)
    {
        Vector2 m = new Vector2(HorizontalReference.Value, VerticalReference.Value) * Time.deltaTime;
        transform.Translate(m * speed, Space.World);

        //Vector3 dir = new Vector3(value.x, 0, value.y);
        //print(dir);
        //Quaternion targetRotation = Quaternion.LookRotation(dir, Vector3.back);
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);

        //transform.Rotate((Vector3.one * value.x) * Time.deltaTime * speed);

        //myRB.AddForce(dir * speed, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        if(inputlock.Value == false)
            Move();
    }

    private void OnDisable()
    {

    }
}