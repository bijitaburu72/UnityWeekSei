using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AttackColliderScript : MonoBehaviour
{
    public enum MineStatus{
        Enemy,
        Player
    }
    // MineStatusでEnemyとPlayerを分けている理由は EnemyとEnemy同士の衝突をさけたり、使いまわしをするため。
    public MineStatus mine_status; //自分がPlayerかEnemyか
    public float AttackPower; //攻撃力(EnemyStatus PlayerStatus それぞれから代入してあげる。)

    GameObject Player;
    PlayerStatus player_status;

    public UnityEvent HittingEvent; //ヒットしたときのイベント
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        player_status = Player.GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(mine_status == MineStatus.Player){
            //自分がPlayerならばEnemyに当たったとき
            if(other.gameObject.tag == "Enemy"){
                EnemyStatus enemy_status = other.gameObject.GetComponent<EnemyStatus>();
                enemy_status.Attacked(AttackPower);
                HittingEvent.Invoke();
            }
        }else if(mine_status == MineStatus.Enemy){
            //自分がEnemyならばPlayerに当たったとき
            if(other.gameObject.tag == "Player"){
                player_status.Attacked(AttackPower);
                HittingEvent.Invoke();
            }
        }


    }
}
