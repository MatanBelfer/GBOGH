using System.Collections.Generic;
using EX04OOP;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GBOGH.Scripts.Managers;

public static class AnimationManager
{
    public static ContentManager Content { set; get; }

    public static GraphicsDevice Graphics { set; get; }
    private static readonly Dictionary<string, Animation> Animations = new Dictionary<string, Animation>();

    public static void AddAnimation(string animationName, Animation animation)
    {
        Animations.Add(animationName, animation);
    }

    public static void AddAnimation(string animationName, string path, int columns, int rows)
    {
        var anim = new Animation(animationName)
        {
            Texture = Content.Load<Texture2D>(path),
            Columns = columns,
            Rows = rows,
            Path = path
        };
        anim.SourceRectangle = anim[0, 0];
        Animations.Add(animationName, anim);
    }

    public static void RemoveAnimation(string animationName)
    {
        Animations?.Remove(animationName);
    }

    public static Animation GetAnimation(string animationName)
    {
        return Animations?.GetValueOrDefault(animationName);
    }
}