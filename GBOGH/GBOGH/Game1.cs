<<<<<<< HEAD
﻿using GBOGH.Scripts.Core;
using GBOGH.Scripts.Managers;
=======
﻿using EX04OOP;
using GBOGH.Scripts.Scenes.MainMenu;
using GBOGH.Scripts.Utils;
>>>>>>> main
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GBOGH;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
<<<<<<< HEAD
        
        SpriteManager.Graphics = GraphicsDevice;
        SpriteManager.Content = Content;
=======
        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.PreferredBackBufferHeight = 1080;
        _graphics.ApplyChanges();
        SpriteManager.Content = Content;
        SpriteManager.Graphics = GraphicsDevice;
>>>>>>> main
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        ScreenPosition.InitializePos(GraphicsDevice);
        MainMenuScene mainMenuScene = new MainMenuScene();
        SceneManager.AddScene("Main Menu", mainMenuScene);
        SceneManager.EnableScene(mainMenuScene);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        for (int i = 0; i < SceneManager.CurrentScene.SceneObjects.Count; i++)
        {
            // Check if index is still valid (in case objects were removed)
            if (i >= SceneManager.CurrentScene.SceneObjects.Count) break;

            var obj = SceneManager.CurrentScene.SceneObjects[i];
            if (obj == null) continue;
            if (!obj.IsActive) continue;

            obj.Update(gameTime);
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        if (SceneManager.CurrentScene?.SceneObjects != null)
        {
            for (int i = 0; i < SceneManager.CurrentScene.SceneObjects.Count; i++)
            {
                // Check if index is still valid
                if (i >= SceneManager.CurrentScene.SceneObjects.Count) break;

                var obj = SceneManager.CurrentScene.SceneObjects[i];
                if (obj == null) continue;
                if (!obj.IsActive) continue;

                obj.Draw(_spriteBatch, gameTime);
            }
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}