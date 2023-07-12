using Crudzin.Model;
using Crudzin.Repository;
using Crudzin.Services;

namespace Crudzin
{
    public partial class Form1 : Form
    {
        IRepository<Produto> repoProduto;
        IProductService prodService;
        public Form1(IRepository<Produto> repoProduto, IProductService prod)
        {
            this.repoProduto = repoProduto;
            this.prodService = prod;

            InitializeComponent();
        }

        private void Refresh()
        {
            dataGridView1.Refresh();
            Crudzin.Model.CrudWinformsContext crud = new();
            dataGridView1.DataSource = crud.Produtos.ToArray();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
            //dataGridView1.DataSource = crud.Estoques.ToArray();
        }


        private async void CreateProduct_Click(object sender, EventArgs e)
        {

            if (ProductName.Text == "")
            {
                MessageBox.Show("You can't insert a new product with an empty Name!",
                   "Null Values!",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                return;
            }

            var nameIsNumber = int.TryParse(ProductName.Text, out int _);
            if (nameIsNumber)
            {
                MessageBox.Show("You can't insert a new product with an number as a Name!",
                  "Invalid Value!",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Warning);
                return;
            }

            var priceIsNumber = int.TryParse(ProductPrice.Text, out int price);
            if (!priceIsNumber)
            {
                MessageBox.Show("You can't insert a new product with an not valid number in the Price!",
                   "Null Values!",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                return;
            }

            var prod = new Produto();
            prod.Nome = ProductName.Text;
            prod.Price = price;
            bool added = await repoProduto.Create(prod);

            if (!added)
                MessageBox.Show("Fail in to insert on Database",
                    "Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
            {
                MessageBox.Show("Created",
                    "Added in DataBase!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ProductName.Text = "";
                ProductPrice.Text = null;
                this.Refresh();
            }
        }
        private async void DeleteProduct_Click(object sender, EventArgs e)
        {
            var SelectdeColumns = dataGridView1.SelectedCells;
            Produto prod = new Produto();

            if (SelectdeColumns[0].ColumnIndex == 0)
            {
                int idProd = int.Parse(SelectdeColumns[0].Value.ToString() ?? "0");

                Produto? prodToDelete = await prodService.GetByID(idProd);
                prod.Id = idProd;
                prod.Price = prodToDelete.Price;
                prod.Nome = prodToDelete.Nome;
            }
            else if (SelectdeColumns[0].ColumnIndex == 1)
            {
                string NameProd = SelectdeColumns[0].Value.ToString();

                Produto? prodToDelete = await prodService.GetByName(NameProd);
                prod.Id = prodToDelete.Id;
                prod.Price = prodToDelete.Price;
                prod.Nome = prodToDelete.Nome;
            }
            else
            {
                MessageBox.Show("You can't delete a product this way!",
                   "Error to Delete!",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                return;
            }
            
            bool deleted = await repoProduto.Delete(prod);

            if (!deleted)
            {
                MessageBox.Show("Fail in to delete on Database",
                   "Error!",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Deleted",
                    "Deleted in DataBase!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            this.Refresh();
        }

        //-\\
        private void label1_Click(object sender, EventArgs e)
        { }
        private void label2_Click(object sender, EventArgs e)
        { }
        private void textBox2_TextChanged(object sender, EventArgs e)
        { }
        private void label3_Click(object sender, EventArgs e)
        { }
        private void label4_Click(object sender, EventArgs e)
        { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { }
    }
}