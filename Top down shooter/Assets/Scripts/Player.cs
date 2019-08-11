using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public int health;
    public GameObject fire_staff;
    public GameObject green_staff;
    public float swapCD;
    private float swapTime;
    public bool greenStaff;
    public Transform holdPos;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    private Rigidbody2D rb;
    private Vector2 moveAmount;
    private Animator anim;
    private SceneTransitions sceneTransitions;

    public Animator hurtAnim;
   
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sceneTransitions = FindObjectOfType<SceneTransitions>();
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
        UpdateHealthUI(health);

        hurtAnim.SetTrigger("hurt");

        if (health <= 0)
        {
            Destroy(gameObject);
            sceneTransitions.LoadScene("Lose");
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


    void UpdateHealthUI(int currentHealth)
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

        }
    }

    public void Heal(int healAmmount)
    {
        if (health + healAmmount > 5)
        {
            health = 5;
        }
        else
        {
            health += healAmmount;
        }
        UpdateHealthUI(health);

    }

}

