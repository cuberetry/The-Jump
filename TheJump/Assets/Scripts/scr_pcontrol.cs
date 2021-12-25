using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class scr_pcontrol : MonoBehaviour
{
    // Rigid Body
    public Rigidbody rigid;

    // Initial  Value
    public int score;
    public float timer = 15f;
    public bool firstStop = true;

    // Text Messages
    public TMPro.TextMeshProUGUI textScore;
    public TMPro.TextMeshProUGUI textTime;
    public TMPro.TextMeshProUGUI textGameOver;

    // Respawn Particle
    public ParticleSystem emitter;

    // Target Prefab
    public GameObject targetPrefab;
    public int targetCount = 5;
    public GameObject[] targetArray;

    // Sound Effect
    public AudioSource pickupsound;
    public AudioSource restartsound;
    public AudioSource fallsound;
    public AudioSource gameoversound;

    // Start is called before the first frame update
    void Start()
    {
        // Hide the gameover text
        textGameOver.enabled = false;
        // Create target
        targetArray = new GameObject[targetCount];

        for (int i = 0; i < targetCount; i++)
        {
            targetArray[i] = Instantiate(targetPrefab, new Vector3(Random.Range(-20f, 20f), 2f, Random.Range(-50f, 0)), this.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update the UI text
        textScore.text = "Score: " + score;
        textTime.text = "Timer: " + Math.Round(timer);

        // Pull down constantly
        if (gameObject.transform.position.y != 1)
        {
            rigid.AddForce(new Vector3(0f, -4f, 0f), ForceMode.Impulse);
        }

        // Check if the time has run out
        if (timer <= 0)
        {
            // Stop the game time and display gameover text
            Time.timeScale = 0;
            if (firstStop) {
                textGameOver.enabled = true;
                gameoversound.Play();
                firstStop = false;
            }
            
        }
        // Else we decrement the time
        timer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            // Press A, go left
            rigid.AddForce(new Vector3(-8f, 0f, 0f), ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.D))
        {
            // Press D, go right
            rigid.AddForce(new Vector3(8f, 0f, 0f), ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.W))
        {
            // Press W, go forward
            rigid.AddForce(new Vector3(0f, 0f, 8f), ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.S))
        {
            // Press S, go backward
            rigid.AddForce(new Vector3(0f, 0f, -8f), ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            // Press Space, jump

            rigid.AddForce(new Vector3(0f, 20f, 0f), ForceMode.Impulse);
            if (Time.timeScale == 0)
            {
                restartsound.Play();
                transform.position = new Vector3(0f, 2f, 0f);

                // Reset game world time and score
                firstStop = true;
                score = 0;
                timer = 15;
                Time.timeScale = 1;
                // Hide gameover text
                textGameOver.enabled = false;
                // Replay Respawn Particle
                emitter.Clear();
                emitter.Play();
            }
        }

        if (gameObject.transform.position.y < -30f)
        {
            // Reset the player position
            fallsound.Play();
            transform.position = new Vector3(0f, 2f, 0f);

            // Replay Respawn Particle
            emitter.Clear();
            emitter.Play();
        }
    }

    void OnCollisionEnter(Collision other)
    {

        // Collide with the item
        if (other.collider.tag == "Target")
        {
            pickupsound.Play();
            score += 1;

            // Deactivate an reactivate
            other.gameObject.SetActive(false);
            StartCoroutine(RespawnTarget(other));

        }
    }

    IEnumerator RespawnTarget(Collision other)
    {
        yield return new WaitForSeconds(3f);
        other.gameObject.transform.position = new Vector3(Random.Range(-20f, 20f), 2f, Random.Range(-50f, 0));
        other.gameObject.SetActive(true);
    }

}
