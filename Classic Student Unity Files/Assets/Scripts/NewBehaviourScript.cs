using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Threading;

public class NewBehaviourScript : MonoBehaviour
{


   
    bool grounded=true; //Дали е на земята 
    public Transform groundCheck; //Проверка дали е на земята
    public Rigidbody2D rb; 
    public float maxSpeed = 20f; //Скоростта на героя
    bool facingRight = true; //Дали е обърнат надясно
    Animator anim;//Въвеждаме реадактор 
    float groundRadius = 0.2f; //Максималното разстояние при което се отцхтита докосваме на земята
    public LayerMask whatIsGround;
    public float jumpForce = 700;//Силата на скока
    bool Death = false; //Проверка за смъртта
    public GameObject player; //Въвеждане героя
  GameObject door;





    void Start () 
    {
      
        anim =GetComponent<Animator>();//Инициализираме редактора на анимациите
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");//Инициализиране на героя 
        door = GameObject.FindGameObjectWithTag("Door");
    }
    void FixedUpdate()
    {
        if (Death == false)//Проверка дали е жив
        {
            anim.SetFloat("vSpeed", rb.velocity.y);
            float move = Input.GetAxis("Horizontal");
            anim.SetFloat("Speed", Mathf.Abs(move));
            rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
            //Движението на героя
            if (move > 0 && !facingRight) { Flip(); }
            else if (move < 0 && facingRight) { Flip(); }
            //Проверка на коя страна е обърнат
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);//Проверка дали е на земята
            anim.SetBool("Ground", grounded);//Отпечатване дали героя е на земята,за да се избере коя анимация да почне
                                             // Движението и обръщането на ляво и на дясно на героя
            if (grounded && Input.GetKeyDown(KeyCode.UpArrow))
            {
                anim.SetBool("Ground", false);
                rb.AddForce(Vector2.up * jumpForce);

            }
            //Скок
        }
    }

    void Update()
    {
        if (Death == true)//проверка дали героя е жив
        {
            anim.SetBool("Death", true);
          
        }
    }

    void Flip()
    {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        //Обръщане на ляво и на дясно
    }

    void OnTriggerEnter2D(Collider2D col)
    {
    
        if (col.gameObject.tag == "Obstacle")       {
            Death = true;
            anim.SetBool("Death", true);
            door.SetActive(false);
}
        //Умиране от грешен отговор и от препядствие
    }
    private void Dead()
    {
        
            Application.LoadLevel(7);//преместване на следващата сцена при приключването на анимацията Death

    }
    
}
