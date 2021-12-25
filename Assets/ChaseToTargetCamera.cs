using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseToTargetCamera : MonoBehaviour
{
    public GameObject Target;
    public float smooth; //滑らかさ

    public Vector3 MaxPosition;
    public Vector3 MinPosition;
    float init_z_position;
    // Start is called before the first frame update
    void Start()
    {
        init_z_position = this.transform.position.z;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float x = Mathf.Clamp(Target.transform.position.x, MinPosition.x, MaxPosition.x);
        float y = Mathf.Clamp(Target.transform.position.y, MinPosition.y, MaxPosition.y);
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(x, y, init_z_position), smooth);
    }
}
