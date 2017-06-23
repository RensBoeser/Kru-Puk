using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kru_Puk
{
  class EntityFactory
  {
    private Texture2D[] ZombieWalking;

    public EntityFactory(Texture2D[] ZombieWalking)
    {
      this.ZombieWalking = ZombieWalking;
    }

    public AIZombie CreateZombie(Point position)
    {
      return new AIZombie(position, 100, new Random().Next(5, 10), ZombieWalking, 128, 128);
    }
  }
}
