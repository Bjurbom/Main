using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _Main
{
    class Player
    {
        Vector2 posistion, velocity;
        Rectangle body;
        Texture2D sprite;

        public Player(Vector2 beginposistion, Texture2D playerSprite)
        {
            posistion = beginposistion;
            sprite = playerSprite;
        }

        public void Update()
        {
            //sätter body
            body = new Rectangle((int)posistion.X, (int)posistion.Y, 200, 200);

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

        }
        //mållar ut body
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, body, Color.White);
        }
    }
}
