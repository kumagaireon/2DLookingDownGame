using UnityEngine;
namespace Common.Data.Character
{
    /// <summary>
    /// キャラクターの死亡処理を管理する抽象クラス
    /// </summary>
    public abstract class CharacterDead : MonoBehaviour
    {
        public SoundController SoundController { get; set; }

        // 指定されたターゲットオブジェクトを非アクティブにするメソッド
        public void Dead(GameObject target)
        {
            SoundController.Death();
            target.gameObject.SetActive(false);
        }
    }
}