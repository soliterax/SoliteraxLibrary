using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliteraxLibrary
{
	class Faktoriyel
	{

		public int faktoriyel_hesapla(int sayi)
		{
			int i = 1;
			sayi++;
			int toplam = 1;
			while(i < sayi)
			{

				toplam *= i;
				i++;

			}
			return toplam;

		}

	}
}
