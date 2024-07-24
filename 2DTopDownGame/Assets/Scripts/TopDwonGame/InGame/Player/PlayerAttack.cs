using Common.Data.Character;
using TopDownGame.InGame;
using UnityEngine.InputSystem;

namespace InGame.Player
{
    /// <summary>
    /// プレイヤーの攻撃クラス。CharacterAttackを継承し、InGameInputProvider.IPlayerActionsインターフェースを実装
    /// </summary>
    public class PlayerAttack : CharacterAttack, InGameInputProvider.IPlayerActions
    {
        private InGameInputProvider provider; // 入力プロバイダー

        // オブジェクトが有効になったときに呼び出される
        void OnEnable()
        {
            provider = new InGameInputProvider(); // 入力プロバイダーのインスタンスを作成
            provider.Player.SetCallbacks(this); // コールバックを設定
            provider.Enable(); // 入力プロバイダーを有効化
        }

        // オブジェクトが無効になったときに呼び出される
        void OnDisable()
        {
            provider.Disable(); // 入力プロバイダーを無効化
            provider.Dispose(); // 入力プロバイダーを破棄
        }

        // 攻撃入力があったときに呼び出される
        public void OnAttack(InputAction.CallbackContext context)
        {
            Attack(); // 攻撃メソッドを呼び出す
        }

        public void OnMove(InputAction.CallbackContext context)
        {

        }

        // 攻撃可能かどうかを判定するメソッド
        protected override bool IsAttack()
        {
            // currentObjectがnullでなく、かつタグが"Enemy"である場合に攻撃可能とする
            return currentObject != null && currentObject.CompareTag("Enemy");
        }
    }
}