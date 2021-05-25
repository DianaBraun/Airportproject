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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "аеропортDataSet.Тип_літака". При необходимости она может быть перемещена или удалена.
            this.тип_літакаTableAdapter.Fill(this.аеропортDataSet.Тип_літака);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                {
                    this.Validate();
                    this.типЛітакаBindingSource.EndEdit();

                    АеропортDataSet.Тип_літакаDataTable deletedTable = (АеропортDataSet.Тип_літакаDataTable)
                        аеропортDataSet.Тип_літака.GetChanges(DataRowState.Deleted);

                    АеропортDataSet.Тип_літакаDataTable newTable = (АеропортDataSet.Тип_літакаDataTable)
                        аеропортDataSet.Тип_літака.GetChanges(DataRowState.Added);

                    АеропортDataSet.Тип_літакаDataTable modifiedTable = (АеропортDataSet.Тип_літакаDataTable)
                        аеропортDataSet.Тип_літака.GetChanges(DataRowState.Modified);

                    try
                    {
                        // Remove all deleted orders from the Orders table.
                        if (deletedTable != null)
                        {
                            тип_літакаTableAdapter.Update(deletedTable); 
                        }

                        // Update the Customers table.
                        тип_літакаTableAdapter.Update(аеропортDataSet.Тип_літака);

                        // Add new orders to the Orders table.
                        if (newTable != null)
                        {
                            тип_літакаTableAdapter.Update(newTable);
                        }

                        // Update all modified Orders.
                        if (modifiedTable != null)
                        {
                            тип_літакаTableAdapter.Update(modifiedTable);
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
    }
}
