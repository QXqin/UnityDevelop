using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //动画组件
    private Animator ani;
    //刚体组件
    private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //获取水平轴
        float horizontal = Input.GetAxisRaw("Horizontal");
        //获取垂直轴
        float vertical = Input.GetAxisRaw("Vertical");
        //按下左或右
        if(horizontal!=0)
        {
            ani.SetFloat("Horizontal", horizontal);
            ani.SetFloat("Vertical", 0);
        }
        //按下上或下
        if (vertical != 0)
        {
            ani.SetFloat("Vertical", vertical);
            ani.SetFloat("Horizontal", 0);
        }
        //切换跑步
        Vector2 dir = new Vector2(horizontal, vertical);
        ani.SetFloat("Speed", dir.magnitude);
        //朝该方向移动
        rBody.velocity = dir * 0.9f;

    }
}
