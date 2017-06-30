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
    private Texture2D[][] playerAnimations;
    private Texture2D[] assets;
    private Texture2D[][] areas;
    private Texture2D[] platforms;
    private Texture2D projectile;
    private Texture2D assaultRifle;

    public EntityFactory(Texture2D[][] zombieAnimations, Texture2D[][] playerAnimations, Texture2D[] levels, Texture2D[] assets, Texture2D[][] areas, Texture2D[] platforms, Texture2D projectile, Texture2D assaultRifle)
    {
      this.zombieAnimations = zombieAnimations;
      this.playerAnimations = playerAnimations;
      this.levels = levels;
      this.assets = assets;
      this.areas = areas;
      this.platforms = platforms;
      this.projectile = projectile;
      this.assaultRifle = assaultRifle;
    }

    public Player CreatePlayer(Rectangle rectangle, WeaponPouch weaponpouch, int ammo, int health)
    {
      return new Player(rectangle, playerAnimations, weaponpouch, ammo, health, this);
    }

    public AIZombie CreateZombie(Rectangle rectangle)
    {
      return new AIZombie(rectangle, 25, 5, zombieAnimations);
    }

    public Area CreateArea(Rectangle rectangle, int areabackground, Asset[] assets, IEntity[] spawnableEntities, Platform[] platforms)
    {
      return new Area(rectangle, areas[areabackground], assets, spawnableEntities, platforms);
    }

    public Asset CreateAsset(Point position, int assetID)
    {
      return new Asset(position, assets[assetID]);
    }

    public Level CreateLevel(Area[] areas, Point spawnpoint, int backgroundID, int levelID)
    {
      return new Level(areas, levels[backgroundID], spawnpoint, levelID);
    }

    public Platform CreatePlatform(Rectangle rectangle, int platformID)
    {
      return new Platform(platforms[platformID], rectangle);
    }

    public Projectile CreateProjectile(Rectangle rectangle, Point velocity, int damage)
    {
      return new Projectile(rectangle, velocity, projectile, damage);
    }

    public WeaponPouch CreateStarterPouch(IWeapon[] weapons, int MaxWeapons)
    {
      return new WeaponPouch(weapons, MaxWeapons, 0, this);
    }

    public AssaultRifle CreateAssaultRifle(int clipamount, int ammoInClip, int damage)
    {
      return new AssaultRifle(clipamount, ammoInClip, damage, assaultRifle); 
    }
  }
}
