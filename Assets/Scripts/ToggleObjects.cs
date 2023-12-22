using UnityEngine;
using System.Collections;

public class ToggleObjects : MonoBehaviour
{
    public GameObject gameObjectToActivate;
    public GameObject gameObjectToDeactivate;

    public void OnButtonClick()
    {
        StartCoroutine(ToggleWithDelay());
    }

    IEnumerator ToggleWithDelay()
    {
        yield return new WaitForSeconds(1f); // Adjust the delay time here (2 seconds in this case)

        if (gameObjectToActivate != null)
        {
            gameObjectToActivate.SetActive(true);
        }

        if (gameObjectToDeactivate != null)
        {
            gameObjectToDeactivate.SetActive(false);
        }
    }
}
