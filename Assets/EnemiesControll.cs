using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemiesControll : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPredab;
    [SerializeField]
    private int enemyCount;
    [SerializeField]
    private float spawnRadius;
    [SerializeField]
    private float spawnDis;
    [SerializeField]
    private Transform P_pos;
    
    [SerializeField]
    private Playermove Player;
    private List<Transform> Enemies = new List<Transform>();
    private List<Transform> currentTargets = new List<Transform>();
    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0;i <enemyCount;i++)
        {
            Vector3 center = Player.transform.forward * spawnDis;

            Vector2 circle = Random.insideUnitSphere * spawnRadius;

            Vector3 randomPos = center + new Vector3(circle.x,circle.y,0);

            GameObject enemy = Instantiate(enemyPredab,randomPos,Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTargets();

        if(Input.GetKeyDown(KeyCode.Z))
        {
            LockOnTargets();
        }
    }

    void UpdateTargets()
    {
        currentTargets.Clear();
        var NomalZ = new Vector3(0, 0, 1);
        var PlayerForward = Player.worldMatrix * NomalZ;
        var P_ViewCos = Mathf.Cos(Player.ViewRadian);
        var candidates = new List<(Transform enemy, float dot)>();
        foreach(var enemy in Enemies)
        {
            Vector3 dir = (enemy.position - P_pos.position).normalized;
            float dot = Vector3.Dot(PlayerForward, dir);

            if(dot >= P_ViewCos)
            {
                candidates.Add((enemy, dot));
            }
        }

        candidates.Sort((a, b) => b.dot.CompareTo(a.dot));

        foreach(var c in candidates.Take(8))
        {
            currentTargets.Add(c.enemy);
        }
    }

    void LockOnTargets()
    {
        foreach(var target in currentTargets)
        {
            var enemyScript = target.GetComponent<enemy_>();
            if(enemyScript!=null)
            {
                enemyScript.SetTarget(true);
            }
        }
    }
}
