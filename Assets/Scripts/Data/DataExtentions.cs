using UnityEngine;

namespace Assets.Scripts.Data
{
    public static class DataExtentions
    {
        public static Vector3Data TurnToVector3Data(this Vector3 position) =>
            new Vector3Data(position.x, position.y, position.z);

        public static Vector3 TurnToVector3Unity(this Vector3Data position) =>
            new Vector3(position.X, position.Y, position.Z);

        public static T ToDeserialized<T>(this string json) => JsonUtility.FromJson<T>(json);

    }
}
