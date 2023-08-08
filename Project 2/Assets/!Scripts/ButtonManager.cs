using UnityEngine;

public enum ColorType
{
    Red,
    Green,
    Blue
}

public class ButtonManager : MonoBehaviour
{
    public Transform[] bulletSpawnPoints;
    public GameObject[] bulletPrefabs;
    public JoystickController joystickController; // Reference to the JoystickController.

    public float shootingCooldown = 0.5f; // The time between each shot in seconds.

    private bool isShooting = false;
    private ColorType selectedColor = ColorType.Red; // Default selected color is Red.
    private float shootingTimer = 0f; // Timer to control shooting cooldown.

    private void Update()
    {
        // If shooting and the joystick is dragging, try to shoot.
        if (isShooting && joystickController != null && joystickController.IsJoystickDragging())
        {
            // Reduce the shooting timer.
            shootingTimer -= Time.deltaTime;

            // Shoot if the cooldown is over.
            if (shootingTimer <= 0f)
            {
                ShootBullet();
                shootingTimer = shootingCooldown;
            }
        }
    }

    public void RedButtonPressed()
    {
        selectedColor = ColorType.Red;
        isShooting = true;
        Debug.Log("is red shooting: " + isShooting);
    }

    public void GreenButtonPressed()
    {
        selectedColor = ColorType.Green;
        isShooting = true;
        Debug.Log("is green shooting: " + isShooting);
    }

    public void BlueButtonPressed()
    {
        selectedColor = ColorType.Blue;
        isShooting = true;
        Debug.Log("is blue shooting: " + isShooting);
    }

    public void StopShooting()
    {
        isShooting = false;
    }

    private void ShootBullet()
    {
        int selectedBulletIndex = (int)selectedColor;
        var bullet = Instantiate(bulletPrefabs[selectedBulletIndex], bulletSpawnPoints[selectedBulletIndex].position, bulletSpawnPoints[selectedBulletIndex].rotation);
    }
}
