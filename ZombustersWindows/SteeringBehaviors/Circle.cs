using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZombustersWindows
{
    /// <summary>
    /// Clase que representa un c�rculo, que puede ser utilizado por ejemplo como obst�culo
    /// </summary>
    public class Circle
    {
        // Atributos de l�gica
        private Vector2 _center;
        private float _radius;

        // Getters p�blicos de los atributos
        public Vector2 Center
        {
            get
            {
                return _center;
            }
        }
        public float Radius
        {
            get
            {
                return _radius;
            }
        }

        // Atributos que se utilizan para pintar el c�rculo en pantalla
        private Primitive2D primitive;
        private Primitive2D primitiveBounding;
        private const int CIRCLE_DRAWN_SIDES = 30;

        /// <summary>
        /// Inicializaci�n gr�fica de la primitiva 2D
        /// </summary>
        /// <param name="graphics">Dispositivo gr�fico</param>
        private void InitializeGraphics(GraphicsDevice graphics)
        {
            primitive = new Primitive2D(graphics);
            primitiveBounding = new Primitive2D(graphics);
        }

        /// <summary>
        /// Prepara la primitiva 2D para su uso en el draw
        /// </summary>
        private void InitializePrimitives()
        {
            primitive.ClearVectors();
            primitive.Position = this._center;
            primitive.CreateCircle(this._radius, CIRCLE_DRAWN_SIDES);
            primitive.Colour = Color.Red;

            primitiveBounding.ClearVectors();
            primitiveBounding.Position = this._center;
            primitiveBounding.CreateCircle(this._radius - this._radius * 0.25f, CIRCLE_DRAWN_SIDES);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        public Circle(GraphicsDevice graphics, Vector2 center, float radius)
        {
            this._center = center;
            this._radius = radius;

            this.InitializeGraphics(graphics);
            this.InitializePrimitives();
        }

        /// <summary>
        /// Dibjuar el c�rculo por pantalla (s�lo se usar�a para debugar, normalmente 
        /// no nos interesar� dibujar las primitivas)
        /// </summary>
        /// <param name="gameTime">Tiempo del juego</param>
        /// <param name="spriteBatch">Spritebatch ya inicializado</param>
        internal void Draw(SpriteBatch spriteBatch)
        {
            primitive.Render(spriteBatch);
            primitiveBounding.Render(spriteBatch);
        }
    }

    /// <summary>
    /// Clase que representa un c�rculo debajo del personaje
    /// </summary>
    public class AvatarCircle
    {
        // Atributos de l�gica
        private Vector2 _center;
        private float _radius;

        // Getters p�blicos de los atributos
        public Vector2 Center
        {
            get
            {
                return _center;
            }
        }
        public float Radius
        {
            get
            {
                return _radius;
            }
        }

        // Atributos que se utilizan para pintar el c�rculo en pantalla
        private Primitive2D primitive;
        private Primitive2D primitiveBounding;
        private const int CIRCLE_DRAWN_SIDES = 30;

        /// <summary>
        /// Inicializaci�n gr�fica de la primitiva 2D
        /// </summary>
        /// <param name="graphics">Dispositivo gr�fico</param>
        private void InitializeGraphics(GraphicsDevice graphics)
        {
            primitive = new Primitive2D(graphics);
            primitiveBounding = new Primitive2D(graphics);
        }

        /// <summary>
        /// Prepara la primitiva 2D para su uso en el draw
        /// </summary>
        private void InitializePrimitives(Color color)
        {
            primitive.ClearVectors();
            primitive.Position = this._center;
            primitive.CreateCircle(this._radius, CIRCLE_DRAWN_SIDES);
            primitive.Colour = color;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        public AvatarCircle(GraphicsDevice graphics, Vector2 center, float radius, Color color)
        {
            this._center = center;
            this._radius = radius;

            this.InitializeGraphics(graphics);
            this.InitializePrimitives(color);
        }

        /// <summary>
        /// Dibjuar el c�rculo por pantalla (s�lo se usar�a para debugar, normalmente 
        /// no nos interesar� dibujar las primitivas)
        /// </summary>
        /// <param name="gameTime">Tiempo del juego</param>
        /// <param name="spriteBatch">Spritebatch ya inicializado</param>
        internal void Draw(SpriteBatch spriteBatch)
        {
            primitive.Render(spriteBatch);
            primitiveBounding.Render(spriteBatch);
        }
    }
}
