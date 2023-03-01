using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BlackJack2D
{
    class DemoGameReadOnly : GameEngine
    { 
        Sprite2D Player;
        Sprite2D GroundRef = new Sprite2D("Ground");

        bool left;
        bool right;
        bool up;
        bool down;

        Vector2 LastPos = new Vector2(0, 0);

        string[,] Map =
        {
            {".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
            {".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
            {".", ".", "p", ".", ".", ".", ".", ".", ".", ".", ".", "." },
            {".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
            {".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
            {".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
            {".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
            {".", "g", "g", "g", "g", "g", ".", ".", ".", ".", ".", "." },
            {".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
            {".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
            {".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
            {".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
            {".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "." }

        };

        public DemoGameReadOnly() : base(new Vector2(615, 512), ("demo")) { }

        public override void OnInitialise()
        {
            throw new NotImplementedException();
        }
        public override void OnLoad()
        {
            BackgroundColour = Color.White;

            CameraPositon.x = 120;


            for (int i = 0; i < Map.GetLength(1); i++)
            {
                for (int j = 0; j < Map.GetLength(0); j++)
                {
                    if (Map[j, i] == "g")
                    {
                        new Sprite2D(new Vector2(i * 50, j * 50), new Vector2(50, 50), GroundRef.Sprite, "ground");
                    }
                    if (Map[j, i] == "p")
                    {
                        Player = new Sprite2D(new Vector2(i * 50, j * 50), new Vector2(50, 50), "Player", "player");
                    }
                }
            }
        }
        public override void OnDraw()
        {

        }

        public override void OnUpdate()
        {
            if (up)
            {
                Player.Position.y -= 2f;
            }
            if (down)
            {
                Player.Position.y += 2f;
            }
            if (left)
            {
                Player.Position.x -= 2f;
            }
            if (right)
            {
                Player.Position.x += 2f;
            }
            if (Player.IsColiding("ground"))
            {
                Player.Position.x = LastPos.x;
                Player.Position.y = LastPos.y;
            }
            else
            {
                LastPos.x = Player.Position.x;
                LastPos.y = Player.Position.y;
            }
        }

        public override void GetKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    up = true;
                    break;
                case Keys.A:
                    left = true;
                    break;
                case Keys.S:
                    down = true;
                    break;
                case Keys.D:
                    right = true;
                    break;
            }
        }

        public override void GetKeyUp(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    up = false;
                    break;
                case Keys.A:
                    left = false;
                    break;
                case Keys.S:
                    down = false;
                    break;
                case Keys.D:
                    right = false;
                    break;
            }
        }

        public override void GetKeyPress(KeyPressEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void GetMouseDown(MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void GetMouseUp(MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void GetMouseHover(EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void GetMouseMove(EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
