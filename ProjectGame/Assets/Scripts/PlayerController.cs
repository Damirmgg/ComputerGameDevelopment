using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jump = 5.0f;

    public TextMeshProUGUI keyText;
    private CharacterController controller;
    private Vector3 velocity;
    private float gravity = -9.81f;

    private int keysCollected = 0;
    private int allKeys = 3;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        UpdateKeyCounter();
    }

    private void Update()
    {
        //ввод от игрока
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        bool isGrounded = controller.isGrounded;
        if(isGrounded && velocity.y < 0)
            velocity.y = -5f;
        if (isGrounded && Input.GetButtonDown("Jump"))
            velocity.y = jump;
        //гравитация
        velocity.y += gravity * Time.deltaTime;

        //двигаем гг
        controller.Move(velocity * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            keysCollected++;
            Destroy(other.gameObject);
            UpdateKeyCounter();

            if (keysCollected == allKeys)
                Debug.Log("Все ключи собраны");
        }
    }
    private void UpdateKeyCounter()
    {
        if (keyText != null)
        {
            keyText.text = keysCollected + "/" + allKeys;
        }
    }
}