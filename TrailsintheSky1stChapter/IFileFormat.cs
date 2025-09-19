using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailsintheSky1stChapter
{
	internal interface IFileFormat
	{
		Byte[] Load(String filename);
		void Save(String filename, Byte[] buffer);
	}
}
