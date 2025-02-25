using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    private GameObject enemy;
    private Vector3 spawnPoint = new Vector3(0, 0, 5);
    private int enemyNumber = 3;
    private GameObject[] enemyArray;

    private int clockTime = 10;
    private Coroutine countingCoroutine; 

    [SerializeField]
    private TextMeshProUGUI countdown;

    // iguanas
    [SerializeField]
    private GameObject iguana;
    [SerializeField]
    private Transform iguanaSpawn;
    private int iguanaNumber = 10;
    private GameObject[] iguanaArray;

    void Start()
    {
        enemyArray = new GameObject[enemyNumber];
        countingCoroutine = StartCoroutine(Tick());

        // spawn the iguanas 
        iguanaArray = new GameObject[iguanaNumber];
        for (int i = 0; i < iguanaNumber; i++)
        {
            iguana = Instantiate(iguana) as GameObject;
            iguana.transform.position = iguanaSpawn.position;
            float angle = Random.Range(0, 360);
            iguana.transform.Rotate(0, angle, 0);
            iguanaArray[i] = iguana;
        }
    }

    IEnumerator Tick()
    {
        countdown.text = clockTime.ToString();
        for (int i = clockTime; i > 0; i--)
        {
            yield return new WaitForSeconds(1);
            clockTime--;
            countdown.text = clockTime.ToString();
        }
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

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (countingCoroutine != null)
            {
                StopCoroutine(countingCoroutine);
                countingCoroutine = null;
            } else
            {
                countingCoroutine = StartCoroutine(Tick());
            }
        }
    }

}
