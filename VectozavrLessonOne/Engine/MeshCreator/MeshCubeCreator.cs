using SFML.Graphics;
using VectozavrLessonOne.Algebra.Matrix;
using VectozavrLessonOne.Algebra.Vector;

namespace VectozavrLessonOne.Engine.MeshCreator
{
	internal class MeshCubeCreator
	{
		/// <summary>
		/// Создать Mesh куб.
		/// Внимание, созданный куб будет смещен на 0.5 по всем осям.
		/// </summary>
		/// <param name="nameTag">Имя куба</param>
		/// <param name="size">Размер куба</param>
		/// <returns></returns>
		public static Mesh Create(ObjectNameTag nameTag, float size)
		{
			Mesh cube = new Mesh(
				nameTag, 
				new Triangle[]
				{
					new Triangle(new Vector(new float[] {0.0f, 0.0f, 0.0f}), new Vector(new float[] {0.0f, 1.0f, 0.0f}), new Vector(new float[] {1.0f, 1.0f, 0.0f})),
					new Triangle(new Vector(new float[] {0.0f, 0.0f, 0.0f}), new Vector(new float[] {1.0f, 1.0f, 0.0f}), new Vector(new float[] {1.0f, 0.0f, 0.0f})),
					new Triangle(new Vector(new float[] {1.0f, 0.0f, 0.0f}), new Vector(new float[] {1.0f, 1.0f, 0.0f}), new Vector(new float[] {1.0f, 1.0f, 1.0f})),
					new Triangle(new Vector(new float[] {1.0f, 0.0f, 0.0f}), new Vector(new float[] {1.0f, 1.0f, 1.0f}), new Vector(new float[] {1.0f, 0.0f, 1.0f})),
					new Triangle(new Vector(new float[] {1.0f, 0.0f, 1.0f}), new Vector(new float[] {1.0f, 1.0f, 1.0f}), new Vector(new float[] {0.0f, 1.0f, 1.0f})),
					new Triangle(new Vector(new float[] {1.0f, 0.0f, 1.0f}), new Vector(new float[] {0.0f, 1.0f, 1.0f}), new Vector(new float[] {0.0f, 0.0f, 1.0f})),
					new Triangle(new Vector(new float[] {0.0f, 0.0f, 1.0f}), new Vector(new float[] {0.0f, 1.0f, 1.0f}), new Vector(new float[] {0.0f, 1.0f, 0.0f})),
					new Triangle(new Vector(new float[] {0.0f, 0.0f, 1.0f}), new Vector(new float[] {0.0f, 1.0f, 0.0f}), new Vector(new float[] {0.0f, 0.0f, 0.0f})),
					new Triangle(new Vector(new float[] {0.0f, 1.0f, 0.0f}), new Vector(new float[] {0.0f, 1.0f, 1.0f}), new Vector(new float[] {1.0f, 1.0f, 1.0f})),
					new Triangle(new Vector(new float[] {0.0f, 1.0f, 0.0f}), new Vector(new float[] {1.0f, 1.0f, 1.0f}), new Vector(new float[] {1.0f, 1.0f, 0.0f})),
					new Triangle(new Vector(new float[] {1.0f, 0.0f, 1.0f}), new Vector(new float[] {0.0f, 0.0f, 1.0f}), new Vector(new float[] {0.0f, 0.0f, 0.0f})),
					new Triangle(new Vector(new float[] {1.0f, 0.0f, 1.0f}), new Vector(new float[] {0.0f, 0.0f, 0.0f}), new Vector(new float[] {1.0f, 0.0f, 0.0f})),
				}
			);

			cube.Color = new Color(255, 245, 180);

			return (
				cube 
				* Matrix.Scale(new Vector(new float[] { size, size, size })) 
				* Matrix.Translation(new Vector(new float[] { -0.5f, -0.5f, -0.5f }))
			);
		}
	}
}
