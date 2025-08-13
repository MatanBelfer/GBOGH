using Microsoft.Xna.Framework;
using System.Collections.Generic;
using GBOGH.Scripts.Managers;
using Microsoft.Xna.Framework.Graphics;

namespace GBOGH.Scripts.Core;

public class BackgroundHandler : GameObject
{
    private bool startTransition = true;
    private readonly List<Color> backColors =
    [
        new Color(1, 111, 131, 255),
        new Color(1, 98, 117, 255),
        new Color(1, 86, 102, 255),
        new Color(1, 74, 88, 255),
        new Color(1, 62, 73, 255),
        new Color(0, 49, 58, 255),
        new Color(0, 37, 44, 255),
        new Color(0, 25, 29, 255),
        new Color(0, 12, 15, 255)
    ];
    private int currentIndex = 0;
    private const float TRANSITIONDURATION = 1f;
    private float elapsedTime = 0f;
    private Color backgroundColor;

    public BackgroundHandler(string name = "BackgroundHandler") : base(name)
    {
        
    }

    public override void Update(GameTime gameTime)
    {
        if (!startTransition) return;
        if (currentIndex < backColors.Count - 1)
        {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            var progress = MathHelper.Clamp(elapsedTime / TRANSITIONDURATION, 0f, 1f);

            backgroundColor = Color.Lerp(backColors[currentIndex], backColors[currentIndex + 1], progress);

            if (!(progress >= 1f)) return;
            currentIndex++;
            elapsedTime = 0f;
        }
        else
        {
            backgroundColor = backColors[^1];
            startTransition = false;
        }
    }

    public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        SpriteManager.Graphics.Clear(backgroundColor);
    }
}