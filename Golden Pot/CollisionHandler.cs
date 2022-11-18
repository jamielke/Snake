using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Golden_Pot
{
    public class CollisionHandler
    {
        private EntityManager entityManager;
        private PlayerManager playerManager;

        public CollisionHandler(EntityManager entityManager, PlayerManager playerManager)
        {
            this.entityManager = entityManager;
            this.playerManager = playerManager;
        }

        public List<Player> checkForCollision()
        {
            List<Player> loser = new List<Player>();

            foreach (Player player in playerManager.getPlayers())
            {
                foreach (Entity entity in entityManager.getEntities())
                {
                    if (player.getSnake().getCoordinates == entity.getCoordinates)
                    {
                        if (entity is Apple)
                        {
                            entityManager.removeEntity(entity);
                            player.getSnake().grow();
                        }
                        else
                        {
                            loser.Add(player);
                        }
                    }
                }
            }

            return loser;
        }

        public List<Player> checkOutOfBounds()
        {
            List<Player> loser = new List<Player>();

            foreach (Player player in playerManager.getPlayers())
            {

            }

            return loser;
        }
    }
}