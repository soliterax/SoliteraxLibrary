using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliteraxLibrary
{
	class YapayZeka
	{
		/// <summary>
		/// parameters
		/// </summary>
		string cevap;
		public string BotAdi;
		string zekala;
		/// <summary>
		/// bot message input and output returns functions
		/// </summary>
		/// <param name="mesaj"></param>
		/// <returns></returns>
		public string cevapla(string mesaj)
		{

			if (mesaj.IndexOf("sa") != -1 || mesaj.IndexOf("Selamün Aleyküm") != -1 || mesaj.IndexOf("SelamünAleyküm") != -1 || mesaj.IndexOf("Selamun Aleykum") != -1 || mesaj.IndexOf("SelamunAleykum") != -1)
			{

				zekala = "ve Aleyküm Selam ve Rahmetullahi ve Beraketühü";

			} else if (mesaj.IndexOf("napıyorsun") != -1 || mesaj.IndexOf("napiyorsun") != -1)
			{

				Random random = new Random();
				random.Next(1, 4);
				switch(Convert.ToInt32(random))
				{

					case 1:
						zekala = "İyiyim ya sen nasılsın ?";
						cevap = zekala;
						break;
					case 2:
						zekala = "kötüyüm";
						cevap = zekala;
						break;
					case 3:
						zekala = "Kendimi pek iyi hissetmiyorum";
						cevap = zekala;
						break;
					case 4:
						zekala = "Nezle olmuşum galiba biraz performans kaybım olabilir";
						cevap = zekala;
						break;

				}

			}
			///<summary>
			///write the thanks mesaj to bot mesaj
			///</summary>
			else if (mesaj.IndexOf("bende iyiyim teşekkür ederim") != -1 || mesaj.IndexOf("bende iyiyim tesekkur ederim") != -1)
			{

				if(cevap.Contains("İyiyim ya sen nasılsın ?"))
				{
					Random random = new Random();
					random.Next(1, 2);
					switch (Convert.ToInt32(random))
					{

						case 1:
							zekala = "Allah iyilik versin";
							cevap = zekala;
							break;
						case 2:
							zekala = "Bişey Değil :)";
							break;

					}
					
				}

			}
			///<summary>
			///thanks message the send bot message
			/// </summary>
			else if (mesaj.IndexOf("sağol") != -1)
			{
				if (cevap.Contains("Allah iyilik versin")){ zekala = "..."; }

			}
			if (zekala.Contains("") || zekala.Contains(null))
			{

				cevapla(cevap);

			}
			return zekala;

		}

	}
}
