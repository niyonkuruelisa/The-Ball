using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControlScript : MonoBehaviour
{

    Rigidbody2D rb;

    [Range(0.2f, 6f)]
    public float moveSpeedModifier = 0.5f;

    float dirX, dirY;

    Animator anim;

    static bool isDead;

    static bool moveAllowed;

    static bool youWin;

    [SerializeField]
    GameObject winPanel;

    float timer = 0.0f;
    int seconds = 0;

    public TMPro.TextMeshProUGUI TextSeconds;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        winPanel.SetActive(false);

        youWin = false;

        isDead = false;
        moveAllowed = true;
        TextSeconds.text = seconds + " Seconds";

        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
        //Gettubg devices accelerometer data in x and t direction
        var acc = Input.acceleration;
        //#if UNITY_ANDROID
        //        var hold = acc.x;
        //        acc.x = -acc.y;
        //        acc.y = hold;
        //#endif
        //multiplied by move speed modifier
        dirX = acc.x * moveSpeedModifier;
        dirY = acc.y * moveSpeedModifier;


        //if isDead is true
        if (isDead)
        {

            rb.velocity = new Vector2(0, 0);
            anim.SetBool("dead", true);


        }

        //if you win
        if (youWin)
        {
            
            moveAllowed = false;

            anim.SetBool("dead", true);
            winPanel.SetActive(true);

            TextSeconds.text = seconds+ " Seconds";

        }
        else
        {
            timer += Time.deltaTime;
            seconds = (int)(timer % 60);
        }

    }
    private void FixedUpdate()
    {
        //setting a velocity to RigidBody2D component accord to accelerometer data
        if (moveAllowed)
        {
            
            //transform.Translate(dirX, dirY, 0);
            rb.velocity = new Vector2(rb.velocity.x + dirX * Time.deltaTime, rb.velocity.y + dirY * Time.deltaTime);
        }
            
            
    }

    //Method is Invoked by DangerHoleScript when ball touches deadtHole collider
    public static void setIsBallDeadTrue()
    {
        isDead = true;
    }
    //Method is Invoked by WinScript when ball touches winHole collider
    public static void setIsBallWinTrue()
    {
        youWin = true;
    }
}
