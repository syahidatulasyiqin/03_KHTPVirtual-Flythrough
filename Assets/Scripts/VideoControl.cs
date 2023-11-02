using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoControl : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private Image playPauseButtonImage;
    public Sprite playIcon;
    public Sprite pauseIcon;
    public Text durationText;

    private bool videoEnded = false;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        playPauseButtonImage = GameObject.Find("PlayPauseButton").GetComponent<Image>();

        UpdatePlayPauseButtonImage();
        DisplayRemainingTime(videoPlayer.length);

        // Add a listener for the loop point reached event
        videoPlayer.loopPointReached += OnVideoEnded;
    }

    private void Update()
    {
        DisplayRemainingTime(videoPlayer.length - videoPlayer.time);

        if (videoPlayer.isPlaying)
        {
            UpdatePlayPauseButtonImage();
        }
    }

    private void OnVideoEnded(VideoPlayer vp)
    {
        // Replace "YourSceneName" with the actual scene name you want to load after the video ends.
        SceneManager.LoadScene("01_Landing");
    }

    public void PlayPauseVideo()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }

        UpdatePlayPauseButtonImage();
    }

    public void StopVideo()
    {
        videoPlayer.frame = 0;  // Set the frame to 0 to start from the beginning
        videoPlayer.Play();  // Play the video
        UpdatePlayPauseButtonImage();  // Update the play/pause button image
    }

    private void UpdatePlayPauseButtonImage()
    {
        if (videoPlayer.isPlaying)
        {
            playPauseButtonImage.sprite = pauseIcon;
        }
        else
        {
            playPauseButtonImage.sprite = playIcon;
        }
    }

    private void DisplayRemainingTime(double remainingTime)
    {
        if (durationText != null)
        {
            int hours = Mathf.FloorToInt((float)remainingTime / 3600);
            int minutes = Mathf.FloorToInt((float)(remainingTime - hours * 3600) / 60);
            int seconds = Mathf.FloorToInt((float)(remainingTime - hours * 3600 - minutes * 60));

            durationText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
        }
    }
}
