using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour {
    // Update is called once per frame
    private Animator anim;
    private Rigidbody rb;

    private void Start()
    {
        anim = GetComponent<Animator>();   // ...(1)
        rb = GetComponent<Rigidbody>();
    }
    void Update () {
        

        if (Input.GetButtonDown("Jump"))   // ...(2)
        {
            if (!anim.IsInTransition(0))
            {
                rb.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
                //anim.SetBool("is_jumping", true);
            }



        }

        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);   // ...(3)
        if (state.IsName("Locomotion.Jump"))   // ...(4)
        {
            // 以下、カーブ調整をする場合の処理
            // 以下JUMP00アニメーションについているカーブJumpHeightとGravityControl
            // JumpHeight:JUMP00でのジャンプの高さ（0〜1）
            // GravityControl:1⇒ジャンプ中（重力無効）、0⇒重力有効
            //float jumpHeight = 0;
            float gravityControl = 0;
            if (gravityControl > 0)
                rb.useGravity = false;  //ジャンプ中の重力の影響を切る

            // レイキャストをキャラクターのセンターから落とす
            Ray ray = new Ray(transform.position + Vector3.up, -Vector3.up);
            RaycastHit hitInfo = new RaycastHit();
            Physics.Raycast(ray, out hitInfo);

            // Jump bool値をリセットする（ループしないようにする）               
            anim.SetBool("is_jumping", false);
        }
	}
}
