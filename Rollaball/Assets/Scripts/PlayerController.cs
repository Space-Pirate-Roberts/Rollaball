using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject pauseTextObject, speedTextObject, speedSliderObject,
            colorDropdownObject, colorTextObject, sizeToggleObject;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private bool gamePaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseTextObject.SetActive(false);
        speedTextObject.SetActive(false);
        speedSliderObject.SetActive(false);
        colorDropdownObject.SetActive(false);
        colorTextObject.SetActive(false);
        sizeToggleObject.SetActive(false);
        count = 0;
        SetCountText();
        rb = GetComponent<Rigidbody>();
        gamePaused = false;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            //winTextObject.SetActive(true);
            SceneManager.LoadScene(2);
        }
    }

    void togglePause()
    {
        if (gamePaused == false)
        {
            Time.timeScale = 0;
            gamePaused = true;
            pauseTextObject.SetActive(true);
            speedTextObject.SetActive(true);
            speedSliderObject.SetActive(true);
            colorDropdownObject.SetActive(true);
            colorTextObject.SetActive(true);
            sizeToggleObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            gamePaused = false;
            pauseTextObject.SetActive(false);
            speedTextObject.SetActive(false);
            speedSliderObject.SetActive(false);
            colorDropdownObject.SetActive(false);
            colorTextObject.SetActive(false);
            sizeToggleObject.SetActive(false);
        }
    }
    
    public void ChangeSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            togglePause();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
}

