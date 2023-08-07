using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public RectTransform joystickBackground;
    public RectTransform joystickHandle;
    public Transform turret;

    public float maxRotationAngle = 45f; // The maximum rotation angle in degrees.

    private Vector2 joystickCenter;
    private Vector2 joystickInput;
    private bool isJoystickDragging = false; // Joystick state flag.

    private void Start()
    {
        joystickCenter = joystickBackground.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        joystickInput = (eventData.position - joystickCenter).normalized;
        Debug.Log("Joystick Input: " + joystickInput);

        joystickHandle.position = joystickCenter + joystickInput * Mathf.Min(joystickBackground.rect.width, joystickBackground.rect.height) * 0.5f;

        float angle = Mathf.Atan2(joystickInput.x, joystickInput.y) * Mathf.Rad2Deg;

        // Clamp the angle within the specified range.
        angle = Mathf.Clamp(angle, -maxRotationAngle, maxRotationAngle);

        turret.rotation = Quaternion.Euler(0f, -angle, 0f);

        // Set joystick state to true when dragging.
        isJoystickDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        joystickInput = Vector2.zero;
        joystickHandle.position = joystickCenter;
        turret.rotation = Quaternion.identity;

        // Set joystick state to false when not dragging.
        isJoystickDragging = false;
    }

    public bool IsJoystickDragging()
    {
        return isJoystickDragging;
    }
}
