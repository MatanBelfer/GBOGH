using System;
using GBOGH.Scripts.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GBOGH.Scripts.Core;

public class Button : GameObject
{
    public delegate void ButtonClickHandler();


    public event ButtonClickHandler OnButtonClick;

    
    public string Text = "";
    public bool TintEnabled = false;
    
    private Sprite _buttonSprite;
    private Rectangle? _clickArea;
    private Sprite _buttonTint;


    // Font properties
    public SpriteFont Font;
    public Color TextColor = Color.Black;
    public float FontScale = 1.0f;
    public float FontRotation = 0f;
    public Vector2 TextOffset = Vector2.Zero;
    public SpriteEffects TextEffects = SpriteEffects.None;


    // Text effects
    public bool HasShadow = false;
    public Color ShadowColor = Color.Gray;
    public Vector2 ShadowOffset = new Vector2(2, 2);


    // Text layer depth (always on top of sprite)
    public float TextLayerDepth => Math.Min(LayerDepth + 0.1f, 1.0f);
    public float ShadowLayerDepth => Math.Min(LayerDepth + 0.05f, 0.95f);

    private bool WasPressed = false;


    public Button(string name) : base("Button_" + name)
    {
    }

    public void SetFontStyle(float scale = 1.0f, float rotationDegrees = 0f, Color? color = null)
    {
        FontScale = scale;
        FontRotation = MathHelper.ToRadians(rotationDegrees);
        if (color.HasValue) TextColor = color.Value;
    }

    public void SetShadow(bool enabled, Color? shadowColor = null, Vector2? offset = null)
    {
        HasShadow = enabled;
        if (shadowColor.HasValue) ShadowColor = shadowColor.Value;
        if (offset.HasValue) ShadowOffset = offset.Value;
    }

    private Vector2 GetTextPosition()
    {
        if (_buttonSprite == null) return Vector2.Zero;
        return _buttonSprite.Position + TextOffset;
    }

    public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        // Draw the sprite first (with its layer depth)
        _buttonSprite?.Draw(spriteBatch, gameTime);
        if (IsMouseOver() && TintEnabled)
        {
            _buttonTint.Draw(spriteBatch, gameTime);
        }

        if (!string.IsNullOrEmpty(Text) && Font != null)
        {
            Vector2 position = GetTextPosition();
            Vector2 origin = Font.MeasureString(Text) * 0.5f;

            // Draw shadow (slightly behind text but in front of sprite)
            if (HasShadow)
            {
                spriteBatch.DrawString(Font, Text, position + ShadowOffset, ShadowColor,
                    FontRotation, origin, FontScale, TextEffects, ShadowLayerDepth);
            }

            // Draw main text (always on top)
            spriteBatch.DrawString(Font, Text, position, TextColor,
                FontRotation, origin, FontScale, TextEffects, TextLayerDepth);
        }
    }

    public override void Update(GameTime gameTime)
    {
        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            if (WasPressed)
            {
                return;
            }

            WasPressed = true;

            if (IsMouseOver())
            {
                OnButtonClick?.Invoke();
            }
        }
        else
        {
            WasPressed = false;
        }


        base.Update(gameTime);
    }


    private bool IsMouseOver()
    {
        if (_buttonSprite == null) return false;
        return _clickArea != null && _clickArea.Value.Contains(Mouse.GetState().Position);
    }

    public static Button CreateButton(string name, Sprite sprite)
    {
        var button = new Button(name) { _buttonSprite = sprite };
        if (sprite != null)
        {
            button.LayerDepth = sprite.LayerDepth;

            Vector2 spriteSize = Vector2.Zero;
            if (!sprite.SourceRectangle.IsEmpty)
            {
                spriteSize = new Vector2(sprite.SourceRectangle.Width, sprite.SourceRectangle.Height);
            }
            else if (sprite.Texture != null)
            {
                spriteSize = new Vector2(sprite.Texture.Width, sprite.Texture.Height);
            }

            // Calculate top-left corner for click area
            Vector2 topLeft = sprite.Position - (spriteSize * 0.5f);
            button._clickArea = new Rectangle((int)topLeft.X, (int)topLeft.Y, (int)spriteSize.X, (int)spriteSize.Y);
        }

        return button;
    }

    public static Button CreateButton(string name, string text, Sprite sprite)
    {
        var button = new Button(name) { Text = text, _buttonSprite = sprite };

        if (sprite != null)
        {
            button.LayerDepth = sprite.LayerDepth;

            // Update click area calculation since sprite now draws from center
            Vector2 spriteSize = Vector2.Zero;
            if (!sprite.SourceRectangle.IsEmpty)
            {
                spriteSize = new Vector2(sprite.SourceRectangle.Width, sprite.SourceRectangle.Height);
            }
            else if (sprite.Texture != null)
            {
                spriteSize = new Vector2(sprite.Texture.Width, sprite.Texture.Height);
            }

            Vector2 topLeft = sprite.Position - (spriteSize * 0.5f);
            button._clickArea = new Rectangle((int)topLeft.X, (int)topLeft.Y, (int)spriteSize.X, (int)spriteSize.Y);
            SpriteManager.AddSprite("ButtonTint", sprite.SourceRectangle, new Color(Color.Black, 0.5f));

            button._buttonTint = SpriteManager.GetSprite("ButtonTint");
            button._buttonTint.Position = sprite.Position;
            button._buttonTint.LayerDepth = sprite.LayerDepth + 0.1f;
            button._buttonTint.Scale = sprite.Scale;
            button._buttonTint.Color = new Color(Color.Black, 0.5f);
        }

        return button;
    }
}