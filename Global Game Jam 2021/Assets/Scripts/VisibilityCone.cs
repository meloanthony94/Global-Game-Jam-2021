using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityCone : MonoBehaviour
{
    [Header("Pause Status")]
    [SerializeField]
    BoolReference pauseStatus;

    [Header("Scriptable Objects")]
    [SerializeField]
    BoolReference detectionStatus;

    //[SerializeField]
    //GameObjectPool IndicatorLinePool;

    //[SerializeField]
    //public DictionaryTransformFloatReference targetsInCone;

    [Header("Cone Settings")]
    [SerializeField]
    public FloatReference viewRadius;
    [SerializeField]
    public FloatReference viewAngle;

    [Header("Visualization Lines")]
    [SerializeField]
    LineRenderer ArcLineA;
    [SerializeField]
    LineRenderer ArcLineB;

    List<GameObject> indicatorLineList = new List<GameObject>();

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pauseStatus.Value == false)
        {
            if (detectionStatus.Value == true)
            {
                DrawCone();
                //DrawIndicators();
            }
            else if (detectionStatus.Value == false)
            {
                ClearIndicators();
                ArcLineA.enabled = false;
                ArcLineB.enabled = false;
            }
        }
    }

    void DrawCone()
    {
        Vector3 viewAngleA = DirFromAngle(-viewAngle.Value / 2, false);
        Vector3 viewAngleB = DirFromAngle(viewAngle.Value / 2, false);

        ArcLineA.enabled = true;
        ArcLineA.SetPosition(0, transform.position);
        ArcLineA.SetPosition(1, transform.position + viewAngleA * viewRadius.Value);

        ArcLineB.enabled = true;
        ArcLineB.SetPosition(0, transform.position);
        ArcLineB.SetPosition(1, transform.position + viewAngleB * viewRadius.Value);
    }

    /*
    void DrawIndicators()
    {
        int index = 0;
        foreach (var item in targetsInCone.Value.Keys)
        {
            if ((indicatorLineList.Count > 0) && (targetsInCone.Value.Count <= indicatorLineList.Count))
            {
                indicatorLineList[index].SetActive(true);
                indicatorLineList[index].GetComponent<LineRenderer>().SetPosition(0, transform.position);
                indicatorLineList[index].GetComponent<LineRenderer>().SetPosition(1, item.position);
            }
            else
            {
                var line = IndicatorLinePool.Get();
                line.GetComponent<LineRenderer>().SetPosition(0, transform.position);
                line.GetComponent<LineRenderer>().SetPosition(1, item.position);
                line.SetActive(true);
                indicatorLineList.Add(line);
            }

            index++;
        }

        if (indicatorLineList.Count > targetsInCone.Value.Count)
        {
            for (int i = targetsInCone.Value.Count; i < indicatorLineList.Count; i++)
            {
                indicatorLineList[i].SetActive(false);
            }
        }
    }
    */
    void ClearIndicators()
    {
        for (int i = 0; i < indicatorLineList.Count; i++)
        {
            indicatorLineList[i].SetActive(false);
        }

        indicatorLineList.Clear();
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += -transform.eulerAngles.z;
        }

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    public void ShowCone()
    {

    }
}
