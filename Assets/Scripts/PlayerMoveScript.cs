using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    Rigidbody2D rigid;
    public float Jumpflap;
    public float MoveSpeed;
    public KeyCode JumpKey;
    
    private float x = 0;
    private float y = 0;

    public bool IsGround;
    public GroundCheckScript ground_check_script; 
    public bool JumpKeyPush;

    Vector2 DefaultLocalScale;
    [HideInInspector]
    public int Direction;
    public int DirectionOfLocalScaleX;
    private float JumpPowerUpTime;

    private bool JumpMove;
    // Start is called before the first frame update
    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
        //
        DefaultLocalScale = this.gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        if(this.transform.localScale.x < 0){
            DirectionOfLocalScaleX = -1;
        }else if(this.transform.localScale.x > 0){
            DirectionOfLocalScaleX = 1;
        }
        if(x > 0){
            Direction = 1;
        }else if(x < 0){
            Direction = -1;
        }
        IsGround = ground_check_script.IsGround;
        if(y > 0){
            JumpKeyPush = true;
        }
        if(y == 0 || y < 0){
            JumpKeyPush = false;
        }
        if(x != 0){
            this.transform.localScale = new Vector2(Direction * DefaultLocalScale.x, DefaultLocalScale.y);
        }
        if(JumpKeyPush){

            JumpMove = true;
        }else{
            JumpPowerUpTime = 0;
            JumpMove = false;
        }
        
    }

    void FixedUpdate()
    {

        if(IsGround && JumpMove){
            rigid.velocity = new Vector2(rigid.velocity.x, Jumpflap);
        }
        rigid.velocity = new Vector2(x * MoveSpeed, rigid.velocity.y);



    }
}
