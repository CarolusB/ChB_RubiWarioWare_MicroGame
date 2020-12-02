using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace TrioBrigantin
{
    namespace CouteauxTires
    {
        public class ACouteauxTiré_Manager : TimedBehaviour
        {
            #region Variables
            static public ACouteauxTiré_Manager instance;

            [SerializeField] int numberOfEnemies; //Serialize field when testing
            int ammo;
            public List<GameObject> enemiesKilled = new List<GameObject>();
            #endregion

            private void Awake()
            {
                if (instance == null)
                    instance = this;
                else
                    Destroy(gameObject);
            }

            public override void Start()
            {
                base.Start(); //Do not erase this line!
                ammo = numberOfEnemies;
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!
                //if (ammo == 0 && enemiesKilled.Count == numberOfEnemies)
                //{
                //    Manager.Instance.Result(true);
                //}
            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                if ((Tick == 8 || ammo == 0) && enemiesKilled.Count < numberOfEnemies)
                {
                    Manager.Instance.Result(false);
                }
                else if (ammo == 0 && enemiesKilled.Count == numberOfEnemies)
                {
                    Manager.Instance.Result(true);
                }
            }

            public void MinusAmmo()
            {
                ammo--;
            }
        }
    }
}