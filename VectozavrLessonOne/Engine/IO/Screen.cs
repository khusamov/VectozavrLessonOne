using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Diagnostics;
using VectozavrLessonOne.Algebra.Vector;
using VectozavrLessonOne.Engine.Utils;
using OpenTK.Graphics.OpenGL;

namespace VectozavrLessonOne.Engine.IO
{
	/// <summary>
	/// Screen
	/// </summary>
	/// <see cref="https://github.com/vectozavr/3dzavr/blob/master/engine/io/Screen.cpp"/>
	/// <see cref="https://github.com/vectozavr/3dzavr/blob/master/engine/io/Screen.h"/>
	internal class Screen
	{
		private int _scene = 0;
		private bool _renderVideo = false;
		private readonly List<Texture> _renderSequence = new();
		private string _title = "";
		private Color _backgroundColor = Color.White;
		private readonly RenderWindow _window;

		public RenderWindow RenderWindow => _window;

		public string Title { get { return _title; } set {  _title = value; } }

		public uint Width => _window.Size.X;

		public uint Height => _window.Size.Y;

		public Screen(
			uint screenWidth = 0,
			uint screenHeight = 0,
			string? title = null, 
			bool verticalSync = true,
			Color? backgroundColor = null,
			Styles styles = Styles.Default
		)
		{
			screenWidth = screenWidth == 0 ? (uint)Consts.STANDARD_SCREEN_WIDTH : screenWidth;
			screenHeight = screenHeight == 0 ? (uint)Consts.STANDARD_SCREEN_HEIGHT : screenHeight;
			title = title ?? Consts.PROJECT_NAME;
			backgroundColor = backgroundColor ?? Consts.BACKGROUND_COLOR;

			_title = title;
			_backgroundColor = (Color)backgroundColor;
			ContextSettings contextSettings = new()
			{
				DepthBits = 12,
				AntialiasingLevel = 1
			};

			_window = new(new VideoMode(screenWidth, screenHeight), title, styles, contextSettings);
			_window.SetVerticalSyncEnabled(verticalSync);

			_window.Closed += OnClosed;
		}

		private static void OnClosed(object? sender, EventArgs e)
		{
			if (sender is not null)
			{
				Window window = (Window)sender;
				window.Close();
			}
		}

		public void Display()
		{
			string title = $"{_title} ({Utils.Time.Fps} fps)";
			_window.SetTitle(title);

			if (_renderVideo)
			{
				Texture copyTexture = new(_window.Size.X, _window.Size.Y);
				copyTexture.Update(_window);
				// большая часть времени рендеринга видео тратится на сохранение
				// последовательности в формате .png,
				// поэтому в конце мы сохраним все изображения
				_renderSequence.Add(copyTexture);
			}

			_window.Display();
		}

		public void Clear()
		{
			// Clear the depth buffer
			GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);

			_window.Clear(_backgroundColor);
		}

		public bool HasFocus()
		{
			return _window.HasFocus();
		}

		public void DrawTriangle(Triangle tri)
		{
			Vertex[] tris = new Vertex[]
			{
				new Vertex(new Vector2f(tri[0].X, tri[0].Y), tri.Color),
				new Vertex(new Vector2f(tri[1].X, tri[1].Y), tri.Color),
				new Vertex(new Vector2f(tri[2].X, tri[2].Y), tri.Color)
			};
			_window.Draw(tris, 0, (uint)tris.Length, SFML.Graphics.PrimitiveType.LineStrip);

			// Раскомментируйте эти строки для отображения границ треугольников.
			/*Vertex[] lines = new Vertex[]
			{
				new Vertex(new Vector2f(tri[0].X, tri[0].Y), Color.Black),
				new Vertex(new Vector2f(tri[1].X, tri[1].Y), Color.Black),
				new Vertex(new Vector2f(tri[2].X, tri[2].Y), Color.Black),
				new Vertex(new Vector2f(tri[0].X, tri[0].Y), Color.Black)
			};
			_window.Draw(lines, 0, (uint)lines.Length, SFML.Graphics.PrimitiveType.LineStrip);*/

		}

