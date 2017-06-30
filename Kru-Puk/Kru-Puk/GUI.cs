using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Kru_Puk
{
  class GUI : IGUI
  {
    Main main;
    DrawingAdapter drawingAdapter;
    SpriteFont font;
    Texture2D backboardSprite;
    Button[] buttons;
    Point healthPosition;
    Point zombieAmountPosition;
    Point ammoPosition;
    Point weaponPosition;
    Point levelNumberPosition;

    public GUI(Main main, SpriteFont font, Window window, Texture2D backboardSprite)
    {
      this.main = main;
      this.font = font;
      this.backboardSprite = backboardSprite;
      this.drawingAdapter = new DrawingAdapter();

      this.healthPosition = new Point(window.WholeWindow().Left + 16, window.WholeWindow().Bottom - 32);
      this.zombieAmountPosition = new Point(0, 0); //DON'T KNOW YET
      this.ammoPosition = new Point(0, 0); //DON'T KNOW YET
      this.weaponPosition = new Point(0, 0); // DON'T KNOW YET
      this.levelNumberPosition = new Point(0, 0); //DON'T KNOW YET

      this.buttons = new Button[0];
      //buttons[0] = new Button();
    }

    public void DrawHealth(SpriteBatch spritebatch)
    {
      string text = main.GetPlayer().Visit<string>((player) => Convert.ToString(player.GetHealth()) + "/100", () => "N/A");
      drawingAdapter.DrawString(spritebatch, font, text, healthPosition, Color.White);
    }
    public void DrawZombieAmount(SpriteBatch spritebatch)
    {
      Func<Level, int> countZombies = (level) =>
      {
        int counter = 0;
        foreach (IEntity entity in level.GetEntities()) { if (entity is IZombie) { counter = counter + 1; } }
        return counter;
      };
      int zombieAmount = main.GetLevel().Visit<int>(countZombies, () => 0);
      drawingAdapter.DrawString(spritebatch, font, "Zombies remaining: " + Convert.ToString(zombieAmount), zombieAmountPosition, Color.White);

    }
    public void DrawAmmo(SpriteBatch spritebatch)
    {
      string playerAmmo = main.GetPlayer().Visit<string>((player) => Convert.ToString(player.GetAmmo()), () => "N/A");
      string weaponAmmo = main.GetPlayer().Visit<string>((player) => Convert.ToString(player.GetWeaponPouch().GetWeapon().GetAmmo()), () => "N/A");
      drawingAdapter.DrawString(spritebatch, font, weaponAmmo + "/" + playerAmmo, ammoPosition, Color.White);
    }
    public void DrawWeapon(SpriteBatch spritebatch)
    {
      main.GetPlayer().Visit((player) => drawingAdapter.Draw(spritebatch, player.GetWeaponPouch().GetWeapon().GetSprite(), weaponPosition, false), () => Console.WriteLine("Couldn't find weapon texture."));
    }
    public void DrawLevelNumber(SpriteBatch spritebatch)
    {
      string levelID = "level: " + main.GetLevel().Visit<string>((level) => Convert.ToString(level.GetLevelID()), () => "N/A");
      drawingAdapter.DrawString(spritebatch, font, levelID, levelNumberPosition, Color.White);
    }
    public void DrawBackboard(SpriteBatch spritebatch)
    {
      drawingAdapter.Draw(spritebatch, backboardSprite, new Point(0, 0), false);
    }
    public void UpdateButtons(float dt)
    {
      foreach(Button button in buttons) { button.Update(dt); }
    }
    public void DrawButtons(SpriteBatch spritebatch)
    {
      foreach(Button button in buttons) { button.Draw(spritebatch); }
    }

    public void Update(float dt)
    {
      UpdateButtons(dt);
    }

    public void Draw(SpriteBatch spritebatch)
    {
      DrawBackboard(spritebatch);
      DrawButtons(spritebatch);
      DrawHealth(spritebatch);
      DrawLevelNumber(spritebatch);
      DrawWeapon(spritebatch);
      DrawAmmo(spritebatch);
      DrawZombieAmount(spritebatch);
    }
  }
}
