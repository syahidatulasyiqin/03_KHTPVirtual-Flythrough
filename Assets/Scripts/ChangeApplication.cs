using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeApplication : MonoBehaviour
{
    // Function to be called when the button is clicked.
    public void ChangeScene(string sceneName)
    {
        StartCoroutine(DelayAndLoadScene(sceneName, 1.0f));
    }

    private IEnumerator DelayAndLoadScene(string sceneName, float delayTime)
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delayTime);

        // Load the scene after the delay
        SceneManager.LoadScene(sceneName);
    }
}
