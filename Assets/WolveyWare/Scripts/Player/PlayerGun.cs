using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public float rotationSpeed;

    public float fireRate;
    public GameObject bulletPrefab;

    public Transform projectileSpawnPoint;

    float lastTimeOfFire;

    // Start is called before the first frame update
    void Start()
    {
        lastTimeOfFire = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - (Vector2)transform.position;
        float angleToMouse = Vector2.SignedAngle(Vector2.right, direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angleToMouse), Time.deltaTime * rotationSpeed);

        if (Input.GetMouseButton(0))
        {
            AttemptToFire();
        }
    }

    void AttemptToFire()
    {
        if(Time.time - lastTimeOfFire > (1 / fireRate))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject spawnedBullet = Instantiate(bulletPrefab, projectileSpawnPoint.position, transform.rotation);
        spawnedBullet.GetComponent<ProjectileMovement>().direction = transform.right;

        lastTimeOfFire = Time.time;
    }
}
