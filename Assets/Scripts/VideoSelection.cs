using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class VideoSelection : MonoBehaviour
{
    public string videoSceneName = "02_Console"; // Name of the scene where videos will be played
    public int selectedVideoIndex = 0; // Index of the selected video

    public void PlaySelectedVideo()
    {
        // Set the selected video index and start the delay coroutine
        PlayerPrefs.SetInt("SelectedVideoIndex", selectedVideoIndex);
        StartCoroutine(DelayBeforeLoadingScene());
    }

    private IEnumerator DelayBeforeLoadingScene()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(1.5f);

        // Load the video scene after the delay
        SceneManager.LoadScene(videoSceneName);
    }
}
