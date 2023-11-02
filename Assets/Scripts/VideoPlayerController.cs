using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class VideoPlayerController : MonoBehaviour
{
    public string[] videoFilePaths; // Array of local video file paths to play

    private VideoPlayer videoPlayer;
    private int selectedVideoIndex;

    public string[] videoTitles; // Array of video titles

    public TextMeshProUGUI textMeshProComponent; // Reference to the TextMeshPro component

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        // Get the selected video index set in Scene A
        selectedVideoIndex = PlayerPrefs.GetInt("SelectedVideoIndex", 0);

        // Play the selected video
        if (selectedVideoIndex >= 0 && selectedVideoIndex < videoFilePaths.Length)
        {
            // Set the video URL to the local file path
            videoPlayer.url = "file://" + videoFilePaths[selectedVideoIndex];
            videoPlayer.Play();
        }

        if (selectedVideoIndex < videoTitles.Length)
        {
            // Set the TextMeshPro text to the corresponding video title
            textMeshProComponent.text = videoTitles[selectedVideoIndex];
        }
    }
}
