﻿using UnityEngine;
using System.Collections;

public class Playermove : MonoBehaviour
{
    Rigidbody2D rigid2D;

    float jumpForce = 400.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 3.1f;
    float dashForce = 400.0f;
    float time = 0f;
    float dashForce2 = 400.0f;
    float time2 = 0f;
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

        //오른쪽으로 대쉬
        if (Input.GetKeyDown(KeyCode.C) && (Input.GetKey(KeyCode.RightArrow)))
        {
            time = Time.time;
        }
        if ((Time.time < time + 1f) && (Input.GetKeyDown(KeyCode.C)))
        {
        this.rigid2D.AddForce(transform.right * this.dashForce);
        {

         }
         }
        //왼쪽으로 대쉬
        if (Input.GetKeyDown(KeyCode.C) && (Input.GetKey(KeyCode.LeftArrow)))
        {
        time2 = Time.time;
        }
        if ((Time.time < time2 + 1f) && (Input.GetKeyDown(KeyCode.C)))
        {
        this.rigid2D.AddForce(transform.right * -1 * this.dashForce2);
            {

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
