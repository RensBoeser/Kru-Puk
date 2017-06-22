using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kru_Puk
{
    class CollisionGroups
    {
        private Players[] Players;
        private Projectile[] Projectiles;
        private AIZombies[] Zombies;
        private AIPlayers[] AIPlayers;

        CollisionGroups(Players[] Players, Projectile[] Projectiles, AIZombies[] AIZombies, AIPlayers[] AIPlayers)
        {
            this.Players = Players;
            this.Projectiles = Projectiles;
            this.AIZombies = AIZombies;
            this.AIPlayers = AIPlayers;

        }
    }
}
