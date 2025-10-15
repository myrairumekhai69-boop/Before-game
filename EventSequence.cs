using UnityEngine;
using System.Collections;

public class EventSequence : MonoBehaviour
{
    public ExplosionTrigger hospitalExplosion;
    public NPCPanicTrigger[] npcs;
    public float delayBeforeExplosion = 2f;
    public float delayBeforeNPCs = 4f;

    void Start()
    {
        StartCoroutine(RunEvents());
    }

    IEnumerator RunEvents()
    {
        yield return new WaitForSeconds(delayBeforeExplosion);
        hospitalExplosion.TriggerExplosion();

        yield return new WaitForSeconds(delayBeforeNPCs);
        foreach (var npc in npcs)
        {
            npc.Panic();
        }
    }
}
