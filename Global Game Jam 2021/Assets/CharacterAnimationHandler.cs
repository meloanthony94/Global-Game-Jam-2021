using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationHandler : MonoBehaviour
{
    [SerializeField]
    ScreamHandler myScreamHandler;

    [SerializeField]
    FloatReference modelChoice;

    SkinnedMeshRenderer myMeshRenderer;

    [SerializeField]
    CharacterModelSelector myModel;

    [SerializeField]
    int[] blendTargets;

    [SerializeField]
    float rampTime = 0;

    float holdTime;

    int currentBlendTarget = 0;

    float yellHoldTimer = 0;

    bool isYelling = false;
    bool isWindingUp = false;
    bool isWindingDown = false;


    //Lerp Stuff
    protected float timeSinceStarted = 0;
    protected float lerpTime = 0;
    protected float timeStartedLerping = 0;
    protected float percentageComplete = 0;

    // Start is called before the first frame update
    void Start()
    {
        myMeshRenderer = myModel.Models[(int)modelChoice.Value].GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWindingUp)
        {
            if (percentageComplete < 1)
            {
                timeSinceStarted = Time.time - timeStartedLerping;
                percentageComplete = timeSinceStarted / lerpTime;

                myMeshRenderer.SetBlendShapeWeight(0, Mathf.Lerp(0, currentBlendTarget, percentageComplete));

                if (percentageComplete >= 1.0f)
                {
                    isWindingUp = false;
                    isYelling = true;
                }
            }
        }

        if (isYelling)
        {
            yellHoldTimer += Time.deltaTime;

            if (yellHoldTimer >= (holdTime * 0.8f))
            {
                yellHoldTimer = 0;
                isYelling = false;
                isWindingDown = true;
                Reset(rampTime);
            }
        }

        if (isWindingDown)
        {
            if (percentageComplete < 1)
            {
                timeSinceStarted = Time.time - timeStartedLerping;
                percentageComplete = timeSinceStarted / lerpTime;

                myMeshRenderer.SetBlendShapeWeight(0, Mathf.Lerp(currentBlendTarget, 0, percentageComplete));

                if (percentageComplete >= 1.0f)
                {
                    isWindingDown = false;
                    //Reset(rampTime);
                }
            }
        }
    }

   // if (percentageComplete< 1)
   //    {
   //        timeSinceStarted = Time.time - timeStartedLerping;
   //        percentageComplete = timeSinceStarted / lerpTime;
   //
   //        transform.position = Vector3.Lerp(startPos, endPos, percentageComplete);
   //
   //        if (percentageComplete >= 1.0f)
   //        {
   //            //EEndOfLevelReached.Raise();
   //        }
   //    }
   //}

    public void BeginYell(float value)
    {
        if (myMeshRenderer != null)
        {
            holdTime = value;
            myMeshRenderer.SetBlendShapeWeight(0, 0);
            currentBlendTarget = blendTargets[myScreamHandler.CurrentScreamLevel];
            Reset(rampTime);
            isWindingUp = true;
            isWindingDown = false;
            isYelling = false;
        }
    }

    protected void Reset(float targetTime)
    {
        percentageComplete = 0;
        timeSinceStarted = 0;
        timeStartedLerping = Time.time;
        lerpTime = targetTime;
    }
}
