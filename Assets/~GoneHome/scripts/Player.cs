using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GoneHome
{
    public class Player : MonoBehaviour
    {
        public float movementSpeed = 20f;

        private Rigidbody rigid;
        private Transform cam;

        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody>();

            cam = Camera.main.transform;
        }

        // Update is called once per frame
        void Update()
        {
            Movement();
        }

        void Movement()
        {
            float inputH = Input.GetAxis("Horizontal");
            float inputV = Input.GetAxis("Vertical");

            Vector3 inputDir = new Vector3(inputH, 0, inputV);

            inputDir = Quaternion.AngleAxis(cam.eulerAngles.y, Vector3.up) * inputDir;

            Vector3 position = transform.position;
            position += inputDir * movementSpeed * Time.deltaTime;
            rigid.MovePosition(position);
        }
    }
}

