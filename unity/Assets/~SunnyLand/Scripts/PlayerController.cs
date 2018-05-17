using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 5f;
        public int health = 100;
        public int damage = 50;
        public float hitForce = 4f;
        public float damageForce = 4f;
        public float maxVelocity = 3f;
        public float maxSlopeAngle = 45f;
        [Header("Grounding")]
        public float rayDistance = .5f;
        public bool isGrounded = false;
        [Header("Crouch")]
        public bool isCrouching = false;
        [Header("Jump")]
        public float jumpHeight = 2f;
        public int maxJumpCount = 2;
        public bool isJumping = false;
        [Header("Climb")]
        public float climbSpeed = 5f;
        public bool isClimbing = false;
        public bool isOnSlope = false;

        private Vector3 groundNormal = Vector3.up;
        private int currentJump = 0;
        private float inputH, inputV;

        private SpriteRenderer rend;
        private Rigidbody2D rigid;

        #region Unity Functions
        // Use this for initialization
        void Awake()
        {
            rend = GetComponent<SpriteRenderer>();
            rigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            PerformClimb();
            PerformMove();
            PerformJump();
        }

        void FixedUpdate()
        {

        }

        void OnDrawGizmos()
        {
            Ray groundRay = new Ray(transform.position, Vector3.down);
            Gizmos.DrawLine(groundRay.origin, groundRay.direction * rayDistance);

            Vector3 right = Vector3.Cross(groundNormal, Vector3.forward);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position - right * 1f,
                transform.position + right * 1f);
        }
        #endregion

        #region Custom Functions
        public void Jump()
        {

        }

        public void Crouch()
        {

        }

        public void UnCrouch()
        {

        }

        public void Move(float horizontal)
        {
            if (horizontal != 0)
            {
                rend.flipX = horizontal < 0;
            }

            inputH = horizontal;
        }

        public void Climb(float vertical)
        {

        }

        public void Hurt(int damage)
        {

        }

        private void PerformClimb()
        {

        }

        private void PerformMove()
        {
            Vector3 right = Vector3.Cross(groundNormal, Vector3.forward);

            rigid.AddForce(right * inputH * speed);

            LimitVelocity();
        }

        private void PerformJump()
        {

        }

        private void DetectGround()
        {
            Ray groundRay = new Ray(transform.position, Vector3.down);

            RaycastHit2D[] hits = Physics2D.RaycastAll(groundRay.origin,
                groundRay.direction,
                rayDistance);

            foreach (var hit in hits)
            {
                CheckEnemy(hit);

                CheckGround(hit);
            }
        }

        private bool CheckGround(RaycastHit2D hit)
        {
            if(hit.collider != null &&
                hit.collider.name != name &&
                hit.collider.isTrigger == false)
            {
                currentJump = 0;

                isGrounded = true;

                groundNormal = hit.normal;


                return true;
            }


            return false;
        }

        private void CheckEnemy(RaycastHit2D hit)
        {

        }

        private void LimitVelocity()
        {
            Vector3 vel = rigid.velocity;

            if (vel.magnitude > maxVelocity)
            {
                vel = vel.normalized * maxVelocity;
            }

            rigid.velocity = vel;
        }

        private void StopClimbing()
        {

        }

        private void DisablePhysics()
        {

        }

        private void EnablePhysics()
        {

        }
        #endregion
    }

}
