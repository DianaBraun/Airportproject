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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "аеропортDataSet.Літак". При необходимости она может быть перемещена или удалена.
            this.літакTableAdapter.Fill(this.аеропортDataSet.Літак);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                {
                    this.Validate();
                    this.літакBindingSource.EndEdit();

                    АеропортDataSet.ЛітакDataTable deletedTable = (АеропортDataSet.ЛітакDataTable)
                        аеропортDataSet.Літак.GetChanges(DataRowState.Deleted);

                    АеропортDataSet.ЛітакDataTable newTable = (АеропортDataSet.ЛітакDataTable)
                        аеропортDataSet.Літак.GetChanges(DataRowState.Added);

                    АеропортDataSet.ЛітакDataTable modifiedTable = (АеропортDataSet.ЛітакDataTable)
                        аеропортDataSet.Літак.GetChanges(DataRowState.Modified);

                    try
                    {
                        // Remove all deleted orders from the Orders table.
                        if (deletedTable != null)
                        {
                            літакTableAdapter.Update(deletedTable);
                        }

                        // Update the Customers table.
                        літакTableAdapter.Update(аеропортDataSet.Літак);

                        // Add new orders to the Orders table.
                        if (newTable != null)
                        {
                            літакTableAdapter.Update(newTable);
                        }

                        // Update all modified Orders.
                        if (modifiedTable != null)
                        {
                            літакTableAdapter.Update(modifiedTable);
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
