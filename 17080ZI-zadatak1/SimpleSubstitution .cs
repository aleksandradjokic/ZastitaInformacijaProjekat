using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Security.Cryptography;

namespace _17080ZI_zadatak1
{
    class SimpleSubstitution
    {
		private byte[] InitVector;
		private bool IVSet;
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
		public SimpleSubstitution()
		{
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
		private byte[] alphabet;

		public byte[] Alphabet
		{
			get
			{
				return this.alphabet;
			}
			set
			{
				this.alphabet = value;
				foreach (byte c in this.alphabet)
				{
					this.alphabetBackUp.Add(c);
				}
			}
		}

		private byte[] coded;

		public byte[] Coded
		{
			get
			{
				return this.coded;
			}
			set
			{
				this.coded = value;

				foreach (byte c in this.coded)
				{
					this.codedBackUp.Add(c);
				}

			}
		}

		private ArrayList alphabetBackUp = new ArrayList();
		private ArrayList codedBackUp = new ArrayList();

		public byte[] Crypt(byte[] source)
		{
			var result= new byte[source.Length];

			for (int i = 0; i < source.Length; i++)
			{
				int index = alphabetBackUp.IndexOf(source[i]);
				if (index < 0 || (index > coded.Length - 1))
				{
					result[i]= 35;
				}
				else
				{
					result[i] = coded[index];
				}
			}
			return result;
		}

		public byte[] Decrypt(byte[] source)
		{
			var result = new byte[source.Length];

			for (int i = 0; i < source.Length; i++)
			{
				int index = codedBackUp.IndexOf(source[i]);
				if (index < 0 || (index > alphabet.Length - 1))
				{
					result[i]= 32;
				}
				else
				{
					result[i]=alphabet[index];
				}
			}
			return result;
		}

		public string[] CryptPCBC(byte[] source)
        {
			this.IV = SetIV();
			return null;
		}
		public string[] DecryptPCBC(byte[] source)
		{
			if (!IVSet)
			{
				throw new Exception("IV not set.");
			}
			return null;
		}
	}
}
