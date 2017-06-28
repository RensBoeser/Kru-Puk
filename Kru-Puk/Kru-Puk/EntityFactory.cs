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
    private Texture2D[] levels;
    private Texture2D[][] zombieAnimations;
    private Texture2D[] assets;
    private Texture2D[][] areas;
    private Texture2D[] platforms;
    private Texture2D projectile;

    public EntityFactory(Texture2D[][] zombieAnimations, Texture2D[] levels, Texture2D[] assets, Texture2D[][] areas, Texture2D[] platforms, Texture2D projectile)
    {
      this.zombieAnimations = zombieAnimations;
      this.levels = levels;
      this.assets = assets;
      this.areas = areas;
      this.platforms = platforms;
      this.projectile = projectile;
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

    public Level CreateLevel(Area[] areas, Point spawnpoint, int backgroundID, Platform[] platforms)
    {
      return new Level(areas, levels[backgroundID], spawnpoint, platforms);
    }

    public Platform CreatePlatform(Rectangle rectangle, int platformID)
    {
      Rectangle collisionRectangle;
      switch (platformID)
      {
        case 0:
          collisionRectangle = new Rectangle(rectangle.X, rectangle.Y + 88, rectangle.Width, rectangle.Height - 88);
          break;
        default:
          collisionRectangle = rectangle;
          break;
      }
      return new Platform(platforms[platformID], rectangle, collisionRectangle);
    }

    public Projectile CreateProjectile(Rectangle rectangle, Point velocity, Point direction, int damage)
    {
      return new Projectile(rectangle, velocity, direction, projectile, damage);
    }

    public WeaponPouch CreateStarterPouch(IWeapon[] weapons, int MaxWeapons)
    {
      return new WeaponPouch(weapons, MaxWeapons, 0, this);
    }

    public AssaultRifle CreateAssaultRifle(int clipamount, int ammoInClip, int damage)
    {
      return new AssaultRifle(clipamount,ammoInClip,damage); 
    }
  }
}
