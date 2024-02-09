using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skripsi.Ship.MovementContoller
{
    public class ShipController : MonoBehaviour
    {
        public float speed = 10.0f;
        public float rotationSpeed = 100.0f;
        public bool IsRideable = false;
        [SerializeField] private GameObject _fanShip;
        
        private void Update()
        {
            if (IsRideable)
            {
                MovementShip();
            }
            else
            {
                fanRotation(rotationSpeed, Time.deltaTime);
            }
        }

        void MovementShip()
        {
            // using arrow keys
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;
            transform.Translate(0, 0, translation);
            if (translation != 0)
            {
                transform.Rotate(0, rotation, 0);
                fanRotation(rotationSpeed * rotationSpeed, Time.deltaTime);
            }
        }

        void fanRotation(float speedFan, float time)
        {
            _fanShip.transform.Rotate(0, 0, speedFan * time);
        }
    }
}
