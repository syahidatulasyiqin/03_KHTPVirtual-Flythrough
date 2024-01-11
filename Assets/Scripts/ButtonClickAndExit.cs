using UnityEngine;
using UnityEngine.UI;

public class ButtonClickAndExit : MonoBehaviour
{
    public Button exitButton;
    private int clickCount = 0;
    private float clickTimer = 2f; // Adjust this value for the maximum time between clicks
    private bool isCounting = false;

    void Start()
    {
        exitButton.onClick.AddListener(ExitApplication);
    }

    void Update()
    {
        // Check if the timer is running and reduce its value each frame
        if (isCounting)
        {
            clickTimer -= Time.deltaTime;

            // Reset the click count and timer if the timer reaches zero
            if (clickTimer <= 0f)
            {
                clickCount = 0;
                clickTimer = 2f; // Reset the timer value
                isCounting = false;
            }
        }
    }

    void ExitApplication()
    {
        clickCount++;

        if (clickCount >= 3)
        {
            Debug.Log("Application Quitting...");

            if (Application.isEditor)
            {
                Debug.Log("Application Quit command ignored in Editor.");
            }
            else
            {
                Application.Quit();
            }
        }
        else
        {
            // Start/reset the timer after each click
            isCounting = true;
        }
    }
}
