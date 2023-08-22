using UnityEngine;

public class FloatUpDown : MonoBehaviour
{
    public float floatSpeed = 1.0f;   // Speed of the floating movement
    public float floatHeight = 1.0f;  // Height of the floating movement

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        // Calculate the new Y position using a sine wave to create the floating effect
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Apply the new position to the object
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
