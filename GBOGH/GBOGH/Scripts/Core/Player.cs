using GBOGH.Scripts.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GBOGH.Scripts.Core;

public class Player : Animation
{
    //TODO add listener to event for release
    //TODO add collider to detect fish
    //TODO add logic for score
    
    private float speed = 250f;
    private bool disableMovement = false; //TODO change to true after there are buttons to start the game and shit
    private const float HorizontalMultiplier = 1f;
    private const float UpMultiplier = 1.4f;
    private const float DownMultiplier = 0.6f;
    
    public Player(string animationName) : base(animationName)
    {
        SpriteManager.AddSprite("weapon", "Images/Trident");
        Rotation = MathHelper.ToRadians(135);
    }
    
    public void EnableMovement()
    {
        disableMovement = false;
    }
    
    public void DisableMovement()
    {
        disableMovement = true;
    }
    
    public override void Update(GameTime gameTime)
    {
        var state = Keyboard.GetState();
        var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        
        if (!disableMovement)
        {
            foreach (var key in state.GetPressedKeys())
            {
                switch (key)
                {
                    //Movements
                    case Keys.Up:
                    case Keys.W:
                        Position.Y -= speed * UpMultiplier * deltaTime;
                        break;
                    case Keys.Left:
                    case Keys.A:
                        Position.X -= speed * HorizontalMultiplier * deltaTime;
                        break;
                    case Keys.Down:
                    case Keys.S:
                        Position.Y += speed * DownMultiplier * deltaTime;
                        break;
                    case Keys.Right:
                    case Keys.D:
                        Position.X += speed * HorizontalMultiplier * deltaTime;
                        break;
                }
            }
        }
        
        base.Update(gameTime);
    }
}