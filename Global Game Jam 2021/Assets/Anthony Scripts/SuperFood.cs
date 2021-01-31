using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SuperFood : Food
{
    public struct SuperFoodData
    {
        public int id;
        public int position;

        public SuperFoodData(int ID, int Position)
        {
            this.id = ID;
            this.position = Position;
        }
    }
    private SuperFoodData data;
    public SuperFoodData Data
    {
        get { return data; }
        set { data = value; }
    }

    [SerializeField]
    private float respawnTimer = 2.0f;

    [SerializeField]
    UnityEvent ConsumeEvent;

    public override void Consume()
    {
        try
        {
            ConsumeEvent.Invoke();
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        catch (System.Exception)
        {
            throw;
        }

        StartCoroutine(waitToRespawn());
    }

    private IEnumerator waitToRespawn()
    {
        while (respawnTimer > 0)
        {
            respawnTimer -= Time.deltaTime;

            if (respawnTimer <= 0)
            {
                EventManager.TriggerEvent("RespawnSuperFood", data.id);
                respawnTimer = 2.0f;
                this.gameObject.GetComponent<BoxCollider>().enabled = true;
                this.gameObject.GetComponent<MeshRenderer>().enabled = true;

                yield break;
            }

            yield return null;
        }
    }
}