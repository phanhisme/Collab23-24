using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleStrike : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] PlayerPointer playerPointer;
    //[SerializeField] EnemyHealth enemyHealth;
    [SerializeField] Vector3[] spawnNeedlePosition = new[] { new Vector3(0, 1, 0), new Vector3(-1, 1, 0), new Vector3(1, 1, 0), new Vector3(1, -1, 0), new Vector3(-1, -1, 0) };
    [SerializeField] List<GameObject> needlePositionList;
    public GameObject needle;
    public float radius;
    public Transform circle;


    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerPointer = FindObjectOfType<PlayerPointer>();
        //enemyHealth = GetComponent<EnemyHealth>();
    }
    private void Update()
    {
        PlayerIsDamaged();
        //Debug.Log(playerPointer.needleStrike);
    }

    void PlayerIsDamaged()
    {
        if(Input.GetKeyDown(KeyCode.Z) && playerPointer.needleStrike == true)
        {
            //Debug.Log("spawn needle");
            for (int i = 0; i < spawnNeedlePosition.Length; i++) 
            {
                Instantiate(needle, spawnNeedlePosition[i], transform.rotation, transform.parent);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 position = circle == null ? Vector3.zero : circle.position;
        Gizmos.DrawWireSphere(position, radius);
    }
}
