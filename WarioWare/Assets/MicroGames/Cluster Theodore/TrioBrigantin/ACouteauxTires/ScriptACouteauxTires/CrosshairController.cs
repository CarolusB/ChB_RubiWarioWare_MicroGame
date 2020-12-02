using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrioBrigantin
{
	namespace CouteauxTires
	{
		/// <summary>
		/// CHB -- Crosshair movement and interactions
		/// </summary>
		public class CrosshairController : MonoBehaviour
		{
			#region Variables
			[Range(0.1f, 500f)]
			[SerializeField] float movementSpeed = 1;

			Rigidbody2D crosshairRb;

			static public CrosshairController instance = null;

			// movement direction variables
			float horizontal = 0, vertical = 0;
			Vector2 movementVector = Vector2.zero;

            //target enemy
            public Enemy targetEnemy;
            #endregion
            private void Awake()
            {
				if(instance == null)
                {
					instance = this;
                }
                else
                {
					Destroy(gameObject);
                }
				
			}
            // Start is called before the first frame update
            void Start()
			{
				crosshairRb = GetComponent<Rigidbody2D>();
			}

            // Update is called once per frame
            void FixedUpdate()
			{
				Move();
				Lock();
			}

			void Move()
            {
				horizontal = Input.GetAxis("Left_Joystick_X");
				vertical = -Input.GetAxis("Left_Joystick_Y");

				if (horizontal < -0.15 || horizontal > 0.15 || vertical < -0.15 || vertical > 0.15)
                {
					movementVector = new Vector2(horizontal, vertical);
				}
                else
                {
					movementVector = Vector2.zero;
                }

				crosshairRb.velocity = movementVector.normalized * movementSpeed;
			}

			void Lock()
            {
                if (Input.GetButtonDown("A_Button"))
                {
					if(targetEnemy != null)
                    {
						targetEnemy.TakeLock();

						//spawn yellow crosshair copy
					}

					//spawn crooshair grey copy
					//ammo--;
				}
			}
		}
	}
}