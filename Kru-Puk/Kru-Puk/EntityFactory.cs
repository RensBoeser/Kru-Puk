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
    private Texture2D[]   levels;
    private Texture2D[]   zombieWalking;
    private Texture2D[]   assets;
    private Texture2D[][] areas;

    public EntityFactory(Texture2D[] zombieWalking, Texture2D[] levels, Texture2D[] assets, Texture2D[][] areas)
    {
      this.zombieWalking = zombieWalking;
      this.levels = levels;
      this.assets = assets;
      this.areas  = areas;
    }

    public AIZombie CreateZombie(Point position)
    {
      return new AIZombie(position, 100, new Random().Next(5, 10), zombieWalking, 128, 128);
    }

    public Area CreateArea(Point position, int width, int height, int areabackground, Asset[] assets)
    {
      return new Area(position, width, height, areas[areabackground], assets);
    }

    public Asset CreateAsset(Point position, int assetID)
    {
      return new Asset(position, assets[assetID]);
    }

    public Level CreateLevel(Area[] areas, IEntity[] entities, Point spawnpoint)
    {
      return new Level(areas, levels, entities, spawnpoint);
    }
  }
}
