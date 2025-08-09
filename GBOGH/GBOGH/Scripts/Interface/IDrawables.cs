using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EX04OOP.Interfaces;

public interface IDrawables
{
    public void Draw(SpriteBatch spriteBatch, GameTime gameTime);
}