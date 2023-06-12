using SFML.Graphics;
using VectozavrLessonOne.Algebra.Matrix;
using VectozavrLessonOne.Algebra.Vector;

namespace VectozavrLessonOne.Engine
{
	/// <summary>
	/// Triangle
	/// </summary>
	/// <see cref="https://github.com/vectozavr/learn_3dzavr/blob/master/engine/Triangle.h"/>
	/// <see cref="https://github.com/vectozavr/learn_3dzavr/blob/master/engine/Triangle.cpp"/>
	internal class Triangle
	{
		private Color _color = new();

		/// <summary>
		/// Список вершин треугольника. Вершины хранятся как трехмерные векторы. 
		/// </summary>
		private readonly List<Vector> _points = new();
		
		/// <summary>
		/// Нормаль треугольника. Трехмерный вектор.
		/// </summary>
		private Vector _normal = Vector.Zero(new VectorSize(3));

		/// <summary>
		/// Вычисление нормали треугольника.
		/// </summary>
		/// <returns></returns>
		private Vector CalculateNormal()
		{
			Vector vector1 = this[1] - this[0];
			Vector vector2 = this[2] - this[0];
			Vector crossProduct = vector1 * vector2;
			return crossProduct.Normalize();
		}

		/// <summary>
		/// Конструктор треугольника.
		/// </summary>
		/// <param name="point1">Первая вершина треугольника</param>
		/// <param name="point2">Вторая вершина треугольника</param>
		/// <param name="point3">Третья вершина треугольника</param>
		/// <param name="color">Цвет поверхности треугольника</param>
		/// <exception cref="ArgumentException"></exception>
		public Triangle(Vector point1, Vector point2, Vector point3, Color color)
		{
			if (point1.Dimensions != 3 || point2.Dimensions != 3 || point3.Dimensions != 3)
			{
				throw new ArgumentException("Вершины треугольника должны быть трехмерными");
			}
			_points.Add(point1);
			_points.Add(point2);
			_points.Add(point3);
			_color = color;
			_normal = CalculateNormal();
		}

		/// <summary>
		/// Создание клона треугольника.
		/// </summary>
		/// <returns></returns>
		public Triangle Clone() => new(this[0], this[1], this[2], Color);

		/// <summary>
		/// Получить доступ к вершинам треугольника.
		/// </summary>
		/// <param name="pointIndex">Индекс вершины треугольника. Равно от 0 до 2.</param>
		/// <returns></returns>
		public Vector this[int pointIndex]
		{
			get => _points[pointIndex];
		}

		/// <summary>
		/// Цвет треугольника.
		/// </summary>
		public Color Color {
			get => _color;
			set => _color = value;
		}

		/// <summary>
		/// Нормаль треугольника. Трехмерный вектор.
		/// </summary>
		public Vector Normal
		{ 
			get => _normal;
		}

		/// <summary>
		/// Операция умножения треугольника на матрицу 4х4.
		/// В результате выполнения этой операции создается новый треугольник, 
		/// вершины которого создаются умножением матрицы на вершины исходного треугольника.
		/// </summary>
		/// <param name="triangle">Треугольник</param>
		/// <param name="matrix">Матрица 4 на 4</param>
		/// <returns>Треугольник</returns>
		/// <exception cref="ArgumentException"></exception>
		public static Triangle operator *(Triangle triangle, Matrix matrix)
		{
			if (matrix.Cols != 4 || matrix.Rows != 4)
			{
				throw new ArgumentException("Матрица должна быть 4 на 4");
			}

			Vector ToVector4(Vector vector, float w = 0)
			{
				if (vector.Dimensions != 3)
				{
					throw new ArgumentException("Вектор должен быть трехмерным");
				}
				return new Vector(new float[] { vector.X, vector.Y, vector.Z, w });
			}

			return new(
				Vector.FromMatrix(matrix * ToVector4(triangle[0]).ToMatrix()),
				Vector.FromMatrix(matrix * ToVector4(triangle[1]).ToMatrix()),
				Vector.FromMatrix(matrix * ToVector4(triangle[2]).ToMatrix()),
				triangle.Color
			);
		}

		/// <summary>
		/// Проверка точки. 
		/// Возвращает true, если точка находится внутри треугольника.
		/// Внимание, перед проверкой необходимо найти точку на плоскости треугольника. 
		/// Например точку пересечения прямой и плоскости треугольника.
		/// 
		/// Похоже эта функция проверяет наличие точки внутри призмы, 
		/// которая получается вытягиванием треугольника вдоль нормали треугольника.
		/// Но это надо еще проверить.
		/// </summary>
		/// <param name="point">Тестируемая точка</param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public bool IsPointInside(Vector point)
		{
			if (point.Dimensions != 3)
			{
				throw new ArgumentException("Вектор должен быть трехмерным");
			}

			float dot1 = ((point - this[0]) * (this[1] - this[0])).Dot(Normal);
			float dot2 = ((point - this[1]) * (this[2] - this[1])).Dot(Normal);
			float dot3 = ((point - this[2]) * (this[0] - this[2])).Dot(Normal);

			return (dot1 >= 0 && dot2 >= 0 && dot3 >= 0) || (dot1 <= 0 && dot2 <= 0 && dot3 <= 0);
		}

		/// <summary>
		/// Явно это вычисление позиции треугольника. Но не ясно почему она именно так вычисляется.
		/// Вопрос задан на форуме. Возможно автор прояснит ситуацию.
		/// Данный метод используется, поэтому надо выяснить этот вопрос.
		/// </summary>
		/// <see cref="https://vectozavr.ru/forum?post=57"/>
		/// <returns></returns>
		public Vector Position()
		{
			return (this[0] + this[1] + this[2]) / 3;
		}

		/// <summary>
		/// Пока не ясно что делает этот метод.
		/// Похоже этот метод нигде не используется.
		/// </summary>
		/// <param name="vector"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public float Distance(Vector vector)
		{
			if (vector.Dimensions != 3)
			{
				throw new ArgumentException("Вектор должен быть трехмерным");
			}

			return Normal.Dot(this[0] - vector);
		}
	}
}
