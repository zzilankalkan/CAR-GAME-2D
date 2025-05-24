using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 5f; // Hareket hýzý
    public float rotationSpeed = 5f; // Dönüþ hýzý

    public GameObject gameOverPanel; // Oyun bittiðinde gösterilecek panel
    public AudioSource collisionAudio; // Çarpma sesi
    public AudioSource collectAudio; // Toplama sesi

    public bool isPlayerTwo = false; // Bu script'in hangi oyuncuya ait olduðunu belirten bayrak

    private bool isMovingLeft = false;
    private bool isMovingRight = false;

    private int coinCount = 0; // Toplanan coin sayýsýný takip etmek için

    void Start()
    {
        gameOverPanel.SetActive(false); // Baþlangýçta oyun sonu panelini gizle
        Time.timeScale = 1; // Oyunu normal hýzda baþlat
    }

    void Update()
    {
        HandleInput(); // Klavye giriþlerini kontrol et
        Clamp(); // Oyuncunun ekran sýnýrlarýndan çýkmasýný engelle
        Movement(); // Hareketi uygula

        if (isMovingLeft)
        {
            MoveLeft();
        }

        if (isMovingRight)
        {
            MoveRight();
        }
    }

    void HandleInput()
    {
        // Klavye giriþlerini kontrol et
        if (isPlayerTwo)
        {
            // Ýkinci oyuncu için kontroller
            if (Input.GetKey(KeyCode.A))
            {
                isMovingLeft = true;
            }
            else
            {
                isMovingLeft = false;
            }

            if (Input.GetKey(KeyCode.D))
            {
                isMovingRight = true;
            }
            else
            {
                isMovingRight = false;
            }
        }
        else
        {
            // Birinci oyuncu için kontroller
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                isMovingLeft = true;
            }
            else
            {
                isMovingLeft = false;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                isMovingRight = true;
            }
            else
            {
                isMovingRight = false;
            }
        }
    }

    void Movement()
    {
        if (transform.rotation.z != 90)
        {
            // Arabanýn rotasyonunu sýfýrla
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 10f * Time.deltaTime);
        }
    }

    void MoveLeft()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 47), rotationSpeed * Time.deltaTime);
    }

    void MoveRight()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -47), rotationSpeed * Time.deltaTime);
    }

    void Clamp()
    {
        // Oyuncunun ekran sýnýrlarýndan çýkmasýný engelle
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -1.8f, 1.8f); // Sýnýrlarý ekran geniþliðine göre ayarlayýn
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cars")
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            collisionAudio.Play();
        }

        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            collectAudio.Play();

            // Coin sayýsýný artýr ve hýzýný güncelle
            coinCount++;
            IncreaseSpeed();
        }
    }

    void IncreaseSpeed()
    {
        // Hýz artýþý (her coin toplandýðýnda 0.5f hýz ekleyebilirsiniz)
        speed += 0.5f;

        // Debug log ile bilgi görüntüleme
        Debug.Log($"Toplanan Coin: {coinCount} - Yeni Hýz: {speed}");
    }
}
