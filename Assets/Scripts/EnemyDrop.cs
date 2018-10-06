using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour {

    public GameObject enemy;
    public Vector3 enemyInstantiateVector;
    public Transform enemyInstantiateTransform;

    // Use this for initialization
    void Start () {
        StartCoroutine(EnemyFall());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator EnemyFall()
    {
        for (int i = 0; i < 100; i++)
        {
            System.Random rnd = new System.Random();
            enemyInstantiateVector.x = rnd.Next(7, 48);
            enemyInstantiateVector.y = rnd.Next(16, 130);
            enemyInstantiateVector.z = 0;
            transform.position = enemyInstantiateVector;
            Instantiate(enemy, transform);
            yield return new WaitForSeconds(1);
        }
    }
}
