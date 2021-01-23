using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
namespace Game1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteBatch beegee;

        float guyspeed;
        Vector2 guypos;

        Vector2 bgpos;
        Texture2D guytexture;
        Texture2D guy;
        Texture2D bg; 
        public Game1()
        {

            
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            System.Diagnostics.Debug.WriteLine(this.Window.ClientBounds.Width);
            System.Diagnostics.Debug.WriteLine(this.Window.ClientBounds.Height);
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            guypos = new Vector2(480, 120);
            guyspeed = 200f;
            bgpos = new Vector2(_graphics.PreferredBackBufferWidth / 2,
                _graphics.PreferredBackBufferHeight / 2);
            base.Initialize();
        }

        
        protected override void LoadContent()
        {

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            beegee = new SpriteBatch(GraphicsDevice);
            guy = this.Content.Load<Texture2D>("guy");

            bg = this.Content.Load<Texture2D>("bg");
            // TODO: use this.Content to load your game content here
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            bool go = true;
            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();

            if (go)
            {
                bgpos.X -= 500f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                
            }

            if (kstate.IsKeyDown(Keys.Up))
                guypos.Y -= guyspeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Down))
                guypos.Y += guyspeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Left))
                guypos.X -= guyspeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            if (kstate.IsKeyDown(Keys.Right))
                guypos.X += guyspeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (guypos.X > _graphics.PreferredBackBufferWidth - guy.Width / 2)
                guypos.X = _graphics.PreferredBackBufferWidth - guy.Width / 2;
            else if (guypos.X < guy.Width / 2)
                guypos.X = guy.Width / 2;

            if (guypos.Y > _graphics.PreferredBackBufferHeight - guy.Height / 2)
                guypos.Y = _graphics.PreferredBackBufferHeight - guy.Height / 2;
            else if (guypos.Y < guy.Height / 2)
                guypos.Y = guy.Height / 2;
                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {


            GraphicsDevice.Clear(Color.Coral);

            // TODO: Add your drawing code here

            beegee = new SpriteBatch(GraphicsDevice);
            beegee.Begin();
            beegee.Draw(bg,
    bgpos,
    Color.White);
            beegee.End();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _spriteBatch.Begin();
            _spriteBatch.Draw(guy,
    guypos,
    null,
    Color.White,
    0f,
    new Vector2(guy.Width / 2, guy.Height / 2),
    Vector2.One,
    SpriteEffects.None,
    0f);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
