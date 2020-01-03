using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Game
{
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
