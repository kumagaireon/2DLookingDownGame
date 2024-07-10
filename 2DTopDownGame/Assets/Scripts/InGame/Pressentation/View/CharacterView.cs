
using UnityEngine;

namespace InGame.Pressentation.View
{
    public interface ICharacterView
    {
        void OnCharacterDirection(Vector2 direction);
    }

    public class CharacterView : MonoBehaviour, ICharacterView
    {
        [SerialzeField] SpriteRenderer renderer;

        public void OnCharacterDirection(Vector2 direction)
        {
            if(direction==Vector2.zero)
            {
                return;
            }
            renderer.flipX = direction.x < 0.0f;
        }
    }
}