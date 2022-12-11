namespace Golden_Pot
{
    public class GameManager
    {
        private static Coordinates size;
        private static EntityManager entityManager;
        private static MovementHandler movementHandler;
        private static Snake snake;
        private static View view;

        public static async Task play()
        {
            init();

            CancellationTokenSource cts = new CancellationTokenSource();

            async Task MonitorKeyPressed()
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

                    // 10 time a sec should be enough
                    await Task.Delay(100);
                }
            }

            var monitorKeyPressed = MonitorKeyPressed();

            bool gameOver = false;
            do
            {
                gameOver = movementHandler.move(snake);
                entityManager.spawnApple();
                view.show(entityManager.getEntities());
                await Task.Delay(250);
            } while (gameOver);

            Console.WriteLine("Game over!");
            Console.ReadKey();
            cts.Cancel();
            await monitorKeyPressed;
        }

        public static void init()
        {
            size = new Coordinates(20, 20);
            entityManager = new EntityManager();
            movementHandler = new MovementHandler(entityManager, size);

            snake = new Snake(new Coordinates(size.getX() / 2, size.getY() / 2));
            entityManager.addEntity(snake);
            view = new View(size);
        }

        public static Coordinates getSize()
        {
            return size;
        }
    }
}

