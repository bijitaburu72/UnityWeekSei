using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    EnemyStatus enemy_status;
    public GameObject BulletPrefab;
    public Transform BulletPrefabCreatePosition;

    public bool BulletShot; //こいつをTrueにすれば、銃が撃たれる。

    GameObject Player;

    float EnemyToPlayer;
    int EnemyToPlayerDirection;
    Vector3 DefaultLocalScale;
    // Start is called before the first frame update
    void Start()
    {
        enemy_status = this.gameObject.GetComponent<EnemyStatus>();
        Player = GameObject.FindWithTag("Player");
        DefaultLocalScale = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //敵からPlayerまでの距離(左側にいるのか 右側にいるのか)
        EnemyToPlayer = Player.transform.position.x - this.transform.position.x;
        if(EnemyToPlayer > 0){
            EnemyToPlayerDirection = 1;
        }else if(EnemyToPlayer < 0){
            EnemyToPlayerDirection = -1;
        }
        this.transform.localScale = new Vector2(DefaultLocalScale.x * EnemyToPlayerDirection, DefaultLocalScale.y);

        if(BulletShot){
            GameObject BulletShotObject = Instantiate(BulletPrefab, BulletPrefabCreatePosition.position, Quaternion.identity);
            BulletScript bullet_script = BulletShotObject.GetComponent<BulletScript>();
            bullet_script.direction = EnemyToPlayerDirection;
            bullet_script.bullet_attack_col.AttackPower = enemy_status.AttackPowerBullet;
            bullet_script.speed = enemy_status.BulletSpeed;
            bullet_script.DistanceDestroy = enemy_status.BulletDistanceDestroy;
            BulletShot = false;
        }
    }
}
