using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EX04OOP.Core;

public class Sprite : GameObject
{
    public Color Color;
    public string Path;
    public Texture2D Texture;
    public SpriteEffects SpriteEffects;
    public Rectangle SourceRectangle;
    public SpriteEffects Effect;
    public Vector2 Origin = Vector2.Zero;

    public Sprite(string name) : base("Sprite_" + name)
    {
    }

    public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        Vector2 drawOrigin = Origin;
        if (Texture != null)
        {
            Rectangle sourceRect = SourceRectangle.IsEmpty
                ? new Rectangle(0, 0, Texture.Width, Texture.Height)
                : SourceRectangle;
          
        }

        spriteBatch.Draw(
            Texture,
            Position,
            SourceRectangle,
            Color.White,
            MathHelper.ToRadians(Rotation),
            drawOrigin, 
            Scale,
            Effect,
            LayerDepth 
        );
    }

    public override void Update(GameTime gameTime)
    {
    }
}