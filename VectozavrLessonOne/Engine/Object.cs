using VectozavrLessonOne.Algebra.Matrix;
using VectozavrLessonOne.Algebra.Vector;

namespace VectozavrLessonOne.Engine
{
	/// <summary>
	/// Object
	/// </summary>
	/// <see cref="https://github.com/vectozavr/learn_3dzavr/blob/master/engine/Object.h"/>
	/// <see cref="https://github.com/vectozavr/learn_3dzavr/blob/master/engine/Object.cpp"/>
	internal class Object
	{

		// OpenGL function
		//[[nodiscard]] GLfloat* glModel() const;
		//[[nodiscard]] GLfloat* glInvModel() const;

		private readonly ObjectNameTag _nameTag = new("");

		private readonly Dictionary<ObjectNameTag, Object> _attachedObjects = new();

		// Примите во внимание, что при повороте тела вы меняете '_angle' и '_angleLeftUpLookAt'
		// только для этого конкретного тела, но не для прикрепленных объектов!
		// Следовательно, во время вращения '_angle' и '_angleLeftUpLookAt'
		// остаются неизменными все прикрепленные объекты.
		private Vector _angle = Vector.Zero(new VectorSize(3));
		private Vector _angleLeftUpLookAt = Vector.Zero(new VectorSize(3));

		/// <summary>
		/// Матрица трансформации. Размер матрицы 4 на 4.
		/// </summary>
		private Matrix _transformMatrix = Matrix.Identity(new MatrixSize(4));

		private Vector _position = Vector.Zero(new VectorSize(3));

		private bool CheckIfAttached(Object sameObject)
		{
			foreach ((_, Object attachedObject) in _attachedObjects)
			{
				if (sameObject == attachedObject || attachedObject.CheckIfAttached(sameObject))
				{
					return true;
				}
			}
			return false;
		}

		public Object(ObjectNameTag nameTag)
		{
			_nameTag = nameTag;
		}

		public Object Clone() => new(_nameTag)
		{
			_angleLeftUpLookAt = _angleLeftUpLookAt,
			_transformMatrix = _transformMatrix,
			_position = _position
		};

		public ObjectNameTag NameTag
		{
			get => _nameTag;
		}

		public Vector Position
		{
			get => _position;
		}

		public Vector Angle
		{
			get => _angle;
		}

		public Vector AngleLeftUpLookAt
		{
			get => _angleLeftUpLookAt;
		}

		public Vector Left
		{
			get => _transformMatrix.X.Normalize();
		}

		public Vector Up
		{
			get => _transformMatrix.Y.Normalize();
		}

		public Vector LookAt
		{
			get => _transformMatrix.Z.Normalize();
		}

		public Matrix Model
		{
			get => Matrix.Translation(Position) * _transformMatrix;
		}

		public Matrix InvModel
		{
			get => Matrix.View(Left, Up, LookAt, Position);
		}

		public void Attach(Object sameObject)
		{
			if (this == sameObject)
			{
				throw new ArgumentException("Нельзя прикреплять объект к самому себе");
			}
			if (sameObject.CheckIfAttached(this))
			{
				throw new ArgumentException("Нельзя создавать бесконечные рекурсивные цепочки вызовов");
			}

			_attachedObjects.Add(sameObject.NameTag, sameObject);
		}

		public void Unattach(ObjectNameTag nameTag) => _attachedObjects.Remove(nameTag);

		public Object Attached(ObjectNameTag nameTag) => _attachedObjects[nameTag];

