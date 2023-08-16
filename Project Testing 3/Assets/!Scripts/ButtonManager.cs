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
    public JoystickController joystickController;
    public float shootingCooldown = 0.5f;
    private bool isShooting = false;
    private ColorType selectedColor = ColorType.Red;
    private float shootingTimer = 0f;

    private void Update()
    {
        if (isShooting && joystickController != null && joystickController.IsJoystickDragging())
        {
            shootingTimer -= Time.deltaTime;
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
