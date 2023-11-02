using UnityEngine;

public class ImageRotate : MonoBehaviour
{
    public float rotationSpeed = 10.0f;

    void Update()
    {
        // Rotate the RectTransform of the image within the Canvas
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