		/// <summary>
		/// Трансформация объекта и всех прикрепленных объектов относительно определенной точки.
		/// </summary>
		/// <param name="point"></param>
		/// <param name="transformMatrix"></param>
		/// <exception cref="ArgumentException"></exception>
		public void TransformRelativePoint(Vector point, Matrix transformMatrix)
		{
			if (point.Dimensions != 3)
			{
				throw new ArgumentException("Вектор должен быть трехмерным");
			}
			if (transformMatrix.Rows != 4 || transformMatrix.Cols != 4)
			{
				throw new ArgumentException("Матрица должна быть 4 на 4");
			}

			// Перевести объект в новую систему координат (связанную с точкой).
			_transformMatrix = Matrix.Translation(Position - point) * _transformMatrix;

			// Преобразуйте объект (в новой системе координат).
			_transformMatrix = transformMatrix * _transformMatrix;

			// Перевести объект обратно в свою систему координат.
			_position = _transformMatrix.W + point;
			_transformMatrix = Matrix.Translation(-_transformMatrix.W) * _transformMatrix;

			foreach ((_, Object attachedObject) in _attachedObjects)
			{
				attachedObject.TransformRelativePoint(point, transformMatrix);
			}
		}

		/// <summary>
		/// Трансформация объекта и всех прикрепленных объектов.
		/// </summary>
		/// <param name="transformMatrix"></param>
		/// <exception cref="ArgumentException"></exception>
		public void Transform(Matrix transformMatrix)
		{
			if (transformMatrix.Rows != 4 || transformMatrix.Cols != 4)
			{
				throw new ArgumentException("Матрица должна быть 4 на 4");
			}

			_transformMatrix = transformMatrix * _transformMatrix;

			foreach ((_, Object attachedObject) in _attachedObjects)
			{
				attachedObject.TransformRelativePoint(Position, transformMatrix);
			}
		}

		/// <summary>
		/// Перемещение объекта по трем осям.
		/// </summary>
		/// <see cref="https://github.com/vectozavr/3dzavr/blob/master/engine/Object.cpp"/>
		/// <param name="translateVector">Вектор перемещения объекта</param>
		public void Translate(Vector translateVector)
		{
			if (translateVector.Dimensions != 3)
			{
				throw new ArgumentException("Вектор перемещения должен быть трехмерным");
			}

			_position += translateVector;

			foreach ((_, Object attachedObject) in _attachedObjects)
			{
				attachedObject.Translate(translateVector);
			}
		}

		/// <summary>
		/// Масштабирование объекта по трем осям.
		/// </summary>
		/// <see cref="https://github.com/vectozavr/3dzavr/blob/master/engine/Object.cpp"/>
		/// <param name="scaleVector">Вектор масштабирования объекта</param>
		public void Scale(Vector scaleVector)
		{
			if (scaleVector.Dimensions != 3)
			{
				throw new ArgumentException("Вектор масштабирования должен быть трехмерным");
			}

			Transform(Matrix.Scale(scaleVector));
		}

		/// <summary>
		/// Вращение объекта по трем осям.
		/// </summary>
		/// <see cref="https://github.com/vectozavr/3dzavr/blob/master/engine/Object.cpp"/>
		/// <param name="rotateVector">Вектор вращения объекта</param>
		public void Rotate(Vector rotateVector)
		{
			if (rotateVector.Dimensions != 3)
			{
				throw new ArgumentException("Вектор вращения должен быть трехмерным");
			}

			// Угол поворота объекта сохраняем в отдельном векторе _angle, чтобы отслеживать на какой угол был повернут объект.
			// Например объект можно будет вернуть обратно (вращать объект в обратную сторону в исходное состояние).
			// Причем угол не сохраняется для операции Rotate(Vector sameVector, float angle).
			_angle += rotateVector;

			Transform(rotateVector.RotationMatrix());
		}

		/// <summary>
		/// Вращение объекта вокруг определенного вектора на определенный угол.
		/// </summary>
		/// <see cref="https://github.com/vectozavr/3dzavr/blob/master/engine/Object.cpp"/>
		/// <param name="sameVector">Вектор, вокруг которого требуется вращать объект</param>
		/// <param name="angle">Угол вращения объекта</param>
		public void Rotate(Vector sameVector, float angle)
		{
			if (sameVector.Dimensions != 3)
			{
				throw new ArgumentException("Вектор вращения должен быть трехмерным");
			}

			Transform(sameVector.RotationMatrix(angle));
		}

