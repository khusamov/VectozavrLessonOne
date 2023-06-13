using SFML.Graphics;
using VectozavrLessonOne.Algebra.Matrix;
using VectozavrLessonOne.Algebra.Vector;
using VectozavrLessonOne.Engine.MeshCreator;

namespace VectozavrLessonOne.Engine
{
	/// <summary>
	/// Сетка треугольников.
	/// По сути массив треугольников, причем независимых треугольников.
	/// </summary>
	/// <see cref="https://github.com/vectozavr/learn_3dzavr/blob/master/engine/Mesh.h"/>
	/// <see cref="https://github.com/vectozavr/learn_3dzavr/blob/master/engine/Mesh.cpp"/>
	/// <see cref="https://github.com/dwmkerr/sharpgl"/>
	internal class Mesh : Object
	{
		private Triangle[] _tris = Array.Empty<Triangle>();
		private Color _color = Color.White;
		private bool _visible = true;

		/// <summary>
		/// Конструктор пустого Mesh.
		/// </summary>
		/// <param name="nameTag">Имя объекта</param>
		public Mesh(ObjectNameTag nameTag) : base(nameTag) { }

		/// <summary>
		/// Конструктор Mesh на основе массива треугольников.
		/// </summary>
		/// <param name="nameTag">Имя объекта</param>
		/// <param name="tris">Массив треугольников</param>
		public Mesh(ObjectNameTag nameTag, Triangle[] tris) : base(nameTag)
		{
			_tris = tris;
		}

		/// <summary>
		/// Конструктор Mesh из файла с возможностью масштабирования.
		/// </summary>
		/// <param name="nameTag">Имя объекта</param>
		/// <param name="filename">Путь к файлу</param>
		/// <param name="scale">Вектор масштабирования</param>
		public Mesh(ObjectNameTag nameTag, string filename, Vector? scale = null) : base(nameTag)
		{
			if (scale is null)
			{
				scale = new Vector(new float[] { 1, 1, 1 });
			}
			LoadObjects(filename, scale);
		}

		/// <summary>
		/// Загрузить треугольники из файла с возможностью масштабирования.
		/// Имеющиеся треугольники будут удалены.
		/// </summary>
		/// <param name="filename">Путь к файлу</param>
		/// <param name="scale">Вектор масштабирования</param>
		public void LoadObjects(string filename, Vector? scale = null)
		{
			if (scale is null)
			{
				scale = new Vector(new float[] { 1, 1, 1 });
			}
			throw new NotImplementedException("Метод LoadObjects() не реализован, требуется реализация класса ResourceManager");
			/*_tris.clear();
			auto objects = ResourceManager::loadObjects(filename);
			for (auto & obj : objects)
			{
				for (auto & tri : obj->triangles())
				{
					_tris.push_back(tri);
				}
			}
			this->scale(scale);*/
		}

		/// <summary>
		/// Операция умножения Mesh на матрицу 4 на 4.
		/// В результате этой операции создается новый Mesh, у которого каждый треугольник умножается на матрицу.
		/// В новый Mesh копируются _color и _visible из исходного.
		/// </summary>
		/// <param name="mesh"></param>
		/// <param name="transformMatrix"></param>
		/// <returns></returns>
		public static Mesh operator *(Mesh mesh, Matrix transformMatrix)
		{
			if (transformMatrix.Rows != 4 || transformMatrix.Cols != 4)
			{
				throw new ArgumentException("Матрица должна быть 4 на 4");
			}
			Triangle[] transformedTris = new Triangle[mesh._tris.Length];
			for (int i = 0; i < mesh._tris.Length; i++)
			{
				transformedTris[i] = mesh._tris[i] * transformMatrix;
			}
			return new(mesh.NameTag, transformedTris)
			{
				_color = mesh._color,
				_visible = mesh._visible
			};
		}

		public new Mesh Clone()
		{
			return new Mesh(NameTag)
			{
				_tris = _tris,
				_color = _color,
				_visible = _visible,
				_geometry = _geometry
			};
		}

