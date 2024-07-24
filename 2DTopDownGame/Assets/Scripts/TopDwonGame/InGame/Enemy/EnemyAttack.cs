using Common.Data.Character;
using UnityEngine;

namespace InGame.Enemy
{
    /// <summary>
    /// 敵の攻撃を管理するクラス。CharacterAttackを継承
    /// </summary>
    public class EnemyAttack : CharacterAttack
    {
        [SerializeField] CharacterBase player;
        [SerializeField] private float retreatDistance; // 攻撃後に離れる距離

        // 攻撃メソッドをオーバーライド
        public override void Attack()
        {
            base.Attack(); // 親クラスのAttackメソッドを呼び出す
            RetreatFromPlayer(); // 攻撃後にプレイヤーから離れる
        }

        // トリガー内にオブジェクトが存在する間に呼び出される
        private void OnTriggerStay2D(Collider2D collision)
        {
            currentObject = collision.gameObject; // 現在のオブジェクトを設定
            if (IsAttack()) // 攻撃可能かどうかをチェック
                Attack(); // 攻撃メソッドを呼び出す
        }

        // プレイヤーから離れる処理
        private void RetreatFromPlayer()
        {
            // プレイヤーから離れる方向を計算
            Vector3 direction = (transform.position - player.transform.position).normalized;
            // 離れる位置を計算
            Vector3 retreatPosition = transform.position + direction * retreatDistance;
            // 新しい位置に移動
            transform.position = retreatPosition;
        }

        // 攻撃可能かどうかを判定するメソッド
        protected override bool IsAttack()
        {
            // currentObjectがnullでなく、かつタグが"Player"である場合に攻撃可能とする
            return currentObject != null && currentObject.CompareTag("Player");
        }
    }
}