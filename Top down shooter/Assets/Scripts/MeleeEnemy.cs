using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public Vector3 derp = new Vector3(0, 0, 0);

    public float stopDistance;

    void Update()
    {
        if(player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                Vector2 movement = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                transform.position = movement;

                Debug.Log(player.position);

            }

        }


    }
}
