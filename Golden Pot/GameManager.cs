namespace Golden_Pot
{
    public class GameManager
    {
        private Entity[,] map;
        private EntityManager entityManager;

        public GameManager(uint xSize, uint ySize)
        {
            map = new Entity[xSize, ySize];
            entityManager = new EntityManager();
        }

        public Entity[,] getMap()
        {
            return map;
        }
    }
}