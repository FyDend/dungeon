using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables movimiento
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 movement;

    //Variables Bala
    Vector2 mousePos;
    public Camera cam;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float bulletForce = 20f;

    //Variables Vara
    public GameObject vara;
    public float varaOffset;
    Quaternion varaAngle;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        Vector3 lookDir = vara.transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        varaAngle = Quaternion.Euler(0f,0f,angle+varaOffset);
        vara.transform.rotation = varaAngle;

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, varaAngle);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
