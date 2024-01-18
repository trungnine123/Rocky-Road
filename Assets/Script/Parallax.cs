using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Camera cam;
    public Transform subject;

    Vector2 startPosition;
    float startZ;

    Vector2 travel => (Vector2)cam.transform.position - startPosition;
    Vector2 parallaxFactor;

    public float smoothness = 2f;  // Adjust this value to control the smoothness of the parallax effect

    void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;
    }

    void Update()
    {
        // Calculate the parallax factor based on the subject's movement
        parallaxFactor = new Vector2(1f - Mathf.Clamp01(subject.position.z / 5f), 1f - Mathf.Clamp01(subject.position.z / 5f));

        // Calculate the target position based on the initial position and the parallax factor
        Vector2 targetPosition = startPosition + Vector2.Scale(travel, parallaxFactor);

        // Smoothly interpolate the current position towards the target position
        transform.position = Vector2.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime);

        // Keep the original Z position
        transform.position = new Vector3(transform.position.x, transform.position.y, startZ);
    }
}
