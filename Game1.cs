using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace try1;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _ballTexture;
    
    private Vector2 _ballPosition;
    private float _ballSpeed;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        
        _ballPosition = new Vector2((float)_graphics.PreferredBackBufferWidth / 2,
            (float)_graphics.PreferredBackBufferHeight / 2);
        _ballSpeed = 100f;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _ballTexture = Content.Load<Texture2D>("ball");

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        
        var kState = Keyboard.GetState();

        if (kState.IsKeyDown(Keys.Up))
        {
            _ballPosition.Y -= _ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (kState.IsKeyDown(Keys.Down))
        {
            _ballPosition.Y += _ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (kState.IsKeyDown(Keys.Left))
        {
            _ballPosition.X -= _ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (kState.IsKeyDown(Keys.Right))
        {
            _ballPosition.X += _ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        
        if (_ballPosition.X > _graphics.PreferredBackBufferWidth - _ballTexture.Width / 2f)
        {
            _ballPosition.X = _graphics.PreferredBackBufferWidth - _ballTexture.Width / 2f;
        }
        else if (_ballPosition.X < _ballTexture.Width / 2f)
        {
            _ballPosition.X = _ballTexture.Width / 2f;
        }

        if (_ballPosition.Y > _graphics.PreferredBackBufferHeight - _ballTexture.Height / 2f)
        {
            _ballPosition.Y = _graphics.PreferredBackBufferHeight - _ballTexture.Height / 2f;
        }
        else if (_ballPosition.Y < _ballTexture.Height / 2f)
        {
            _ballPosition.Y = _ballTexture.Height / 2f;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _spriteBatch.Begin();
        _spriteBatch.Draw(
            _ballTexture,
            _ballPosition,
            null,
            Color.White,
            0f,
            new Vector2(_ballTexture.Width / 2f, _ballTexture.Height / 2f),
            Vector2.One,
            SpriteEffects.None,
            0f);
        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
