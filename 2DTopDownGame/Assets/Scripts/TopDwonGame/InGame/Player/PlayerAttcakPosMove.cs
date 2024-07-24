using UnityEngine;

namespace InGame.Player
{
    public class PlayerAttcakPosMove : MonoBehaviour
    {
        [SerializeField] private GameObject Player;
        [Header("ÉvÉåÉCÉÑÅ[Ç©ÇÁÇÃãóó£")][SerializeField] private float followDistance;
        private void FixedUpdate()
        {
            FollowMouse();
        }
        void FollowMouse()
        {
            if (Player != null)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;

                Vector3 direction = (mousePosition - Player.transform.position).normalized;
                Vector3 targetPosition = Player.transform.position + direction * followDistance;

                transform.position = targetPosition;
            }
        }
    }
}