using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace склад
{
    public partial class Form1 : Form
    {
        private readonly List<sclad> sc;
        private ScladLIB.bisnesSclad<sclad> ScldBLS;
        private readonly List<sclad> ScldBL;
        private readonly BindingSource BSourse;
        public Form1()
        {
            InitializeComponent();
            sc = new List<sclad>();
            BSourse = new BindingSource();
            ScldBL = new List<sclad>();
            ScldBLS = new ScladLIB.bisnesSclad<sclad>();
            BSourse.DataSource = sc;
            dataGridView1.DataSource = ScldBLS.Get();
            dataGridView1.DataSource = BSourse;

        }
        double sum1=0,sum2=0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void repit()
        {
            var infoForm = new addform();
            toolStripStatusLabel1.Text = "Колличество товаров на складе: " + Convert.ToString(ScldBLS.Get().ToList().Count());
            toolStripStatusLabel3.Text = "Общая цена товаров(cНДС): " + Convert.ToString(ScldBLS.Get().Sum(x => x.fulprice + (x.fulprice * 0.2)));
            toolStripStatusLabel2.Text = "Общая цена товаров(безНДС): " + Convert.ToString(ScldBLS.Get().Sum(x => x.fulprice));
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           
            var infoForm = new addform();
            infoForm.Text = "Добавление товара";


           
            if (infoForm.ShowDialog(this) == DialogResult.OK)
            {
                sc.Add(infoForm.sclad);
                BSourse.ResetBindings(false);
                ScldBLS.Add(infoForm.sclad);

                sum1 += infoForm.sclad.fulprice;

                sum2 +=(infoForm.sclad.fulprice + (infoForm.sclad.fulprice * 0.2));

                repit();
            }

            
           
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var id = (sclad)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
            var infoForm = new addform(id);
            sum1 -=  id.fulprice;
            sum2 -=  (id.fulprice + (id.fulprice * 0.2));
            if (infoForm.ShowDialog(this) == DialogResult.OK)
                {
                  
                    id.name= infoForm.sclad.name;
                    id.mater = infoForm.sclad.mater;
                    id.kol= infoForm.sclad.kol;
                    id.raz = infoForm.sclad.raz;
                    id.min = infoForm.sclad.min;
                    id.price = infoForm.sclad.price;
                  
                    id.fulprice = infoForm.sclad.fulprice;
                BSourse.ResetBindings(false);
                ScldBLS.Update(id,infoForm.sclad);
                sum1 +=  id.fulprice;
                sum2 +=  (id.fulprice + (id.fulprice * 0.2));
                repit();
            }
           
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
       
               toolStripButton2.Enabled =toolStripButton3.Enabled = dataGridView1.SelectedRows.Count>0;
            удалитьToolStripMenuItem.Enabled = изменитьToolStripMenuItem.Enabled = dataGridView1.SelectedRows.Count > 0;

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "DepterColumn")
            {
                var id = (sclad)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                e.Value = id.price+(id.price*0.2);
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "noNDS")
            {
                var id = (sclad)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                e.Value = id.fulprice + (id.fulprice * 0.2);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           
            var id = (sclad)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
          
            sum1 = sum1 - id.fulprice;
            sum2 = sum2 - (id.fulprice + (id.fulprice * 0.2));

            sc.Remove(id);
            BSourse.ResetBindings(false);
            ScldBLS.Remove(id);
            repit();

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
           
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton3_Click(sender, e);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton2_Click(sender, e);
        }

        private void forprogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Склад гвоздей", "Бажин Кирилл Адреевич", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
