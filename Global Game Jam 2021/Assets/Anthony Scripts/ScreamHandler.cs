using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScreamHandler : MonoBehaviour
{
    [System.Serializable]
    struct ScreamLevelData
    {
        public FloatReference screamAngle;

        public FloatReference screamRadius;

        public AudioClip screamAudioClip;
    }

    VisibilityCone screamDebug;

    [SerializeField]
    TextMeshProUGUI tempScreamUI;

    [SerializeField]
    ScreamLevelData[] ScreamDataSet;

    [SerializeField]
    FloatReference ScreamDuration;

    [SerializeField]
    FloatReference ScreamCooldown;

    [SerializeField]
    int currentScreamLevel = 0;

    const int MaxScreamLevel = 3;

    float screamTimer = 0;
    bool isScreaming = false;
    bool isCoolingDown = false;

    // Start is called before the first frame update
    void Start()
    {
        screamDebug = GetComponentInChildren<VisibilityCone>();
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
            }
        }
    }

    public void PerformScream()
    {
        if (isCoolingDown == false && isScreaming == false)
        {
            ApplyScreamLevel();
            isScreaming = true;
            screamDebug.IsActive = true;
            currentScreamLevel = 0;
            tempScreamUI.text = currentScreamLevel.ToString();
        }
    }

    void ApplyScreamLevel()
    {
        screamDebug.viewRadius = ScreamDataSet[currentScreamLevel].screamRadius;
        screamDebug.viewAngle = ScreamDataSet[currentScreamLevel].screamAngle;
    }

    public void IncreaseScreamLevel(int value)
    {
        currentScreamLevel += value;

        currentScreamLevel = Mathf.Clamp(currentScreamLevel, 0, MaxScreamLevel);

        tempScreamUI.text = currentScreamLevel.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BaseFood" || other.tag == "Test1")
        {
            IncreaseScreamLevel(1);
            //do any neccessary logic to the food
        }
        else if (other.tag == "SuperFood" || other.tag == "Test2")
        {
            IncreaseScreamLevel(2);
            //do any neccessary logic to the food
        }
    }
}
