using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SePePlayerController2 : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody2D rb2d;
    private bool facingRight = false;
    private int count;
    private float timer;
    private int wholetime;

    private AudioSource source;
    public AudioClip fishClip;
    public AudioClip greetClip;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
        GetComponent<AudioSource>().PlayOneShot(greetClip);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }
        timer = timer + Time.deltaTime;
        if (timer >= 10.5) //&& (count <= 10);
        {
            winText.text = "Time's up!";
            StartCoroutine(ByeAfterDelay(2));

        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            //GameLoader.AddScore(1);
            SetCountText();
            GetComponent<AudioSource>().PlayOneShot(fishClip);
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 10)
        {
            winText.text = "You win!";
            StartCoroutine(ByeAfterDelay(2));
        }
    }

    IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        //GameLoader.gameOn = false;
    }
}
