using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    private const int Enemynum = 24;

    [SerializeField]
    private Transform P_pos;
    public int Targetindex { get; set; } = 0;
    [SerializeField]
    private Playermove Player;
    [SerializeField, Header("“Gˆê——")]
    private enemy_[] Enemies = new enemy_[Enemynum];

    private enemy_[] Targets = new enemy_[Enemynum];
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
        var NomalZ = new Vector3(0, 0, 1);
        var PlayerForward = Player.worldMatrix * NomalZ;
        var P_ViewCos = Mathf.Cos(Player.ViewRadian);
        //for (int i = 0; i < Targets.Length; i++)
        //{
        //    var PtoE = (Enemies[i].transform.position - Player.transform.position).normalized;

        //    var Dot = Vector3.Dot(PlayerForward, PtoE);

        //    if (P_ViewCos > Dot && Dot > 0)
        //    {
        //        Targets[i] = Enemies[i];
        //    }
        //    else
        //    {
        //        if (Targetindex == i)
        //        {
        //            Targets[Targetindex]?.SetTarget(false);
        //        }
        //        Targets[i] = null;
        //    }
        //}
        //if (Input.GetKey(KeyCode.Z))
        //{
        //    UpdateTarget();
        //}
    }

    public void UpdateTarget()
    {
        Targets[Targetindex]?.SetTarget(false);
        for (int index = ((Targetindex + 1) % 8); index != Targetindex; index = ((index + 1) % 8))
        {
            if (Targets[index])
            {
                Targetindex = index;
                break;
            }
            Targets[Targetindex]?.SetTarget(true);
        }
    }
}
