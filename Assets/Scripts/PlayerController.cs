using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 5f;
    public List<Transform> shootingPoints;
    public GameObject bulletPrefab;

    Vector3 rotationDir;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        Move();
        Shoot();
    }

    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
        { 
            foreach(Transform point in shootingPoints)
            {
                var rocket = Instantiate(bulletPrefab, point.position, point.rotation);

                var centre = new Vector2(Screen.width / 2, Screen.height / 2);
                var ray = Camera.main.ScreenPointToRay(centre);

                if(Physics.Raycast(ray, out var hit))
                {
                    rocket.GetComponent<Rocket>().target = hit.transform;
                }
            }
        }
    }

    void Move()
    {
        rotationDir.y += Input.GetAxis("Horizontal");
        rotationDir.x += Input.GetAxis("Vertical");

        transform.position += transform.forward * Time.deltaTime * speed;

        //transform.rotation = Quaternion.Euler(rotationDir * rotationSpeed * Time.deltaTime);

        var targetRotation = Quaternion.Euler(rotationDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
