using UnityEngine;



    public class KameraTakip : MonoBehaviour
    {
        public float mouseSensitivity = 100f;
        public Transform playerBody;

        float xRotation = 0f;

        void Start()
        {
            // Mouse'u ekran ortas�na kilitle
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            // Mouse hareketini al
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            // Yukar�-a�a�� bakma (X ekseni)
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Kamera ba� a�a�� d�nmesin

            // Kameray� d�nd�r
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            // Karakteri sa�-sol d�nd�r (Y ekseni)
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
