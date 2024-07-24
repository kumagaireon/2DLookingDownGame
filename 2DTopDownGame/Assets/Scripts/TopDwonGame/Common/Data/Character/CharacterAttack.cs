using UnityEngine;
namespace Common.Data.Character
{
    /// <summary>
    /// キャラクターの攻撃を管理する抽象クラス
    /// </summary>
    public abstract class CharacterAttack : MonoBehaviour
    {
        public int damage { get; set; }
        protected GameObject currentObject;

        // 攻撃メソッド。攻撃可能な場合にターゲットのHPを減少させる
        public virtual void Attack()
        {
            if (IsAttack()) // 攻撃可能かどうかをチェック
            {
                // ターゲットのCharacterHpコンポーネントを取得
                CharacterHp hp = currentObject.GetComponent<CharacterHp>();

                // ターゲットのHPを減少させる
                hp.HP(damage, currentObject);

                // 攻撃後にターゲットをクリア
                currentObject = null;
            }
        }

        // 攻撃可能かどうかを判定する抽象メソッド
        protected abstract bool IsAttack();

        // トリガーに入ったときに呼び出されるメソッド
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // トリガーに入ったオブジェクトを現在のターゲットとして設定
            currentObject = collision.gameObject;
        }
    }
}