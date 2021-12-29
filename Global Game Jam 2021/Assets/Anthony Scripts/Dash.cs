using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField]
    FloatReference Horizontal;
    [SerializeField]
    FloatReference Vertical;

    [SerializeField]
    FloatReference DashSpeed;
    [SerializeField]
    FloatReference DashDuration;
    [SerializeField]
    FloatReference DashCooldown;

    [SerializeField]
    BoolReference inputLock;

    Rigidbody myRB;

    float dashCooldownTimer = 0;
    float dashDurationTimer = 0;
    bool isDashing = false;
    bool isCoolingDown = false;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetKeyDown(KeyCode.Space))
       // {
       //     PerformDash();
       // }

        if (isDashing)
        {
            dashDurationTimer += Time.deltaTime;

            if (dashDurationTimer > DashDuration.Value)
            {
                dashDurationTimer = 0;
                isDashing = false;
                inputLock.Value = false;
                isCoolingDown = true;
                //myRB.velocity = Vector3.zero;
            }
        }

        if (isCoolingDown)
        {
            dashCooldownTimer += Time.deltaTime;

            if (dashCooldownTimer > DashCooldown.Value)
            {
                dashCooldownTimer = 0;
                isCoolingDown = false;
            }
        }
    }

    public void PerformDash()
    {
        if (isCoolingDown == false && isDashing == false)
        {
            Vector3 dir = new Vector3(Horizontal.Value, 0, Vertical.Value);
            myRB.AddForce(dir * DashSpeed.Value, ForceMode.Impulse);
            isDashing = true;
        }
    }


}
