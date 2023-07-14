using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Security.Cryptography;

namespace _17080ZI_zadatak1
{
    public partial class Form1 : Form
    {
        public string fileName;
        public string keyFileName;

        public Form1()
        {
            
            InitializeComponent();
        }
        private void FileSystemWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            if (cbFileSystemWatcher.Checked)
            {
                string destinationFile = tbxCryptS.Text;
                this.fileName = e.Name;
                Decrypt(e.FullPath, destinationFile);
               
            }
        }
        private void Crypt(string src, string dst)
        {
            //byte[] hashValue = null;
            //SHA256 mySHA256 = SHA256.Create();

            if (rbSS.Checked) 
            {
                string cyper = File.ReadAllText(src);
                byte[] tocyper = File.ReadAllBytes(src);
                SimpleSubstitution ss = new SimpleSubstitution();
                ss.Alphabet = Encoding.ASCII.GetBytes(this.tbxAlph.Text);
                ss.Coded = Encoding.ASCII.GetBytes(this.tbxCode.Text);
                byte[] txt;
                txt = ss.Crypt(tocyper);
                string str = Encoding.Default.GetString(txt);

                SHA Sha = new SHA();
                string hashCode = Sha.GetHash(cyper);
                string write = hashCode + "\n" + str;

                textBox1.Text = str;
                string destination = dst + @"\" + fileName;
                File.WriteAllText(destination, write);
            }
            else if(rbS.Checked)
            {
                string tocyper = File.ReadAllText(src);
                
                Solitaire s = new Solitaire();
                string strpom = s.Translate(tocyper);
                string key=s.Shuffle();

                string str, mode = "";// = s.Crypt(tocyper);

                if (cbPCBC.Checked == true) //biranje moda
                {
                    str = s.CryptPCBC(tocyper);
                    if (s.IVSet)
                        mode = Encoding.Default.GetString(s.IV); //vrednost IV
                }
                else str = s.Crypt(tocyper);

                SHA Sha = new SHA();
                string hashCode = Sha.GetHash(strpom);
                
                textBox2.Text = hashCode;
                string write = hashCode + "\n" + str;

                textBox1.Text = str;

                string destination = dst + @"\" + fileName;
                File.AppendAllText(destination, write);

                string destin = dst + @"\" + keyFileName;
                if (mode != "")
                    key = key + "." + mode +"\n";
               
                File.AppendAllText(destin, key);
                
            }
            
        }
        private void Decrypt(string src, string dst)
        {
            if (rbSS.Checked)
            {
                string hash1 = File.ReadLines(src).First(); // hash
                //byte[] hs = Encoding.ASCII.GetBytes(hash1);
                string cyper = File.ReadAllText(src).Remove(0, hash1.Length + 1);
                byte[] tocyper = Encoding.ASCII.GetBytes(cyper);
                SimpleSubstitution ss = new SimpleSubstitution();
                ss.Alphabet = Encoding.ASCII.GetBytes(this.tbxAlph.Text);
                ss.Coded = Encoding.ASCII.GetBytes(this.tbxCode.Text);
                byte[] txt;
                txt = ss.Decrypt(tocyper);
                string str = Encoding.Default.GetString(txt);
                textBox2.Text = str;

                SHA Sha = new SHA();
                string hash2 = Sha.GetHash(str);

                if (hash1 != hash2)
                    MessageBox.Show("Different hash codes");
                else
                {
                    string destination = dst + @"\" + fileName;
                    File.WriteAllText(destination, str);
                    MessageBox.Show("Same hash codes");
                }

                
            }
            else if (rbS.Checked)
            {
                string hash1 = File.ReadLines(src).First(); // hash
                string tocyper = File.ReadAllText(src).Remove(0, hash1.Length + 1);
                string key = null; //= File.ReadAllText(tbxFindDeck.Text);
                
                Solitaire s = new Solitaire();
                
                string mode = "";
                if(cbPCBC.Checked == true)
                { 
                    foreach (string line in File.ReadLines(tbxFindDeck.Text))
                    {
                       // if (line.EndsWith(" ."))
                        //{
                            string[] keys = line.Split('.');
                            key = keys[0];
                            mode = keys[1];
                            
                        //}
                    }
                }
                else
                     key = File.ReadAllText(tbxFindDeck.Text);
                textBox1.Text = key;
                textBox2.Text = mode;
                s.setTocardSet(key);

                textBox1.Text = tocyper;
                string str; //= s.Decrypt(tocyper);
                
                string pom = this.fileName;
                pom = pom.Replace("key", "");

                if (cbPCBC.Checked == true) //biranje moda
                {
                    s.IV = Encoding.Default.GetBytes(mode);
                    str = s.DecryptPCBC(tocyper);
                    
                }
                else str = s.Decrypt(tocyper);
                textBox2.Text = str;
                SHA Sha = new SHA();
                string hash2 = Sha.GetHash(str);

                if (hash1 != hash2)
                    MessageBox.Show("Different hash codes");
                else
                {
                    string destination = dst + @"\" + pom;
                    File.AppendAllText(destination, str);
                    MessageBox.Show("Same hash codes");
                }
                
                
                

            }
        }

        private void btnCrypt_Click(object sender, EventArgs e)
        {
            Crypt(tbxCrypt.Text, tbxCryptS.Text);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {

            Decrypt(tbxCrypt.Text, tbxCryptS.Text);

        }

        private void btnCryptF_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    keyFileName = "";
                    this.fileName = Path.GetFileName(ofd.FileName);
                    tbxCrypt.Text = ofd.FileName;
                    int i = fileName.IndexOf(".");
                    for(int j=0;j<i;j++)
                    {
                        keyFileName+= fileName[j];
                    }
                    this.keyFileName+=  "key.txt";
                }
            }
        }



        private void btnCryptS_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    tbxCryptS.Text = fbd.SelectedPath;
                }
            }
        }


        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            string destination = tbxCryptS.Text;
            this.fileName = e.Name;
            Crypt(e.FullPath, destination);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
                tbxAlph.Enabled = false;
                tbxCode.Enabled = false;
                
            
        }

        private void deck_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.fileName = Path.GetFileName(ofd.FileName);
                    tbxFindDeck.Text = ofd.FileName;

                }
            }
        }

        private void rbSS_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSS.Checked)
            {
                tbxAlph.Enabled = true;
                tbxCode.Enabled = true;
                tbxFindDeck.Enabled = false;
                btnDeck.Enabled = false;
                //rbS.Checked = false;
            }
        }

        private void rbS_CheckedChanged(object sender, EventArgs e)
        {
            if (rbS.Checked)
            {
                tbxAlph.Enabled = false;
                tbxCode.Enabled = false;
                btnDeck.Enabled = true;
                tbxFindDeck.Enabled = true;
                //cbSS.Checked = false;
            }
        }
    }
}
