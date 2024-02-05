using System;
using System.Collections.Generic;
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
        private static Vector2 ScreenSize = new Vector2(512, 512);
        private static string Title = "*insert title*";
        private static Canvas Window = null;
        private static Thread GameLoopThread = null;

        public static Dictionary<string, GraphicElement> AllGraphicElements = new Dictionary<string, GraphicElement>();


        public static Vector2 CursorPosition;
        public static Color BackgroundColour = Color.White;
        public static Vector2 CameraPositon = new Vector2(0,0);
        public static float CameraAngle = 0f;
        public static Vector2 CameraZoom = new Vector2(1, 1);
        public static FormWindowState WindowStateSize = FormWindowState.Normal;

        public GameEngine(Vector2 screenSize, string title)
        {
            OnInitialise();
            ScreenSize = screenSize;
            Title = title;
            Window = new Canvas();
            Window.Size = new Size((int)ScreenSize.x, (int)ScreenSize.y);
            Window.Text = Title;
            Window.Paint += Renderer;
            Window.KeyDown += Window_KeyDown;
            Window.KeyUp += Window_KeyUP;
            Window.KeyPress += Window_KeyPress;
            Window.MouseDown += Window_MouseDown;
            Window.MouseUp += Window_MouseUp;
            Window.MouseMove += Window_MouseMove;
            Window.FormClosing += Window_FormClosing;
            Window.Resize += Window_Resize;
            Window.WindowState = WindowStateSize;
            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();

            Application.Run(Window);
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            // Offset if needed
            CursorPosition = new Vector2(Window.PointToClient(Cursor.Position).X - CameraPositon.x, Window.PointToClient(Cursor.Position).Y - CameraPositon.y);
            GetMouseMove(e);
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
        private void Window_Resize(object sender, EventArgs e)
        {
            WindowResize(e);
        }

        public Vector2 getWindowWidth()
        {
            return new Vector2(Window.ClientSize.Width, Window.Height);
        }

        public static void RegisterGraphicElement(GraphicElement graphicElements)
        {
            if (AllGraphicElements.ContainsKey(graphicElements.Tag)){
                Log.Warning("KeyAlreadyExist: " + graphicElements.Tag + ". It Will not be added to AllGraphicElements");
            }
            AllGraphicElements[graphicElements.Tag] = graphicElements;
        }
        public static void UnRegisterGraphicElement(GraphicElement graphicElements)
        {
            AllGraphicElements.Remove(graphicElements.Tag);
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
            foreach (GraphicElement graphicElement in AllGraphicElements.Values)
            {
                graphicElement.Draw(g);
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
        public abstract void GetMouseMove(EventArgs e);
        public abstract void WindowResize(EventArgs e);

    }
}
