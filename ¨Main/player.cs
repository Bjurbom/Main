using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _Main
{
    class Player
    {
        public Vector2 posistion, oldposistion, velocity;
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
            if (countdown >= 50)
            {
                oldposistion = new Vector2(200,200);
            }
            
            //sätter body
            body = new Rectangle((int)posistion.X, (int)posistion.Y, sprite.Width, sprite.Height);
            posistionOrgin = new Vector2(body.Width / 2, body.Height / 2);

            //sätter up crossair
            crossairbody = new Rectangle(Mouse.GetState().X -25, Mouse.GetState().Y - 25, 50, 50);
            

            //roation för player
            direction = Mouse.GetState().Position.ToVector2() - posistion;
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
            posistion += velocity;
            
            velocity *= (float)0.95;

            countdown++;

        }
        //mållar ut body
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(crossair, crossairbody, Color.White);
            spriteBatch.Draw(sprite, body, null, Color.White, rotation, posistionOrgin, SpriteEffects.None, 0);
            
        }
    }
}
