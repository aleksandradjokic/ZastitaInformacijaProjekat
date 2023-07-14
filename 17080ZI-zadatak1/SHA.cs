using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace _17080ZI_zadatak1
{
    class SHA
    {
      
         private byte[] text;
         private UInt32[] k;
         private UInt32 h0,h1,h2,h3,h4,h5,h6,h7;

         public SHA()
         {
             //k = new UInt32[64];
             set();
         }
         public SHA(string text)
         {
             //k = new UInt32[64];
             this.text = Encoding.ASCII.GetBytes(text);
             set();
         }
         public void set()
         {
             this.h0 = 0x6a09e667;
             this.h1 = 0xbb67ae85;
             this.h2 = 0x3c6ef372;
             this.h3 = 0xa54ff53a;
             this.h4 = 0x510e527f;
             this.h5 = 0x9b05688c;
             this.h6 = 0x1f83d9ab;
             this.h7 = 0x5be0cd19;

             this.k = new UInt32[64] {
             0x428A2F98, 0x71374491, 0xB5C0FBCF, 0xE9B5DBA5, 0x3956C25B, 0x59F111F1, 0x923F82A4, 0xAB1C5ED5,
             0xD807AA98, 0x12835B01, 0x243185BE, 0x550C7DC3, 0x72BE5D74, 0x80DEB1FE, 0x9BDC06A7, 0xC19BF174,
             0xE49B69C1, 0xEFBE4786, 0x0FC19DC6, 0x240CA1CC, 0x2DE92C6F, 0x4A7484AA, 0x5CB0A9DC, 0x76F988DA,
             0x983E5152, 0xA831C66D, 0xB00327C8, 0xBF597FC7, 0xC6E00BF3, 0xD5A79147, 0x06CA6351, 0x14292967,
             0x27B70A85, 0x2E1B2138, 0x4D2C6DFC, 0x53380D13, 0x650A7354, 0x766A0ABB, 0x81C2C92E, 0x92722C85,
             0xA2BFE8A1, 0xA81A664B, 0xC24B8B70, 0xC76C51A3, 0xD192E819, 0xD6990624, 0xF40E3585, 0x106AA070,
             0x19A4C116, 0x1E376C08, 0x2748774C, 0x34B0BCB5, 0x391C0CB3, 0x4ED8AA4A, 0x5B9CCA4F, 0x682E6FF3,
             0x748F82EE, 0x78A5636F, 0x84C87814, 0x8CC70208, 0x90BEFFFA, 0xA4506CEB, 0xBEF9A3F7, 0xC67178F2
             };
         }
         public string GetHash(string text)
         {
             this.text = Encoding.ASCII.GetBytes(text);

             // PREPROCESIRANJE

             var newLength = (56 - ((this.text.Length + 1) % 64)) % 64; // doda se k bitova '0', gde je k minimalni broj >= 0 takav da dužina rezultujuće poruke daje ostatak 448 pri deljenju sa 512.
             byte[] newText = new byte[this.text.Length + 1 + newLength + 8];
             Array.Copy(this.text, newText, this.text.Length);
             newText[this.text.Length] = 0x80; //doda se jedan bit '1' na poruku

             byte[] length = BitConverter.GetBytes(this.text.Length * 8); // big endian reči   
             Array.Copy(length, 0, newText, newText.Length - 8, 4); // add length in bits

             for (int i = 0; i < newText.Length / 64; ++i) //po 512 bitova
             {
                 UInt32[] w = new UInt32[64]; //niz od po 16 little endian reči
                 for (int j = 0; j < 16; ++j)
                     w[j] = BitConverter.ToUInt32(newText, (i * 64) + (j * 4));
   

                for (int j = 16; j < 64; j++)
                 {
                     UInt32 s0 = this.rightrotate(w[j - 15], 7) ^ this.rightrotate(w[j - 15], 18) ^ this.rightrotate(w[j - 15], 3);
                     UInt32 s1 = this.rightrotate(w[j - 2], 17) ^ this.rightrotate(w[j - 2], 19) ^ this.rightrotate(w[j - 2], 10);
                     w[j] = w[j - 16] + s0 + w[j - 7] + s1;
                 }

                 UInt32 a = this.h0;
                 UInt32 b = this.h1;
                 UInt32 c = this.h2;
                 UInt32 d = this.h3;
                 UInt32 e = this.h4;
                 UInt32 f = this.h5;
                 UInt32 g = this.h6;
                 UInt32 h = this.h7;

                 for(int j =0;j<64;j++)
                 {
                     UInt32 s0 = this.rightrotate(a, 2) ^ this.rightrotate(a, 13) ^ this.rightrotate(a, 22);
                     UInt32 ma = (a & b) ^ (a & c) ^ (b & c);
                     UInt32 t2 = s0 + ma;
                     UInt32 s1 = this.rightrotate(e, 6) ^ this.rightrotate(e, 11) ^ this.rightrotate(e, 25);
                     UInt32 ch = (e & f) ^ ((~e) & g);
                     UInt32 t1 = h + s1 + ch + k[i] + w[i];

                     h = g;
                     g = f;
                     f = e;
                     e = d + t1;
                     d = c;
                     c = b;
                     b = a;
                     a = t1 + t2;

                 }
                 this.h0 = this.h0 + a;
                 this.h1 = this.h1 + b;
                 this.h2 = this.h2 + c;
                 this.h3 = this.h3 + d;
                 this.h4 = this.h4 + e;
                 this.h5 = this.h5 + f;
                 this.h6 = this.h6 + g;
                 this.h7 = this.h7 + h;




             }
             return (ByteToString(h0) + ByteToString(h1) + ByteToString(h2) + ByteToString(h3) + ByteToString(h4) + ByteToString(h5) + ByteToString(h6) + ByteToString(h7));
         }
         public UInt32 rightrotate(UInt32 x, int n)
         {
             return (x >> n) | (x << (32 - n));
         }
         private static string ByteToString(UInt32 x)
         {
             return String.Join("", BitConverter.GetBytes(x).Select(y => y.ToString("x2")));
             //return UInt32.ToString()
         }
    }
}