		/// <summary>
		/// Получить доступ к массиву треугольников.
		/// </summary>
		public Triangle[] Triangles
		{
			get => _tris;
		}

		/// <summary>
		/// Размер Mesh. Возвращает количество всех вершин всех треугольников.
		/// </summary>
		public uint Size
		{
			get => (uint)_tris.Length * 3;
		}

		/// <summary>
		/// Получить или задать цвет Mesh.
		/// При задании цвета изменяются цвета всех треугольников на первом уровне этого объекта.
		/// </summary>
		public Color Color
		{
			get => _color;
			set {
				_color = value;
				foreach (Triangle triangle in _tris)
				{
					triangle.Color = _color;
				}

				// поскольку мы меняем цвет сетки, мы должны обновить геометрию новым цветом
				GLFreeFloatArray();
			}
		}

		public void SetOpacity(byte alpha)
		{
			Color = new Color(_color.R, _color.G, _color.B, alpha);
		}

		public void SetVisible(bool visible)
		{
			_visible = visible;
		}

		public bool IsVisible
		{
			get => _visible;
		}

		public static Mesh Cube(ObjectNameTag tag, float size = 1.0f)
		{
			return MeshCubeCreator.Create(tag, size);
		}

		public static Mesh LineTo(ObjectNameTag nameTag, Vector from, Vector to, float lineWidth = 0.1f, Color? color = null)
		{
			if (color is null)
			{
				color = new Color(150, 150, 150, 100);
			}
			throw new NotImplementedException();
		}

		public static Mesh ArrowTo(ObjectNameTag nameTag, Vector from, Vector to, float lineWidth = 0.1f, Color? color = null)
		{
			if (color is null)
			{
				color = new Color(150, 150, 150, 255);
			}
			throw new NotImplementedException();
		}

		#region OpenGL вариант этого класса.

		private float[] _geometry = new float[0];

		/// <summary>
		/// Вычислить геометрию Mesh для OpenGL.
		/// </summary>
		/// <see cref="https://github.com/vectozavr/learn_3dzavr/blob/master/engine/Mesh.cpp#L189"/>
		/// <returns></returns>
		public float[] GLFloatArray()
		{
			if (_geometry.Length != 0)
			{
				return _geometry;
			}

			_geometry = new float[_tris.Length * 7 * 3];

			Vector ToVector4(Vector vector)
			{
				if (vector.Dimensions != 3)
				{
					throw new ArgumentException("Вектор должен быть трехмерным");
				}
				return new Vector(new float[] { vector.X, vector.Y, vector.Z, 1 });
			}

			for (int i = 0; i < _tris.Length; i++)
			{
				uint stride = (uint)(21 * i);
				Triangle triangle = _tris[i];
				Vector normal = (Model * ToVector4(triangle.Normal)).Normalize();
				float dot = normal.Dot(new Vector(new float[] { 0f, 1f, 2f }).Normalize());
				for (int k = 0; k < 3; k++)
				{
					Color color = triangle.Color;
					float[] ambientColor = new float[] {
						color.R * (0.3f * MathF.Abs(dot) + 0.7f) / 255f,
						color.G * (0.3f * MathF.Abs(dot) + 0.7f) / 255f,
						color.B * (0.3f * MathF.Abs(dot) + 0.7f) / 255f,
						color.A / 255f,
					};
					_geometry[stride + 7 * k + 0] = triangle[k].X;
					_geometry[stride + 7 * k + 1] = triangle[k].Y;
					_geometry[stride + 7 * k + 2] = triangle[k].Z;
					_geometry[stride + 7 * k + 3] = ambientColor[0];
					_geometry[stride + 7 * k + 4] = ambientColor[1];
					_geometry[stride + 7 * k + 5] = ambientColor[2];
					_geometry[stride + 7 * k + 6] = ambientColor[3];
				}
			}

			return _geometry;
		}

		public void GLFreeFloatArray()
		{
			_geometry = new float[0];
		}

		#endregion
	}
}