using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _Main
{
    class Shoot
    {
        Vector2 position, otherposistion;
        Texture2D sprite;
        Vector2 movment;

        public Shoot(Vector2 playerPosition, Vector2 curiorPosistion ,Texture2D sprite )
        {
            //ger värde
            position = playerPosition;
            otherposistion = curiorPosistion;
            this.sprite = sprite;

            //sätter position för skottet
            movment = otherposistion - position;
        }
        
        public void Update()
        {
            
            
            if (movment != Vector2.Zero)
            {
                movment.Normalize();
            }
            
            position += movment * (float)100;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, Color.White);
        }
    }
}