		public void DrawTetragon(Vector point0, Vector point1, Vector point2, Vector point3, Color color)
		{
			ConvexShape polygonShape = new();
			polygonShape.SetPointCount(4);
			polygonShape.FillColor = color;
			polygonShape.SetPoint(0, new Vector2f(point0.X, point0.Y));
			polygonShape.SetPoint(1, new Vector2f(point1.X, point1.Y));
			polygonShape.SetPoint(2, new Vector2f(point2.X, point2.Y));
			polygonShape.SetPoint(3, new Vector2f(point3.X, point3.Y));
			_window.Draw(polygonShape);
		}

		public void DrawText(Text text)
		{
			_window.Draw(text);
		}

		public void DrawText(string textString, Vector position, uint size, Color color)
		{
			Text text = new(textString, ResourceManager.LoadFont(Consts.MEDIUM_FONT))
			{
				CharacterSize = size,
				FillColor = color,
				Style = Text.Styles.Italic,
				Position = new Vector2f(position.X, position.Y)
			};
			_window.Draw(text);
		}

		public void DrawSprite(Sprite sprite)
		{
			_window.Draw(sprite);
		}

		public bool IsOpen()
		{
			return _window.IsOpen;
		}

		public void Close()
		{
			_window.Close();
		}

		public void SetMouseCursorVisible(bool visible)
		{
			_window.SetMouseCursorVisible(visible);
		}

		#region --- OpenGL functions ---------------------------------------------------------

		public void PrepareToGlDrawMesh()
		{
			GL.Enable(EnableCap.CullFace);
			GL.CullFace(CullFaceMode.Back);
			GL.FrontFace(FrontFaceDirection.Ccw);

			GL.Enable(EnableCap.DepthTest);
			GL.DepthMask(true);
			GL.ClearDepth(1);

			GL.Disable(EnableCap.Lighting);

			GL.Enable(EnableCap.AlphaTest);
			GL.AlphaFunc(AlphaFunction.Notequal, 0.0f);

			GL.Enable(EnableCap.Blend);
			GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

			GL.Viewport(0, 0, (int)_window.Size.X, (int)_window.Size.Y);

			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadIdentity();
			float ratio = _window.Size.X / _window.Size.Y;
			GL.Frustum(-ratio, ratio, -1, 1, 1, 100);

			GL.EnableClientState(ArrayCap.VertexArray);
			GL.EnableClientState(ArrayCap.ColorArray);

			GL.DisableClientState(ArrayCap.NormalArray);
			GL.DisableClientState(ArrayCap.TextureCoordArray);

			GL.MatrixMode(MatrixMode.Modelview);
		}
		public void GlDrawMesh(float[] geometry, float[] view, float[] model, int count)
		{
			GL.VertexPointer(3, VertexPointerType.Float, 0, geometry);
			GL.ColorPointer(4, ColorPointerType.Float, 0, geometry);

			GL.LoadIdentity();

			GL.LoadMatrix(view);
			GL.MultMatrix(model);

			GL.DrawArrays(OpenTK.Graphics.OpenGL.PrimitiveType.Triangles, 0, count);
		}
		
		public void PushGLStates()
		{
			_window.PushGLStates();
		}

		public void PopGLStates()
		{
			_window.PopGLStates();
		}
		 
		public void StartRender()
		{
			StopRender();
			Debug.WriteLine("Screen::startRender(): start recording the screen");
			_renderVideo = true;
		}
		public void StopRender()
		{
			if (_renderVideo)
			{
				Debug.WriteLine("Screen::stopRender(): stop recording the screen");
				Debug.WriteLine("Screen::stopRender(): start saving .png sequence");
				string c = "rm film/png/*.png";
			}
		}

		#endregion
	}
}
