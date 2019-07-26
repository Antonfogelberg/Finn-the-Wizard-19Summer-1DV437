using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_ball : MonoBehaviour
{

    public float speed;
    public float lifeTime;
    public GameObject explosion;

    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        
    }

    void DestroyProjectile()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
