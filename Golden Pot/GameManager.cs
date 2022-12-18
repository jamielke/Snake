namespace Golden_Pot
{
    public class GameManager
    {
        private EntityManager entityManager;
        private int gameTick;
        private MovementHandler movementHandler;
        private Coordinates size;
        private Snake snake;
        private View view;

        public GameManager()
        {
            this.entityManager = new EntityManager();
            this.gameTick = 250;
            this.movementHandler = new MovementHandler(entityManager, size);
            this.size = new Coordinates(20, 20);
            this.snake = new Snake(new Coordinates(size.getX() / 2, size.getY() / 2));
            this.view = new View(size);

            entityManager.addEntity(snake);
        }

        public async Task play()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            var monitorKeyPressed = MonitorKeyPressed(cts, gameTick);

            bool gameOver = false;
            do
            {
                gameOver = movementHandler.move(snake);
                entityManager.spawnApple();
                view.show(entityManager.getEntities());
                await Task.Delay(gameTick);
            } while (gameOver);

            Console.WriteLine("Game over!");
            Console.ReadKey();
            cts.Cancel();
            await monitorKeyPressed;
        }

        // Private

        private async Task MonitorKeyPressed(CancellationTokenSource cts, int gameTick)
        {
            while (!cts.Token.IsCancellationRequested)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true).Key;
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            snake.setNextDirection(Direction.up);
                            break;
                        case ConsoleKey.RightArrow:
                            snake.setNextDirection(Direction.right);
                            break;
                        case ConsoleKey.DownArrow:
                            snake.setNextDirection(Direction.down);
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.setNextDirection(Direction.left);
                            break;
                    }
                }

                // How often per gameTick
                await Task.Delay(gameTick / 10);
            }
        }
    }
}

