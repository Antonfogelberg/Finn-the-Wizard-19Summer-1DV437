using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float health;
    public GameObject fire_staff;
    public GameObject green_staff;
    public float swapCD;
    private float swapTime;
    public bool greenStaff;
    public Transform holdPos;

    private Rigidbody2D rb;
    private Vector2 moveAmount;
    private Animator anim;
   
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        moveAmount = moveInput.normalized * speed;

        if(moveInput != Vector2.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        // Does keybinds have to be this ugly? 

        if(Input.GetKeyDown("1") && Time.time > swapTime){
            swapFire();

        }
        if (Input.GetKeyDown("2") && Time.time > swapTime && greenStaff)
        {
            swapGreen();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeWeapon(Weapon weaponToEquip)
    {
        
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(weaponToEquip, holdPos.position, transform.rotation, transform);


    }


    // Ugly weapon swap system ?
    public void swapFire()
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(fire_staff, holdPos.position, transform.rotation, transform);
        swapTime = Time.time + swapCD;

    }
    public void swapGreen()
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(green_staff, holdPos.position, transform.rotation, transform);
        swapTime = Time.time + swapCD;
    }



    public void greenStaffPickedUp()
    {
        greenStaff = true;
    }


}

