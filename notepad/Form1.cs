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


namespace notepad
{
    public partial class Form1 : Form

    {
        StringReader leitura = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void newNotepad()
        {
            richTextBox1.Clear();
            richTextBox1.Focus();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            newNotepad();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newNotepad();
        }

        private void Save()
        {
            try
            {
                if(this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter notepad_streamWriter = new StreamWriter(arquivo);
                    notepad_streamWriter.Flush();
                    notepad_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
                    notepad_streamWriter.Write(this.richTextBox1.Text);
                    notepad_streamWriter.Flush();
                    notepad_streamWriter.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro na criação do arquivo" + ex.Message, "Erro ao gravar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }
        
        private void Open()
        {
            this.openFileDialog1.Multiselect = false;

            this.openFileDialog1.Title = "Abrir Arquivo";
            openFileDialog1.InitialDirectory = @"C:\Users\matheus\Dropbox\PROJETOS\notepad\notepad";
            openFileDialog1.Filter = "(*.TXT)|*TXT";

            DialogResult dr = this.openFileDialog1.ShowDialog();
            if(dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    FileStream arquivo = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader notepad_streamReader = new StreamReader(arquivo);
                    notepad_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.richTextBox1.Text = "";
                    string linha = notepad_streamReader.ReadLine();
                    while(linha != null)
                    {
                        this.richTextBox1.Text += linha + "\n";
                        linha = notepad_streamReader.ReadLine();
                    }

                    notepad_streamReader.Close();

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Erro de Leitura" + ex.Message, "Erro ao ler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void Copy()
        {
            if(richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void Paste()
        {
            richTextBox1.Paste();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void btnColar_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void Bold()
        {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool b = false;

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;
            b = richTextBox1.Font.Bold;

            if(b == false)
            {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte,FontStyle.Bold);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);
            }

        }

        private void Regular()
        {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool b = false;

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;
            b = richTextBox1.Font.Bold;

            if (b == false)
            {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);
            }
        }

        private void Italic()
        {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool it = false;

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;
            it = richTextBox1.Font.Italic;

            if (it == false)
            {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic);
            }

        }

        private void Underlined()
        {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool sub = false;

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;
            sub = richTextBox1.Font.Underline;

            if (sub == false)
            {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);
            }

        }

        private void btnNegrito_Click(object sender, EventArgs e)
        {
            Bold();
        }

        private void negritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bold();
        }

        private void itálicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Italic();
        }

        private void btnItalico_Click(object sender, EventArgs e)
        {
            Italic();
        }

        private void btnSublinhado_Click(object sender, EventArgs e)
        {
            Underlined();
        }

        private void sublinhadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Underlined();
        } 

        private void alignLeft()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }
        private void alignRight()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }
        private void alignCenter()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void centroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alignCenter();
        }

        private void esquerdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alignLeft();
        }

        private void direitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alignRight();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            string texto = this.richTextBox1.Text;
            leitura = new StringReader(texto);

            if(printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linePage = 0;
            float PosY = 0;
            int cont = 0;
            float marginLeft = e.MarginBounds.Left - 50;
            float marginTop = e.MarginBounds.Top - 50;

            if(marginLeft < 5)
            {
                marginLeft = 20;
            }
            if(marginTop < 5)
            {
                marginTop = 20;
            }

            string line = null;

            Font fonte = this.richTextBox1.Font;
            SolidBrush pincel = new SolidBrush(Color.Black);
            linePage = e.MarginBounds.Height / fonte.GetHeight(e.Graphics);
            line = leitura.ReadLine();
            while(cont < linePage)
            {
                PosY = (marginTop + (cont * fonte.GetHeight(e.Graphics)));
                e.Graphics.DrawString(line, fonte, pincel, marginLeft, PosY, new StringFormat());
                cont++;
                line = leitura.ReadLine();
            }

            if(line != null)
            {
                e.HasMorePages = true; 
            }
            else
            {
                e.HasMorePages = false;
            }

            pincel.Dispose();

        }

        private void btnRegular_Click(object sender, EventArgs e)
        {
            Regular();
        }
    }
}
