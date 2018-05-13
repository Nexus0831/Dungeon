using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;  // ターゲットへの参照
    private Vector3 offset;  // 相対座標

    void Start()
    {
        //自分自身とtargetとの相対距離を求める
        offset = GetComponent<Transform>().position - target.position;
    }

    void Update()
    {
        // 自分自身の座標に、targetの座標に相対座標を足した値を設定する
        GetComponent<Transform>().position = target.position + offset;

        // マウスの右クリックを押している間
        if (Input.GetMouseButton(1))
        {
            // マウスの移動量
            float mouseInputX = Input.GetAxis("Mouse X");
            float mouseInputY = Input.GetAxis("Mouse Y");
            // targetの位置のY軸を中心に、回転（公転）する
            //GetComponent<Transform>().RotateAround(offset, Vector3.up, mouseInputX * Time.deltaTime * 200f);
            GetComponent<Transform>().RotateAround(offset, Vector3.up, mouseInputX * Time.deltaTime * 200f);
            // カメラの垂直移動（※角度制限なし、必要が無ければコメントアウト）
            GetComponent<Transform>().RotateAround(offset, transform.right, mouseInputY * Time.deltaTime * 200f);
        }
    }
}