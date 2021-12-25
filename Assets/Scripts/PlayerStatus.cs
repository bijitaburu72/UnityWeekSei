using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerStatus : MonoBehaviour
{
    public float HP = 100;
    public float AttackPower;
    public bool Death;
    //↡通常攻撃
    public AttackColliderScript[] AttackColliders;
    //↡弾攻撃

    [Header("イベント系")]
    public UnityEvent DeathEvent; 
    public UnityEvent AttackedEvent;
    public UnityEvent DeathAnimationEndEvent;
    Animator anim;

    PlayerController player_controller;

    bool death_once = false;

    [Header("弾の設定")]
    public float AttackPowerBullet;
    public float BulletSpeed;
    public float BulletDestroyDistance;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        player_controller = this.gameObject.GetComponent<PlayerController>();
        foreach(AttackColliderScript attack_col_script in AttackColliders){
            //AttackColliderScriptのAttackPowerに自分のステータスの攻撃力を代入してあげる。
            attack_col_script.AttackPower = this.AttackPower;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0){
            //もし死んだら
            //DeathEventを実行。
            Death = true;
            if(!death_once){
                death_once = true;
            }
            if(Death){
                anim.SetBool("Death", death_once);
            }
            DeathEvent.Invoke();
        }
    }

    public void Attacked(float _attacked){
        //プレイヤーが攻撃を受ける関数
        HP -= _attacked;
        AttackedEvent.Invoke();
        anim.SetTrigger("Hurt");
    }

    public void DeathAnimationEnd(){
        //Deathアニメーションが終了したら(AnimationからこのFunctionを指定しています)
        DeathAnimationEndEvent.Invoke();
    }
}
