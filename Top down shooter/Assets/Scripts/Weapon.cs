using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject projectile;
    public Transform shotPoint;
    public float timeBetweenShots;

    private float shotTime;


    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Är tydligen alltid Vector3.forward? -90 gör att den följer musen mycket bättre. Ingen aning om varför?
        Quaternion rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);
        transform.rotation = rotation;




        // Får projektilen att rendera åt rätt håll. Och om cooldown är redo
        if(Input.GetMouseButton(0) && Time.time >= shotTime)
        {
            Instantiate(projectile, shotPoint.position, transform.rotation);
            shotTime = Time.time + timeBetweenShots;
        }
    }
}
