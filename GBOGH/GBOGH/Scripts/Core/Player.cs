using GBOGH.Scripts.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GBOGH.Scripts.Core;

public class Player : Animation
{
    //TODO add listener to event for starting
    //TODO add logic for scoring system
    
    private float speed = 250f;
    private bool disableMovement = false; //TODO change to true after there are buttons to start the game and shit
    private const float HORIZONTALMULTIPLIER = 1f;
    private const float UPMULTIPLIER = 1.66f;
    private const float DOWNMULTIPLIER = 0.66f;
    private const float SLOWMOTION = 0.7f;
    
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
                        Position.Y -= speed * UPMULTIPLIER * deltaTime;
                        break;
                    case Keys.Left:
                    case Keys.A:
                        Position.X -= speed * HORIZONTALMULTIPLIER * deltaTime;
                        break;
                    case Keys.Down:
                    case Keys.S:
                        Position.Y += speed * DOWNMULTIPLIER * deltaTime;
                        break;
                    case Keys.Right:
                    case Keys.D:
                        Position.X += speed * HORIZONTALMULTIPLIER * deltaTime;
                        break;
                }
            }
        }
        
        base.Update(gameTime);
    }
}