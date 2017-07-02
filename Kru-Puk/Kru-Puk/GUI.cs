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
    EntityFactory entityFactory;
    Point healthPosition;
    Point zombieAmountPosition;
    Point ammoPosition;
    Point weaponPosition;
    Point levelNumberPosition;

    public GUI(Main main, SpriteFont font, Window window, EntityFactory entityFactory, Texture2D backboardSprite)
    {
      this.main = main;
      this.font = font;
      this.backboardSprite = backboardSprite;
      this.entityFactory = entityFactory;
      this.drawingAdapter = new DrawingAdapter();
      this.healthPosition = new Point(window.WholeWindow().Left + 16, window.WholeWindow().Bottom - 56);
      this.zombieAmountPosition = new Point(window.WholeWindow().Left + 256, window.WholeWindow().Bottom - 56); //DON'T KNOW YET
      this.ammoPosition = new Point(window.WholeWindow().Right - 256, window.WholeWindow().Bottom - 56); //DON'T KNOW YET
      this.weaponPosition = new Point(window.WholeWindow().Right - 234, window.WholeWindow().Bottom - 72); // DON'T KNOW YET
      this.levelNumberPosition = new Point(window.WholeWindow().Left + 16, window.WholeWindow().Top + 16); //DON'T KNOW YET
      this.buttons = new Button[1];
      buttons[0] = entityFactory.CreateButton(new Rectangle(window.WholeWindow().Right - 256, window.WholeWindow().Top, 256, 128), () => main.ToggleMenu(), font, "Menu");
    }
    public void DrawHealth(SpriteBatch spritebatch) { drawingAdapter.DrawString(spritebatch, font, main.GetPlayer().Visit<string>((player) => Convert.ToString(player.GetHealth()) + "/100", () => "N/A"), healthPosition, Color.White); }
    public void DrawZombieAmount(SpriteBatch spritebatch)
    {
      Func<Level, int> countZombies = (level) => { int counter = 0; foreach (IEntity entity in level.GetEntities()) { if (entity is IZombie) { counter = counter + 1; } } return counter; };
      drawingAdapter.DrawString(spritebatch, font, "Zombies remaining: " + Convert.ToString(main.GetLevel().Visit<int>(countZombies, () => 0)), zombieAmountPosition, Color.White);
    }
    public void DrawAmmo(SpriteBatch spritebatch)
    {
      if (main.GetPlayer().Visit<bool>((player) => player.GetWeaponPouch().GetWeapon().IsReloading(), () => true))
      { drawingAdapter.DrawString(spritebatch, font, "Reloading..", ammoPosition, Color.White); }
      else
      { drawingAdapter.DrawString(spritebatch, font, main.GetPlayer().Visit<string>((player) => Convert.ToString(player.GetAmmo()), () => "N/A") + "/" + main.GetPlayer().Visit<string>((player) => Convert.ToString(player.GetWeaponPouch().GetWeapon().GetAmmo()), () => "N/A"), ammoPosition, Color.White); }
    }
    public void DrawWeapon(SpriteBatch spritebatch) { main.GetPlayer().Visit((player) => drawingAdapter.Draw(spritebatch, player.GetWeaponPouch().GetWeapon().GetSprite(), weaponPosition, false), () => Console.WriteLine("Couldn't find weapon texture.")); }
    public void DrawLevelNumber(SpriteBatch spritebatch) { drawingAdapter.DrawString(spritebatch, font, "level: " + main.GetLevel().Visit<string>((level) => Convert.ToString(level.GetLevelID()), () => "N/A"), levelNumberPosition, Color.White); }
    public void DrawBackboard(SpriteBatch spritebatch) { drawingAdapter.Draw(spritebatch, backboardSprite, new Point(0, 0), false); }
    public void UpdateButtons(float dt) { foreach(Button button in buttons) { button.Update(dt); } }
    public void DrawButtons(SpriteBatch spritebatch) { foreach(Button button in buttons) { button.Draw(spritebatch); } }
    public void Update(float dt) { UpdateButtons(dt); }
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
