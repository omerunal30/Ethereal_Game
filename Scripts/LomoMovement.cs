using UnityEngine;


    [RequireComponent(typeof(CharacterController))]
    public class LomoKontrol : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float gravity = -20f;
        public float jumpHeight = 1.5f;

        private CharacterController controller;
        private Vector3 velocity;

        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            // Hareket
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * moveSpeed * Time.deltaTime);

            // Yere temas kontrolü
            if (controller.isGrounded)
            {
                if (velocity.y < 0)
                    velocity.y = -2f;

                if (Input.GetButtonDown("Jump"))
                    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            // Yerçekimi uygula
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
