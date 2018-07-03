﻿using UnityEngine;
using System.Collections;

public class Playermove : MonoBehaviour
{
    Rigidbody2D rigid2D;
    
    float jumpForce = 400.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 3.1f;
    private float coolTime = 0.5f;
    private float lastCheckTime;
    private float coolTime2 = 0.5f;
    private float lastCheckTime2;
    public int jumpcount = 2;
    public bool isGrounded = false;

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        jumpcount = 0;
    }

    private void OnCollisionEnter2D(Collision2D col)

    {

        if (col.gameObject.tag == "Ground")
        isGrounded = true;
        jumpcount = 2;
    }


    void Update()
    {
        if (isGrounded)
            // 점프한다
            if (Input.GetKeyDown(KeyCode.X) && jumpcount > 0)

            {
                this.rigid2D.AddForce(transform.up * this.jumpForce);
                jumpcount--;
            }

        //오른쪽으로 대쉬 쿨타임 1초
        if (Input.GetKeyDown(KeyCode.C) && (Input.GetKey(KeyCode.RightArrow)))
        {
            if ((lastCheckTime + coolTime) < Time.time)
            {
                transform.Translate(2, 0, 0);
                lastCheckTime = Time.time;
        }
        }
        //왼쪽으로 대쉬 쿨타임 1초
        if (Input.GetKeyDown(KeyCode.C) && (Input.GetKey(KeyCode.LeftArrow)))
        {
        if ((lastCheckTime2 + coolTime2) < Time.time)
        {
        transform.Translate(-2, 0, 0);
        lastCheckTime2 = Time.time;
        }
        }


        // 좌우이동
        int key = 0;
            if (Input.GetKey(KeyCode.RightArrow)) key = 1;
            if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

            // 플레이어 속도
            float speedx = Mathf.Abs(this.rigid2D.velocity.x);

            // 속도 제한
            if (speedx < this.maxWalkSpeed)
            {
                this.rigid2D.AddForce(transform.right * key * this.walkForce);
            }

            // 캐릭터 스프라이트 반전
            if (key != 0)
            {
                transform.localScale = new Vector3(key, 1, 1);
            }

        }

    }

