using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public ScoreBoard scoreBoard;

    public float jumpForce = 10;
    public TextMeshProUGUI scoreText;

    [Header("Audio effects")]
    public AudioClip jumpSound;
    public AudioClip deathSound;
    public AudioClip scoreSound;

    private int score = 0;

    private Rigidbody2D rb;
    private AudioSource audioSource;

    void Start()
    {
        // Get component from the same object this script is on
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) &&  rb.velocity.y < 0) {}

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            audioSource.PlayOneShot(jumpSound);
        }

        if (rb.velocity.y < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -30);
        }
        else {
            transform.rotation = Quaternion.Euler(0, 0, 30);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Point"))
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
            audioSource.PlayOneShot(scoreSound);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        audioSource.PlayOneShot(deathSound);
        scoreBoard.ShowScore(score);
        Destroy(this);
    }
}
