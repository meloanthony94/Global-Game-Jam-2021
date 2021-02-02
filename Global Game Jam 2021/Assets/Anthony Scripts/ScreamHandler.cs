using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScreamHandler : MonoBehaviour
{
    [System.Serializable]
    public struct ScreamLevelData
    {
        public FloatReference PushPower;

        public FloatReference screamAngle;

        public FloatReference screamRadius;

        public AudioClip screamAudioClip;
    }

    VisibilityCone screamDebug;
    WithinConeDetector inConeChecker;

    [SerializeField]
    public ScreamLevelData[] ScreamDataSet;

    [SerializeField]
    FloatReference ScreamDuration;

    [SerializeField]
    FloatReference ScreamCooldown;

    [SerializeField]
    int currentScreamLevel = 0;

    const int MaxScreamLevel = 3;

    float screamTimer = 0;
    public bool isScreaming = false;
    public bool isCoolingDown = false;

    public int CurrentScreamLevel { get => currentScreamLevel; set => currentScreamLevel = value; }

    public int ID = 0;

    // Start is called before the first frame update
    void Awake()
    {
        screamDebug = GetComponentInChildren<VisibilityCone>();
        inConeChecker = GetComponentInChildren<WithinConeDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isScreaming)
        {
            screamTimer += Time.deltaTime;
            if (screamTimer >= ScreamDuration.Value)
            {
                screamTimer = 0;
                isScreaming = false;
                isCoolingDown = true;
                inConeChecker.IsActive = false;
                screamDebug.IsActive = false;
            }
        }

        if (isCoolingDown)
        {
            screamTimer += Time.deltaTime;
            if (screamTimer >= ScreamCooldown.Value)
            {
                screamTimer = 0;
                isCoolingDown = false;
                //inConeChecker.IsActive = false;
                CurrentScreamLevel = 0;
            }
        }
    }

    public void PerformScream()
    {
        if (isCoolingDown == false && isScreaming == false)
        {
            EventManager.TriggerEvent("Scream", ID);
            ApplyScreamLevel();
            isScreaming = true;
            screamDebug.IsActive = true;
            inConeChecker.IsActive = true;
        }
    }

    void ApplyScreamLevel()
    {
        if (screamDebug)
        {
            screamDebug.viewRadius = ScreamDataSet[CurrentScreamLevel].screamRadius;
            screamDebug.viewAngle = ScreamDataSet[CurrentScreamLevel].screamAngle;
        }
    }

    public void IncreaseScreamLevel(int value)
    {
        CurrentScreamLevel += value;

        for (int i = 0; i < value; i++)
        {
            EventManager.TriggerEvent("ScreamLevelChanged", ID);
        }

        CurrentScreamLevel = Mathf.Clamp(CurrentScreamLevel, 0, MaxScreamLevel);

        //inConeChecker.ConeCheck();
    }

  //  private void OnTriggerEnter(Collider other)
  //  {
  //      if (other.tag == "BaseFood" || other.tag == "Test1")
  //      {
  //          IncreaseScreamLevel(1);
  //          //do any neccessary logic to the food
  //      }
  //      else if (other.tag == "SuperFood" || other.tag == "Test2")
  //      {
  //          IncreaseScreamLevel(2);
  //          //do any neccessary logic to the food
  //      }
  //  }
}
