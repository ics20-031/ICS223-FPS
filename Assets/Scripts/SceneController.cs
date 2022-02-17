using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    private GameObject enemy;
    private Vector3 spawnPoint = new Vector3(0, 0, 5);
    private int enemyNumber = 3;
    private GameObject[] enemyArray;

    private void Start()
    {
        enemyArray = new GameObject[enemyNumber];
    }

    // Update is called once per frame 

    void Update()
    {
        for (int i = 0; i < enemyArray.Length; i++)
        {
            if (enemyArray[i] == null)
            {
                enemy = Instantiate(enemyPrefab) as GameObject;
                enemy.transform.position = spawnPoint;
                float angle = Random.Range(0, 360);
                enemy.transform.Rotate(0, angle, 0);
                enemyArray[i] = enemy;
            }
        }
    }
}
