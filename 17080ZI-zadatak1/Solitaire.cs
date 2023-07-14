using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace _17080ZI_zadatak1
{
	
	class Solitaire
    {
		private byte[] InitVector;
		public bool IVSet;
		private uint xl;
		private uint xr;
		public byte[] IV
		{
			get { return InitVector; }
			set
			{
				if (value.Length == 8)
				{
					InitVector = value;
					IVSet = true;
				}
				else
				{
					throw new Exception("Invalid IV size.");
				}
			}
		}
		/* Numerisanje karti:
			  1-13 => A,2,...,K tref
			 14-26 => A,2,...,K karo
			 27-39 => A,2,...,K herc
			 40-52 => A,2,...,K pik
			53 & 54 => A & B dzokeri*/
		public int[] CardSet;
		public Solitaire()
        {
			CardSet = new int[54];

			for(int i =0;i<54;i++)
			{
				CardSet[i] = i + 1;
			}
	
		}
		public byte[] SetIV()
		{
			InitVector = new byte[8];
			RNGCryptoServiceProvider randomSource = new RNGCryptoServiceProvider();
			randomSource.GetBytes(InitVector);
			IVSet = true;
			//this.IV = InitVector;
			return InitVector;
		}
		public string setTocardSet(string text)
		{
			string p="";
			int j = 0;
			string l = "";
			for (int i = 0; i < text.Length; i++)
			{
				if(isNumeric(text[i].ToString()))
				{

					p += text[i].ToString();
				}
				else
				{
					if (isNumeric(p))
					{
						CardSet[j] = int.Parse(p); 
						j++;
					}		
					else
						l += p + " ";
					
					p = "";
				}
			}
			return l;
		}
		public static bool isNumeric(string s)
		{
			return int.TryParse(s, out int n);
		}
		private static readonly Random rand = new Random();
		private static readonly object syncLock = new object();
		public int RandomNumber(int min, int max)
		{
			lock (syncLock)
			{
				return rand.Next(min, max);
			}
		}
		public string Shuffle()
		{
			for (int i = 0; i < 54; i++)
			{
				var temp = CardSet[i];
				var index = RandomNumber(0, 54);
				CardSet[i] = CardSet[index];
				CardSet[index] = temp;
			}
			return Deck();

		}
		public string Deck()
		{
			string k = "";
			for (int i = 0; i < 54; i++)
			{
				k += CardSet[i].ToString();
				k += " | ";
			}
			return k;
		}
		public void Cuting()
		{
			this.JokerDown(53);
			this.JokerDown(54);
			this.JokerDown(54);
			this.tripleCut();
			this.countCut();
		}
		public void JokerDown(int j)
		{
			//pomera kartu z jednu poziciju
			int pom = Array.IndexOf(CardSet, j);
			if(pom==53)
			{
				int c = CardSet[53];
				for (int i = 53; i > 0; i--)
					CardSet[i] = CardSet[i - 1];
				CardSet[0] = c;
			}
			else
			{
				CardSet[pom] = CardSet[pom + 1];
				CardSet[pom + 1] = j;
			}
		}
		public void tripleCut()
		{
			// menjamo karte ispred prvog i iza drugog dzokera
			int top = Array.IndexOf(CardSet, 53);//pozicija prvog dzokera
			int bottom = Array.IndexOf(CardSet, 54);//pozicija drugog dzokera
			if (top > bottom)
			{
				//ukoliko su dzokeri zamenili mesta
				int pom = top;
				top = bottom;
				bottom = pom;
			}
			int[] newSet = new int[54];//pomocni set
			int lb = 53 - bottom;//duzina niza ispod drugog dzokera
			int lm = bottom - top - 1;//duzina niza izmedju dzokera
			int s = bottom + 1;
			for(int i=0;i<lb;i++)
			{
				newSet[i] = CardSet[s];
				s++;
			}
			s = top;
			for (int i = lb; i < lb+lm+2; i++)
			{
				int po = CardSet[s];
				newSet[i] = po;
				s++;
			}
			s = 0 ;
			for (int i = lb + lm + 2; i < 54; i++)
			{
				newSet[i] = CardSet[s];
				s++;
			}//zamena mesta spilova
			newSet.CopyTo(CardSet,0);

		}
		public void countCut()
		{
			int cut = CardSet[53];//poslednja karta
			int[] newSet = new int[54];//pomocni set
			if (cut < 53)
			{
				int s = cut;
				for (int i = 0; i < 53 - cut; i++)
				{
					newSet[i] = CardSet[s];
					s++;
				}
				s = 0;
				for (int i = 53 - cut;i< 53; i++)
				{
					newSet[i] = CardSet[s];
					s++;
				}//menjamo mesta delovima spila 
				newSet[53] = CardSet[53];
				newSet.CopyTo(CardSet, 0);
			}
		}
		public string Translate(string text)
		{
			text = text.ToUpper();
			//string result = text.Replace(' ', '');
			//string result = text.Trim(' ');
			return new string(text.ToCharArray()
					   .Where(c => !Char.IsWhiteSpace(c))
					   .ToArray());
			//return result;

		}
		public string TranslateDC(string text)
		{
			text = text.ToUpper();
			//string result = text.Replace(' ', '');
			//string result = text.Trim(' ');
			char[] tx = text.ToCharArray();
			StringBuilder txt = new StringBuilder();
			for(int i= 0;i<tx.Length;i++)
            {
				if(i%5==0 & i!=0)
                {
					txt.Append(' ');
                }
				txt.Append(tx[i]);
            }
			return txt.ToString();

		}
		protected String Conv(string text, bool type)
		{
			//string sb;
			StringBuilder txt = new StringBuilder();
			int Char, Key;
			int i = 0;
			while (i < text.Length)
			{
				Cuting();
				if (!((int)text[i] == 32))
				{
					Char = ((int)text[i] - 64);//text prebacujemo u broj
												  //curKey = CardSet[0];
				}
				else
				{
					Char = 32;
				}
				//curChar = ((Int32)message[x] - 64);
				Key = CardSet[0];// vrednost prve karte

				if (Key == 54)
					Key = CardSet[53]; // vrednost dzokera je 53
				else
					Key = CardSet[Key];

				if (type)//crypt
				{
					if (!(Char == 32))// proveravamo da li je karakter razmak
					{

						Char = (Char + Key);//curKey = CardSet[0];
					}
				}
				else
				{ // decode
					

					if (!(Char == 32))//proveravamo da li je karakter razmak
					{
						if (Char < Key) 
							Char += 26;
						Char = (Char - Key);
					}
				}
				if (Key < 53) // proveravamo da li je karta dzoker
				{
					if (Char == 32)//proveravamo da li je karakter razmak
						txt.Append((char)(32));//ukoliko jeste appendujemo ga
					else
					{
						if (Char > 26) Char %= 26;
						if (Char < 1) Char += 26;
						txt.Append((char)(Char + 64));//prebacujemo u ascii karakter (veliko slovo)
					}
					i++;
				}
			}
			return txt.ToString();
		}
		
		public string Crypt(string source)
		{
			source=this.Translate(source);//pocetni tekst prevodimo u velika slova
			
			return Conv(source, true);
		}

		public string Decrypt(string source)
		{
			//pocetni tekst prevodimo u velika slova
			 //Conv(source, false);
			return this.TranslateDC(Conv(source, false));
		}
		public string CryptPCBC(string source)
		{
			if (!IVSet)
				this.IV = SetIV();
			source = this.Translate(source);
			byte[] text = Encoding.Default.GetBytes(source);
			int len = (text.Length % 8 == 0 ? text.Length : text.Length + 8 - (text.Length % 8)); //  po 64 bitova 
			byte[] plainText = new byte[len];
			Buffer.BlockCopy(text, 0, plainText, 0, text.Length);
			byte[] Pj = new byte[8];

			byte[] Ij = new byte[8];
			Buffer.BlockCopy(IV, 0, Ij, 0, 8); 
			for (int i = 0; i < plainText.Length; i += 8)
			{
				Buffer.BlockCopy(plainText, i, Pj, 0, 8); 

				XorBlock(ref Pj, Ij); 
				string pomocni = Encoding.Default.GetString(Pj);

				Ij=Encoding.Default.GetBytes(Conv(pomocni, true));
				Buffer.BlockCopy(Pj, 0, plainText, i, 8);
			}

			return Encoding.Default.GetString(plainText);

		}
		public string DecryptPCBC(string source)
		{
			source = this.Translate(source);
			byte[] text = Encoding.ASCII.GetBytes(source);
			if (!IVSet)
			{
				throw new Exception("IV not set.");
			}
			int len = (text.Length % 8 == 0 ? text.Length : text.Length + 8 - (text.Length % 8)); //  po 64 bitova 
			byte[] plainText = new byte[len];
			Buffer.BlockCopy(text, 0, plainText, 0, text.Length);
			byte[] Pj = new byte[8];

			byte[] Ij = new byte[8];
			Buffer.BlockCopy(IV, 0, Ij, 0, 8); //I0=IV
			for (int i = 0; i < plainText.Length; i += 8)
			{
				
				Buffer.BlockCopy(plainText, i, Pj, 0, 8); //kopiranje u Pj

			string pomocni = Encoding.Default.GetString(Pj);
				Pj = Encoding.Default.GetBytes(Conv(pomocni, true));
				 XorBlock(ref Pj, Ij);
				Ij = Pj;

				
				Buffer.BlockCopy(Pj, 0, plainText, i, 8);
			}

			return Encoding.Default.GetString(plainText);

			//return Encoding.Default.GetString(plainText);
		}
			private void XorBlock(ref byte[] block, byte[] iv)
			{
				for (int i = 0; i < block.Length; i++)
				{
					block[i] ^= iv[i];
				}
			}

		
	}
}
