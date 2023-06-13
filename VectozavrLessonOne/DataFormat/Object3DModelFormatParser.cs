using SFML.Graphics;
using VectozavrLessonOne.Algebra.Vector;
using VectozavrLessonOne.Engine;

namespace VectozavrLessonOne.DataFormat
{
	/// <summary>
	/// Парсер OBJ-файлов.
	/// </summary>
	/// <see cref="https://ru.wikipedia.org/wiki/Obj"/>
	/// <see cref="http://www.martinreddy.net/gfx/3d/OBJ.spec"/>
	internal class Object3DModelFormatParser
	{
		/// <summary>
		/// Парсинг текстового файла (представленного как массив строк) 
		/// в словарь массивов треугольников.
		/// </summary>
		/// <param name="data">Содержимое OBJ-файла в виде массива строк (UTF-8)</param>
		/// <returns></returns>
		public static Dictionary<string, Triangle[]> Parse(string[] data)
		{
			Dictionary<string, Color> colors = new();
			List<Vector> vertexes = new();

			string currentObjectName = "";
			Color currentGroupColor = new(255, 245, 194, 255);
			List<Triangle> currentObjectTris = new();

			Dictionary<string, Triangle[]> objects = new();

			foreach (string line in data)
			{
				string[] lineParts = line.Split(' ');
				switch (lineParts[0])
				{
					case "m":
						// Материал (а точнее цвет).
						// m 003 77 77 77 255
						string colorName = lineParts[1];
						byte red = Convert.ToByte(lineParts[2]);
						byte green = Convert.ToByte(lineParts[3]);
						byte blue = Convert.ToByte(lineParts[4]);
						byte alpha = Convert.ToByte(lineParts[5]);
						colors.Add(colorName, new Color(red, green, blue, alpha));
						break;
					case "v":
						// Вершина.
						// v 0.044140 0.012938 -0.190583
						float x = Convert.ToSingle(lineParts[1]);
						float y = Convert.ToSingle(lineParts[2]);
						float z = Convert.ToSingle(lineParts[3]) ;
						vertexes.Add(new Vector(new float[] {x, y, z}));
						break;
					case "f":
						// Грань (а точнее треугольник).
						// f 3 11 10
						int vertexIndex1 = Convert.ToInt32(lineParts[1]) - 1;
						int vertexIndex2 = Convert.ToInt32(lineParts[2]) - 1;
						int vertexIndex3 = Convert.ToInt32(lineParts[3]) - 1;
						currentObjectTris.Add(new Triangle(vertexes[vertexIndex1], vertexes[vertexIndex2], vertexes[vertexIndex3], currentGroupColor));
						break;
					case "g":
						// Группа треугольников (одного цвета). По сути это смена текущего цвета.
						// g Cube.001_Cube.014_Material.002
						string nextColorName = lineParts[1].Substring(lineParts[1].Length - 3);
						currentGroupColor = colors[nextColorName];
						break; 
					case "o":
						// o Cube.002_Cube.015
						if (currentObjectTris.Count != 0)
						{ 
							objects.Add(currentObjectName, currentObjectTris.ToArray());
							currentObjectTris.Clear();
						}
						currentObjectName = lineParts[1];
						break;
				}
			}

			return objects;
		}
	}
}
