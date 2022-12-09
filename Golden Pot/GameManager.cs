namespace Golden_Pot
{
    public class GameManager
    {
        private static Coordinates size;
        private static EntityManager entityManager;
        private static MovementHandler movementHandler;
        private static Snake snake;

        public static async Task play()
        {
            Console.WriteLine("Start game");

            init();

            View view = new View(entityManager, size);
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
                                snake.setDirection(Direction.up);
                                break;
                            case ConsoleKey.RightArrow:
                                snake.setDirection(Direction.right);
                                break;
                            case ConsoleKey.DownArrow:
                                snake.setDirection(Direction.down);
                                break;
                            case ConsoleKey.LeftArrow:
                                snake.setDirection(Direction.left);
                                break;
                        }
                    }

                    // 50 time a sec should be enough
                    await Task.Delay(20);
                }
            }

            var monitorKeyPressed = MonitorKeyPressed();

            bool gameOver = false;
            do
            {
                gameOver = movementHandler.move(snake);
                view.show();
                await Task.Delay(1000);
            } while (!gameOver);

            Console.WriteLine("Game over!");
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
        }
    }
}