		/// <summary>
		/// RotateToAngle
		/// </summary>
		/// <see cref="https://github.com/vectozavr/3dzavr/blob/master/engine/Object.cpp"/>
		public void RotateToAngle(Vector vector)
		{
			if (vector.Dimensions != 3)
			{
				throw new ArgumentException("Вектор должен быть трехмерным");
			}
			Rotate(vector - _angle);
		}

		/// <summary>
		/// Вращение объекта по трем осям относительно точки.
		/// </summary>
		/// <see cref="https://github.com/vectozavr/3dzavr/blob/master/engine/Object.cpp"/>
		/// <param name="point">Точка, относительно которой вращается объект</param>
		/// <param name="rotateVector">Вектор вращения по трем осям</param>
		public void RotateRelativePoint(Vector point, Vector rotateVector)
		{
			if (point.Dimensions != 3)
			{
				throw new ArgumentException("Точка должна быть трехмерной");
			}
			if (rotateVector.Dimensions != 3)
			{
				throw new ArgumentException("Вектор вращения должен быть трехмерным");
			}
			_angle += rotateVector;
			TransformRelativePoint(point, rotateVector.RotationMatrix());
		}

		/// <summary>
		/// Вращение объекта вокруг определенного вектора на определенный угол относительно точки.
		/// </summary>
		/// <see cref="https://github.com/vectozavr/3dzavr/blob/master/engine/Object.cpp"/>
		/// <param name="point">Точка, относительно которой вращается объект</param>
		/// <param name="sameVector">Вектор, вокруг которого требуется вращать объект</param>
		/// <param name="angle">Угол вращения объекта</param>
		public void RotateRelativePoint(Vector point, Vector sameVector, float angle)
		{
			if (point.Dimensions != 3)
			{
				throw new ArgumentException("Точка должна быть трехмерной");
			}
			if (sameVector.Dimensions != 3)
			{
				throw new ArgumentException("Вектор вращения должен быть трехмерным");
			}
			TransformRelativePoint(point, sameVector.RotationMatrix(angle));
		}

		/// <summary>
		/// RotateLeft
		/// </summary>
		/// <see cref="https://github.com/vectozavr/3dzavr/blob/master/engine/Object.cpp"/>
		public void RotateLeft(float angle)
		{
			_angleLeftUpLookAt = new(new float[] { _angleLeftUpLookAt.X + angle, _angleLeftUpLookAt.Y, _angleLeftUpLookAt.Z });
			Rotate(Left, angle);
		}

		/// <summary>
		/// RotateUp
		/// </summary>
		/// <see cref="https://github.com/vectozavr/3dzavr/blob/master/engine/Object.cpp"/>
		public void RotateUp(float angle)
		{
			_angleLeftUpLookAt = new(new float[] { _angleLeftUpLookAt.X, _angleLeftUpLookAt.Y + angle, _angleLeftUpLookAt.Z });
			Rotate(Up, angle);
		}

		/// <summary>
		/// RotateLookAt
		/// </summary>
		/// <see cref="https://github.com/vectozavr/3dzavr/blob/master/engine/Object.cpp"/>
		public void RotateLookAt(float angle)
		{
			_angleLeftUpLookAt = new(new float[] { _angleLeftUpLookAt.X, _angleLeftUpLookAt.Y, _angleLeftUpLookAt.Z + angle });
			Rotate(LookAt, angle);
		}

		/// <summary>
		/// Перемещение объекта в определенную точку.
		/// </summary>
		/// <see cref="https://github.com/vectozavr/3dzavr/blob/master/engine/Object.cpp"/>
		public void TranslateToPoint(Vector point)
		{
			if (point.Dimensions != 3)
			{
				throw new ArgumentException("Точка должна быть трехмерной");
			}
			Translate(point - Position);
		}

		/// <summary>
		/// Перемещение объекта в направлении определенной точки на определенное расстояние value.
		/// </summary>
		/// <see cref="https://github.com/vectozavr/3dzavr/blob/master/engine/Object.cpp"/>
		public void AttractToPoint(Vector point, float value)
		{
			if (point.Dimensions != 3)
			{
				throw new ArgumentException("Точка должна быть трехмерной");
			}
			Translate((point - Position).Normalize() * value);
		}
	}
}
