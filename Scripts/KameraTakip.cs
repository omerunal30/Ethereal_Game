using UnityEngine;



    public class KameraTakip : MonoBehaviour
    {
        public float mouseSensitivity = 100f;
        public Transform playerBody;

        float xRotation = 0f;

        void Start()
        {
            // Mouse'u ekran ortasýna kilitle
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            // Mouse hareketini al
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            // Yukarý-aþaðý bakma (X ekseni)
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Kamera baþ aþaðý dönmesin

            // Kamerayý döndür
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            // Karakteri sað-sol döndür (Y ekseni)
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
