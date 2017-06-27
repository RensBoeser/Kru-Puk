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
    private Texture2D[][]   zombieAnimations;
    private Texture2D[]   assets;
    private Texture2D[][] areas;

    public EntityFactory(Texture2D[][] zombieAnimations, Texture2D[] levels, Texture2D[] assets, Texture2D[][] areas)
    {
      this.zombieAnimations = zombieAnimations;
      this.levels = levels;
      this.assets = assets;
      this.areas  = areas;
    }

    public AIZombie CreateZombie(Rectangle rectangle)
    {
      return new AIZombie(rectangle, 25, 5, zombieAnimations); //the random is for random damage.
    }

    public Area CreateArea(Rectangle rectangle, int areabackground, Asset[] assets)
    {
      return new Area(rectangle, areas[areabackground], assets);
    }

    public Asset CreateAsset(Point position, int assetID)
    {
      return new Asset(position, assets[assetID]);
    }

    public Level CreateLevel(Area[] areas, Point spawnpoint, int backgroundID)
    {
      return new Level(areas, levels[backgroundID], spawnpoint);
    }
  }
}
