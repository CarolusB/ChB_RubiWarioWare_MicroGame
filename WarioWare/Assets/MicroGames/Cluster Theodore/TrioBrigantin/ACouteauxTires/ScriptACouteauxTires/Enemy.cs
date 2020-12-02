﻿using System.Collections;
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

			//placeholder feedbacks
			SpriteRenderer mySprite;

			[Range(1,2)]
			[SerializeField] int needLock = 1;
			#endregion

			// Start is called before the first frame update
			void Start()
			{
				detectZone = GetComponent<CircleCollider2D>();
				mySprite = GetComponent<SpriteRenderer>();
			}

            #region Trigger calls
            private void OnTriggerEnter2D(Collider2D collision)
            {
                if(collision.gameObject == CrosshairController.instance.gameObject)
                {
					CrosshairController.instance.targetEnemy = this;
					mySprite.color = Color.blue;
                }
            }

            private void OnTriggerExit2D(Collider2D collision)
            {
				if (collision.gameObject == CrosshairController.instance.gameObject)
				{
					CrosshairController.instance.targetEnemy = null;
					mySprite.color = Color.white;
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
					CrosshairController.instance.targetEnemy = null;
					ACouteauxTiré_Manager.instance.enemiesKilled.Add(gameObject);
					mySprite.color = Color.magenta;
				}
            }
        }
    }
}