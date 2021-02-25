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
using System.Drawing.Text;
 

namespace WordPad
{
    public partial class Form1 : Form
    {
        string type;

        int first;

        string startBcolor = "Window";
        string startColor = "Black";
        string startFont="";
        double startSize = 8.25;
        string startText="";
        
       // string startT="";

        public Form1()
        {
            InitializeComponent();
           
        }
        

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "" && type == null)
            {
                DialogResult rec = new DialogResult();
                rec = MessageBox.Show("Вы хотите сохранить?", "Сохранить!!!", MessageBoxButtons.YesNo);
                if (rec.ToString() == "Yes")
                {
                    saveToolStripMenuItem_Click(sender, e);
                    this.Text = Path.GetFileName("WordPad");
                    type = null;
                    richTextBox1.Clear();
                    startColor = "Black";
                    startSize = 8.25;
                }
                if (rec.ToString() == "No")
                {
                    this.Text = Path.GetFileName("WordPad");
                    type = null;
                    richTextBox1.Clear();
                    startColor = "Black";
                    startSize = 8.25;
                }  
            }
            
            if (richTextBox1.Text != "" || richTextBox1.Text == "" && type != null)
            {
                DialogResult rec = new DialogResult();                
                rec = MessageBox.Show("Вы хотите сохранить?", "Сохранить!!!", MessageBoxButtons.YesNo);
                if (rec.ToString() == "Yes")
                {
                    saveToolStripMenuItem1_Click(sender, e);
                    this.Text = Path.GetFileName("WordPad");
                    richTextBox1.Clear();
                    type = null;
                    startColor = "Black";
                    startSize = 8.25;
                }
               
                if (rec.ToString() == "No")
                {
                    this.Text = Path.GetFileName("WordPad");
                    richTextBox1.Clear();
                    type = null;
                    startColor = "Black";
                    startSize = 8.25;
                }  
            } 
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (richTextBox1.Text == "" && type == null)
            {
                OpenFileDialog op = new OpenFileDialog();

                op.Title = "Open My New File";
                op.Filter = "RTF Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt| All Files (*.*)|*.*";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    if (op.FilterIndex == 1)
                    {
                        richTextBox1.LoadFile(op.FileName, RichTextBoxStreamType.RichText);
                    }
                    //MessageBox.Show(op.FilterIndex.ToString());
                    else
                    if (op.FilterIndex == 2)
                    {
                        richTextBox1.LoadFile(op.FileName, RichTextBoxStreamType.PlainText);
                    }

                    this.Text = Path.GetFileName(op.FileName);

                    type = op.FileName;
                    first = op.FilterIndex;

                    startText = richTextBox1.Text;  
                    startFont = richTextBox1.SelectionFont.Name;
                    startSize = richTextBox1.SelectionFont.Size;
                    startColor = richTextBox1.SelectionColor.Name;
                    startBcolor = richTextBox1.SelectionBackColor.Name;
                    //  MessageBox.Show(startText.ToString()+"  "+ endText.ToString());
                }

            }


            else
            if (richTextBox1.Text != "" && type == null)
            {
                DialogResult rec = new DialogResult();
                rec = MessageBox.Show("Вы хотите сохранить?", "Сохранить!!!", MessageBoxButtons.YesNo);
                if (rec.ToString() == "Yes")
                {
                    saveToolStripMenuItem_Click(sender, e);
                    OpenSave();
                }
                if (rec.ToString() == "No")
                {
                    OpenSave();
                }
            }

            else
                if (richTextBox1.Text != "" && type != null)
            {

                DialogResult rec1 = new DialogResult();
                rec1 = MessageBox.Show("Вы хотите сохранить?", "Сохранить!!!", MessageBoxButtons.YesNo);
                if (rec1.ToString() == "Yes")
                {
                    saveToolStripMenuItem1_Click(sender, e);
                    OpenSave();
                }
                if (rec1.ToString() == "No")
                {
                    OpenSave();
                }
            }
            
          
        }


        void OpenSave()
        {
            OpenFileDialog op = new OpenFileDialog();

            op.Title = "Open My New File";
            op.Filter = "RTF Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt| All Files (*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                if (op.FilterIndex == 1)
                {
                    richTextBox1.LoadFile(op.FileName, RichTextBoxStreamType.RichText);
                }
                //MessageBox.Show(op.FilterIndex.ToString());
                else
                if (op.FilterIndex == 2)
                {
                    richTextBox1.LoadFile(op.FileName, RichTextBoxStreamType.PlainText);
                }

                this.Text = Path.GetFileName(op.FileName);

                type = op.FileName;
                first = op.FilterIndex;

                startText = richTextBox1.Text;
                startFont = richTextBox1.SelectionFont.Name;
                startSize = richTextBox1.SelectionFont.Size;
                startColor = richTextBox1.SelectionColor.Name;
                startBcolor = richTextBox1.SelectionBackColor.Name;
                // this.Text = Path.GetFileName("WordPad");
                //  richTextBox1.Clear();

            }
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Title = "Save My New File";
            sv.Filter = "RTF Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt";

            if (sv.ShowDialog() == DialogResult.OK)
            {

                if (sv.FilterIndex == 1)
                {
                    richTextBox1.SaveFile(sv.FileName, RichTextBoxStreamType.RichText);
                   // MessageBox.Show(sv.FilterIndex.ToString());
                }
                else
                if (sv.FilterIndex == 2)
                {
                    richTextBox1.SaveFile(sv.FileName, RichTextBoxStreamType.PlainText);
                }
                

                this.Text = Path.GetFileName(sv.FileName);
                type = sv.FileName;

                startText = richTextBox1.Text;
                startFont = richTextBox1.SelectionFont.Name;
                startSize = richTextBox1.SelectionFont.Size;
                startColor = richTextBox1.SelectionColor.Name;
                startBcolor = richTextBox1.SelectionBackColor.Name;
                MessageBox.Show("You File Save!");
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void cotyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = richTextBox1.SelectionFont;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fd.Font;
            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton10_Click(sender, e);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 1.0.0\nCreadet by Vitaliy Pinchuk");
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowIcon = true;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
            
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }
         
        private void Form1_Load(object sender, EventArgs e)
        {
            List<int> size = new List<int>
            { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            

            notifyIcon1.BalloonTipText = "WordPad";

            foreach (FontFamily font in FontFamily.Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
                //toolStripComboBox1.SelectedItem = "Times New Roman";
                
            }
 
            foreach (var item in size)
            {
                toolStripComboBox2.Items.Add(item.ToString());
               // toolStripComboBox2.SelectedItem = richTextBox1.SelectionFont.Size;
            }
            
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        
 

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            richTextBox1.SelectionFont =
                    new Font(
                        richTextBox1.SelectionFont,
                        richTextBox1.SelectionFont.Style ^ FontStyle.Bold
                        );

            //   toolStripButton1.Checked = !toolStripButton1.Checked;

            richTextBox1.Select();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {        
            richTextBox1.SelectionFont =
                new Font(
                    richTextBox1.SelectionFont,
                    richTextBox1.SelectionFont.Style ^ FontStyle.Strikeout
                    );
            richTextBox1.Select();
            //toolStripButton1.Checked = !toolStripButton1.Checked;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            richTextBox1.SelectionFont =
                new Font(
                    richTextBox1.SelectionFont,
                    richTextBox1.SelectionFont.Style ^ FontStyle.Underline
                    );

           // toolStripButton1.Checked = !toolStripButton1.Checked;
        }


        

        private void pageSetapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }
         
        
        private void toolStripButton8_Click(object sender, EventArgs e)
        {

            richTextBox1.Undo();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = richTextBox1.SelectionBackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionBackColor = colorDialog1.Color;
            }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = richTextBox1.SelectionColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "" && type == null)
            {
                saveToolStripMenuItem_Click(sender, e);

            }
            else
            if (richTextBox1.Text != "" && type != null)
            {
                 
                    if (first == 1)
                    {
                        richTextBox1.SaveFile(type, RichTextBoxStreamType.RichText);
                    }
                    else
                    if (first == 2)
                    {
                        richTextBox1.SaveFile(type, RichTextBoxStreamType.PlainText);
                    }


                MessageBox.Show("You File Save!");
            }

        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem1_Click(sender, e);
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            // MessageBox.Show(startSize.ToString()+"  "+richTextBox1.SelectionFont.Size);
            if (startBcolor != richTextBox1.SelectionBackColor.Name)
            {
                //MessageBox.Show(startSize + " " + richTextBox1.SelectionFont.Size);
                DialogResult rec = new DialogResult();
                rec = MessageBox.Show("Вы хотите сохранить изменения и закрить?", "Сохранить!!!", MessageBoxButtons.YesNoCancel);
                if (rec.ToString() == "Yes")
                {
                    saveToolStripMenuItem1_Click(sender, e);
                    e.Cancel = false;
                }

                if (rec.ToString() == "No")
                {
                    e.Cancel = false;
                }

                if (rec.ToString() == "Cancel")
                {
                    e.Cancel = true;
                }

            }
            else
            if (startColor != richTextBox1.SelectionColor.Name)
            {
                
                DialogResult rec = new DialogResult();
                rec = MessageBox.Show("Вы хотите сохранить изменения и закрить?", "Сохранить!!!", MessageBoxButtons.YesNoCancel);
                if (rec.ToString() == "Yes")
                {
                    saveToolStripMenuItem1_Click(sender, e);
                    e.Cancel = false;
                }

                if (rec.ToString() == "No")
                {
                    e.Cancel = false;
                }

                if (rec.ToString() == "Cancel")
                {
                    e.Cancel = true;
                }

            }
            else
            if (startSize != richTextBox1.SelectionFont.Size)
            {
                
                DialogResult rec = new DialogResult();
                rec = MessageBox.Show("Вы хотите сохранить изменения и закрить?", "Сохранить!!!", MessageBoxButtons.YesNoCancel);
                if (rec.ToString() == "Yes")
                {
                    saveToolStripMenuItem1_Click(sender, e);
                    e.Cancel = false;
                }

                if (rec.ToString() == "No")
                {
                    e.Cancel = false;
                }

                if (rec.ToString() == "Cancel")
                {
                    e.Cancel = true;
                }

            }
            else

            if (richTextBox1.Text != "" && type == null)
            {
                
                DialogResult rec = new DialogResult();
                rec = MessageBox.Show("Вы хотите сохранить изменения и закрить?", "Сохранить!!!", MessageBoxButtons.YesNoCancel);
                if (rec.ToString() == "Yes")
                {
                    saveToolStripMenuItem_Click(sender, e);
                    e.Cancel = false;
                }

                if (rec.ToString() == "No")
                {
                    e.Cancel = false;
                }

                if (rec.ToString() == "Cancel")
                {
                    e.Cancel = true;
                }

            }
            else
                if (startText == richTextBox1.Text && type != null && richTextBox1.Text != "" &&
                startColor == richTextBox1.SelectionColor.Name && startSize == richTextBox1.SelectionFont.Size
                && startBcolor == richTextBox1.SelectionBackColor.Name)
            {
                e.Cancel = false;
            }
            else
                if (type == null && richTextBox1.Text == "") 
            {
                e.Cancel = false;
            }
            else
                if (startText != richTextBox1.Text && type != null && richTextBox1.Text != "")
            {
                
                DialogResult rec = new DialogResult();
                rec = MessageBox.Show("Вы хотите сохранить изменения и закрить?", "Сохранить!!!", MessageBoxButtons.YesNoCancel);
                if (rec.ToString() == "Yes")
                {
                    saveToolStripMenuItem1_Click(sender, e);
                    e.Cancel = false;
                }

                if (rec.ToString() == "No")
                {
                    e.Cancel = false;
                }

                if (rec.ToString() == "Cancel")
                {
                    e.Cancel = true;
                }
            }
            
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // double SizeNow = richTextBox1.SelectionFont.Size;
            string fontName = (string)toolStripComboBox1.SelectedItem;   
            richTextBox1.SelectionFont =
                new Font(fontName, Convert.ToInt32(startSize),
                richTextBox1.SelectionFont.Style);


        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            double SizeNow = richTextBox1.SelectionFont.Size;
            string fontName = (string)toolStripComboBox1.SelectedItem;
            richTextBox1.SelectionFont =
                new Font(fontName, Convert.ToInt32(toolStripComboBox2.SelectedItem), 
                richTextBox1.SelectionFont.Style);
        }
        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Maximized;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            fontToolStripMenuItem1_Click(sender, e);
        }

        
        private void textSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Нет текста!!!");
            }
            if (richTextBox1.Text != "" &&  type != null)
            { 
                f.Main = this;
                f.Owner = this;
                f.Show();
                
            }
            if (richTextBox1.Text != "" && type == null)
            {
                f.Main = this;
                f.Owner = this;
                f.Show();
            }

        }
        
        public void FindMyText(string text)
        {
            int start = richTextBox1.SelectionStart; 
            if (richTextBox1.Text != "" && type != null)
            {
                if (text.Length > 0 && start >= 0)
                {
                    richTextBox1.Find(text, start + 1, RichTextBoxFinds.None);
                    richTextBox1.Focus();
                }
                if ((richTextBox1.Find(text, start + 1, RichTextBoxFinds.None)) == -1) 
                {
                    MessageBox.Show("Не удается найти \"" + text + "\"");
                }
            }

           
            
            if (richTextBox1.Text != "" && type == null)
            {
                int start1 = (richTextBox1.Text.Length > richTextBox1.SelectionStart ?
                    richTextBox1.SelectionStart + 1 : richTextBox1.SelectionStart = 0);
                if (text.Length > 0 && start >= 0)
                {
                    richTextBox1.Find(text, start1, RichTextBoxFinds.None);
                    richTextBox1.Focus();
                }
                if ((richTextBox1.Find(text, start1, RichTextBoxFinds.None)) == -1)
                {
                    MessageBox.Show("Не удается найти \"" + text + "\"");
                }
            }
        }

       

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength == 0) 
            {
                toolStripComboBox1.SelectedItem = richTextBox1.SelectionFont.Name;

                toolStripComboBox2.SelectedItem = richTextBox1.SelectionFont.Size.ToString();              
            
           

            if (richTextBox1.SelectionFont.Bold == true && richTextBox1.SelectionFont.Strikeout == true &&
                richTextBox1.SelectionFont.Underline == true)
            {
                toolStripButton1.BackColor = Color.FromArgb(255, 182, 193);
                toolStripButton2.BackColor = Color.FromArgb(255, 182, 193);
                toolStripButton3.BackColor = Color.FromArgb(255, 182, 193);
            }
            else
                if (richTextBox1.SelectionFont.Bold == false && richTextBox1.SelectionFont.Strikeout == false &&
                richTextBox1.SelectionFont.Underline == false)
            {
                toolStripButton1.BackColor = Color.AliceBlue;
                toolStripButton2.BackColor = Color.AliceBlue;
                toolStripButton3.BackColor = Color.AliceBlue;
            }
            //---------------------------------
            else
            if (richTextBox1.SelectionFont.Bold == true && richTextBox1.SelectionFont.Strikeout == true &&
                richTextBox1.SelectionFont.Underline == false)
            {
                toolStripButton1.BackColor = Color.FromArgb(255, 182, 193);
                toolStripButton2.BackColor = Color.FromArgb(255, 182, 193);
                toolStripButton3.BackColor = Color.AliceBlue;
            }
            else
            if (richTextBox1.SelectionFont.Bold == true && richTextBox1.SelectionFont.Strikeout == false &&
                richTextBox1.SelectionFont.Underline == true)
            {
                toolStripButton1.BackColor = Color.FromArgb(255, 182, 193);
                toolStripButton2.BackColor = Color.AliceBlue;
                toolStripButton3.BackColor = Color.FromArgb(255, 182, 193);
            }
            else
            if (richTextBox1.SelectionFont.Bold == false && richTextBox1.SelectionFont.Strikeout == true &&
                richTextBox1.SelectionFont.Underline == true)
            {
                toolStripButton1.BackColor = Color.AliceBlue;
                toolStripButton2.BackColor = Color.FromArgb(255, 182, 193);
                toolStripButton3.BackColor = Color.FromArgb(255, 182, 193);
            }
            //---------------------------------
            else
            if (richTextBox1.SelectionFont.Bold == true && richTextBox1.SelectionFont.Strikeout == false &&
                richTextBox1.SelectionFont.Underline == false)
            {
                toolStripButton1.BackColor = Color.FromArgb(255, 182, 193);
                toolStripButton2.BackColor = Color.AliceBlue;
                toolStripButton3.BackColor = Color.AliceBlue;
            }
            else
            if (richTextBox1.SelectionFont.Bold == false && richTextBox1.SelectionFont.Strikeout == true &&
                richTextBox1.SelectionFont.Underline == false)
            {
                toolStripButton1.BackColor = Color.AliceBlue;
                toolStripButton2.BackColor = Color.FromArgb(255, 182, 193);
                toolStripButton3.BackColor = Color.AliceBlue;
            }
            else
            if (richTextBox1.SelectionFont.Bold == false && richTextBox1.SelectionFont.Strikeout == false &&
                richTextBox1.SelectionFont.Underline == true)
            {
                toolStripButton1.BackColor = Color.AliceBlue;
                toolStripButton2.BackColor = Color.AliceBlue;
                toolStripButton3.BackColor = Color.FromArgb(255, 182, 193);
            }
            //----------------------------
             
            if (richTextBox1.SelectionAlignment == HorizontalAlignment.Left )
            {
                toolStripButton5.BackColor = Color.FromArgb(255, 182, 193);
                toolStripButton6.BackColor = Color.AliceBlue;
                toolStripButton7.BackColor = Color.AliceBlue;
            }
            else
            if (richTextBox1.SelectionAlignment == HorizontalAlignment.Center)
            {
                toolStripButton6.BackColor = Color.FromArgb(255, 182, 193);
                toolStripButton5.BackColor = Color.AliceBlue;
                toolStripButton7.BackColor = Color.AliceBlue;
            }
            else
            if (richTextBox1.SelectionAlignment == HorizontalAlignment.Right)
            {
                toolStripButton7.BackColor = Color.FromArgb(255, 182, 193);
                toolStripButton5.BackColor = Color.AliceBlue;
                toolStripButton6.BackColor = Color.AliceBlue;
            }

            }
            else
            if (richTextBox1.SelectionLength != 0)
            {
                toolStripComboBox1.SelectedItem = "";
                toolStripComboBox2.SelectedItem = "";
            }
        }
    }
}
