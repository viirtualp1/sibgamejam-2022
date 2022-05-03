using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionAfterCutscene : MonoBehaviour
{
    public int secWait;
    public int sceneTransition;

    private void Start()
    {
        StartCoroutine(DelayTime());
    }

    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(secWait);
        SceneManager.LoadScene(sceneTransition);
    }
}
