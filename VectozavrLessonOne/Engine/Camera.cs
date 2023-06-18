using VectozavrLessonOne.Algebra.Plane;
using VectozavrLessonOne.Algebra.Matrix;
using VectozavrLessonOne.Algebra.Vector;
using System.Diagnostics;
using SFML.Graphics;

namespace VectozavrLessonOne.Engine
{
	/// <summary>
	/// 
	/// </summary>
	/// <see cref="https://github.com/vectozavr/3dzavr/blob/master/engine/Camera.cpp"/>
	/// <see cref="https://github.com/vectozavr/3dzavr/blob/master/engine/Camera.h"/>
	/// <see cref="https://vectozavr.ru/lesson.php?id_article=23"/>
	/// <see cref="https://vectozavr.ru/lesson.php?id_article=27"/>
	/// <see cref="https://vectozavr.ru/lesson.php?id_article=31"/>
	internal class Camera : Object
	{
		private readonly List<Triangle> _triangles = new();
		private Plane[] _clipPlanes = Array.Empty<Plane>();
		private bool _ready = false;
		private float _aspect = 0f;
		private Matrix _sp = new(new float[,] {});

		public Camera() : base(new ObjectNameTag("Camera")) {}

		public int BufferSize => _triangles.Count;

		/// <summary>
		/// Подготовка камеры к работе.
		/// </summary>
		/// <param name="width">Ширина экрана</param>
		/// <param name="height">Высота экрана</param>
		/// <param name="fov">Угол обзора в радианах</param>
		/// <param name="zNear"></param>
		/// <param name="zFar"></param>
		public void Init(int width, int height, float fov = MathF.PI / 2, float zNear = 0.1f, float zFar = 100f)
		{
			Vector zero = Vector.Zero(new VectorSize(3));
			// Нам нужно инициализировать камеру только после создания или изменения ширины, высоты, угла обзора, zNear или zFar.
			// Потому что здесь мы вычисляем матрицу, которая не изменяется во время движения _объектов или камеры.
			_aspect = width / height;
			
			Matrix p = Matrix.Projection(fov, _aspect, zNear, zFar);
			Matrix s = Matrix.Screen(width, height);
			_sp = s * p;

			float thetta1 = fov / 2;
			float thetta2 = MathF.Atan(_aspect * MathF.Tan(thetta1));

			// Плоскости отсечения камеры. 
			_clipPlanes = new Plane[] 
			{
				new Plane(new Vector(new float[] {0, 0, 1}), new Vector(new float[] {0, 0, zNear})),
				new Plane(new Vector(new float[] {0, 0, 1}), new Vector(new float[] {0, 0, zFar})),
				new Plane(new Vector(new float[] {-MathF.Cos(thetta2), 0, MathF.Sin(thetta2)}), zero), // Left Plane.
				new Plane(new Vector(new float[] {+MathF.Cos(thetta2), 0, MathF.Sin(thetta2)}), zero), // Right Plane.
				new Plane(new Vector(new float[] {0, +MathF.Cos(thetta1), MathF.Sin(thetta1)}), zero), // Bottom Plane.
				new Plane(new Vector(new float[] {0, -MathF.Cos(thetta1), MathF.Sin(thetta1)}), zero), // Top Plane.
			};

			_ready = true;
			Debug.WriteLine("Camera.Init(): Камера готова к работе.");
		}

		/// <summary>
		/// Проекция всех треугольников mesh на (КАКУЮ?) плоскость.
		/// </summary>
		/// <param name="mesh"></param>
		/// <returns></returns>
		public Triangle[] Project(Mesh mesh)
		{
			if (!_ready)
			{
				Debug.WriteLine("Camera.Project(): Проекцию сделать нельзя. Камера еще не готова к работе.");
				return _triangles.ToArray();
			}

			if (!mesh.IsVisible)
			{
				return _triangles.ToArray();
			}

			// Матрица преобразования модели: переведите _tris в начало координат тела.
			Matrix m = mesh.Model;
			Matrix v = Matrix.View(Left, Up, LookAt, Position);

			// Мы не хотим тратить время на повторное выделение памяти каждый раз.
			List<Triangle> clippedTriangles = new(), tempBuffer = new();

			foreach (var tri in _triangles)
			{
				Triangle mtri = tri * m;
				
				float dot = mtri.Normal.Dot((mtri[0] - Position).Normalize());

				if (dot > 0)
				{
					continue;
				}

				Triangle vmtri = mtri * v;

				// Его необходимо очистить, потому что он повторно используется в ходе итераций. Обычно это не освобождает память.
				clippedTriangles.Clear();
				tempBuffer.Clear();

				// Вначале нам нужно перевести треугольник из мировых координат в нашу систему камер:
				// После этого мы применяем отсечение для всех плоскостей из _clipPlanes
				clippedTriangles.Add(vmtri);
				foreach (var clipPlane in _clipPlanes)
				{
					while (clippedTriangles.Count > 0)
					{
						Triangle[] clipResult = clippedTriangles.Last().Clip(clipPlane);
						clippedTriangles.Remove(clippedTriangles.Last());
						foreach (Triangle t in clipResult)
						{
							tempBuffer.Add(t);
						}
					}
					// clippedTriangles.swap(tempBuffer);
					clippedTriangles = tempBuffer;
					tempBuffer = new();
				}

				foreach (var clippedTriangle in clippedTriangles)
				{
					Color color = clippedTriangle.Color;
					Color ambientColor = new Color()
					{
						R = Convert.ToByte(color.R * (0.3 * MathF.Abs(dot) + 0.7)),
						G = Convert.ToByte(color.G * (0.3 * MathF.Abs(dot) + 0.7)),
						B = Convert.ToByte(color.B * (0.3 * MathF.Abs(dot) + 0.7)),
						A = color.A
					};

					// Наконец-то пришло время спроецировать наш обрезанный цветной треугольник из 3D -> 2D
					// и преобразовать его координаты в пространство экрана (в пикселях):
					Triangle clippedProjected = clippedTriangle * _sp;

					Triangle clippedProjectedNormalized = new Triangle(
						// Компонента W похоже хранит что-то важное?
						// https://vectozavr.ru/forum?post=59
						clippedProjected[0] / clippedProjected[0].W,
						clippedProjected[1] / clippedProjected[1].W,
						clippedProjected[2] / clippedProjected[2].W,
						ambientColor
					);

					_triangles.Add(clippedProjectedNormalized);
				}
			}

			return _triangles.ToArray();
		}

		/// <summary>
		/// Cleaning all _tris and recalculation of View matrix
		/// </summary>
		public void Clear()
		{
			_triangles.Clear();
		}

		/// <summary>
		/// Sort _tris from back to front 
		/// This is some replacement for Z-buffer
		/// </summary>
		/// <see cref="https://vectozavr.ru/lesson.php?id_article=27"/>
		/// <returns></returns>
		public Triangle[] SortTriangles()
		{
			// Внимание, считаем что массив _triangles содержит треугольники, координаты которых переведены в пространство камеры.
			Comparison<Triangle> triangleComparison = (Triangle tri1, Triangle tri2) => 
			{
				// Расстояние по Z для каждого треугольника от камеры.
				float z1 = tri1[0].Z + tri1[1].Z + tri1[2].Z;
				float z2 = tri2[0].Z + tri2[1].Z + tri2[2].Z;
				if (z1 > z2) return 1;
				if (z1 < z2) return -1;
				return 0;
			};

			Array.Sort(_triangles.ToArray(), triangleComparison);

			return _triangles.ToArray();
		}
	}
}
