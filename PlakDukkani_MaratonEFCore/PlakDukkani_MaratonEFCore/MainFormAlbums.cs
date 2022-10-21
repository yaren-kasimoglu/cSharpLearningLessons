using PlakDukkani_MaratonEFCore.DAL.Context;
using PlakDukkani_MaratonEFCore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlakDukkani_MaratonEFCore
{
    public partial class MainFormAlbums : Form
    {
        public MainFormAlbums()
        {
            InitializeComponent();
        }

        private void MainFormAlbums_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            FillAdminTable();
            FillAlbumTable();
            FillArtistTable();
            FillGridLayoutList2();
            FillGridLayoutList3();
            FillGridLayoutList5();
            FillGridLayoutListAdmin();
            FillGridLayoutListArtist();
            FillList2();
            FillList3();
            FillList4();
            FillList5();

        }

        private void FillGridLayoutListArtist()
        {
            dataGridViewArtist.AutoGenerateColumns = false;
            dataGridViewArtist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FillGridLayoutListAdmin()
        {
            dataGridViewAdmin.AutoGenerateColumns = false;
            dataGridViewAdmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FillAdminTable()
        {
            using (PlakDbContext db = new PlakDbContext())
            {           
                var admin = db.Admin.ToList();
                dataGridViewAdmin.DataSource = admin;
            }
        }

        private void FillList4()
        {
            using (PlakDbContext db = new PlakDbContext())
            {
                var album = db.Album.OrderByDescending(x => x.CikisTarihi).Take(10).ToList();
                dataGridViewList4.DataSource = album;
            }
        }

        private void FillList5()
        {
            using (PlakDbContext db = new PlakDbContext())
            {
                var album = db.Album.Where(a => a.IndirimOrani > 0).OrderByDescending(x => x.IndirimOrani).ToList();
                dataGridViewList5.DataSource = album;
            }
        }

        private void FillGridLayoutList5()
        {
            dataGridViewList5.AutoGenerateColumns = false;
            dataGridViewList5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewList5.Columns.Add(GenerateColumn("AlbumAdi", "Albüm Adı"));
            dataGridViewList5.Columns.Add(GenerateColumn("ArtistId", "Sanatçı Id"));
        }

        private void FillList3()
        {
            using (PlakDbContext db = new PlakDbContext())
            {
                var album = db.Album.Where(a => a.DevamDurumu == true).ToList();
                dataGridViewList3.DataSource = album;
            }
        }
        private void FillGridLayoutList3()
        {
            dataGridViewList3.AutoGenerateColumns = false;
            dataGridViewList3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewList3.Columns.Add(GenerateColumn("AlbumAdi", "Albüm Adı"));
            dataGridViewList3.Columns.Add(GenerateColumn("ArtistId", "Sanatçı Id"));
        }

        private void FillList2()
        {
            using (PlakDbContext db = new PlakDbContext())
            {
                var album = db.Album.Where(a => a.DevamDurumu == false).ToList();
                dataGridViewList2.DataSource = album;
            }
        }
        private void FillGridLayoutList2()
        {
            dataGridViewList2.AutoGenerateColumns = false;
            dataGridViewList2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewList2.Columns.Add(GenerateColumn("AlbumAdi", "Albüm Adı"));
            dataGridViewList2.Columns.Add(GenerateColumn("ArtistId", "Sanatçı Id"));
        }

        private void FillArtistTable()
        {
            using (PlakDbContext db = new PlakDbContext())
            {
                var artist = db.Artist.ToList();
                dataGridViewArtist.DataSource = artist;
            }
        }

        private void FillAlbumTable()
        {
            using (PlakDbContext db = new PlakDbContext())
            {
                var album = db.Album.ToList();
                dataGridViewAlbum.DataSource = album;
            }
        }

        private void dataGridViewAlbum_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int albumId = ((dataGridViewAlbum.DataSource as List<Album>)[e.RowIndex].AlbumId);
            var form = new AlbumForm();
            form.Tag = albumId;
            form.ShowDialog();
            FillAlbumTable();
        }

        public DataGridViewColumn GenerateColumn(string name, string caption)
        {
            var column = new DataGridViewTextBoxColumn();
            column.Name = name;
            column.DataPropertyName = name;
            column.HeaderText = caption;
            return column;
        }

        private void dataGridViewArtist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int aristId = ((dataGridViewAlbum.DataSource as List<Artist>)[e.RowIndex].Id);
            var form = new ArtistForm();
            form.Tag = aristId;
            form.ShowDialog();
            FillArtistTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var reg=new Register();
            reg.ShowDialog();
            this.Close();
        }
    }
}
