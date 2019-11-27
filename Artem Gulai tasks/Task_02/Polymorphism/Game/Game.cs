using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Polymorphism.Game.Bonuses;
using Task_02.Polymorphism.Game.Interfaces;
using Task_02.Polymorphism.Game.Monsters;
using Task_02.Polymorphism.Game.Obstacles;

namespace Task_02.Polymorphism.Game
{
    /// <summary>
    /// Main class of the Game
    /// </summary>
    class Game
    {
        private Field field;
        private Player player;
        private List<Monster> monsters;
        private List<Obstacle> obstacles;
        private List<Bonus> bonuses;

        public Game()
        {
            field = Field.GetField();
            player = new Player(100,100,15);
            monsters = new List<Monster>();
            obstacles = new List<Obstacle>();
            bonuses = new List<Bonus>();
        }

        public void SetUp()
        {
            // setting up monsters
            monsters.Add(new Wolf());
            monsters.Add(new Bear());

            // setting up obstacles
            obstacles.Add(new Tree());
            obstacles.Add(new Stone());
            obstacles.Add(new Pit());

            // setting up bonuses
            bonuses.Add(new Apple());
            bonuses.Add(new Banana());
            bonuses.Add(new Cherry());

            Console.WriteLine("The game is set up.");
        }

        /// <summary>
        /// Demonstration: monsters hit player.
        /// </summary>
        public void HitPlayerByMonster()
        {
            foreach (Monster monster in monsters)
            {
                monster.Hit(player);
            }
        }

        /// <summary>
        /// Demonstration: monsters hit monsters.
        /// </summary>
        public void HitMonsterByMonster()
        {
            monsters[0].Hit(monsters[1]);
            monsters[1].Hit(monsters[0]);
        }

        /// <summary>
        /// Demonstration: player hits monsters and player.
        /// </summary>
        public void PlayerHit()
        {
            foreach (Monster monster in monsters)
            {
                player.Hit(monster);
            }
            player.Hit(player);
        }

        /// <summary>
        /// Demonstration. Player collects bonuses.
        /// </summary>
        public void PlayerCollectBonus()
        {
            foreach (Bonus bonus in bonuses)
            {
                player.CollectBonus(bonus);
            }
            Console.WriteLine(player);
        }

        /// <summary>
        /// Demonstration: monsters move.
        /// </summary>
        public void MonsterMove()
        {
            foreach(Monster monster in monsters)
            {
                monster.Move();
            }
        }

        /// <summary>
        /// Demonstration: all move.
        /// </summary>
        public void EveryoneMove()
        {
            List<IMovable> movables = new List<IMovable>();
            movables.Add(player);
            foreach (Monster monster in monsters)
            {
                movables.Add(monster);
            }

            foreach(IMovable movable in movables)
            {
                movable.Move();
            }
        }

        /// <summary>
        /// Demonstration: hittables hit movables.
        /// </summary>
        public void EveryoneHit()
        {
            List<IMovable> movables = new List<IMovable>();
            movables.Add(player);
            movables.AddRange(monsters);

            List<IHittable> hittables = new List<IHittable>();
            hittables.Add(player);
            hittables.AddRange(monsters);
            hittables.AddRange(obstacles);

            foreach (IHittable hittable in hittables)
            {
                foreach (IMovable movable in movables)
                {
                    hittable.Hit(movable);
                }
            }
        }
    }

    class GameDemo
    {
        public static void Demo()
        {
            Polymorphism.Game.Game game = new Polymorphism.Game.Game();
            game.SetUp();
            Console.ReadLine();
            game.HitPlayerByMonster();
            Console.ReadLine();
            game.HitMonsterByMonster();
            Console.ReadLine();
            game.PlayerHit();
            Console.ReadLine();
            game.PlayerCollectBonus();
            Console.ReadLine();
            game.MonsterMove();
            Console.ReadLine();
            game.EveryoneMove();
            Console.ReadLine();
            game.EveryoneHit();
            Console.ReadLine();
        }
    }
}
