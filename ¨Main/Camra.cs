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
    class Camra
    {
        Vector2 position;
        Matrix viewMatrix;

        public Matrix ViewMatrix
        {
            get { return viewMatrix; }
        }

        public int ScreenWidth
        {
            get { return 1980; }
        }

        public int ScreenHeight
        {
            get { return 1080; }
        }

        public void Update(Vector2 playerPosistion)
        {
            // sätter ut mmittpunkten på spelaren
            position.X = playerPosistion.X - (ScreenWidth / 2);
            position.Y = playerPosistion.Y - (ScreenHeight / 2);

            // där magi händer
            viewMatrix = Matrix.CreateTranslation(new Vector3(-position, 0));
        }
    }
}
