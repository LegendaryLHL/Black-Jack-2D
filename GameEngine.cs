﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BlackJack2D
{
    class Canvas : Form
    {
        public Canvas()
        {
            this.DoubleBuffered = true;
        }
    }
    public abstract class GameEngine
    {
        private Vector2 ScreenSize = new Vector2(512, 512);
        private string Title = "*insert title*";
        private Canvas Window = null;
        private Thread GameLoopThread = null;

        public static List<Shape2D> AllShapes = new List<Shape2D>();
        public static List<Sprite2D> AllSprite = new List<Sprite2D>();
        public static List<Text> AllText = new List<Text>();

        public Color BackgroundColour = Color.White;
        public Vector2 CameraPositon = new Vector2(0,0);
        public float CameraAngle = 0f;
        public Vector2 CameraZoom = new Vector2(1, 1);
        public FormWindowState WindowStateSize = FormWindowState.Normal;

        public GameEngine(Vector2 ScreenSize, string Title)
        {
            OnInitialise();
            this.ScreenSize = ScreenSize;
            this.Title = Title;
            Window = new Canvas();
            Window.Size = new Size((int)ScreenSize.x, (int)ScreenSize.y);
            Window.Text = this.Title;
            Window.Paint += Renderer;
            Window.KeyDown += Window_KeyDown;
            Window.KeyUp += Window_KeyUP;
            Window.KeyPress += Window_KeyPress;
            Window.MouseDown += Window_MouseDown;
            Window.MouseUp += Window_MouseUp;
            Window.MouseHover += Window_MouseHover;
            Window.MouseMove += Window_MouseMove;
            Window.FormClosing += Window_FormClosing;
            Window.WindowState = WindowStateSize;
            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();

            Application.Run(Window);
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            GetMouseMove(e);
        }

        private void Window_MouseHover(object sender, EventArgs e)
        {
            GetMouseHover(e);
        }

        private void Window_MouseUp(object sender, MouseEventArgs e)
        {
            GetMouseUp(e);
        }

        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            GetMouseDown(e);
        }

        private void Window_KeyPress(object sender, KeyPressEventArgs e)
        {
            GetKeyPress(e);
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            GameLoopThread.Abort();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            GetKeyDown(e);
        }
        private void Window_KeyUP(object sender, KeyEventArgs e)
        {
            GetKeyUp(e);
        }

        public static void RegisterShape(Shape2D Shape) 
        {
            AllShapes.Add(Shape);
        }
        public static void UnRegisterShape(Shape2D Shape)
        {
            AllShapes.Remove(Shape);
        }

        public static void RegisterSprite(Sprite2D Sprite)
        {
            AllSprite.Add(Sprite);
        }
        public static void UnRegisterSprite(Sprite2D Sprite)
        { 
            AllSprite.Remove(Sprite);
        }

        public static void RegisterText(Text Text)
        {
            AllText.Add(Text);
        }
        public static void UnRegisterText(Text Text)
        {
            AllText.Remove(Text);
        }

        void GameLoop()
        {
            OnLoad();

            while (GameLoopThread.IsAlive)
            {
                try
                {
                    OnDraw();
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(2);
                }
                catch
                {
                    //log info game is loading
                    Log.Info("Window has not loaded or is loading...");
                }
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackgroundColour);
            g.TranslateTransform(CameraPositon.x, CameraPositon.y);
            g.RotateTransform(CameraAngle);
            g.ScaleTransform(CameraZoom.x, CameraZoom.y);
            foreach (Shape2D shape in AllShapes)
            {
                g.FillRectangle(new SolidBrush(Color.Red), shape.Position.x, shape.Position.y, shape.Scale.x, shape.Scale.y);
            }
            foreach (Sprite2D sprite in AllSprite) 
            {
                if (!sprite.IsRefrence)
                {
                    g.DrawImage(sprite.Sprite, sprite.Position.x, sprite.Position.y - 28, sprite.Scale.x, sprite.Scale.y);
                }
            }
            foreach (Text Text in AllText)
            {
                g.DrawString(Text.TextString, Text.Font, new SolidBrush(Color.Black), Text.Position.x, Text.Position.y);
            }
        }

        public abstract void OnInitialise();
        public abstract void OnLoad();
        public abstract void OnUpdate();
        public abstract void OnDraw();
        public abstract void GetKeyDown(KeyEventArgs e);
        public abstract void GetKeyUp(KeyEventArgs e);
        public abstract void GetKeyPress(KeyPressEventArgs e);
        public abstract void GetMouseDown(MouseEventArgs e);
        public abstract void GetMouseUp(MouseEventArgs e);
        public abstract void GetMouseHover(EventArgs e);
        public abstract void GetMouseMove(EventArgs e);

    }
}
