using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class VideoSelection : MonoBehaviour
{
    public string videoSceneName = "02_Console"; // Name of the scene where videos will be played
    public int selectedVideoIndex = 0; // Index of the selected video
    
    public Animator musicAnim;
    public float waitTime;

    public void PlaySelectedVideo()
    {
        // Set the selected video index and start the delay coroutine
        PlayerPrefs.SetInt("SelectedVideoIndex", selectedVideoIndex);
        StartCoroutine(DelayBeforeLoadingScene());
    }

    private IEnumerator DelayBeforeLoadingScene()
    {
        musicAnim.SetTrigger("fadeOut");
        // Wait for 2 seconds
        yield return new WaitForSeconds(waitTime);

        // Load the video scene after the delay
        SceneManager.LoadScene(videoSceneName);
    }
}
