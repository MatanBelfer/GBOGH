using EX04OOP;
using GBOGH.Scripts.Utils;
using Microsoft.Xna.Framework;

namespace GBOGH.Scripts.Scene.MainMenu;

public class ExitButton : Button
{
    public ExitButton(string name) : base(name)
    {
        SpriteManager.AddSprite(
            "ExitButton",
            new Rectangle(0, 0, 150, 150),
            Color.Red);

        this.OnButtonClick += Exit;
        this._buttonSprite = SpriteManager.GetSprite("ExitButton");
        Position = ScreenPosition.MiddleCenter();
        
    }

    private void Exit()
    {
        SceneManager.Exit = true;
    }
}