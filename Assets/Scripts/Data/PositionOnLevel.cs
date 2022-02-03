
namespace Assets.Scripts.Data
{
    public class PositionOnLevel
    {
        public string LevelName;
        public Vector3Data Position;

        public PositionOnLevel(string levelName, Vector3Data position)
        {
            LevelName = levelName;
            Position = position;
        }
    }
}
