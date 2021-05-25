using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Аеропорт
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "аеропортDataSet.Авіакомпанія". При необходимости она может быть перемещена или удалена.
            this.авіакомпаніяTableAdapter.Fill(this.аеропортDataSet.Авіакомпанія);
 
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

            DialogResult dr = MessageBox.Show("Видалити запис?", "Видалити", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }

        }
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Закрыть?", "Message", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;

            else
                e.Cancel = false;

        }


        private void button3_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13();
            f13.ShowDialog();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            {
                {
                    this.Validate();
                    this.авіакомпаніяBindingSource.EndEdit();

                    АеропортDataSet.АвіакомпаніяDataTable deletedTable = (АеропортDataSet.АвіакомпаніяDataTable)
                        аеропортDataSet.Авіакомпанія.GetChanges(DataRowState.Deleted);

                    АеропортDataSet.АвіакомпаніяDataTable newTable = (АеропортDataSet.АвіакомпаніяDataTable)
                        аеропортDataSet.Авіакомпанія.GetChanges(DataRowState.Added);

                    АеропортDataSet.АвіакомпаніяDataTable modifiedTable = (АеропортDataSet.АвіакомпаніяDataTable)
                        аеропортDataSet.Авіакомпанія.GetChanges(DataRowState.Modified);

                    try
                    {
                        // Remove all deleted orders from the Orders table.
                        if (deletedTable != null)
                        {
                            авіакомпаніяTableAdapter.Update(deletedTable);
                        }

                        // Update the Customers table.
                        авіакомпаніяTableAdapter.Update(аеропортDataSet.Авіакомпанія);

                        // Add new orders to the Orders table.
                        if (newTable != null)
                        {
                            авіакомпаніяTableAdapter.Update(newTable);
                        }

                        // Update all modified Orders.
                        if (modifiedTable != null)
                        {
                            авіакомпаніяTableAdapter.Update(modifiedTable);
                        }

                       аеропортDataSet.AcceptChanges();
                    }

                    catch (System.Exception ex)
                    {
                        MessageBox.Show("Update");
                    }

                    finally
                    {
                        if (deletedTable != null)
                        {
                            deletedTable.Dispose();
                        }
                        if (newTable != null)
                        {
                            newTable.Dispose();
                        }
                        if (modifiedTable != null)
                        {
                            modifiedTable.Dispose();
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
       
