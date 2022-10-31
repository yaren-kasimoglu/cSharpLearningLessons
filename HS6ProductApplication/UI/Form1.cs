using BL.Repositories;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UI
{
    public partial class Form1 : Form
    {
        private readonly ProductApplicationContext _context;
        private readonly Repository<Product> _repository;

        public Form1(ProductApplicationContext context)
        {
            InitializeComponent();
            _context = context;
            _repository = new Repository<Product>(_context);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product();
                product.ProductName = txtName.Text;
                product.UnitPrice = Convert.ToDecimal(txtPrice.Text);

                _repository.Insert(product);
                MessageBox.Show("ürün eklenmiştir");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}