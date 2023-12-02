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

    public float seekDuration = 5f; // Duration to seek forward or backward

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
        SceneManager.LoadScene("01_Landing 1");
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

    public void FastForward()
    {
        videoPlayer.Pause(); // Pause the video

        // Calculate the new time to seek forward
        double newTime = videoPlayer.time + seekDuration;
        if (newTime < videoPlayer.length)
        {
            videoPlayer.time = newTime; // Seek the video forward
        }

        videoPlayer.Play(); // Resume playing

        // Update UI or perform other tasks if needed
    }

    public void Rewind()
    {
        videoPlayer.Pause(); // Pause the video

        // Calculate the new time to seek backward
        double newTime = videoPlayer.time - seekDuration;
        if (newTime > 0)
        {
            videoPlayer.time = newTime; // Seek the video backward
        }
        else
        {
            videoPlayer.time = 0; // Rewind to the beginning if seeking beyond start
        }

        videoPlayer.Play(); // Resume playing

        // Update UI or perform other tasks if needed
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
