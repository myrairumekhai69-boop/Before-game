using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEventManager : MonoBehaviour
{
    [Header("Scene Event Settings")]
    public string nextSceneName;
    public float delayBeforeLoad = 2f;

    [Header("Optional")]
    public AudioSource transitionSound;
    public Animator fadeAnimator;

    public void TriggerSceneTransition()
    {
        if (transitionSound) transitionSound.Play();
        if (fadeAnimator) fadeAnimator.SetTrigger("FadeOut");

        Invoke(nameof(LoadNextScene), delayBeforeLoad);
    }

    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Next scene not set in SceneEventManager!");
        }
    }
}
