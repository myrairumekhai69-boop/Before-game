using UnityEngine;
using System.Collections;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    public PlayableDirector introCutscene;
    public bool hasPlayed = false;

    void Start()
    {
        if (introCutscene != null && !hasPlayed)
        {
            StartCoroutine(PlayIntro());
        }
    }

    IEnumerator PlayIntro()
    {
        yield return new WaitForSeconds(2f);
        introCutscene.Play();
        hasPlayed = true;
    }
}
