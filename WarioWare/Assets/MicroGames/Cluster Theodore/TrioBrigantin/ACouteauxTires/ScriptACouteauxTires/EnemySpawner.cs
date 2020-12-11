using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrioBrigantin
{
	namespace CouteauxTires
	{
		public class EnemySpawner : MonoBehaviour
		{
			#region Variables
			[SerializeField] GameObject[] spawnPoints;
			int enemiesLeftToSpawn;
			bool doSpawnSuperEnemy;
			bool superEnemyIsSpawned = false;

			#endregion


			public void GetEnemyNumber(int _enemyNb, bool _hasSuper)
            {
				enemiesLeftToSpawn = _enemyNb;
				doSpawnSuperEnemy = _hasSuper;
            }

			public void SpawnBehavior()
            {
				for(int e = 0; e < spawnPoints.Length; e++)
                {
					if(enemiesLeftToSpawn == spawnPoints.Length - e)
                    {
						if (doSpawnSuperEnemy && !superEnemyIsSpawned)
						{
							if (enemiesLeftToSpawn == 1)
							{
								InstEnemy(ACouteauxTiré_Manager.instance.superEnemy, e);
							}
                            else
                            {
								ChanceOfSuperSpawn(e);
                            }
						}
                        else
                        {
							InstEnemy(ACouteauxTiré_Manager.instance.baseEnemy, e);
						}
                    }
                    else
                    {
						int spawnChance = Random.Range(1, 5);

						if(spawnChance == 1)
                        {
							if(doSpawnSuperEnemy && !superEnemyIsSpawned)
                            {
								ChanceOfSuperSpawn(e);
                            }
                            else
                            {
								InstEnemy(ACouteauxTiré_Manager.instance.baseEnemy, e);
							}
                        }
                    }

					if(enemiesLeftToSpawn == 0)
                    {
						break;
                    }
                }
            }

			void InstEnemy(GameObject _enemyType, int _position)
            {
				Instantiate(_enemyType, spawnPoints[_position].transform.position, Quaternion.identity);
				enemiesLeftToSpawn--;
			}

			void ChanceOfSuperSpawn(int _position)
            {
				int superSpawnChance = Random.Range(1, 3);

				if (superSpawnChance == 1)
				{
					InstEnemy(ACouteauxTiré_Manager.instance.superEnemy, _position);
				}
				else
				{
					InstEnemy(ACouteauxTiré_Manager.instance.baseEnemy, _position);
				}
			}
		}
	}
}