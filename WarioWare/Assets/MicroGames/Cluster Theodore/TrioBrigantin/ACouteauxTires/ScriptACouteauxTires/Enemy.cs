using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrioBrigantin
{
	namespace CouteauxTires
	{
		public class Enemy : MonoBehaviour
		{
			#region Variables
			CircleCollider2D detectZone;

			[Range(1,2)]
			[SerializeField] int needLock = 1;

			bool isKilled;
			#endregion

			// Start is called before the first frame update
			void Start()
			{
				detectZone = GetComponent<CircleCollider2D>();
			}

            #region Trigger calls
            private void OnTriggerEnter2D(Collider2D collision)
            {
                if(collision.gameObject == CrosshairController.instance.gameObject)
                {
					CrosshairController.instance.targetEnemy = this;
                }
            }

            private void OnTriggerExit2D(Collider2D collision)
            {
				if (collision.gameObject == CrosshairController.instance.gameObject)
				{
					CrosshairController.instance.targetEnemy = null;
				}
			}
            #endregion

			public void TakeLock()
            {
				needLock--;

				if(needLock == 0)
                {
					//Manager enemyKilled++;
					detectZone.enabled = false;
					isKilled = true;
                }
            }
        }
    }
}