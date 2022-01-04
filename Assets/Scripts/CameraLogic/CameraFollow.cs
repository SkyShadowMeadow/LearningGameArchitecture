using UnityEngine;

namespace Scripts.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        private Transform _following;
        [SerializeField] private float _angleRotationX;
        [SerializeField] private float _offsetY;
        [SerializeField] private float _distance;

        public void SetWhatToFollow(GameObject following) => _following = following.transform;

        private void LateUpdate()
        {
            Quaternion rotation = Quaternion.Euler(_angleRotationX, 0, 0);
            var position = rotation * new Vector3(0, 0, -_distance) + GetFollowingPosition();

            transform.rotation = rotation;
            transform.position = position;
        }

        private Vector3 GetFollowingPosition()
        {
            Vector3 followingPosition = _following.position;
            followingPosition.y += _offsetY;
            return followingPosition;
        }
    }
}
