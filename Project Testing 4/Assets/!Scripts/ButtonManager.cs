using UnityEngine;

public enum ColorType
{
    Red,
    Green,
    Blue,
    Purple
}

public class ButtonManager : MonoBehaviour
{
    public Transform[] bulletSpawnPoints;
    public GameObject[] bulletPrefabs;
    public JoystickController joystickController;
    public float shootingCooldown;
    private bool isShooting = false;
    private ColorType selectedColor = ColorType.Red;
    private float shootingTimer = 0f;
    public GameObject Turret;
    public Material[] TurretColors;
    public ParticleSystem smoke;
    int count = 0;

    private void Start()
    {
        if (PlayerPrefs.GetInt("gamestartedfirsttime") < 1)
        {
            count++;
            PlayerPrefs.SetInt("gamestartedfirsttime", count);
            shootingCooldown = 0.5f;
            PlayerPrefs.SetFloat("cooldown", shootingCooldown);
        }
        shootingCooldown = PlayerPrefs.GetFloat("cooldown");
    }
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
        Turret.GetComponent<MeshRenderer>().material = TurretColors[2];
    }

    public void GreenButtonPressed()
    {
        selectedColor = ColorType.Green;
        isShooting = true;
        Debug.Log("is green shooting: " + isShooting);
        Turret.GetComponent<MeshRenderer>().material = TurretColors[1];
    }

    public void BlueButtonPressed()
    {
        selectedColor = ColorType.Blue;
        isShooting = true;
        Debug.Log("is blue shooting: " + isShooting);
        Turret.GetComponent<MeshRenderer>().material = TurretColors[0];
    }
    public void PurpleButtonPressed()
    {
        selectedColor = ColorType.Purple;
        isShooting = true;
        Debug.Log("is purple shooting: " + isShooting);
        Turret.GetComponent<MeshRenderer>().material = TurretColors[3];
    }

    public void StopShooting()
    {
        isShooting = false;
    }

    private void ShootBullet()
    {
        int selectedBulletIndex = (int)selectedColor;
        var bullet = Instantiate(bulletPrefabs[selectedBulletIndex], bulletSpawnPoints[selectedBulletIndex].position, bulletSpawnPoints[selectedBulletIndex].rotation);
        smoke.Play();
    }
    public void SetShootingCooldown(float cooldown)
    {
        shootingCooldown = cooldown;
    }
    


}