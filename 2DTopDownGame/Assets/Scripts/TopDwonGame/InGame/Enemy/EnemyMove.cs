using Common.Data.Character;
using UnityEngine;

namespace InGame.Enemy
{
    /// <summary>
    /// 敵の移動を管理するクラス。CharacterMoveを継承
    /// </summary>
    public class EnemyMove : CharacterMove
    {
        [SerializeField] CharacterBase player;
        // 移動メソッドをオーバーライド
        public override void Move()
        {
            UpdateDirection(); // 移動方向を更新
            base.Move(); // 親クラスのMoveメソッドを呼び出す
        }

        // 移動方向を更新するメソッド
        void UpdateDirection()
        {
            // プレイヤーの位置を取得
            Vector2 playerPosition = player.transform.position;

            // 現在の位置を取得
            Vector2 currentPosition = transform.position;

            // プレイヤーの方向を計算し、正規化して方向ベクトルを設定
            direction = (playerPosition - currentPosition).normalized;
        }
    }
}