using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 5f; // Hareket h�z�
    public float rotationSpeed = 5f; // D�n�� h�z�

    public GameObject gameOverPanel; // Oyun bitti�inde g�sterilecek panel
    public AudioSource collisionAudio; // �arpma sesi
    public AudioSource collectAudio; // Toplama sesi

    public bool isPlayerTwo = false; // Bu script'in hangi oyuncuya ait oldu�unu belirten bayrak

    private bool isMovingLeft = false;
    private bool isMovingRight = false;

    private int coinCount = 0; // Toplanan coin say�s�n� takip etmek i�in

    void Start()
    {
        gameOverPanel.SetActive(false); // Ba�lang��ta oyun sonu panelini gizle
        Time.timeScale = 1; // Oyunu normal h�zda ba�lat
    }

    void Update()
    {
        HandleInput(); // Klavye giri�lerini kontrol et
        Clamp(); // Oyuncunun ekran s�n�rlar�ndan ��kmas�n� engelle
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
        // Klavye giri�lerini kontrol et
        if (isPlayerTwo)
        {
            // �kinci oyuncu i�in kontroller
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
            // Birinci oyuncu i�in kontroller
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
            // Araban�n rotasyonunu s�f�rla
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
        // Oyuncunun ekran s�n�rlar�ndan ��kmas�n� engelle
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -1.8f, 1.8f); // S�n�rlar� ekran geni�li�ine g�re ayarlay�n
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

            // Coin say�s�n� art�r ve h�z�n� g�ncelle
            coinCount++;
            IncreaseSpeed();
        }
    }

    void IncreaseSpeed()
    {
        // H�z art��� (her coin topland���nda 0.5f h�z ekleyebilirsiniz)
        speed += 0.5f;

        // Debug log ile bilgi g�r�nt�leme
        Debug.Log($"Toplanan Coin: {coinCount} - Yeni H�z: {speed}");
    }
}
