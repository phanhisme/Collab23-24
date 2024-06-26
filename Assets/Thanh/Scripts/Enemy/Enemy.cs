using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;


    /*private EnemyData enemyData;
    EnemyHealth enemyHealth;
    public GameObject gold;
    PlayerPointer playerPointer;

    private void Start()
    {
        enemyHealth = FindObjectOfType<EnemyHealth>();
        playerPointer = FindObjectOfType<PlayerPointer>();
    }

    public void InitEnemy()
    {
        EnemyDataSO enemyDataSO = Resources.Load<EnemyDataSO>("Enemy/EnemyData_");

        enemyData = new EnemyData
        {
            //ID = enemyDataSO.ID,
            //health = enemyDataSO.health,
            baseGoldDrop = enemyDataSO.baseGoldDrop,
            finalGoldDrop = enemyDataSO.finalGoldDrop,
            currencyMultiplier = enemyDataSO.currencyMultiplier,
        };
    }

    public EnemyData GetEnemyData()
    {
        return enemyData;
    }

    public void SetEnemyGoldDrop()
    {
        enemyData.finalGoldDrop = enemyData.baseGoldDrop * enemyData.currencyMultiplier;

    }

    public void EnemyDeath()
    {
        if(enemyHealth.currentHealth <= 0 && playerPointer.ldActive == true)
        {
            GameObject go = Instantiate(gold, Vector3.zero, Quaternion.identity);
            go.GetComponent<ItemDrop>().SetData(enemyData.rewardType, enemyData.finalGoldDrop);
        }
    }*/

