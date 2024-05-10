using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    public float JumpForce;
    public float MaxVelocityY;
    public int Points;

    public Rigidbody2D Rigidbody2D;
    public TextMeshProUGUI PointsTextField;
    public GameObject GameOverScreen;

    public static bool GameOver;
    public static bool HasStarted;

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
        HasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
            return;

        if(Input.GetButtonDown("Jump"))
        {
            Rigidbody2D.velocity = Vector2.zero;
            Rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            HasStarted = true;
            Rigidbody2D.gravityScale = 1;
        }

        if(Rigidbody2D.velocity.y > MaxVelocityY)
        {
            Rigidbody2D.velocity = new Vector2(0, MaxVelocityY);
        }

        PointsTextField.text = Points.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver = true;
        GameOverScreen.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PointZone"))
        {
            Points++;
        }
    }

}
