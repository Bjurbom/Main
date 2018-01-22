using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _Main
{
    class @object
    {
        Vector2 posistion;
        Texture2D sprite;
        public Rectangle hitBox;

        public @object(Texture2D objsprite, Vector2 posistion)
        {
            sprite = objsprite;
            this.posistion = posistion;
        }

        public void Update()
        {
            hitBox = new Rectangle((int)posistion.X,(int)posistion.Y, sprite.Width, sprite.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, posistion, Color.White);
        }
    }
}
