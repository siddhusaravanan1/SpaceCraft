using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    float Y;

    public int moveSpeed;
    public int petrol;
    public int health = 3;
    public int collectables = 50;

    public float Completiontimer;

    public Text score;
    public Text timerText;

    Rigidbody2D rb;

    public GameObject cam;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject GameOverPanel;

    public bool canMove = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canMove = true;

    }
    void Movement()
    {
        Y = Input.GetAxis("Vertical");

        transform.Translate(0 , Y * moveSpeed * Time.deltaTime, 0);
    }
    void PushEffect()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = transform.up * -moveSpeed;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            rb.velocity = Vector2.zero;
        }
    }
    void Rotation()
    {
        Vector3 mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rotation = Quaternion.LookRotation(transform.position - mousePos, Vector3.forward);

        transform.rotation = rotation;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
    }
    void CamMovement()
    {
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
    }
    void Update()
    {
        timerText.text = Completiontimer.ToString();
        Completiontimer -= Time.deltaTime;
        if (canMove)
        {
            Movement();
        }
        PushEffect();
        Rotation();
        CamMovement();
        score.text = "Needed :" + collectables;
        if(health == 2)
        {
            heart3.SetActive(false);
        }
        if (health == 1)
        {
            heart2.SetActive(false);
        }
        if (health == 0)
        {
            heart1.SetActive(false);
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
        if(collectables <= 0)
        {
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
        if(Completiontimer <= 0)
        {
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D cd)
    {
        if(cd.gameObject.tag=="Petrol")
        {
            petrol += 10;
            Destroy(cd.gameObject);
            Debug.Log("Collected");
            collectables -= 1;
        }
        if(cd.gameObject.tag=="Storm")
        {
            health -= 1;
            canMove = false;
        }
    }
    private void OnTriggerStay2D(Collider2D cd)
    {
        if(cd.gameObject.tag=="Storm")
        {
            canMove = false;
        }
    }
    private void OnTriggerExit2D(Collider2D cd)
    {
        if (cd.gameObject.tag == "Storm")
        {
            canMove = true;
        }
    }
}
