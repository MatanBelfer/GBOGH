using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GBOGH.Scripts.Interface;

public interface IDrawables
{
    public void Draw(SpriteBatch spriteBatch, GameTime gameTime);
}