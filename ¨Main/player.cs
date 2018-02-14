using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _Main
{
    class Player
    {
        public Vector2 posistion, cposistion, velocity, oldposition, cvelocity;
        Vector2  direction, posistionOrgin;
        public Rectangle body,crossairbody;
        Texture2D sprite, crossair;
        float rotation;
        int countdown;

        public Player(Vector2 beginposistion, Texture2D playerSprite, Texture2D crossair)
        {
            posistion = beginposistion;
            sprite = playerSprite;
            this.crossair = crossair;
            
           
        }

        public void Update()
        {
            //sätter old posistion med countdown
            //Mouse.SetPosition(GraphicsDeviceManager.DefaultBackBufferWidth,GraphicsDeviceManager.DefaultBackBufferHeight);

            Vector2 deltaposition = Mouse.GetState().Position.ToVector2() - oldposition;

            cposistion += deltaposition;

            Mouse.SetPosition(100, 100);
            
            //sätter body
            body = new Rectangle((int)posistion.X, (int)posistion.Y, sprite.Width, sprite.Height);
            posistionOrgin = new Vector2(body.Width / 2, body.Height / 2);

            //sätter up crossair
            
            crossairbody = new Rectangle((int)cposistion.X - 25, (int)cposistion.Y - 25, 50, 50);


            //roation för player
            direction = cposistion - posistion;
            rotation = (float)Math.Atan2(direction.Y, direction.X);
            rotation += (float)Math.PI * 0.5f;

            //Up
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                velocity.Y--;
                
            }
            //Down
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                velocity.Y++;
            }
            //Left
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                velocity.X--;
            }
            //Right
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                velocity.X++;
            }

            //movements
            cvelocity = velocity;

            posistion += velocity;
            cposistion += cvelocity;

            velocity *= (float)0.95;

            cvelocity = new Vector2(0, 0);

            countdown++;
            oldposition = Mouse.GetState().Position.ToVector2();

        }
        //mållar ut body
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(crossair, crossairbody, Color.White);
            spriteBatch.Draw(sprite, body, null, Color.White, rotation, posistionOrgin, SpriteEffects.None, 0);
            
        }
    }
}
