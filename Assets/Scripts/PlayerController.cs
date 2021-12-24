using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerStatus player_status;
    public GameObject BulletPrefab; //BulletPrefab
    public GameObject BulletPrefabCreatePositionObject; //BulletがCreateされる場所
    public KeyCode BulletCreateKey; //Bulletを発射するKey
    PlayerMoveScript player_move_script;
    // AttackColliderScript attack_collider_script;

    // Start is called before the first frame update
    void Start()
    {
        player_status = this.gameObject.GetComponent<PlayerStatus>();
        player_move_script = this.gameObject.GetComponent<PlayerMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(BulletCreateKey)){
            GameObject Bullet = Instantiate(BulletPrefab, BulletPrefabCreatePositionObject.transform.position, Quaternion.identity);
            BulletScript bullet_script = Bullet.GetComponent<BulletScript>();
            if(bullet_script != null){
                bullet_script.direction = player_move_script.DirectionOfLocalScaleX;
                bullet_script.speed = player_status.BulletSpeed;
                bullet_script.DistanceDestroy = player_status.BulletDestroyDistance;
                bullet_script.bullet_attack_col.AttackPower = player_status.AttackPowerBullet;
                
            }
        }
    }
    
}
