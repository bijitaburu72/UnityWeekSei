using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class EnemyMove : MonoBehaviour
{
    public string[] TargetTurningPointTag; //ぶつかったら迂回するtagたちをここに書く
    public float speed;
    public float DirectionX = 1;
    Rigidbody2D rigid;

    private bool turn;

    Vector3 DefaultLocalScale;
    public bool Move = true;
    EnemyController enemy_controller;
    // Start is called before the first frame update
    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
        DefaultLocalScale = this.transform.localScale;
        enemy_controller = this.gameObject.GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = new Vector2(DefaultLocalScale.x * DirectionX, DefaultLocalScale.y);
        if(enemy_controller.BulletShot){
            //銃を撃ってる間は動けないようにする
            Move = false;
        }
        if(Move){
            rigid.velocity = new Vector2(DirectionX * speed, rigid.velocity.y);
        }else{
            rigid.velocity = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(TargetTurningPointTag.Contains(other.gameObject.tag)){
            //もしTargetTurningPointTagのなかにいま触れたオブジェクトのtagがあったら
            // turn = true;

            DirectionX *= -1;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(TargetTurningPointTag.Contains(collision.gameObject.tag)){
            //もしTargetTurningPointTagのなかにいま触れたオブジェクトのtagがあったら
            // turn = true;
            
            DirectionX *= -1;
        }    
    }
}
