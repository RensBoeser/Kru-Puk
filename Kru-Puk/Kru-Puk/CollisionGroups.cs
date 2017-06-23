using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kru_Puk
{
    class CollisionGroups
    {
        private Player[] Players;
        private Projectile[] Projectiles;
        private AIZombie[] Zombies;
        private AIPlayer[] AIPlayers;

        CollisionGroups(Player[] Players, Projectile[] Projectiles, AIZombie[] AIZombies, AIPlayer[] AIPlayers)
        {
            this.Players = Players;
            this.Projectiles = Projectiles;
            this.Zombies = AIZombies;
            this.AIPlayers = AIPlayers;

        }
    }
}
