using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float moveSpeed = 24f;       // скорость движения вверх/вниз
    public float edgeMargin = 1.7f;     // отступ от края экрана (примерно радиус/половина высоты машины)
    public LogicScript logic;
    public bool birdIsAlive = true;
    AudioManagerScript audioManager;

    private float minY;
    private float maxY;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();

        // Машина не падает: отключаем гравитацию и вращение
        myRigidbody.gravityScale = 0f;
        myRigidbody.freezeRotation = true;
        myRigidbody.velocity = Vector2.zero;
    }

    void Start()
    {
        gameObject.name = "Vasya";
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        // Границы по высоте берём из камеры, чтобы машина не уезжала за экран
        Camera cam = Camera.main;
        minY = cam.transform.position.y - cam.orthographicSize + edgeMargin;
        maxY = cam.transform.position.y + cam.orthographicSize - edgeMargin;
    }

    void Update()
    {
        if (!birdIsAlive)
        {
            myRigidbody.velocity = Vector2.zero;
            return;
        }

        // W / стрелка вверх = +1, S / стрелка вниз = -1, ничего не нажато = 0 (машина стоит на месте)
        float direction = 0f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) direction += 1f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) direction -= 1f;

        float y = transform.position.y;

        // не даём выйти за верхнюю и нижнюю границы
        if ((direction > 0f && y >= maxY) || (direction < 0f && y <= minY))
        {
            direction = 0f;
        }

        myRigidbody.velocity = new Vector2(0f, direction * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
        myRigidbody.velocity = Vector2.zero;
        audioManager.PlaySFX(audioManager.death);
    }
}
