using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemiesControll : MonoBehaviour
{
    private const int Enemynum = 24;

    public int Targetindex { get; set; } = 0;
    [SerializeField]
    private Playermove Player;
    [SerializeField,Header("“Gˆê——")]
    private enemy_[] Enemies = new enemy_[Enemynum];

    private enemy_[] Targets = new enemy_[Enemynum];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var NomalZ = new Vector3(0,0,1);
        var PlayerForward = Player.worldMatrix * NomalZ;
        var P_ViewCos = Mathf.Cos(Player.ViewRadian);
        for(int i= 0;i < Enemies.Length;i++)
        {
            var PtoE = (Enemies[i].transform.position - Player.transform.position ).normalized;

            var Dot = Vector3.Dot(PlayerForward,PtoE);

            if (P_ViewCos <= Dot)
            {
                Targets[i] = Enemies[i];
            }
            else
            {
                if(Targetindex==i)
                {
                    Targets[Targetindex]?.SetTarget(false);
                }
                Targets[i] = null;
            }
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            UpdateTarget();
        }
    }

    public void UpdateTarget()
    {
        Targets[Targetindex]?.SetTarget(false);
        for(int index = ((Targetindex + 1)% Targets.Length);index != Targetindex; index = ((index + 1) % Targets.Length))
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
