using UnityEngine;

namespace InGame.Player
{
    /// <summary>
    /// プレイヤーの攻撃位置をマウスに追従させるクラス
    /// </summary>
    public class PlayerAttcakPosMove : MonoBehaviour
    {
        [SerializeField] private GameObject Player;
        [Header("プレイヤーからの距離")][SerializeField] private float followDistance;
      
        // 固定更新メソッド。物理演算の更新タイミングで呼び出される
        private void FixedUpdate()
        {
            FollowMouse(); // マウスに追従する処理を呼び出す
        }

        // マウスの位置に追従するメソッド
        void FollowMouse()
        {
            if (Player != null)
            {
                // マウスのワールド座標を取得
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0; // z座標を0に設定

                // プレイヤーからマウスへの方向を計算し、正規化
                Vector3 direction = (mousePosition - Player.transform.position).normalized;
                // プレイヤーから指定された距離だけ離れた位置を計算
                Vector3 targetPosition = Player.transform.position + direction * followDistance;

                // オブジェクトの位置を更新
                transform.position = targetPosition;
            }
        }
    }
}